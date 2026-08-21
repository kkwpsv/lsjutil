using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Win32.ComInterfaces
{
#pragma warning disable IDE1006
    /// <summary>
    /// <para>
    /// Represents an object in the Shell.
    /// Methods are provided to control the Shell and to execute commands within the Shell.
    /// There are also methods to obtain other Shell-related objects.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/shell/ishelldispatch"/>
    /// </para>
    /// </summary>
    public unsafe struct IShellDispatch
    {
        nint* _vTable;

        /// <summary>
        /// Contains an object that represents an application.
        /// </summary>
        /// <param name="ppid">
        /// A variable of type <see cref="IDispatch"/> that receives the application object.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The Application property returns the automation object supported by the application that contains the WebBrowser control, if that object is accessible.
        /// Otherwise, this property returns the WebBrowser control's automation object.
        /// Use this property with the Set and CreateObject commands or with the GetObject command
        /// to create and manipulate an instance of the Windows Internet Explorer application.
        /// </remarks>
        public HRESULT get_Application([Out] out P<IDispatch> ppid)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDispatch>, HRESULT>)_vTable[7])(thisPtr, out ppid);
            }
        }

        /// <summary>
        /// Retrieves an object that represents the parent of the current object.
        /// </summary>
        /// <param name="ppid">
        /// A variable of type IDispatch that receives the parent object.
        /// </param>
        /// <returns></returns>
        public HRESULT get_Parent([Out] out P<IDispatch> ppid)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDispatch>, HRESULT>)_vTable[8])(thisPtr, out ppid);
            }
        }

        /// <summary>
        /// Creates and returns a <see cref="Folder"/> object for the specified folder.
        /// </summary>
        /// <param name="vDir">
        /// The folder for which to create the <see cref="Folder"/> object.
        /// This can be a string that specifies the path of the folder or one of the <see cref="ShellSpecialFolderConstants"/> values.
        /// </param>
        /// <param name="ppsdf">
        /// Object reference to the Folder object for the specified folder.
        /// If the folder is not successfully created, this value returns null.
        /// </param>
        /// <returns></returns>
        public HRESULT NameSpace([In] VARIANT vDir, [Out] out P<Folder> ppsdf)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, VARIANT, out P<Folder>, HRESULT>)_vTable[9])(thisPtr, vDir, out ppsdf);
            }
        }

        /// <summary>
        /// Creates a dialog box that enables the user to select a folder and then returns the selected folder's <see cref="Folder"/> object.
        /// </summary>
        /// <param name="Hwnd">
        /// The handle to the parent window of the dialog box.
        /// This value can be zero.
        /// </param>
        /// <param name="Title">
        /// A String value that represents the title displayed inside the Browse dialog box.
        /// </param>
        /// <param name="Options">
        /// An Integer value that contains the options for the method.
        /// This can be zero or a combination of the values listed under the <see cref="BROWSEINFO.ulFlags"/> member of the <see cref="BROWSEINFO"/> structure.
        /// </param>
        /// <param name="RootFolder">
        /// The root folder to use in the dialog box.
        /// The user cannot browse higher in the tree than this folder.
        /// If this value is not specified, the root folder used in the dialog box is the desktop.
        /// This value can be a string that specifies the path of the folder or one of the <see cref="ShellSpecialFolderConstants"/> values.
        /// </param>
        /// <param name="ppsdf">
        /// An object reference to the selected folder's Folder object.
        /// </param>
        /// <returns></returns>
        public HRESULT BrowseForFolder([In] int Hwnd, [In] BSTR Title, [In] int Options, [In] VARIANT RootFolder, [Out] out P<Folder> ppsdf)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, int, BSTR, int, VARIANT, out P<Folder>, HRESULT>)_vTable[10])(thisPtr, Hwnd, Title, Options, RootFolder, out ppsdf);
            }
        }

        /// <summary>
        /// Creates and returns a ShellWindows object.
        /// This object represents a collection of all of the open windows that belong to the Shell.
        /// </summary>
        /// <param name="ppid">
        /// An object reference to the ShellWindows object.
        /// </param>
        /// <returns></returns>
        public HRESULT Windows([Out] out P<IDispatch> ppid)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out P<IDispatch>, HRESULT>)_vTable[11])(thisPtr, out ppid);
            }
        }

        /// <summary>
        /// Opens the specified folder.
        /// </summary>
        /// <param name="vDir">
        /// A string that specifies the path of the folder or one of the <see cref="ShellSpecialFolderConstants"/> values.
        /// If <paramref name="vDir"/> is set to one of the <see cref="ShellSpecialFolderConstants"/> and the special folder does not exist,
        /// this function will create the folder.
        /// </param>
        /// <returns></returns>
        public HRESULT Open([In] VARIANT vDir)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, VARIANT, HRESULT>)_vTable[12])(thisPtr, vDir);
            }
        }

        /// <summary>
        /// Opens a specified folder in a Windows Explorer window.
        /// </summary>
        /// <param name="vDir">
        /// The folder to be displayed.
        /// This can be a string that specifies the path of the folder or one of the <see cref="ShellSpecialFolderConstants"/> values.
        /// </param>
        /// <returns></returns>
        public HRESULT Explore([In] VARIANT vDir)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, VARIANT, HRESULT>)_vTable[13])(thisPtr, vDir);
            }
        }

        /// <summary>
        /// Minimizes all of the windows on the desktop.
        /// This method has the same effect as right-clicking the taskbar and selecting Minimize All Windows on older systems
        /// or clicking the Show Desktop icon on the taskbar.
        /// </summary>
        /// <returns></returns>
        public HRESULT MinimizeAll()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[14])(thisPtr);
            }
        }

        /// <summary>
        /// Restores all desktop windows to the state they were in before the last <see cref="MinimizeAll"/> command.
        /// This method has the same effect as right-clicking the taskbar and selecting Undo Minimize All Windows (on older systems)
        /// or a second clicking of the Show Desktop icon in the taskbar.
        /// </summary>
        /// <returns></returns>
        public HRESULT UndoMinimizeALL()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[15])(thisPtr);
            }
        }

        /// <summary>
        /// Displays the Run dialog to the user.
        /// </summary>
        /// <returns></returns>
        public HRESULT FileRun()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[16])(thisPtr);
            }
        }

        /// <summary>
        /// Cascades all of the windows on the desktop.
        /// This method has the same effect as right-clicking the taskbar and selecting Cascade windows.
        /// </summary>
        /// <returns></returns>
        public HRESULT CascadeWindows()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[17])(thisPtr);
            }
        }

        /// <summary>
        /// Tiles all of the windows on the desktop vertically.
        /// This method has the same effect as right-clicking the taskbar and selecting Show windows side by side.
        /// </summary>
        /// <returns></returns>
        public HRESULT TileVertically()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[18])(thisPtr);
            }
        }

        /// <summary>
        /// Tiles all of the windows on the desktop horizontally.
        /// This method has the same effect as right-clicking the taskbar and selecting Show windows stacked.
        /// </summary>
        /// <returns></returns>
        public HRESULT TileHorizontally()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[19])(thisPtr);
            }
        }

        /// <summary>
        /// Displays the Shut Down Windows dialog box.
        /// This is the same as clicking the Start menu and selecting Shut Down.
        /// </summary>
        /// <returns></returns>
        public HRESULT ShutdownWindows()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[20])(thisPtr);
            }
        }

        /// <summary>
        /// This method is not implemented.
        /// </summary>
        /// <returns></returns>
        public HRESULT Suspend()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[21])(thisPtr);
            }
        }

        /// <summary>
        /// Ejects the computer from its docking station.
        /// This is the same as clicking the Start menu and selecting Eject PC, if your computer supports this command.
        /// </summary>
        /// <returns></returns>
        public HRESULT EjectPC()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[22])(thisPtr);
            }
        }

        /// <summary>
        /// Displays the Date and Time dialog box.
        /// This method has the same effect as right-clicking the clock in the taskbar status area and selecting Adjust date/time.
        /// </summary>
        /// <returns></returns>
        public HRESULT SetTime()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[23])(thisPtr);
            }
        }

        /// <summary>
        /// Displays the Taskbar and Start Menu Properties dialog box.
        /// This method has the same effect as right-clicking the taskbar and selecting Properties.
        /// </summary>
        /// <returns></returns>
        public HRESULT TrayProperties()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[24])(thisPtr);
            }
        }

        /// <summary>
        /// Displays the Windows Help and Support window.
        /// This method has the same effect as clicking the Start menu and selecting Help and Support.
        /// </summary>
        /// <returns></returns>
        public HRESULT Help()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[25])(thisPtr);
            }
        }

        /// <summary>
        /// Displays the Find: All Files dialog box.
        /// This is the same as clicking the Start menu and then selecting Search.
        /// </summary>
        /// <returns></returns>
        public HRESULT FindFiles()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[26])(thisPtr);
            }
        }

        /// <summary>
        /// Displays the Search Results: Computers dialog box.
        /// The dialog box shows the result of the search for a specified computer.
        /// </summary>
        /// <returns></returns>
        public HRESULT FindComputer()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[27])(thisPtr);
            }
        }

        /// <summary>
        /// Refreshes the contents of the Start menu.
        /// Used only with systems preceding Windows XP.
        /// </summary>
        /// <returns></returns>
        public HRESULT RefreshMenu()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[28])(thisPtr);
            }
        }

        /// <summary>
        /// Runs the specified Control Panel application.
        /// If the application is already open, it will activate the running instance.
        /// </summary>
        /// <param name="bstrDir">
        /// The Control Panel application's file name.
        /// </param>
        /// <returns></returns>
        public HRESULT ControlPanelItem([In] BSTR bstrDir)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSTR, HRESULT>)_vTable[29])(thisPtr, bstrDir);
            }
        }
    }
#pragma warning restore IDE1006
}
