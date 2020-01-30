using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Savaged.BusyStateManager.Test
{
    public class BusyMgnrWrapper : ViewModelBase, IBusyStateRegistry
    {
        private readonly IBusyStateRegistry _registry;

        public BusyMgnrWrapper(IBusyStateRegistry registry)
        {
            _registry = registry;
        }

        public bool IsBusy => _registry.IsBusy;

        public IMessenger GetMessengerInstance()
        {
            return _registry.GetMessengerInstance();
        }
    }
}
