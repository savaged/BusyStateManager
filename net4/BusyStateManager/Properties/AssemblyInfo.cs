using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("BusyStateManager")]
[assembly: AssemblyDescription("A .Net Framework library, for use in WPF, for controlling the 'Busy' state gracefully. It aims to be simple with one main class that provides a Boolean value for busy which should be used in conjunction with the Xceed Toolkit BusyIndicator or similar control. This class is responsible for managing the busy state which can be problematic if it is just being set in process because different threads can set it prior to other threads completing. This class aims to provide a better solution, namely to have this central static register of running threads, which unregister once complete, then the busy value is only set to true once the register is empty.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("savaged")]
[assembly: AssemblyProduct("BusyStateManager")]
[assembly: AssemblyCopyright("Copyright (C) 2007 Free Software Foundation, Inc.")]
[assembly: AssemblyTrademark("NA")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("7792ac59-996a-4300-98a5-195bdb30ea63")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.1.1.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
