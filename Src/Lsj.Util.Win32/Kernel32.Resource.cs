using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Gdi32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32
{
    public partial class Kernel32
    {
        /// <summary>
        /// <para>
        /// Determines the location of a resource with the specified type and name in the specified module.
        /// To specify a language, use the <see cref="FindResourceEx"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-findresourcea"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the module whose portable executable file or an accompanying MUI file contains the resource.
        /// If this parameter is <see langword="null"/>, the function searches the module used to create the current process.
        /// </param>
        /// <param name="lpName">
        /// The name of the resource.
        /// Alternately, rather than a pointer, this parameter can be <see cref="MAKEINTRESOURCE"/>(ID), where ID is the integer identifier of the resource.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="lpType">
        /// The resource type. 
        /// Alternately, rather than a pointer, this parameter can be <see cref="MAKEINTRESOURCE"/>(ID),
        /// where ID is the integer identifier of the given resource type.
        /// For standard resource types, see Resource Types. 
        /// For more information, see the Remarks section below.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified resource's information block.
        /// To obtain a handle to the resource, pass this handle to the LoadResource function.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If <see cref="IS_INTRESOURCE"/> is <see cref="IS_INTRESOURCE"/> for x = <paramref name="lpName"/> or <paramref name="lpType"/>,
        /// x specifies the integer identifier of the name or type of the given resource.
        /// Otherwise, those parameters are long pointers to null-terminated strings.
        /// If the first character of the string is a pound sign (#), the remaining characters represent a decimal number
        /// that specifies the integer identifier of the resource's name or type.
        /// For example, the string "#258" represents the integer identifier 258.
        /// To reduce the amount of memory required for a resource, an application should refer to it by integer identifier instead of by name.
        /// An application can use FindResource to find any type of resource, but this function should be used only if the application
        /// must access the binary resource data by making subsequent calls to <see cref="LoadResource"/> and then to <see cref="LockResource"/>.
        /// To use a resource immediately, an application should use one of the following resource-specific functions
        /// to find the resource and convert the data into a more usable form.
        /// <see cref="FormatMessage"/>: Loads and formats a message-table entry.
        /// <see cref="LoadAccelerators"/>: Loads an accelerator table.
        /// <see cref="LoadBitmap"/>: Loads a bitmap resource.
        /// <see cref="LoadCursor"/>: Loads a cursor resource.
        /// <see cref="LoadIcon"/>: Loads an icon resource.
        /// <see cref="LoadMenu"/>: Loads a menu resource.
        /// <see cref="LoadString"/>: Loads a string-table entry.
        /// For example, an application can use the <see cref="LoadIcon"/> function to load an icon for display on the screen.
        /// However, the application should use <see cref="FindResource"/> and <see cref="LoadResource"/>
        /// if it is loading the icon to copy its data to another application.
        /// String resources are stored in sections of up to 16 strings per section.
        /// The strings in each section are stored as a sequence of counted (not necessarily null-terminated) Unicode strings.
        /// The <see cref="LoadString"/> function will extract the string resource from its corresponding section.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindResourceW", ExactSpelling = true, SetLastError = true)]
        public static extern HRSRC FindResource([In]HMODULE hModule, [MarshalAs(UnmanagedType.LPWStr)][In]string lpName,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpType);

        /// <summary>
        /// <para>
        /// Determines the location of the resource with the specified type, name, and language in the specified module.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/nf-winbase-findresourceexa"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the module whose portable executable file or an accompanying MUI file contains the resource.
        /// If this parameter is <see cref="NULL"/>, the function searches the module used to create the current process.
        /// </param>
        /// <param name="lpType">
        /// The resource type.
        /// Alternately, rather than a pointer, this parameter can be <code>MAKEINTRESOURCE(ID)</code>,
        /// where ID is the integer identifier of the given resource type.
        /// For standard resource types, see Resource Types.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="lpName">
        /// The name of the resource. Alternately, rather than a pointer, this parameter can be <code>MAKEINTRESOURCE(ID)</code>,
        /// where ID is the integer identifier of the resource.
        /// For more information, see the Remarks section below.
        /// </param>
        /// <param name="wLanguage">
        /// The language of the resource.
        /// If this parameter is MAKELANGID(LANG_NEUTRAL, SUBLANG_NEUTRAL), the current language associated with the calling thread is used.
        /// To specify a language other than the current language, use the <see cref="MAKELANGID"/> macro to create this parameter.
        /// For more information, see <see cref="MAKELANGID"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the specified resource's information block.
        /// To obtain a handle to the resource, pass this handle to the <see cref="LoadResource"/> function.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FindResourceExW", ExactSpelling = true, SetLastError = true)]
        public static extern HRSRC FindResourceEx([In]HMODULE hModule, [MarshalAs(UnmanagedType.LPWStr)][In]string lpType,
            [MarshalAs(UnmanagedType.LPWStr)][In]string lpName, [In]WORD wLanguage);

        /// <summary>
        /// <para>
        /// Decrements (decreases by one) the reference count of a loaded resource.
        /// When the reference count reaches zero, the memory occupied by the resource is freed.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-freeresource"/>
        /// </para>
        /// </summary>
        /// <param name="hResData">
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.FALSE"/>.
        /// If the function fails, the return value is <see cref="BOOL.TRUE"/>, which indicates that the resource has not been freed.
        /// </returns>
        /// <remarks>
        /// For resources loaded with other functions, <see cref="FreeResource"/> has been replaced by the following functions:
        /// Accelerator: <see cref="DestroyAcceleratorTable"/>
        /// Bitmap: <see cref="DeleteObject"/>
        /// Cursor: <see cref="DestroyCursor"/>
        /// Icon: <see cref="DestroyIcon"/>
        /// Menu: <see cref="DestroyMenu"/>
        /// The reference count for a resource is incremented (increased by one) each time an application
        /// calls the <see cref="LoadResource"/> function for the resource.
        /// The system automatically deletes these resources when the process that created them terminates.
        /// However, calling the appropriate function saves memory.
        /// For more information, see <see cref="LoadResource"/>.
        /// </remarks>
        [Obsolete("This function is obsolete and is only supported for backward compatibility with 16-bit Windows." +
            "For 32-bit Windows applications, it is not necessary to free the resources loaded using LoadResource." +
            "If used on 32 or 64-bit Windows systems, this function will return FALSE.")]
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "FreeResource", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL FreeResource([In]HGLOBAL hResData);

        /// <summary>
        /// <para>
        /// Retrieves a handle that can be used to obtain a pointer to the first byte of the specified resource in memory.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-loadresource"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the module whose executable file contains the resource.
        /// If <paramref name="hModule"/> is <see cref="NULL"/>, the system loads the resource from the module that was used to create the current process.
        /// </param>
        /// <param name="hResInfo">
        /// A handle to the resource to be loaded.
        /// This handle is returned by the <see cref="FindResource"/> or <see cref="FindResourceEx"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the data associated with the resource.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// The return type of <see cref="LoadResource"/> is <see cref="HGLOBAL"/> for backward compatibility,
        /// not because the function returns a handle to a global memory block.
        /// Do not pass this handle to the <see cref="GlobalLock"/> or <see cref="GlobalFree"/> function.
        /// To obtain a pointer to the first byte of the resource data, call the <see cref="LockResource"/> function;
        /// to obtain the size of the resource, call <see cref="SizeofResource"/>.
        /// To use a resource immediately, an application should use the following resource-specific functions to find and load the resource in one call.
        /// Function                        Action                                      To remove resource
        /// <see cref="FormatMessage"/>     Loads and formats a message-table entry     No action needed
        /// <see cref="LoadAccelerators"/>  Loads an accelerator table                  <see cref="DestroyAcceleratorTable"/>
        /// <see cref="LoadBitmap"/>        Loads a bitmap resource                     <see cref="DeleteObject"/>
        /// <see cref="LoadCursor"/>        Loads a cursor resource                     <see cref="DestroyCursor"/>
        /// <see cref="LoadIcon"/>          Loads an icon resource                      <see cref="DestroyIcon"/>
        /// <see cref="LoadMenu"/>          Loads a menu resource                       <see cref="DestroyMenu"/>
        /// <see cref="LoadString"/>        Loads a string resource                     No action needed
        /// For example, an application can use the <see cref="LoadIcon"/> function to load an icon for display on the screen,
        /// followed by <see cref="DestroyIcon"/> when done.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LoadResource", ExactSpelling = true, SetLastError = true)]
        public static extern HGLOBAL LoadResource([In]HMODULE hModule, [In]HRSRC hResInfo);

        /// <summary>
        /// <para>
        /// Retrieves a pointer to the specified resource in memory.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-lockresource"/>
        /// </para>
        /// </summary>
        /// <param name="hResData">
        /// A handle to the resource to be accessed.
        /// The <see cref="LoadResource"/> function returns this handle.
        /// Note that this parameter is listed as an <see cref="HGLOBAL"/> variable only for backward compatibility.
        /// Do not pass any value as a parameter other than a successful return value from the <see cref="LoadResource"/> function.
        /// </param>
        /// <returns>
        /// If the loaded resource is available, the return value is a pointer to the first byte of the resource; otherwise, it is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// The pointer returned by <see cref="LockResource"/> is valid until the module containing the resource is unloaded.
        /// It is not necessary to unlock resources because the system automatically deletes them when the process that created them terminates.
        /// Do not try to lock a resource by using the handle returned by the <see cref="FindResource"/> or <see cref="FindResourceEx"/> function.
        /// Such a handle points to random data.
        /// Note
        /// <see cref="LockResource"/> does not actually lock memory; it is just used to obtain a pointer to the memory containing the resource data.
        /// The name of the function comes from versions prior to Windows XP,
        /// when it was used to lock a global memory block allocated by <see cref="LoadResource"/>.
        /// </remarks>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "LockResource", ExactSpelling = true, SetLastError = true)]
        public static extern LPVOID LockResource([In]HGLOBAL hResData);

        /// <summary>
        /// <para>
        /// Converts an integer value to a resource type compatible with the resource-management functions.
        /// This macro is used in place of a string containing the name of the resource.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winuser/nf-winuser-makeintresourcew"/>
        /// </para>
        /// </summary>
        /// <param name="i">
        /// The integer value to be converted.
        /// </param>
        /// <returns>
        /// The return value should be passed only to functions which explicitly indicate that they accept <see cref="MAKEINTRESOURCE"/> as a parameter.
        /// For example, the resource management functions allow the return value of <see cref="MAKEINTRESOURCE"/>
        /// to be passed as the lpType or lpName parameters.
        /// </returns>
        public static IntPtr MAKEINTRESOURCE(WORD i) => (IntPtr)(int)i;

        /// <summary>
        /// <para>
        /// Retrieves the size, in bytes, of the specified resource.
        /// </para>
        /// <para>
        /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/libloaderapi/nf-libloaderapi-sizeofresource"/>
        /// </para>
        /// </summary>
        /// <param name="hModule">
        /// A handle to the module whose executable file contains the resource.
        /// </param>
        /// <param name="hResInfo">
        /// A handle to the resource.
        /// This handle must be created by using the <see cref="FindResource"/> or <see cref="FindResourceEx"/> function.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the number of bytes in the resource.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "SizeofResource", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD SizeofResource([In]HMODULE hModule, [In]HRSRC hResInfo);
    }
}
