using GalaSoft.MvvmLight;
using System;

namespace Savaged.BusyStateManager.Test
{
    public class ViewModelUsingWrappedBusyMngr : ViewModelBase
    {
        public ViewModelUsingWrappedBusyMngr(BusyMgnrWrapper busyMngrWrapper)
        {
            ViewState = busyMngrWrapper;
        }

        public void SimulateLongProcess(bool isBusy)
        {
            MessengerInstance.Send(new BusyMessage(isBusy, this));
        }

        public BusyMgnrWrapper ViewState { get; }
    }
}
