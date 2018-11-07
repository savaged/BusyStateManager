using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

namespace Savaged.BusyStateManager.Test
{
    [TestClass]
    public class NinjectTests
    {
        private static StandardKernel _kernel;

        [ClassInitialize]
        public static void InitOnce(TestContext context)
        {
            _kernel = new StandardKernel();
            _kernel.Bind<TestMainViewModel>().ToSelf();
            _kernel.Bind<IBusyStateRegistry>().To<BusyStateRegistry>();
        }

        [TestMethod]
        public void IoCWithNinjectTest()
        {
            var mngr = _kernel.Get<IBusyStateRegistry>();
            var main = _kernel.Get<TestMainViewModel>();
            Assert.IsNotNull(main);
            Assert.AreEqual(mngr.GetMessengerInstance(), main.GetMessengerInstance());
        }
    }
}
