using GalaSoft.MvvmLight.Messaging;
using System.ComponentModel;

namespace Savaged.BusyStateManager
{
    public interface IBusyStateRegistry 
    {
        bool IsBusy { get; }

        IMessenger GetMessengerInstance();
    }
}