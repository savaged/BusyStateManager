using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Savaged.BusyStateManager.Test
{
    public abstract class TestViewModelBase : ViewModelBase
    {
        public TestViewModelBase(IBusyStateRegistry busyStateRegistry)
        {
            BusyStateRegistry = busyStateRegistry;
        }

        public IMessenger GetMessengerInstance() => MessengerInstance;

        public bool IsBusy => BusyStateRegistry.IsBusy;

        public IBusyStateRegistry BusyStateRegistry { get; }

        public void SimulateLongProcess(bool isBusy)
        {
            MessengerInstance.Send(new BusyMessage(isBusy, this));
        }
    }
}
