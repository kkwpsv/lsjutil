using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// Represents an adapter output (such as a monitor).
    /// The <see cref="IDXGIOutput6"/> interface exposes methods to provide specific monitor capabilities.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_6/nn-dxgi1_6-idxgioutput6"/>
    /// </para>
    /// </summary>
    public unsafe struct IDXGIOutput6
    {
        IntPtr* _vTable;

        /// <summary>
        /// Get an extended description of the output that includes color characteristics and connection type.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to the output description (see <see cref="DXGI_OUTPUT_DESC1"/>).
        /// </param>
        /// <returns>
        /// Returns a code that indicates success or failure.
        /// <see cref="S_OK"/> if successful, <see cref="DXGI_ERROR_INVALID_CALL"/> if <paramref name="pDesc"/> is passed in as <see cref="NullRef{DXGI_OUTPUT_DESC1}"/>.
        /// </returns>
        /// <remarks>
        /// Some scenarios do not have well-defined values for all fields in this struct.
        /// For example, if this <see cref="IDXGIOutput"/> represents a clone/duplicate set, or if the EDID has missing or invalid data.
        /// In these cases, the OS will provide some default values that correspond to a standard SDR display.
        /// An output's reported color and luminance characteristics can adjust dynamically
        /// while the system is running due to user action or changing ambient conditions.
        /// Therefore, apps should periodically query <see cref="IDXGIFactory1.IsCurrent"/>
        /// and re-create their <see cref="IDXGIFactory"/> if it returns <see cref="FALSE"/>.
        /// Then re-query <see cref="GetDesc1"/> from the new factory's equivalent output to retrieve the newest color information.
        /// For more details on how to write apps that react dynamically to monitor capabilities,
        /// see Using DirectX with high dynamic range displays and Advanced Color.
        /// On a high DPI desktop, <see cref="GetDesc1"/> returns the visualized screen size unless the app is marked high DPI aware.
        /// For info about writing DPI-aware Win32 apps, see High DPI.
        /// </remarks>
        public HRESULT GetDesc1([Out] out DXGI_OUTPUT_DESC1 pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_OUTPUT_DESC1, HRESULT>)_vTable[26])(thisPtr, out pDesc);
            }
        }

        /// <summary>
        /// Notifies applications that hardware stretching is supported.
        /// </summary>
        /// <param name="pFlags">
        /// A bitfield of <see cref="DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAGS"/> enumeration values describing
        /// which types of hardware composition are supported.
        /// The values are bitwise OR'd together.
        /// </param>
        /// <returns>
        /// Returns a code that indicates success or failure.
        /// </returns>
        public HRESULT CheckHardwareCompositionSupport([Out] DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAGS pFlags)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_HARDWARE_COMPOSITION_SUPPORT_FLAGS, HRESULT>)_vTable[27])(thisPtr, out pFlags);
            }
        }
    }
}
