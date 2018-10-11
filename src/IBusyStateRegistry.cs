using GalaSoft.MvvmLight.Messaging;

namespace Savaged.BusyStateManager
{
    public interface IBusyStateRegistry
    {
        bool IsBusy { get; }

        IMessenger MessengerInstance { get; }
    }
}