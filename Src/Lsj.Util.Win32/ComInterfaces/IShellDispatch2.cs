using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Lsj.Util.Win32.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Extends the <see cref="IShellDispatch"/> object with a variety of new functionality.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/shell/ishelldispatch2-object"/>
    /// </para>
    /// </summary>
    public unsafe struct IShellDispatch2
    {
        nint* _vTable;

        /// <summary>
        /// Retrieves a group's restriction setting from the registry.
        /// </summary>
        /// <param name="Group">
        /// A String that contains the group name.
        /// This value is the name of a registry subkey under which to check for the restriction.
        /// </param>
        /// <param name="Restriction">
        /// A String that contains the restriction whose value is to be retrieved.
        /// </param>
        /// <param name="plRestrictValue">
        /// The value of the restriction.
        /// If the specified restriction is not found, the return value is 0.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// <see cref="IsRestricted"/> first looks for a subkey name that matches <paramref name="Group"/> under the following key.
        /// HKEY_LOCAL_MACHINE \ Software \ Microsoft \ Windows \ CurrentVersion \ Policies
        /// Restrictions are declared as values of the individual policy subkeys.
        /// If the restriction named in <paramref name="Restriction"/> is found in the subkey named in <paramref name="Group"/>,
        /// <see cref="IsRestricted"/> returns the restriction's current value.
        /// If the restriction is not found under HKEY_LOCAL_MACHINE, the same subkey is checked under HKEY_CURRENT_USER.
        /// </remarks>
        public HRESULT IsRestricted([In] BSTR Group, [In] BSTR Restriction, [Out] out int plRestrictValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSTR, BSTR, out int, HRESULT>)_vTable[30])(thisPtr, Group, Restriction, out plRestrictValue);
            }
        }

        /// <summary>
        /// Performs a specified operation on a specified file.
        /// </summary>
        /// <param name="File">
        /// A String that contains the name of the file on which <see cref="ShellExecute"/> will perform the action specified by <paramref name="vOperation"/>.
        /// </param>
        /// <param name="vArgs">
        /// A string that contains parameter values for the operation.
        /// </param>
        /// <param name="vDir">
        /// The fully qualified path of the directory that contains the file specified by <paramref name="File"/>.
        /// If this parameter is not specified, the current working directory is used.
        /// </param>
        /// <param name="vOperation">
        /// The operation to be performed.
        /// This value is set to one of the verb strings that is supported by the file.
        /// For a discussion of verbs, see the Remarks section.
        /// If this parameter is not specified, the default operation is performed.
        /// </param>
        /// <param name="vShow">
        /// A recommendation as to how the application window should be displayed initially.
        /// The application can ignore this recommendation.
        /// This parameter can be one of the following values.
        /// If this parameter is not specified, the application uses its default value.
        /// 0: Open the application with a hidden window.
        /// 1: Open the application with a normal window.
        /// If the window is minimized or maximized, the system restores it to its original size and position.
        /// 2: Open the application with a minimized window.
        /// 3: Open the application with a maximized window.
        /// 4: Open the application with its window at its most recent size and position.
        /// The active window remains active.
        /// 5: Open the application with its window at its current size and position.
        /// 7: Open the application with a minimized window.
        /// The active window remains active.
        /// 10: Open the application with its window in the default state specified by the application.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// This method is equivalent to launching one of the commands associated with a file's shortcut menu.
        /// Each command is represented by a verb string.
        /// The set of supported verbs varies from file to file.
        /// The most commonly supported verb is "open", which is also usually the default verb.
        /// Other verbs might be supported by only certain types of files.
        /// For further discussion of Shell verbs, see Launching Applications or Extending Shortcut Menus.
        /// </remarks>
        public HRESULT ShellExecute([In] BSTR File, [In] VARIANT vArgs, [In] VARIANT vDir, [In] VARIANT vOperation, [In] VARIANT vShow)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSTR, VARIANT, VARIANT, VARIANT, VARIANT, HRESULT>)_vTable[31])(thisPtr, File, vArgs, vDir, vOperation, vShow);
            }
        }

        /// <summary>
        /// Displays the Find Printer dialog box.
        /// </summary>
        /// <param name="name">
        /// A String that contains the printer name.
        /// </param>
        /// <param name="location">
        /// A String that contains the printer location.
        /// </param>
        /// <param name="model">
        /// A String that contains the printer model.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// If you assign strings to one or more of the optional parameters,
        /// they are displayed as default values in the associated edit control when the Find Printer dialog box is displayed.
        /// The user can either accept or override these values.
        /// If no value is assigned to a parameter, the associated edit box is empty and the user must enter a value.
        /// </remarks>
        public HRESULT FindPrinter([In] BSTR name, [In] BSTR location, [In] BSTR model)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSTR, BSTR, BSTR, HRESULT>)_vTable[32])(thisPtr, name, location, model);
            }
        }

        /// <summary>
        /// Retrieves system information.
        /// </summary>
        /// <param name="name">
        /// A String that specifies the system information that is being requested.
        /// </param>
        /// <param name="pv">
        /// Returns the value of the requested system information.
        /// The return type depends on which system information is requested.
        /// See the Remarks section for details.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// This method can be used to request many system information values.
        /// The following table gives the sName value that is used to request the information and the associated type of the returned value.
        /// DirectoryServiceAvailable
        /// Boolean
        /// Set to true if the directory service is available; otherwise, false.
        /// 
        /// DoubleClickTime
        /// Integer
        /// The double-click time, in milliseconds.
        /// 
        /// ProcessorLevel
        /// Integer
        /// Windows Vista and later.
        /// The processor level.
        /// Returns 3, 4, or 5, for x386, x486, and Pentium-level processors, respectively.
        /// 
        /// ProcessorSpeed
        /// Integer
        /// The processor speed, in megahertz (MHz).
        /// 
        /// ProcessorArchitecture
        /// Integer
        /// The processor architecture.
        /// For details, see the discussion of the <see cref="SYSTEM_INFO.wProcessorArchitecture"/> member of the <see cref="SYSTEM_INFO"/> structure.
        /// 
        /// PhysicalMemoryInstalled
        /// Integer
        /// The amount of physical memory installed, in bytes.
        /// The following are valid only on Windows XP.
        /// 
        /// IsOS_Professional
        /// Boolean
        /// Set to true if the operating system is Windows XP Professional Edition; otherwise, false.
        /// 
        /// IsOS_Personal
        /// Boolean
        /// Set to true if the operating system is Windows XP Home Edition; otherwise, false.
        /// 
        /// The following is valid only on Windows XP and later.
        /// IsOS_DomainMember
        /// Boolean
        /// Set to true if the computer is a member of a domain; otherwise, false.
        /// </remarks>
        public HRESULT GetSystemInformation([In] BSTR name, [Out] out VARIANT pv)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSTR, out VARIANT, HRESULT>)_vTable[33])(thisPtr, name, out pv);
            }
        }

        /// <summary>
        /// Starts a named service.
        /// </summary>
        /// <param name="ServiceName">
        /// A String that contains the name of the service.
        /// </param>
        /// <param name="Persistent">
        /// Set to true to have the service started automatically by the service control manager during system startup.
        /// Set to false to leave the service configuration unchanged.
        /// </param>
        /// <param name="pSuccess">
        /// Returns true if successful; otherwise, false.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The method returns false if the service has already been started.
        /// Before calling this method, you can call <see cref="IsServiceRunning"/> to ascertain the status of the service.
        /// </remarks>
        public HRESULT ServiceStart([In] BSTR ServiceName, [In] VARIANT Persistent, [Out] out VARIANT pSuccess)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSTR, VARIANT, out VARIANT, HRESULT>)_vTable[34])(thisPtr, ServiceName, Persistent, out pSuccess);
            }
        }

        /// <summary>
        /// Stops a named service.
        /// </summary>
        /// <param name="ServiceName">
        /// A String that contains the name of the service.
        /// </param>
        /// <param name="Persistent">
        /// Set to true to have the service started by the service control manager when <see cref="ServiceStart"/> is called.
        /// To leave the service configuration unchanged, set <paramref name="Persistent"/> to false.
        /// </param>
        /// <param name="pSuccess">
        /// Returns true if successful; otherwise, false.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The method returns false if the service has already been stopped.
        /// Before calling this method, you can call <see cref="IsServiceRunning"/> to ascertain the status of the service.
        /// </remarks>
        public HRESULT ServiceStop([In] BSTR ServiceName, [In] VARIANT Persistent, [Out] out VARIANT pSuccess)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSTR, VARIANT, out VARIANT, HRESULT>)_vTable[35])(thisPtr, ServiceName, Persistent, out pSuccess);
            }
        }

        /// <summary>
        /// Returns a value that indicates whether a particular service is running.
        /// </summary>
        /// <param name="ServiceName">
        /// A String that contains the name of the service.
        /// </param>
        /// <param name="pRunning">
        /// Returns true if the service specified by <paramref name="ServiceName"/> is running; otherwise, false.
        /// </param>
        /// <returns></returns>
        public HRESULT IsServiceRunning([In] BSTR ServiceName, [Out] out VARIANT pRunning)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSTR, out VARIANT, HRESULT>)_vTable[36])(thisPtr, ServiceName, out pRunning);
            }
        }

        /// <summary>
        /// Determines if the current user can start and stop the named service.
        /// </summary>
        /// <param name="ServiceName">
        /// A String that contains the name of the service.
        /// </param>
        /// <param name="pCanStartStop">
        /// Returns true if the user can start and stop the service; otherwise, false.
        /// </param>
        /// <returns></returns>
        public HRESULT CanStartStopService([In] BSTR ServiceName, [Out] out VARIANT pCanStartStop)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSTR, out VARIANT, HRESULT>)_vTable[37])(thisPtr, ServiceName, out pCanStartStop);
            }
        }

        /// <summary>
        /// Displays a browser bar.
        /// </summary>
        /// <param name="bstrClsid">
        /// A String that contains the string form of the CLSID of the browser bar to be displayed.
        /// The object must be registered as an Explorer Bar object with a CATID_InfoBand component category.
        /// For further information, see Creating Custom Explorer Bars, Tool Bands, and Desk Bands.
        /// </param>
        /// <param name="bShow">
        /// Set to true to show the browser bar or false to hide it.
        /// </param>
        /// <param name="pSuccess">
        /// Returns true if successful; otherwise, false.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// You can display one of the standard Explorer Bars by setting the <paramref name="bstrClsid"/> parameter to the CLSID of that Explorer Bar.
        /// The standard Explorer Bars and their CLSID strings are as follows:
        /// Favorites: {EFA24E61-B078-11d0-89E4-00C04FC9E26E}
        /// Folders: {EFA24E64-B078-11d0-89E4-00C04FC9E26E}
        /// History: {EFA24E62-B078-11d0-89E4-00C04FC9E26E}
        /// Search: {30D02401-6A81-11d0-8274-00C04FD5AE38}
        /// </remarks>
        public HRESULT ShowBrowserBar([In] BSTR bstrClsid, [In] VARIANT bShow, [Out] out VARIANT pSuccess)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSTR, VARIANT, out VARIANT, HRESULT>)_vTable[38])(thisPtr, bstrClsid, bShow, out pSuccess);
            }
        }
    }
}
