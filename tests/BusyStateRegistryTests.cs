using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Savaged.BusyStateManager.Test
{
    [TestClass]
    public class BusyStateRegistryTests
    {
        [ClassInitialize]
        public static void InitOnce(TestContext context)
        {
            SimpleIoc.Default.Register<TestMainViewModel>();
            SimpleIoc.Default.Register<TestSubViewModel>();
            SimpleIoc.Default.Register<IBusyStateRegistry>(() => 
            {
                return new BusyStateRegistry();
            });
        }

        [TestInitialize]
        public void InitEachTest()
        {
            var mngr = SimpleIoc.Default.GetInstance<IBusyStateRegistry>();
            Assert.IsNotNull(mngr);
            var main = SimpleIoc.Default.GetInstance<TestMainViewModel>();
            Assert.IsNotNull(main);
            Assert.AreEqual(mngr.MessengerInstance, main.GetMessengerInstance());
        }

        [TestMethod]
        public void MultipleProcessesIsBusyTest()
        {
            var main = SimpleIoc.Default.GetInstance<TestMainViewModel>();
            var sub = SimpleIoc.Default.GetInstance<TestSubViewModel>();
            Assert.AreEqual(main.BusyStateRegistry, sub.BusyStateRegistry);

            Assert.IsFalse(main.IsBusy, "Main not busy before long process");
            Assert.IsFalse(sub.IsBusy, "Sub not busy before long process");
            main.SimulateLongProcess(true);
            Assert.IsTrue(main.IsBusy, "Main is busy during long process");
            Assert.IsTrue(sub.IsBusy, "Sub is busy during long process of Main");
            main.SimulateLongProcess(false);
            sub.SimulateLongProcess(true);
            Assert.IsTrue(main.IsBusy, "Main is busy during long process of Sub");
            Assert.IsTrue(sub.IsBusy, "Sub is busy during long process");
            sub.SimulateLongProcess(false);
            Assert.IsFalse(main.IsBusy, "Main not busy after long process");
            Assert.IsFalse(sub.IsBusy, "Sub not busy after long process");
            main.SimulateLongProcess(true);
            sub.SimulateLongProcess(true);
            main.SimulateLongProcess(false);
            Assert.IsTrue(main.IsBusy, "Overlapping Main is busy during long process of Sub");
            Assert.IsTrue(sub.IsBusy, "Overlapping Sub is busy during long process");
            sub.SimulateLongProcess(false);
            Assert.IsFalse(main.IsBusy, "Overlapping Main not busy after long process");
            Assert.IsFalse(sub.IsBusy, "Overlapping Sub not busy after long process");
        }

        [TestMethod]
        public void DiagnosticsOutputTest()
        {
            var main = SimpleIoc.Default.GetInstance<TestMainViewModel>();
            var sub = SimpleIoc.Default.GetInstance<TestSubViewModel>();

            main.SimulateLongProcess(true);
            sub.SimulateLongProcess(true);
            Assert.AreEqual(
                "Registry: [{ caller: Savaged.BusyStateManager.Test.TestMainViewModel" +
                ".SimulateLongProcess },{ caller: Savaged.BusyStateManager.Test." +
                "TestSubViewModel.SimulateLongProcess },]", main.BusyStateRegistry.ToString());
        }
    }
}
