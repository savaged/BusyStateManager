using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Savaged.BusyStateManager
{
    /// <summary>
    /// The main class that provides a Boolean value for busy which should
    /// be used in conjunction with the Xceed Toolkit BusyIndicator or 
    /// similar control. This class is responsible for managing the busy
    /// state which can be problematic if it is just being set in process
    /// because different threads can set it prior to other threads 
    /// completing. This class aims to provide a better solution, namely
    /// to have this central static register of running threads, which 
    /// unregister once complete, then the busy value is only set to 
    /// true once the register is empty.
    /// </summary>
    public class BusyStateRegistry : ObservableObject, IBusyStateRegistry
    {
        private IList<string> _registry;

        public BusyStateRegistry()
        {
            _registry = new List<string>();

            if (MessengerInstance is null)
            {
                MessengerInstance = Messenger.Default;
            }
            MessengerInstance.Register<BusyMessage>(this, OnBusyMessage);
        }

        public BusyStateRegistry(IMessenger messenger) : this()
        {
            if (messenger != null)
            {
                MessengerInstance = messenger;
            }
        }

        public IMessenger MessengerInstance { get; }

        public bool IsBusy => _registry.Count > 0;

        private void OnBusyMessage(IBusyMessage m)
        {
            if (m is null)
            {
                throw new ArgumentException("The message object should never be null", "m");
            }
            if (m.IsBusy)
            {
                _registry.Add($"{m.CallerType}.{m.CallerMember}");
            }
            else
            {
                _registry.Remove($"{m.CallerType}.{m.CallerMember}");
            }
            RaisePropertyChanged(nameof(IsBusy));
        }

        /// <summary>
        /// For diagnostics
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var registry = "Registry: [";
            foreach (var caller in _registry)
            {
                registry += "{ caller: " + caller + " },";
            }
            registry += $"]";
            return registry;
        }
    }
}
