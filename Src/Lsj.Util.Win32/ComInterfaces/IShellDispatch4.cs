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
    /// Extends the <see cref="IShellDispatch3"/> object.
    /// In addition to the properties and methods supported by <see cref="IShellDispatch3"/>, <see cref="IShellDispatch4"/> supports four additional methods.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/shell/ishelldispatch4"/>
    /// </para>
    /// </summary>
    public unsafe struct IShellDispatch4
    {
        nint* _vTable;

        /// <summary>
        /// Displays the Windows Security dialog box.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// This method displays the dialog box shown after pressing CTRL+ALT+DELETE or using the security option on the Start menu.
        /// </remarks>
        public HRESULT WindowsSecurity()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[40])(thisPtr);
            }
        }

        /// <summary>
        /// Displays or hides the desktop.
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// This method has the same effect as the Show Desktop button on the taskbar.
        /// It either hides all open windows to show the desktop or it hides the desktop by showing all open windows.
        /// The <see cref="ToggleDesktop"/> method does not display a user interface, it just invokes the toggle action.
        /// </remarks>
        public HRESULT ToggleDesktop()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[41])(thisPtr);
            }
        }

        /// <summary>
        /// Gets the value for a specified Windows Internet Explorer policy.
        /// </summary>
        /// <param name="bstrPolicyName">
        /// A String that specifies the name of the policy.
        /// </param>
        /// <param name="pValue">
        /// The value associated with the specified policy name.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// Network Administrators can control and manage the computing environment of their users by setting policies.
        /// The specified value name must be within the HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\Explorer subkey.
        /// If the value name does not exist then the method returns null.
        /// </remarks>
        public HRESULT ExplorerPolicy([In] BSTR bstrPolicyName, [Out] out VARIANT pValue)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, BSTR, out VARIANT, HRESULT>)_vTable[42])(thisPtr, bstrPolicyName, out pValue);
            }
        }

        /// <summary>
        /// Retrieves a global Shell setting.
        /// </summary>
        /// <param name="lSetting">
        /// A value that specifies the current Shell setting to retrieve.
        /// Only one setting can be retrieved in each call.
        /// The following values are recognized by this method.
        /// SSF_AUTOCHECKSELECT (0x00800000)
        /// Windows Vista and later.
        /// The state of the Use check boxes to select items option.
        /// This option is enabled automatically when the system has a pen input device configured.
        /// SSF_DESKTOPHTML (0x00000200)
        /// Not used.
        /// SSF_DONTPRETTYPATH (0x00000800)
        /// The state of the Allow all uppercase names option.
        /// As of Windows Vista, this folder option is no longer available.
        /// SSF_DOUBLECLICKINWEBVIEW (0x00000080)
        /// The state of the Double-click to open an item (single-click to select) option.
        /// SSF_FILTER (0x00010000)
        /// Not used.
        /// SSF_HIDDENFILEEXTS (0x00000004)
        /// Not used.
        /// SSF_HIDEICONS (0x00004000)
        /// The state of icon display in the Windows Explorer list view.
        /// If this option is active, no icons are displayed in the list view.
        /// SSF_ICONSONLY (0x01000000)
        /// Windows Vista and later.
        /// The state of display name display in the Windows Explorer list view.
        /// If this option is active, icons are displayed in the list view, but display names are not.
        /// SSF_MAPNETDRVBUTTON (0x00001000)
        /// The state of the Show map network drive button in toolbar option.
        /// As of Windows Vista, this option is no longer available.
        /// SSF_NOCONFIRMRECYCLE (0x00008000)
        /// The state of the Recycle Bin's Display delete confirmation dialog option.
        /// SSF_NONETCRAWLING (0x00100000)
        /// The state of the Automatically search for network folders and printers option. As of Windows Vista, this option is no longer available.
        /// SSF_SEPPROCESS (0x00080000)
        /// The state of the Launch folder windows in a separate process option.
        /// SSF_SERVERADMINUI (0x00000004)
        /// Not used.
        /// SSF_SHOWALLOBJECTS (0x00000001)
        /// The state of the Hidden files and folders option.
        /// SSF_SHOWATTRIBCOL (0x00000100)
        /// The state of the Show File Attributes in Detail View option.
        /// As of Windows Vista, this option is no longer available.
        /// SSF_SHOWCOMPCOLOR (0x00000008)
        /// The state of the Show encrypted or compressed NTFS files in color option.
        /// SSF_SHOWEXTENSIONS (0x00000002)
        /// The state of the Hide extensions for known file types option.
        /// SSF_SHOWINFOTIP (0x00002000)
        /// The state of the Show pop-up description for folder and desktop items option.
        /// SSF_SHOWSTARTPAGE (0x00400000)
        /// Not used.
        /// SSF_SHOWSUPERHIDDEN (0x00040000)
        /// The state of the Hide protected operating system files option.
        /// SSF_SHOWSYSFILES (0x00000020)
        /// The state of the Hidden files and folders option.
        /// In Windows Vista and later, this is equivalent to SSF_SHOWALLOBJECTS.
        /// In versions of Windows before Windows Vista, this value referred to the state of the Do not show hidden files and folders option.
        /// SSF_SHOWTYPEOVERLAY (0x02000000)
        /// Windows Vista and later.
        /// The state of the Display file icon on thumbnails option.
        /// If this option is active, a file type overlay is applied when a file supplies a thumbnail representation.
        /// SSF_SORTCOLUMNS (0x00000010)
        /// Not used.
        /// SSF_STARTPANELON (0x00200000)
        /// The state of the Windows XP display option, which selects between the Windows XP style and the classic style.
        /// As of Windows Vista, this option is no longer available.
        /// SSF_WEBVIEW (0x00020000)
        /// The state of the Display as a web view option.
        /// As of Windows Vista, this option is no longer available.
        /// SSF_WIN95CLASSIC (0x00000400)
        /// The state of the Classic Style option. As of Windows Vista, this option is no longer available.
        /// </param>
        /// <param name="pResult">
        /// Set to true if the setting exists; otherwise, false.
        /// </param>
        /// <returns></returns>
        public HRESULT GetSetting([In] int lSetting, [Out] out VARIANT_BOOL pResult)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, int, out VARIANT_BOOL, HRESULT>)_vTable[43])(thisPtr, lSetting, out pResult);
            }
        }
    }
}
