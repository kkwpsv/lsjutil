using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Enums.POINTER_FLAGS;
using static Lsj.Util.Win32.Enums.POINTER_INPUT_TYPE;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public static partial class User32
    {
        /// <summary>
        /// <para>
        /// Enables the mouse to act as a pointer input device and send <see cref="WM_POINTER"/> messages.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/Winuser/nf-winuser-enablemouseinpointer"/>
        /// </para>
        /// </summary>
        /// <param name="fEnable">
        /// <see cref="TRUE"/> to turn on mouse input support in <see cref="WM_POINTER"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// This function can be called only once in the context of a process lifetime.
        /// Prior to the first call, Windows Store apps run with mouse-in-pointer enabled, as do any desktop applications that consume mshtml.dll.
        /// All other desktop applications run with mouse-in-pointer disabled.
        /// On the first call in the process lifetime, the state is changed as specified and the call succeeds.
        /// On subsequent calls, the state will not change.
        /// If the current state is not equal to the specified state, the call fails.
        /// Call <see cref="IsMouseInPointerEnabled"/> to verify the mouse-in-pointer state.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnableMouseInPointer", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL EnableMouseInPointer([In] BOOL fEnable);

        /// <summary>
        /// <para>
        /// Retrieves the cursor identifier associated with the specified pointer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointercursorid"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// An identifier of the pointer for which to retrieve the cursor identifier.
        /// </param>
        /// <param name="cursorId">
        /// An address of a <see cref="UINT32"/> to receive the tablet cursor identifier, if any, associated with the specified pointer.
        /// </param>
        /// <returns></returns>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerCursorId", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerCursorId([In] UINT32 pointerId, [Out] out UINT32 cursorId);

        /// <summary>
        /// <para>
        /// Gets information about the pointer device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerdevice"/>
        /// </para>
        /// </summary>
        /// <param name="device">
        /// The handle to the device.
        /// </param>
        /// <param name="pointerDevice">
        /// A <see cref="POINTER_DEVICE_INFO"/> structure that contains information about the pointer device.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="TRUE"/>.
        /// Otherwise, it returns <see cref="FALSE"/>.
        /// To retrieve extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerDevice", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerDevice([In] HANDLE device, [Out] out POINTER_DEVICE_INFO pointerDevice);

        /// <summary>
        /// <para>
        /// Gets the cursor IDs that are mapped to the cursors associated with a pointer device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerdevicecursors"/>
        /// </para>
        /// </summary>
        /// <param name="device">
        /// The device handle.
        /// </param>
        /// <param name="cursorCount">
        /// The number of cursors associated with the pointer device.
        /// </param>
        /// <param name="deviceCursors">
        /// An array of <see cref="POINTER_DEVICE_CURSOR_INFO"/> structures that contain info about the cursors.
        /// If NULL, <paramref name="cursorCount"/> returns the number of cursors associated with the pointer device.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if the function succeeds; otherwise, <see cref="FALSE"/>.
        /// If the function fails, call the <see cref="GetLastError"/> function for more information.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerDeviceCursors", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerDeviceCursors([In] HANDLE device, [In][Out] ref UINT32 cursorCount, [Out] POINTER_DEVICE_CURSOR_INFO[] deviceCursors);

        /// <summary>
        /// <para>
        /// Gets device properties that aren't included in the <see cref="POINTER_DEVICE_INFO"/> structure.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerdeviceproperties"/>
        /// </para>
        /// </summary>
        /// <param name="device">
        /// The pointer device to query properties from.
        /// A call to the <see cref="GetPointerDevices"/> function returns this handle in the <see cref="POINTER_DEVICE_INFO"/> structure.
        /// </param>
        /// <param name="propertyCount">
        /// The number of properties.
        /// Returns the count that's written or needed if <paramref name="pointerProperties"/> is <see langword="null"/>.
        /// If this value is less than the number of properties that the pointer device supports
        /// and <paramref name="pointerProperties"/> is not <see langword="null"/>,
        /// the function returns the actual number of properties in this variable and fails.
        /// </param>
        /// <param name="pointerProperties">
        /// The array of properties.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if the function succeeds; otherwise, <see cref="FALSE"/>.
        /// If the function fails, call the <see cref="GetLastError"/> function for more information.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerDeviceProperties", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerDeviceProperties([In] HANDLE device, [In][Out] ref UINT32 propertyCount,
            [Out] POINTER_DEVICE_PROPERTY[] pointerProperties);

        /// <summary>
        /// <para>
        /// Gets the x and y range for the pointer device (in himetric) and
        /// the x and y range (current resolution) for the display that the pointer device is mapped to.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerdevicerects"/>
        /// </para>
        /// </summary>
        /// <param name="device">
        /// The handle to the pointer device.
        /// </param>
        /// <param name="pointerDeviceRect">
        /// The structure for retrieving the device's physical range data.
        /// </param>
        /// <param name="displayRect">
        /// The structure for retrieving the display resolution.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if the function succeeds; otherwise, <see cref="FALSE"/>.
        /// If the function fails, call the <see cref="GetLastError"/> function for more information.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerDeviceRects", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerDeviceRects([In] HANDLE device, [Out] out RECT pointerDeviceRect, [Out] out RECT displayRect);

        /// <summary>
        /// <para>
        /// Gets information about the pointer devices attached to the system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerdevices"/>
        /// </para>
        /// </summary>
        /// <param name="deviceCount">
        /// If <paramref name="pointerDevices"/> is <see langword="null"/>,
        /// <paramref name="deviceCount"/> returns the total number of attached pointer devices.
        /// Otherwise, <paramref name="deviceCount"/> specifies
        /// the number of <see cref="POINTER_DEVICE_INFO"/> structures pointed to by <paramref name="pointerDevices"/>.
        /// </param>
        /// <param name="pointerDevices">
        /// Array of <see cref="POINTER_DEVICE_INFO"/> structures for the pointer devices attached to the system.
        /// If <see langword="null"/>, the total number of attached pointer devices is returned in <paramref name="deviceCount"/>.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="TRUE"/>.
        /// Otherwise, it returns <see cref="FALSE"/>.
        /// To retrieve extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        /// <remarks>
        /// Windows 8 supports the following:
        /// 256 contacts per pointer device.
        /// 2560 total contacts per system session, regardless of the number of attached devices.
        /// For example, 10 pointer devices with 256 contacts each, 20 pointer devices with 128 contacts each, and so on.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerDevices", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerDevices([In][Out] ref UINT32 deviceCount, [Out] POINTER_DEVICE_INFO[] pointerDevices);

        /// <summary>
        /// <para>
        /// Gets the entire frame of information for the specified pointers associated with the current message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerframeinfo"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// An identifier of the pointer for which to retrieve frame information.
        /// </param>
        /// <param name="pointerCount">
        /// A pointer to a variable that specifies the count of structures in the buffer to which pointerInfo points.
        /// If <see cref="GetPointerFrameInfo"/> succeeds, <paramref name="pointerCount"/> is updated with the total count of pointers in the frame.
        /// </param>
        /// <param name="pointerInfo">
        /// Address of an array of <see cref="POINTER_INFO"/> structures to receive the pointer information.
        /// This parameter can be <see langword="null"/> if *<paramref name="pointerCount"/> is zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Parallel-mode devices may report pointer input in frames, that is,
        /// they may report the state and position of all pointers from that device in a single input report to the system.
        /// Ideally, applications should view the entire frame as a single input unless the application-specific requirements dictate otherwise.
        /// <see cref="GetPointerFrameInfo"/> retrieves the entire pointer input frame associated with a pointer message.
        /// Use <see cref="GetPointerInfo"/> to retrieve information for a single pointer associated with a pointer message.
        /// The frame contains only pointers that are currently owned by the same window as the specified pointer.
        /// The information returned by <see cref="GetPointerFrameInfo"/> is associated with the most recent pointer message retrieved by the calling thread.
        /// When the next message is retrieved by the calling thread, the information associated with the previous message may no longer be available.
        /// If the application does not process pointer input messages as fast as they are generated,
        /// some messages may be coalesced into a <see cref="WM_POINTERUPDATE"/> message.
        /// Use <see cref="GetPointerFrameInfoHistory"/> to retrieve the message history from the most recent <see cref="WM_POINTERUPDATE"/> message.
        /// Having retrieved the entire frame of information, the application can then call the <see cref="SkipPointerFrameMessages"/> function
        /// to skip remaining pointer messages associated with this frame that are pending retrieval.
        /// This saves the application the overhead of retrieving and processing the remaining messages one by one.
        /// However, the <see cref="SkipPointerFrameMessages"/> function should be used with care and only when the caller can be sure
        /// that no other entity on the caller’s thread is expecting to see the remaining pointer messages one by one as they are retrieved.
        /// Note that the information retrieved is associated with the pointer frame most recently retrieved by the calling thread.
        /// Once the calling thread retrieves its next message, the information associated with the previous pointer frame may no longer be available.
        /// If the pointer frame contains no additional pointers besides the specified pointer,
        /// this function succeeds and returns only the information for the specified pointer.
        /// If the information associated with the pointer frame is no longer available,
        /// this function fails with the last error set to <see cref="ERROR_NO_DATA"/>.
        /// If the calling thread does not own the window (where the input was originally delivered or where the message was forwarded)
        /// to which the pointer message has been delivered, this function fails with the last error set to <see cref="ERROR_ACCESS_DENIED"/>.
        /// For apps that have both client and non-client areas, the input frame can include both client and non-client data.
        /// To differentiate between client and non-client data, you must perform hit testing on the target window.
        /// We recommend the following if you want to filter data from the input frame:
        /// For each update that does not include a pointer contact (a <see cref="POINTER_FLAG_UPDATE"/> without <see cref="POINTER_FLAG_INCONTACT"/>),
        /// hit test to determine if the input is client or non-client.
        /// For each new contact (<see cref="POINTER_FLAG_DOWN"/>), hit test to determine if the input is client or non-client and track this info.
        /// For each update that includes a pointer contact (a <see cref="POINTER_FLAG_UPDATE"/> with <see cref="POINTER_FLAG_INCONTACT"/>),
        /// use the tracking info to determine whether the input is client or non-client.
        /// For each <see cref="POINTER_FLAG_UP"/>, use the tracking info to determine
        /// whether the input is client or non-client and then clear this pointer from the tracking data.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerFrameInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerFrameInfo([In] UINT32 pointerId, [In][Out] ref UINT32 pointerCount, [Out] POINTER_INFO[] pointerInfo);

        /// <summary>
        /// <para>
        /// Gets the entire frame of information (including coalesced input frames) for the specified pointers associated with the current message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerframeinfohistory"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// An identifier of the pointer for which to retrieve frame information.
        /// </param>
        /// <param name="entriesCount">
        /// A pointer to a variable that specifies the count of rows in the two-dimensional array to which <paramref name="pointerInfo"/> points.
        /// If <see cref="GetPointerFrameInfoHistory"/> succeeds, <paramref name="entriesCount"/> is updated with the total count of frames available in the history.
        /// </param>
        /// <param name="pointerCount">
        /// A pointer to a variable that specifies the count of columns in the two-dimensional array to which <paramref name="pointerInfo"/> points.
        /// If <see cref="GetPointerFrameInfoHistory"/> succeeds, <paramref name="pointerCount"/> is updated with the total count of pointers in each frame.
        /// </param>
        /// <param name="pointerInfo">
        /// Address of a two-dimensional array of <see cref="POINTER_INFO"/> structures to receive the pointer information.
        /// This parameter can be <see langword="null"/> if *<paramref name="entriesCount"/> and *<paramref name="pointerCount"/> are both zero.
        /// This array is interpreted as POINTER_INFO[*entriesCount][*pointerCount].
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Parallel-mode devices may report pointer input in frames, that is,
        /// they may report the state and position of all pointers from that device in a single input report to the system.
        /// Ideally, applications should view the entire frame as a single input unless the application-specific requirements dictate otherwise.
        /// The information returned by <see cref="GetPointerFrameInfo"/> is associated with the most recent pointer message retrieved by the calling thread.
        /// When the next message is retrieved by the calling thread, the information associated with the previous message may no longer be available.
        /// If the application does not process pointer input messages as fast as they are generated,
        /// some messages may be coalesced into a <see cref="WM_POINTERUPDATE"/> message.
        /// Use <see cref="GetPointerFrameInfoHistory"/> to retrieve the message history (including coalesced input frames)
        /// from the most recent <see cref="WM_POINTERUPDATE"/> message.
        /// Having retrieved the entire frame of information, the application can then call the <see cref="SkipPointerFrameMessages"/> function
        /// to skip remaining pointer messages associated with this frame that are pending retrieval.
        /// This saves the application the overhead of retrieving and processing the remaining messages one by one.
        /// However, the <see cref="SkipPointerFrameMessages"/> function should be used with care
        /// and only when the caller can be sure that no other entity on the caller’s thread is expecting
        /// to see the remaining pointer messages one by one as they are retrieved.
        /// The frame contains only pointers that are currently owned by the same window as the specified pointer.
        /// The information retrieved represents a two-dimensional array with one row for each history entry and one column for each pointer in the frame.
        /// The information retrieved appears in reverse chronological order, with the most recent entry in the first row of the returned array.
        /// The most recent entry is the same as that returned by the <see cref="GetPointerFrameInfo"/> function.
        /// If the count of rows in the buffer provided is insufficient to hold all available history entries,
        /// this function succeeds with the buffer containing the most recent entries and *<paramref name="entriesCount"/>
        /// containing the total count of entries available.
        /// If the pointer frame contains no additional pointers besides the specified pointer,
        /// this function succeeds and returns only the information for the specified pointer.
        /// If the information associated with the pointer frame is no longer available,
        /// this function fails with the last error set to <see cref="ERROR_NO_DATA"/>.
        /// If the calling thread does not own the window (where the input was originally delivered or where the message was forwarded)
        /// to which the pointer message has been delivered, this function fails with the last error set to <see cref="ERROR_ACCESS_DENIED"/>.
        /// For apps that have both client and non-client areas, the input frame can include both client and non-client data.
        /// To differentiate between client and non-client data, you must perform hit testing on the target window.
        /// We recommend the following if you want to filter data from the input frame:
        /// For each update that does not include a pointer contact (a <see cref="POINTER_FLAG_UPDATE"/> without <see cref="POINTER_FLAG_INCONTACT"/>),
        /// hit test to determine if the input is client or non-client.
        /// For each new contact (<see cref="POINTER_FLAG_DOWN"/>), hit test to determine if the input is client or non-client and track this info.
        /// For each update that includes a pointer contact (a <see cref="POINTER_FLAG_UPDATE"/> with <see cref="POINTER_FLAG_INCONTACT"/>),
        /// use the tracking info to determine whether the input is client or non-client.
        /// For each <see cref="POINTER_FLAG_UP"/>, use the tracking info to determine
        /// whether the input is client or non-client and then clear this pointer from the tracking data.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerFrameInfoHistory", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerFrameInfoHistory([In] UINT32 pointerId, [In][Out] ref UINT32 entriesCount,
            [In][Out] ref UINT32 pointerCount, [Out] POINTER_INFO[] pointerInfo);

        /// <summary>
        /// <para>
        /// Gets the entire frame of pen-based information for the specified pointers (of type <see cref="PT_PEN"/>) associated with the current message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerframepeninfo"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// An identifier of the pointer for which to retrieve frame information.
        /// </param>
        /// <param name="pointerCount">
        /// A pointer to a variable that specifies the count of structures in the buffer to which penInfo points.
        /// If <see cref="GetPointerFramePenInfo"/> succeeds, <paramref name="pointerCount"/> is updated with the total count of pointers in the frame.
        /// </param>
        /// <param name="penInfo">
        /// Address of an array of <see cref="POINTER_PEN_INFO"/> structures to receive the pointer information.
        /// This parameter can be <see langword="null"/> if *<paramref name="pointerCount"/> is zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Parallel-mode devices may report pointer input in frames, that is,
        /// they may report the state and position of all pointers from that device in a single input report to the system.
        /// Ideally, applications should view the entire frame as a single input unless the application-specific requirements dictate otherwise.
        /// <see cref="GetPointerFramePenInfo"/> retrieves the entire pointer input frame associated with a pointer (of type <see cref="PT_PEN"/>) message.
        /// Use <see cref="GetPointerPenInfo"/> to retrieve information for a single pointer associated with a pointer message.
        /// The frame contains only pointers that are currently owned by the same window as the specified pointer.
        /// The information returned by <see cref="GetPointerFrameInfo"/> is associated with the most recent pointer message retrieved by the calling thread.
        /// When the next message is retrieved by the calling thread, the information associated with the previous message may no longer be available.
        /// If the application does not process pointer input messages as fast as they are generated,
        /// some messages may be coalesced into a <see cref="WM_POINTERUPDATE"/> message.
        /// Use <see cref="GetPointerFramePenInfoHistory"/> to retrieve the message history from the most recent <see cref="WM_POINTERUPDATE"/> message.
        /// Having retrieved the entire frame of information, the application can then call the <see cref="SkipPointerFrameMessages"/> function
        /// to skip remaining pointer messages associated with this frame that are pending retrieval.
        /// This saves the application the overhead of retrieving and processing the remaining messages one by one.
        /// However, the <see cref="SkipPointerFrameMessages"/> function should be used with care and only when the caller can be sure
        /// that no other entity on the caller’s thread is expecting to see the remaining pointer messages one by one as they are retrieved.
        /// Note that the information retrieved is associated with the pointer frame most recently retrieved by the calling thread.
        /// Once the calling thread retrieves its next message, the information associated with the previous pointer frame may no longer be available.
        /// If the pointer frame contains no additional pointers besides the specified pointer,
        /// this function succeeds and returns only the information for the specified pointer.
        /// If the information associated with the pointer frame is no longer available, this function fails with the last error set to <see cref="ERROR_NO_DATA"/>.
        /// If the calling thread does not own the window to which the pointer message has been delivered,
        /// this function fails with the last error set to <see cref="ERROR_ACCESS_DENIED"/>.
        /// If the specified pointer is not of type <see cref="PT_PEN"/>, this function fails with the last error set to <see cref="ERROR_DATATYPE_MISMATCH"/>.
        /// For apps that have both client and non-client areas, the input frame can include both client and non-client data.
        /// To differentiate between client and non-client data, you must perform hit testing on the target window.
        /// We recommend the following if you want to filter data from the input frame:
        /// For each update that does not include a pointer contact (a <see cref="POINTER_FLAG_UPDATE"/> without <see cref="POINTER_FLAG_INCONTACT"/>),
        /// hit test to determine if the input is client or non-client.
        /// For each new contact (<see cref="POINTER_FLAG_DOWN"/>), hit test to determine if the input is client or non-client and track this info.
        /// For each update that includes a pointer contact (a <see cref="POINTER_FLAG_UPDATE"/> with <see cref="POINTER_FLAG_INCONTACT"/>),
        /// use the tracking info to determine whether the input is client or non-client.
        /// For each <see cref="POINTER_FLAG_UP"/>, use the tracking info to determine
        /// whether the input is client or non-client and then clear this pointer from the tracking data.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerFramePenInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerFramePenInfo([In] UINT32 pointerId, [In][Out] ref UINT32 pointerCount, [Out] POINTER_PEN_INFO[] penInfo);

        /// <summary>
        /// <para>
        /// Gets the entire frame of pen-based information (including coalesced input frames)
        /// for the specified pointers (of type <see cref="PT_PEN"/>) associated with the current message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerframepeninfohistory"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// The identifier of the pointer for which to retrieve frame information.
        /// </param>
        /// <param name="entriesCount">
        /// A pointer to a variable that specifies the count of rows in the two-dimensional array to which penInfo points.
        /// If <see cref="GetPointerFramePenInfoHistory"/> succeeds,
        /// <paramref name="entriesCount"/> is updated with the total count of frames available in the history.
        /// </param>
        /// <param name="pointerCount">
        /// A pointer to a variable that specifies the count of columns in the two-dimensional array to which penInfo points.
        /// If <see cref="GetPointerFramePenInfoHistory"/> succeeds, pointerCount is updated with the total count of pointers in each frame.
        /// </param>
        /// <param name="penInfo">
        /// Address of a two-dimensional array of <see cref="POINTER_PEN_INFO"/> structures to receive the pointer information.
        /// This parameter can be <see langword="null"/> if *<paramref name="entriesCount"/> and *<paramref name="pointerCount"/> are both zero.
        /// This array is interpreted as POINTER_PEN_INFO[*entriesCount][*pointerCount].
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Parallel-mode devices may report pointer input in frames, that is,
        /// they may report the state and position of all pointers from that device in a single input report to the system.
        /// Ideally, applications should view the entire frame as a single input unless the application-specific requirements dictate otherwise.
        /// The information returned by <see cref="GetPointerFramePenInfo"/> is associated with the most recent pointer (<see cref="PT_PEN"/>) message
        /// retrieved by the calling thread. When the next message is retrieved by the calling thread,
        /// the information associated with the previous message may no longer be available.
        /// If the application does not process pointer input messages as fast as they are generated,
        /// some messages may be coalesced into a <see cref="WM_POINTERUPDATE"/> message.
        /// Use <see cref="GetPointerFramePenInfoHistory"/> to retrieve the message history (including coalesced input frames)
        /// from the most recent <see cref="WM_POINTERUPDATE"/> message.
        /// Having retrieved the entire frame of information, the application can then call the <see cref="SkipPointerFrameMessages"/> function
        /// to skip remaining pointer messages associated with this frame that are pending retrieval.
        /// This saves the application the overhead of retrieving and processing the remaining messages one by one.
        /// However, the <see cref="SkipPointerFrameMessages"/> function should be used with care
        /// and only when the caller can be sure that no other entity on the caller’s thread is expecting
        /// to see the remaining pointer messages one by one as they are retrieved.
        /// The frame contains only pointers that are currently owned by the same window as the specified pointer.
        /// The information retrieved represents a two-dimensional array with one row for each history entry and one column for each pointer in the frame.
        /// The information retrieved appears in reverse chronological order, with the most recent entry in the first row of the returned array.
        /// The most recent entry is the same as that returned by the <see cref="GetPointerFramePenInfo"/> function.
        /// If the count of rows in the buffer provided is insufficient to hold all available history entries,
        /// this function succeeds with the buffer containing the most recent entries and *<paramref name="entriesCount"/>
        /// containing the total count of entries available.
        /// If the pointer frame contains no additional pointers besides the specified pointer,
        /// this function succeeds and returns only the information for the specified pointer.
        /// If the information associated with the pointer frame is no longer available,
        /// this function fails with the last error set to <see cref="ERROR_NO_DATA"/>.
        /// If the calling thread does not own the window (where the input was originally delivered or where the message was forwarded)
        /// to which the pointer message has been delivered, this function fails with the last error set to <see cref="ERROR_ACCESS_DENIED"/>.
        /// If the specified pointer is not of type <see cref="PT_PEN"/>, this function fails with the last error set to <see cref="ERROR_DATATYPE_MISMATCH"/>.
        /// For apps that have both client and non-client areas, the input frame can include both client and non-client data.
        /// To differentiate between client and non-client data, you must perform hit testing on the target window.
        /// We recommend the following if you want to filter data from the input frame:
        /// For each update that does not include a pointer contact (a <see cref="POINTER_FLAG_UPDATE"/> without <see cref="POINTER_FLAG_INCONTACT"/>),
        /// hit test to determine if the input is client or non-client.
        /// For each new contact (<see cref="POINTER_FLAG_DOWN"/>), hit test to determine if the input is client or non-client and track this info.
        /// For each update that includes a pointer contact (a <see cref="POINTER_FLAG_UPDATE"/> with <see cref="POINTER_FLAG_INCONTACT"/>),
        /// use the tracking info to determine whether the input is client or non-client.
        /// For each <see cref="POINTER_FLAG_UP"/>, use the tracking info to determine
        /// whether the input is client or non-client and then clear this pointer from the tracking data.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerFramePenInfoHistory", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerFramePenInfoHistory([In] UINT32 pointerId, [In][Out] ref UINT32 entriesCount,
            [In][Out] ref UINT32 pointerCount, [Out] POINTER_PEN_INFO[] penInfo);

        /// <summary>
        /// <para>
        /// Gets the entire frame of pen-based information for the specified pointers (of type <see cref="PT_TOUCH"/>) associated with the current message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerframetouchinfo"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// An identifier of the pointer for which to retrieve frame information.
        /// </param>
        /// <param name="pointerCount">
        /// A pointer to a variable that specifies the count of structures in the buffer to which penInfo points.
        /// If <see cref="GetPointerFrameTouchInfo"/> succeeds, <paramref name="pointerCount"/> is updated with the total count of pointers in the frame.
        /// </param>
        /// <param name="touchInfo">
        /// Address of an array of <see cref="POINTER_TOUCH_INFO"/> structures to receive the pointer information.
        /// This parameter can be <see langword="null"/> if *<paramref name="pointerCount"/> is zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Parallel-mode devices may report pointer input in frames, that is,
        /// they may report the state and position of all pointers from that device in a single input report to the system.
        /// Ideally, applications should view the entire frame as a single input unless the application-specific requirements dictate otherwise.
        /// <see cref="GetPointerFrameTouchInfo"/> retrieves the entire pointer input frame associated with a pointer (of type <see cref="PT_TOUCH"/>) message.
        /// Use <see cref="GetPointerTouchInfo"/> to retrieve information for a single pointer associated with a pointer message.
        /// The frame contains only pointers that are currently owned by the same window as the specified pointer.
        /// The information returned by <see cref="GetPointerFrameTouchInfo"/> is associated with the most recent pointer message retrieved by the calling thread.
        /// When the next message is retrieved by the calling thread, the information associated with the previous message may no longer be available.
        /// If the application does not process pointer input messages as fast as they are generated,
        /// some messages may be coalesced into a <see cref="WM_POINTERUPDATE"/> message.
        /// Use <see cref="GetPointerFrameTouchInfoHistory"/> to retrieve the message history from the most recent <see cref="WM_POINTERUPDATE"/> message.
        /// Having retrieved the entire frame of information, the application can then call the <see cref="SkipPointerFrameMessages"/> function
        /// to skip remaining pointer messages associated with this frame that are pending retrieval.
        /// This saves the application the overhead of retrieving and processing the remaining messages one by one.
        /// However, the <see cref="SkipPointerFrameMessages"/> function should be used with care and only when the caller can be sure
        /// that no other entity on the caller’s thread is expecting to see the remaining pointer messages one by one as they are retrieved.
        /// Note that the information retrieved is associated with the pointer frame most recently retrieved by the calling thread.
        /// Once the calling thread retrieves its next message, the information associated with the previous pointer frame may no longer be available.
        /// If the pointer frame contains no additional pointers besides the specified pointer,
        /// this function succeeds and returns only the information for the specified pointer.
        /// If the information associated with the pointer frame is no longer available, this function fails with the last error set to <see cref="ERROR_NO_DATA"/>.
        /// If the calling thread does not own the window to which the pointer message has been delivered,
        /// this function fails with the last error set to <see cref="ERROR_ACCESS_DENIED"/>.
        /// If the specified pointer is not of type <see cref="PT_TOUCH"/>, this function fails with the last error set to <see cref="ERROR_DATATYPE_MISMATCH"/>.
        /// For apps that have both client and non-client areas, the input frame can include both client and non-client data.
        /// To differentiate between client and non-client data, you must perform hit testing on the target window.
        /// We recommend the following if you want to filter data from the input frame:
        /// For each update that does not include a pointer contact (a <see cref="POINTER_FLAG_UPDATE"/> without <see cref="POINTER_FLAG_INCONTACT"/>),
        /// hit test to determine if the input is client or non-client.
        /// For each new contact (<see cref="POINTER_FLAG_DOWN"/>), hit test to determine if the input is client or non-client and track this info.
        /// For each update that includes a pointer contact (a <see cref="POINTER_FLAG_UPDATE"/> with <see cref="POINTER_FLAG_INCONTACT"/>),
        /// use the tracking info to determine whether the input is client or non-client.
        /// For each <see cref="POINTER_FLAG_UP"/>, use the tracking info to determine
        /// whether the input is client or non-client and then clear this pointer from the tracking data.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerFrameTouchInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerFrameTouchInfo([In] UINT32 pointerId, [In][Out] ref UINT32 pointerCount, [Out] POINTER_TOUCH_INFO[] touchInfo);

        /// <summary>
        /// <para>
        /// Gets the entire frame of pen-based information (including coalesced input frames)
        /// for the specified pointers (of type <see cref="PT_TOUCH"/>) associated with the current message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerframetouchinfohistory"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// The identifier of the pointer for which to retrieve frame information.
        /// </param>
        /// <param name="entriesCount">
        /// A pointer to a variable that specifies the count of rows in the two-dimensional array to which penInfo points.
        /// If <see cref="GetPointerFrameTouchInfoHistory"/> succeeds,
        /// <paramref name="entriesCount"/> is updated with the total count of frames available in the history.
        /// </param>
        /// <param name="pointerCount">
        /// A pointer to a variable that specifies the count of columns in the two-dimensional array to which penInfo points.
        /// If <see cref="GetPointerFrameTouchInfoHistory"/> succeeds, pointerCount is updated with the total count of pointers in each frame.
        /// </param>
        /// <param name="touchInfo">
        /// Address of a two-dimensional array of <see cref="POINTER_TOUCH_INFO"/> structures to receive the pointer information.
        /// This parameter can be <see langword="null"/> if *<paramref name="entriesCount"/> and *<paramref name="pointerCount"/> are both zero.
        /// This array is interpreted as POINTER_TOUCH_INFO[*entriesCount][*pointerCount].
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Parallel-mode devices may report pointer input in frames, that is,
        /// they may report the state and position of all pointers from that device in a single input report to the system.
        /// Ideally, applications should view the entire frame as a single input unless the application-specific requirements dictate otherwise.
        /// The information returned by <see cref="GetPointerFrameTouchInfo"/> is associated with the most recent pointer (<see cref="PT_TOUCH"/>) message
        /// retrieved by the calling thread. When the next message is retrieved by the calling thread,
        /// the information associated with the previous message may no longer be available.
        /// If the application does not process pointer input messages as fast as they are generated,
        /// some messages may be coalesced into a <see cref="WM_POINTERUPDATE"/> message.
        /// Use <see cref="GetPointerFramePenInfoHistory"/> to retrieve the message history (including coalesced input frames)
        /// from the most recent <see cref="WM_POINTERUPDATE"/> message.
        /// Having retrieved the entire frame of information, the application can then call the <see cref="SkipPointerFrameMessages"/> function
        /// to skip remaining pointer messages associated with this frame that are pending retrieval.
        /// This saves the application the overhead of retrieving and processing the remaining messages one by one.
        /// However, the <see cref="SkipPointerFrameMessages"/> function should be used with care
        /// and only when the caller can be sure that no other entity on the caller’s thread is expecting
        /// to see the remaining pointer messages one by one as they are retrieved.
        /// The frame contains only pointers that are currently owned by the same window as the specified pointer.
        /// The information retrieved represents a two-dimensional array with one row for each history entry and one column for each pointer in the frame.
        /// The information retrieved appears in reverse chronological order, with the most recent entry in the first row of the returned array.
        /// The most recent entry is the same as that returned by the <see cref="GetPointerFrameTouchInfo"/> function.
        /// If the count of rows in the buffer provided is insufficient to hold all available history entries,
        /// this function succeeds with the buffer containing the most recent entries and *<paramref name="entriesCount"/>
        /// containing the total count of entries available.
        /// If the pointer frame contains no additional pointers besides the specified pointer,
        /// this function succeeds and returns only the information for the specified pointer.
        /// If the information associated with the pointer frame is no longer available,
        /// this function fails with the last error set to <see cref="ERROR_NO_DATA"/>.
        /// If the calling thread does not own the window (where the input was originally delivered or where the message was forwarded)
        /// to which the pointer message has been delivered, this function fails with the last error set to <see cref="ERROR_ACCESS_DENIED"/>.
        /// If the specified pointer is not of type <see cref="PT_TOUCH"/>, this function fails with the last error set to <see cref="ERROR_DATATYPE_MISMATCH"/>.
        /// For apps that have both client and non-client areas, the input frame can include both client and non-client data.
        /// To differentiate between client and non-client data, you must perform hit testing on the target window.
        /// We recommend the following if you want to filter data from the input frame:
        /// For each update that does not include a pointer contact (a <see cref="POINTER_FLAG_UPDATE"/> without <see cref="POINTER_FLAG_INCONTACT"/>),
        /// hit test to determine if the input is client or non-client.
        /// For each new contact (<see cref="POINTER_FLAG_DOWN"/>), hit test to determine if the input is client or non-client and track this info.
        /// For each update that includes a pointer contact (a <see cref="POINTER_FLAG_UPDATE"/> with <see cref="POINTER_FLAG_INCONTACT"/>),
        /// use the tracking info to determine whether the input is client or non-client.
        /// For each <see cref="POINTER_FLAG_UP"/>, use the tracking info to determine
        /// whether the input is client or non-client and then clear this pointer from the tracking data.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerFrameTouchInfoHistory", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerFrameTouchInfoHistory([In] UINT32 pointerId, [In][Out] ref UINT32 entriesCount,
            [In][Out] ref UINT32 pointerCount, [Out] POINTER_TOUCH_INFO[] touchInfo);

        /// <summary>
        /// <para>
        /// Gets the information for the specified pointer associated with the current message.
        /// Note
        /// Use <see cref="GetPointerType"/> if you don't need the additional information exposed by <see cref="GetPointerInfo"/>.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/Winuser/nf-winuser-getpointerinfo"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// The pointer identifier.
        /// </param>
        /// <param name="pointerInfo">
        /// Address of a <see cref="POINTER_INFO"/> structure that receives the pointer information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="GetPointerInfo"/> retrieves information for a single pointer associated with a pointer message.
        /// Use <see cref="GetPointerFrameInfo"/> to retrieve frame information associated with a message for a set of pointers.
        /// The information returned by <see cref="GetPointerInfo"/> is associated with the most recent pointer message retrieved by the calling thread.
        /// When the next message is retrieved by the calling thread, the information associated with the previous message may no longer be available.
        /// If the application does not process pointer input messages as fast as they are generated,
        /// some messages may be coalesced into a <see cref="WM_POINTERUPDATE"/> message.
        /// Use <see cref="GetPointerInfoHistory"/> to retrieve the message history from the most recent <see cref="WM_POINTERUPDATE"/> message.
        /// If the information associated with the message is no longer available, this function fails with the last error set to <see cref="ERROR_NO_DATA"/>.
        /// If the calling thread does not own the window to which the pointer message has been delivered,
        /// this function fails with the last error set to <see cref="ERROR_ACCESS_DENIED"/>.
        /// Note that this may be the window to which the input was originally delivered or it may be a window to which the message was forwarded.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerInfo([In] UINT32 pointerId, [Out] out POINTER_INFO pointerInfo);

        /// <summary>
        /// <para>
        /// Gets the information associated with the individual inputs, if any,
        /// that were coalesced into the current message for the specified pointer.
        /// The most recent input is included in the returned history and
        /// is the same as the most recent input returned by the <see cref="GetPointerInfo"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerinfohistory"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// An identifier of the pointer for which to retrieve information.
        /// </param>
        /// <param name="entriesCount">
        /// A pointer to a variable that specifies the count of structures in the buffer to which pointerInfo points.
        /// If <see cref="GetPointerInfoHistory"/> succeeds, <paramref name="entriesCount"/> is updated with the total count of structures available.
        /// The total count of structures available is the same as the <see cref="POINTER_INFO.historyCount"/> field
        /// of the <see cref="POINTER_INFO"/> structure returned by a call to <see cref="GetPointerInfo"/>.
        /// </param>
        /// <param name="pointerInfo">
        /// Address of an array of <see cref="POINTER_INFO"/> structures to receive the pointer information.
        /// This parameter can be <see langword="null"/> if *<paramref name="entriesCount"/> is zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the application does not process pointer input messages as fast as they are generated, some moves may be coalesced.
        /// When an application receives a coalescable pointer message,
        /// it can use the <see cref="GetPointerInfoHistory"/> function to retrieve information for all the individual inputs,
        /// if any, that were coalesced into the message.
        /// Note that the information retrieved is associated with the pointer message most recently retrieved by the calling thread.
        /// Once the calling thread retrieves its next message, the information associated with the previous message may no longer be available.
        /// The information retrieved appears in reverse chronological order,
        /// with the most recent entry in the first row of the returned array.
        /// The most recent entry is the same as that returned by the <see cref="GetPointerInfo"/> function.
        /// If the count of rows in the buffer provided is insufficient to hold all available history entries,
        /// this function succeeds with the buffer containing the most recent entries
        /// and *<paramref name="entriesCount"/> containing the total count of entries available.
        /// If the pointer frame contains no additional pointers besides the specified pointer,
        /// this function succeeds and returns only the information for the specified pointer.
        /// If the information associated with the pointer frame is no longer available,
        /// this function fails with the last error set to <see cref="ERROR_NO_DATA"/>.
        /// If the calling thread does not own the window (where the input was originally delivered or where the message was forwarded)
        /// to which the pointer message has been delivered, this function fails with the last error set to <see cref="ERROR_ACCESS_DENIED"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerInfoHistory", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerInfoHistory([In] UINT32 pointerId, [In][Out] ref UINT32 entriesCount, [Out] POINTER_INFO[] pointerInfo);

        /// <summary>
        /// <para>
        /// Gets one or more transforms for the pointer information coordinates associated with the current message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerinputtransform"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// An identifier of the pointer for which to retrieve information.
        /// </param>
        /// <param name="historyCount">
        /// The number of <see cref="INPUT_TRANSFORM"/> structures that <paramref name="inputTransform"/> can point to.
        /// This value must be no less than 1 and no greater than the value specified in <see cref="POINTER_INFO.historyCount"/>
        /// of the <see cref="POINTER_INFO"/> structure returned by <see cref="GetPointerInfo"/>, <see cref="GetPointerTouchInfo"/>,
        /// or <see cref="GetPointerPenInfo"/> (for a single input transform) or <see cref="GetPointerInfoHistory"/>,
        /// <see cref="GetPointerTouchInfoHistory"/>, or <see cref="GetPointerPenInfoHistory"/> (for an array of input transforms).
        /// </param>
        /// <param name="inputTransform">
        /// Address of an array of <see cref="INPUT_TRANSFORM"/> structures to receive the transform information.
        /// This parameter cannot be <see langword="null"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// A consumer of pointer input messages typically uses <see cref="ScreenToClient"/> or <see cref="MapWindowPoints"/>
        /// to convert screen coordinates to client coordinates.
        /// If a transform is applied on the message consumer, use <see cref="GetPointerInputTransform"/> to retrieve
        /// the transform on the message consumer at the time the input occurred.
        /// The inverse of this transform can then be used to convert pointer input coordinates
        /// from screen coordinates to the client coordinates of the message consumer.
        /// If an input transform is not associated with the input,
        /// the <see cref="GetPointerInputTransform"/> function fails with the last error set to <see cref="ERROR_NO_DATA"/>.
        /// Use <see cref="ScreenToClient"/> or <see cref="MapWindowPoints"/> instead.
        /// The input transform does not respect any right-to-left layout setting on the input target.
        /// An application that requires adjusted coordinates for right-to-left layout must perform the right-to-left mirroring
        /// or combine an appropriate mirroring transform with the input transform.
        /// The information returned by <see cref="GetPointerInputTransform"/> is associated with the most recent pointer message retrieved by the calling thread.
        /// When the next message is retrieved by the calling thread, the information associated with the previous message might no longer be available.
        /// If an application calls <see cref="GetPointerInfo"/>, it can call <see cref="GetPointerInputTransform"/> with the same pointer Id
        /// and a single <see cref="INPUT_TRANSFORM"/> output buffer to get the input transform associated with the data.
        /// If an application calls <see cref="GetPointerFrameInfo"/>, it can call <see cref="GetPointerInputTransform"/> with the same pointer Id
        /// and a single <see cref="INPUT_TRANSFORM"/> output buffer to get the input transform associated with the data.
        /// The same input transform applies to the entire frame.
        /// If an application calls <see cref="GetPointerInfoHistory"/>, it can call <see cref="GetPointerInputTransform"/> with the same pointer Id
        /// and an output buffer to hold the entries retrieved using <see cref="GetPointerInfoHistory"/>.
        /// Each input transform in the returned array can be used with the corresponding entry in the array returned by <see cref="GetPointerInfoHistory"/>.
        /// If an application calls <see cref="GetPointerFrameInfoHistory"/>, it can call <see cref="GetPointerInputTransform"/> with the same pointer Id
        /// and an output buffer to hold the entries retrieved using <see cref="GetPointerInfoHistory"/>.
        /// Each input transform in the returned array can be used with the corresponding frame in the array returned by <see cref="GetPointerFrameInfoHistory"/>,
        /// with the same input transform being applied to the entire frame.
        /// If the information associated with the message is no longer available,
        /// this function fails with the last error set to <see cref="ERROR_INVALID_PARAMETER"/>.
        /// If <paramref name="historyCount"/> contains a value larger than the <see cref="POINTER_INFO.historyCount"/> field
        /// of the <see cref="POINTER_INFO"/> structure returned by <see cref="GetPointerInfo"/>
        /// (or the first <see cref="POINTER_INFO"/> structure in the array returned by <see cref="GetPointerInfoHistory"/>),
        /// the function fails with the last error set to <see cref="ERROR_INVALID_PARAMETER"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8_1)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerInputTransform", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerInputTransform([In] UINT32 pointerId, [In] UINT32 historyCount, [Out] INPUT_TRANSFORM[] inputTransform);

        /// <summary>
        /// <para>
        /// Gets the pen-based information for the specified pointer (of type <see cref="PT_PEN"/>) associated with the current message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerpeninfo"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// An identifier of the pointer for which to retrieve information.
        /// </param>
        /// <param name="penInfo">
        /// Address of a <see cref="POINTER_PEN_INFO"/> structure to receive the pen-specific pointer information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="GetPointerPenInfo"/> retrieves information for a single pointer (of type <see cref="PT_PEN"/>) associated with a pointer message.
        /// Use <see cref="GetPointerFramePenInfo"/> to retrieve frame information associated with a message for a set of pointers.
        /// The information returned by <see cref="GetPointerInfo"/> is associated with the most recent pointer message retrieved by the calling thread.
        /// When the next message is retrieved by the calling thread, the information associated with the previous message may no longer be available.
        /// If the application does not process pointer input messages as fast as they are generated,
        /// some messages may be coalesced into a <see cref="WM_POINTERUPDATE"/> message.
        /// Use <see cref="GetPointerPenInfoHistory"/> to retrieve the message history from the most recent <see cref="WM_POINTERUPDATE"/> message.
        /// If the information associated with the message is no longer available,
        /// this function fails with the last error set to <see cref="ERROR_NO_DATA"/>.
        /// If the calling thread does not own the window to which the pointer message has been delivered,
        /// this function fails with the last error set to <see cref="ERROR_ACCESS_DENIED"/>.
        /// Note that this may be the window to which the input was originally delivered or it may be a window to which the message was forwarded.
        /// If the specified pointer is not of type <see cref="PT_PEN"/>, this function fails with the last error set to <see cref="ERROR_DATATYPE_MISMATCH"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerPenInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerPenInfo([In] UINT32 pointerId, [Out] out POINTER_PEN_INFO penInfo);

        /// <summary>
        /// <para>
        /// Gets the pen-based information associated with the individual inputs,
        /// if any, that were coalesced into the current message for the specified pointer (of type <see cref="PT_PEN"/>).
        /// The most recent input is included in the returned history and
        /// is the same as the most recent input returned by the <see cref="GetPointerPenInfo"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointerpeninfohistory"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// An identifier of the pointer for which to retrieve information.
        /// </param>
        /// <param name="entriesCount">
        /// A pointer to a variable that specifies the count of structures in the buffer to which <paramref name="penInfo"/> points.
        /// If <see cref="GetPointerPenInfoHistory"/> succeeds, <paramref name="entriesCount"/> is updated with the total count of structures available.
        /// The total count of structures available is the same as the <see cref="POINTER_INFO.historyCount"/> field
        /// in the <see cref="POINTER_PEN_INFO"/> structure returned by a call to <see cref="GetPointerPenInfo"/>.
        /// </param>
        /// <param name="penInfo">
        /// Address of an array of <see cref="POINTER_PEN_INFO"/> structures to receive the pointer information.
        /// This parameter can be <see langword="null"/> if *<paramref name="entriesCount"/> is zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the application does not process pointer input messages as fast as they are generated, some moves may be coalesced.
        /// When an application receives a coalescable pointer (of type <see cref="PT_PEN"/>) message,
        /// it can use the <see cref="GetPointerPenInfoHistory"/> function to retrieve information for all the individual inputs,
        /// if any, that were coalesced into the message.
        /// Note that the information retrieved is associated with the pointer message most recently retrieved by the calling thread.
        /// Once the calling thread retrieves its next message, the information associated with the previous message may no longer be available.
        /// The information retrieved appears in reverse chronological order, with the most recent entry in the first row of the returned array.
        /// The most recent entry is the same as that returned by the <see cref="GetPointerPenInfo"/> function.
        /// If the count of rows in the buffer provided is insufficient to hold all available history entries,
        /// this function succeeds with the buffer containing the most recent entries
        /// and *<paramref name="entriesCount"/> containing the total count of entries available.
        /// If the pointer frame contains no additional pointers besides the specified pointer,
        /// this function succeeds and returns only the information for the specified pointer.
        /// If the information associated with the pointer frame is no longer available,
        /// this function fails with the last error set to <see cref="ERROR_NO_DATA"/>.
        /// If the calling thread does not own the window (where the input was originally delivered or where the message was forwarded)
        /// to which the pointer message has been delivered, this function fails with the last error set to <see cref="ERROR_ACCESS_DENIED"/>.
        /// If the specified pointer is not of type <see cref="PT_PEN"/>,
        /// this function fails with the last error set to <see cref="ERROR_DATATYPE_MISMATCH"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerPenInfoHistory", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerPenInfoHistory([In] UINT32 pointerId, [In][Out] ref UINT32 entriesCount, [Out] POINTER_PEN_INFO[] penInfo);

        /// <summary>
        /// <para>
        /// Gets the touch-based information for the specified pointer (of type <see cref="PT_TOUCH"/>) associated with the current message.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointertouchinfo"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// An identifier of the pointer for which to retrieve information.
        /// </param>
        /// <param name="touchInfo">
        /// Address of a <see cref="POINTER_TOUCH_INFO"/> structure to receive the touch-specific pointer information.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// <see cref="GetPointerTouchInfo"/> retrieves information for a single pointer (of type <see cref="PT_TOUCH"/>) associated with a pointer message.
        /// Use <see cref="GetPointerFrameTouchInfo"/> to retrieve frame information associated with a message for a set of pointers.
        /// The information returned by <see cref="GetPointerTouchInfo"/> is associated with the most recent pointer message retrieved by the calling thread.
        /// When the next message is retrieved by the calling thread, the information associated with the previous message may no longer be available.
        /// If the application does not process pointer input messages as fast as they are generated,
        /// some messages may be coalesced into a <see cref="WM_POINTERUPDATE"/> message.
        /// Use <see cref="GetPointerTouchInfoHistory"/> to retrieve the message history from the most recent <see cref="WM_POINTERUPDATE"/> message.
        /// If the information associated with the message is no longer available,
        /// this function fails with the last error set to <see cref="ERROR_NO_DATA"/>.
        /// If the calling thread does not own the window to which the pointer message has been delivered,
        /// this function fails with the last error set to <see cref="ERROR_ACCESS_DENIED"/>.
        /// Note that this may be the window to which the input was originally delivered or it may be a window to which the message was forwarded.
        /// If the specified pointer is not of type <see cref="PT_TOUCH"/>, this function fails with the last error set to <see cref="ERROR_DATATYPE_MISMATCH"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerTouchInfo", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerTouchInfo([In] UINT32 pointerId, [Out] out POINTER_TOUCH_INFO touchInfo);

        /// <summary>
        /// <para>
        /// Gets the touch-based information associated with the individual inputs,
        /// if any, that were coalesced into the current message for the specified pointer (of type <see cref="PT_TOUCH"/>).
        /// The most recent input is included in the returned history and
        /// is the same as the most recent input returned by the <see cref="GetPointerTouchInfo"/> function.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointertouchinfohistory"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// An identifier of the pointer for which to retrieve information.
        /// </param>
        /// <param name="entriesCount">
        /// A pointer to a variable that specifies the count of structures in the buffer to which <paramref name="touchInfo"/> points.
        /// If <see cref="GetPointerTouchInfoHistory"/> succeeds, <paramref name="entriesCount"/> is updated with the total count of structures available.
        /// The total count of structures available is the same as the <see cref="POINTER_INFO.historyCount"/> field
        /// in the <see cref="POINTER_TOUCH_INFO"/> structure returned by a call to <see cref="GetPointerInfo"/> or <see cref="GetPointerTouchInfo"/>.
        /// </param>
        /// <param name="touchInfo">
        /// Address of an array of <see cref="POINTER_TOUCH_INFO"/> structures to receive the pointer information.
        /// This parameter can be <see langword="null"/> if *<paramref name="entriesCount"/> is zero.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// If the application does not process pointer input messages as fast as they are generated, some moves may be coalesced.
        /// When an application receives a coalescable pointer (of type <see cref="PT_TOUCH"/>) message,
        /// it can use the <see cref="GetPointerTouchInfoHistory"/> function to retrieve information for all the individual inputs,
        /// if any, that were coalesced into the message.
        /// Note that the information retrieved is associated with the pointer message most recently retrieved by the calling thread.
        /// Once the calling thread retrieves its next message, the information associated with the previous message may no longer be available.
        /// The information retrieved appears in reverse chronological order, with the most recent entry in the first row of the returned array.
        /// The most recent entry is the same as that returned by the <see cref="GetPointerTouchInfo"/> function.
        /// If the count of rows in the buffer provided is insufficient to hold all available history entries,
        /// this function succeeds with the buffer containing the most recent entries
        /// and *<paramref name="entriesCount"/> containing the total count of entries available.
        /// If the pointer frame contains no additional pointers besides the specified pointer,
        /// this function succeeds and returns only the information for the specified pointer.
        /// If the information associated with the pointer frame is no longer available,
        /// this function fails with the last error set to <see cref="ERROR_NO_DATA"/>.
        /// If the calling thread does not own the window (where the input was originally delivered or where the message was forwarded)
        /// to which the pointer message has been delivered, this function fails with the last error set to <see cref="ERROR_ACCESS_DENIED"/>.
        /// If the specified pointer is not of type <see cref="PT_TOUCH"/>,
        /// this function fails with the last error set to <see cref="ERROR_DATATYPE_MISMATCH"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerTouchInfoHistory", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerTouchInfoHistory([In] UINT32 pointerId, [In][Out] ref UINT32 entriesCount, [Out] POINTER_TOUCH_INFO[] touchInfo);

        /// <summary>
        /// <para>
        /// Retrieves the pointer type for a specified pointer.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getpointertype"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// An identifier of the pointer for which to retrieve pointer type.
        /// </param>
        /// <param name="pointerType">
        /// An address of a <see cref="POINTER_INPUT_TYPE"/> type to receive a pointer input type.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// An application can use the <see cref="GetPointerType"/> function to determine the pointer type
        /// if it wishes to react differently to pointers of different types.
        /// Note
        /// This function will never return with the generic <see cref="PT_POINTER"/> type.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetPointerType", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetPointerType([In] UINT32 pointerId, [Out] out POINTER_INPUT_TYPE pointerType);

        /// <summary>
        /// <para>
        /// Gets the raw input data from the pointer device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getrawpointerdevicedata"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// An identifier of the pointer for which to retrieve information.
        /// </param>
        /// <param name="historyCount">
        /// The pointer history.
        /// </param>
        /// <param name="propertiesCount">
        /// Number of properties to retrieve.
        /// </param>
        /// <param name="pProperties">
        /// Array of <see cref="POINTER_DEVICE_PROPERTY"/> structures that contain raw data reported by the device.
        /// </param>
        /// <param name="pValues">
        /// The values for <paramref name="pProperties"/>.
        /// </param>
        /// <returns>
        /// <see cref="TRUE"/> if the function succeeds; otherwise, <see cref="FALSE"/>.
        /// If the function fails, call the <see cref="GetLastError"/> function for more information.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetRawPointerDeviceData", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetRawPointerDeviceData([In] UINT32 pointerId, [In] UINT32 historyCount, [In] UINT32 propertiesCount,
            [In] POINTER_DEVICE_PROPERTY[] pProperties, [Out] LONG[] pValues);

        /// <summary>
        /// <para>
        /// Gets pointer data before it has gone through touch prediction processing.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-getunpredictedmessagepos"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// The screen location of the pointer input.
        /// </returns>
        /// <remarks>
        /// By default, touch prediction is activated.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetUnpredictedMessagePos", ExactSpelling = true, SetLastError = true)]
        public static extern DWORD GetUnpredictedMessagePos();

        /// <summary>
        /// <para>
        /// Indicates whether <see cref="EnableMouseInPointer"/> is set for the mouse to act as a pointer input device
        /// and send <see cref="WM_POINTER"/> messages.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-ismouseinpointerenabled"/>
        /// </para>
        /// </summary>
        /// <returns>
        /// If <see cref="EnableMouseInPointer"/> is set, the return value is nonzero.
        /// If <see cref="EnableMouseInPointer"/> is not set, the return value is zero.
        /// </returns>
        /// <remarks>
        /// <see cref="EnableMouseInPointer"/> can be called only once in the context of a process lifetime.
        /// Prior to the first call, Windows Store apps run with mouse-in-pointer enabled, as do any desktop applications that consume mshtml.dll.
        /// All other desktop applications run with mouse-in-pointer disabled.
        /// On the first call to <see cref="EnableMouseInPointer"/> in the process lifetime, the state is changed as specified and the call succeeds.
        /// On subsequent calls to <see cref="EnableMouseInPointer"/>, the state will not change.
        /// If the current state is not equal to the specified state, the call fails.
        /// Call <see cref="IsMouseInPointerEnabled"/> to verify the mouse-in-pointer state.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "IsMouseInPointerEnabled", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL IsMouseInPointerEnabled();

        /// <summary>
        /// <para>
        /// Registers a window to process the <see cref="WM_POINTERDEVICECHANGE"/>, <see cref="WM_POINTERDEVICECHANGE"/>,
        /// and <see cref="WM_POINTERDEVICEOUTOFRANGE"/> pointer device notifications.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-registerpointerdevicenotifications"/>
        /// </para>
        /// </summary>
        /// <param name="window">
        /// The window that receives <see cref="WM_POINTERDEVICECHANGE"/>, <see cref="WM_POINTERDEVICEINRANGE"/>,
        /// and <see cref="WM_POINTERDEVICEOUTOFRANGE"/> notifications.
        /// </param>
        /// <param name="notifyRange">
        /// If set to <see cref="TRUE"/>, process the <see cref="WM_POINTERDEVICEINRANGE"/> and <see cref="WM_POINTERDEVICEOUTOFRANGE"/> messages.
        /// If set to <see cref="FALSE"/>, these messages aren't processed.
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="TRUE"/>.
        /// Otherwise, it returns <see cref="FALSE"/>.
        /// To retrieve extended error information, call the <see cref="GetLastError"/> function.
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "RegisterPointerDeviceNotifications", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL RegisterPointerDeviceNotifications([In] HWND window, [In] BOOL notifyRange);

        /// <summary>
        /// <para>
        /// Determines which pointer input frame generated the most recently retrieved message for the specified pointer
        /// and discards any queued (unretrieved) pointer input messages generated from the same pointer input frame.
        /// If an application has retrieved information for an entire frame using the <see cref="GetPointerFrameInfo"/> function,
        /// the <see cref="GetPointerFrameInfoHistory"/> function or one of their type-specific variants,
        /// it can use this function to avoid retrieving and discarding remaining messages from that frame one by one.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-skippointerframemessages"/>
        /// </para>
        /// </summary>
        /// <param name="pointerId">
        /// Identifier of the pointer.
        /// Pending messages will be skipped for the frame that includes the most recently retrieved input for this pointer.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is non-zero.
        /// If the function fails, the return value is zero.
        /// To get extended error information, call <see cref="GetLastError"/>.
        /// </returns>
        /// <remarks>
        /// Parallel-mode devices may report pointer input in frames, that is,
        /// they may report the state and position of all pointers from that device in a single input report to the system.
        /// Ideally, applications should view the entire frame as a single input unless the application-specific requirements dictate otherwise.
        /// The <see cref="SkipPointerFrameMessages"/> function can be used in conjunction with the <see cref="GetPointerFrameInfo"/> function
        /// (or one of its type-specific variants) to consume entire frames as a single input.
        /// When an application sees a pointer message, it can use the <see cref="GetPointerFrameInfo"/> function
        /// to retrieve the entire pointer input frame to which the pointer message belongs,
        /// hence obtaining an updated view of all of the pointers currently owned by the window.
        /// Note that the returned frame contains only pointers that are currently owned by the same window as the specified pointer.
        /// Having retrieved the entire frame of information, the application can then call the <see cref="SkipPointerFrameMessages"/> function
        /// to skip remaining pointer messages associated with this frame that are pending retrieval.
        /// This saves the application the overhead of retrieving and processing the remaining messages one by one.
        /// Warning
        /// The <see cref="SkipPointerFrameMessages"/> function should be used only when the caller can be sure
        /// that no other entity on the caller’s thread (such as Direct Manipulation) is expecting to retrieve pending pointer messages.
        /// For this reason, <see cref="SkipPointerFrameMessages"/> should not be used
        /// in conjunction with Direct Manipulation when processing multiple, simultaneous interactions.
        /// Note that the information retrieved is associated with the pointer frame most recently retrieved by the calling thread.
        /// Once the calling thread retrieves its next message, the information associated with the previous pointer frame may no longer be available.
        /// If the pointer frame contains no additional pointers besides the specified pointer, this function succeeds with no action.
        /// If the calling thread does not own the window to which the pointer message has been delivered,
        /// this function fails with the last error set to <see cref="ERROR_ACCESS_DENIED"/>.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.Windows8)]
        [DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint = "SkipPointerFrameMessages", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL SkipPointerFrameMessages([In] UINT32 pointerId);
    }
}
