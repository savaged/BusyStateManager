using System;

namespace Savaged.BusyStateManager
{
    public interface IBusyMessage
    {
        string CallerMember { get; }
        Type CallerType { get; }
        bool IsBusy { get; }
    }
}