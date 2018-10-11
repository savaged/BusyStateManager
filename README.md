# Busy State Manager

A Standard .Net library, for use in WPF, for controlling the 'Busy' state gracefully. It aims to be simple with one main class that provides a Boolean value for busy which should be used in conjunction with the Xceed Toolkit BusyIndicator or  similar control. This class is responsible for managing the busy state which can be problematic if it is just being set in process because different threads can set it prior to other threads  completing. This class aims to provide a better solution, namely to have this central static register of running threads, which  unregister once complete, then the busy value is only set to  true once the register is empty.

