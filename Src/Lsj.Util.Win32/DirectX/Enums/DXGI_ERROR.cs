using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.ComInterfaces;
using static Lsj.Util.Win32.BaseTypes.BOOL;

namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// Error codes that can be returned by a DXGI function.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct3ddxgi/dxgi-error"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// You may be interested only in whether the method succeeded or failed.
    /// The best way to test whether an <see cref="HRESULT"/> value indicates success or failure is
    /// to pass the value to the one of the following macros, defined in WinError.h:
    /// The <see cref="SUCCEEDED"/> macro returns <see cref="TRUE"/> for a success code and <see cref="FALSE"/> for a failure code.
    /// The <see cref="FAILED"/> macro returns <see cref="TRUE"/> for a failure code and <see cref="FALSE"/> for a success code.
    /// The <see cref="HRESULT"/> value for each <see cref="DXGI_ERROR"/> value is determined from this macro that is defined in DXGItype.h:
    /// <code>
    /// #define _FACDXGI    0x87a
    /// #define MAKE_DXGI_HRESULT(code) MAKE_HRESULT(1, _FACDXGI, code)
    /// </code>
    /// For example, <see cref="DXGI_ERROR_INVALID_CALL"/> is defined as 0x887A0001:
    /// <code>
    /// #define DXGI_ERROR_INVALID_CALL                 MAKE_DXGI_HRESULT(1)
    /// </code>
    /// </remarks>
    public enum DXGI_ERROR : uint
    {
        /// <summary>
        /// You tried to use a resource to which you did not have the required access privileges.
        /// This error is most typically caused when you write to a shared resource with read-only access.
        /// </summary>
        DXGI_ERROR_ACCESS_DENIED = 0x887A002B,

        /// <summary>
        /// The desktop duplication interface is invalid.
        /// The desktop duplication interface typically becomes invalid when a different type of image is displayed on the desktop.
        /// </summary>
        DXGI_ERROR_ACCESS_LOST = 0x887A0026,

        /// <summary>
        /// The desired element already exists.
        /// This is returned by <see cref="DXGIDeclareAdapterRemovalSupport"/> if it is not the first time that the function is called.
        /// </summary>
        DXGI_ERROR_ALREADY_EXISTS = 0x887A0036,

        /// <summary>
        /// DXGI can't provide content protection on the swap chain.
        /// This error is typically caused by an older driver, or when you use a swap chain that is incompatible with content protection.
        /// </summary>
        DXGI_ERROR_CANNOT_PROTECT_CONTENT = 0x887A002A,

        /// <summary>
        /// The application's device failed due to badly formed commands sent by the application.
        /// This is an design-time issue that should be investigated and fixed.
        /// </summary>
        DXGI_ERROR_DEVICE_HUNG = 0x887A0006,

        /// <summary>
        /// The video card has been physically removed from the system, or a driver upgrade for the video card has occurred.
        /// The application should destroy and recreate the device.
        /// For help debugging the problem, call <see cref="ID3D10Device.GetDeviceRemovedReason"/>.
        /// </summary>
        DXGI_ERROR_DEVICE_REMOVED = 0x887A0005,

        /// <summary>
        /// The device failed due to a badly formed command.
        /// This is a run-time issue; The application should destroy and recreate the device.
        /// </summary>
        DXGI_ERROR_DEVICE_RESET = 0x887A0007,

        /// <summary>
        /// The driver encountered a problem and was put into the device removed state.
        /// </summary>
        DXGI_ERROR_DRIVER_INTERNAL_ERROR = 0x887A0020,

        /// <summary>
        /// An event (for example, a power cycle) interrupted the gathering of presentation statistics.
        /// </summary>
        DXGI_ERROR_FRAME_STATISTICS_DISJOINT = 0x887A000B,

        /// <summary>
        /// The application attempted to acquire exclusive ownership of an output,
        /// but failed because some other application (or device within the application) already acquired ownership.
        /// </summary>
        DXGI_ERROR_GRAPHICS_VIDPN_SOURCE_IN_USE = 0x887A000C,

        /// <summary>
        /// The application provided invalid parameter data; this must be debugged and fixed before the application is released.
        /// </summary>
        DXGI_ERROR_INVALID_CALL = 0x887A0001,

        /// <summary>
        /// The buffer supplied by the application is not big enough to hold the requested data.
        /// </summary>
        DXGI_ERROR_MORE_DATA = 0x887A0003,

        /// <summary>
        /// The supplied name of a resource in a call to <see cref="IDXGIResource1.CreateSharedHandle"/> is already associated with some other resource.
        /// </summary>
        DXGI_ERROR_NAME_ALREADY_EXISTS = 0x887A002C,

        /// <summary>
        /// A global counter resource is in use, and the Direct3D device can't currently use the counter resource.
        /// </summary>
        DXGI_ERROR_NONEXCLUSIVE = 0x887A0021,

        /// <summary>
        /// The resource or request is not currently available, but it might become available later.
        /// </summary>
        DXGI_ERROR_NOT_CURRENTLY_AVAILABLE = 0x887A0022,

        /// <summary>
        /// When calling <see cref="IDXGIObject.GetPrivateData"/>, the GUID passed in is not recognized
        /// as one previously passed to <see cref="IDXGIObject.SetPrivateData"/> or <see cref="IDXGIObject.SetPrivateDataInterface"/>.
        /// When calling <see cref="IDXGIFactory.EnumAdapters"/> or <see cref="IDXGIAdapter.EnumOutputs"/>, the enumerated ordinal is out of range.
        /// </summary>
        DXGI_ERROR_NOT_FOUND = 0x887A0002,

        /// <summary>
        /// Reserved
        /// </summary>
        DXGI_ERROR_REMOTE_CLIENT_DISCONNECTED = 0x887A0023,

        /// <summary>
        /// Reserved
        /// </summary>
        DXGI_ERROR_REMOTE_OUTOFMEMORY = 0x887A0024,

        /// <summary>
        /// The DXGI output (monitor) to which the swap chain content was restricted is now disconnected or changed.
        /// </summary>
        DXGI_ERROR_RESTRICT_TO_OUTPUT_STALE = 0x887A0029,

        /// <summary>
        /// The operation depends on an SDK component that is missing or mismatched.
        /// </summary>
        DXGI_ERROR_SDK_COMPONENT_MISSING = 0x887A002D,

        /// <summary>
        /// The Remote Desktop Services session is currently disconnected.
        /// </summary>
        DXGI_ERROR_SESSION_DISCONNECTED = 0x887A0028,

        /// <summary>
        /// The requested functionality is not supported by the device or the driver.
        /// </summary>
        DXGI_ERROR_UNSUPPORTED = 0x887A0004,

        /// <summary>
        /// The time-out interval elapsed before the next desktop frame was available.
        /// </summary>
        DXGI_ERROR_WAIT_TIMEOUT = 0x887A0027,

        /// <summary>
        /// The GPU was busy at the moment when a call was made to perform an operation, and did not execute or schedule the operation.
        /// </summary>
        DXGI_ERROR_WAS_STILL_DRAWING = 0x887A000A,
    }
}
