# Busy State Manager

A Standard .Net library, for use in WPF, for controlling the 'Busy' state gracefully. It aims to be simple with one main class that provides a Boolean value for busy which should be used in conjunction with the Xceed Toolkit BusyIndicator or  similar control. Mvvm-Light is leveraged for the messaging of processes that aim to set busy state. This class is responsible for managing the busy state which can be problematic if it is just being set in process because different threads can set it prior to other threads  completing. This class aims to provide a better solution, namely to have this central static register of running threads, which  unregister once complete, then the busy value is only set to  true once the register is empty.

## Usage

### Download
Available to clone and add as a project reference or via NuGet.
`Install-Package BusyStateManager -Version 1.0.1` or `dotnet add package BusyStateManager --version 1.0.1`

### In Code
As this library is aimed at WPF developers, the following is the likely route for instatiation. This uses Mvvm-Light SimpleIoC, however you can of course use your DI of choice or even create an instance without DI.
```
SimpleIoc.Default.Register<IBusyStateRegistry>(() => 
{
    return new BusyStateRegistry();
});
```
Then in a view model that inherits from the Mvvm-Light `ViewModelBase`, at the start and end of long running process add:
`MessengerInstance.Send(new BusyMessage(true, this));` and `MessengerInstance.Send(new BusyMessage(false, this));`. For example:
```
private void OnAuthenticated(AuthenticatedMessage m)
{
    MessengerInstance.Send(new BusyMessage(true, this));
    User.Current.Initialise(m.Token);
    RaisePropertyChanged(nameof(IsLoggedIn));
    _navigationService.NavigateTo(
        HamburgerNavItemsIndex.Requirement.ToString());
    MessengerInstance.Send(new BusyMessage(false, this));
}
```
Add a public property in your view model like this: `public IBusyStateRegistry BusyStateManager { get; }`, which you would set in the constructor. After that one can add a `BusyIndicator`, to any view, like the following. First, the Xceed tool ref in the header:
```
xmlns:xctk="http://schemas.xceed.com/wpf/xaml/toolkit"
```
Then somewhere in your view add the control:
```
<xctk:BusyIndicator IsBusy="{Binding BusyStateManager.IsBusy}">
```
Or similar control of your choice.
