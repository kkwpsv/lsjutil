using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ENUM_MODES;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_USAGE;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An <see cref="IDXGIOutput"/> interface represents an adapter output (such as a monitor).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nn-dxgi-idxgioutput"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To see the outputs available, use <see cref="IDXGIAdapter.EnumOutputs"/>.
    /// To see the specific output that the swap chain will update, use <see cref="IDXGISwapChain.GetContainingOutput"/>.
    /// </remarks>
    [ComInterface(IID = "ae02eedb-c735-4690-8d52-5a8dc20213aa", BeginVTableSlotIndex = 7, EndVTableSlotIndex = 18,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject)])]
    public unsafe struct IDXGIOutput
    {
        nint* _vTable;

        /// <summary>
        /// Get a description of the output.
        /// </summary>
        /// <param name="pDesc">
        /// A pointer to the output description (see <see cref="DXGI_OUTPUT_DESC"/>).
        /// </param>
        /// <returns>
        /// Returns a code that indicates success or failure.
        /// <see cref="S_OK"/> if successful, <see cref="DXGI_ERROR_INVALID_CALL"/>
        /// if <paramref name="pDesc"/> is passed in as <see cref="NullRef{DXGI_OUTPUT_DESC}"/>.
        /// </returns>
        /// <remarks>
        /// On a high DPI desktop, <see cref="GetDesc"/> returns the visualized screen
        /// size unless the app is marked high DPI aware.
        /// For info about writing DPI-aware Win32 apps, see High DPI.
        /// </remarks>
        public HRESULT GetDesc([Out] out DXGI_OUTPUT_DESC pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_OUTPUT_DESC, HRESULT>)_vTable[7])(thisPtr, out pDesc);
            }
        }

        /// <summary>
        /// <para>
        /// Gets the display modes that match the requested format and other input options.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-getdisplaymodelist"/>
        /// </para>
        /// </summary>
        /// <param name="EnumFormat">
        /// The color format (see <see cref="DXGI_FORMAT"/>).
        /// </param>
        /// <param name="Flags">
        /// Options for modes to include (see <see cref="DXGI_ENUM_MODES"/>).
        /// <see cref="DXGI_ENUM_MODES_SCALING"/> needs to be specified to expose the display modes that require scaling.
        /// Centered modes, requiring no scaling and corresponding directly to the display output, are enumerated by default.
        /// </param>
        /// <param name="pNumModes">
        /// Set <paramref name="pDesc"/> to <see langword="null"/>
        /// so that <paramref name="pNumModes"/> returns the number of display modes that match the format and the options.
        /// Otherwise, <paramref name="pNumModes"/> returns the number of display modes returned in <paramref name="pDesc"/>.
        /// </param>
        /// <param name="pDesc">
        /// A pointer to a list of display modes (see <see cref="DXGI_MODE_DESC"/>);
        /// set to <see langword="null"/> to get the number of display modes.
        /// </param>
        /// <returns>
        /// <para>
        /// Returns one of the following <see cref="DXGI_ERROR"/>.
        /// It is rare, but possible, that the display modes available can change immediately after calling this method,
        /// in which case <see cref="DXGI_ERROR_MORE_DATA"/> is returned (if there is not enough room for all the display modes).
        /// </para>
        /// <para>
        /// If <see cref="GetDisplayModeList"/> is called from a Remote Desktop Services session
        /// (formerly Terminal Services session), <see cref="DXGI_ERROR_NOT_CURRENTLY_AVAILABLE"/> is returned.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// In general, when switching from windowed to full-screen mode,
        /// a swap chain automatically chooses a display mode
        /// that meets (or exceeds) the resolution, color depth and refresh rate of the swap chain.
        /// To exercise more control over the display mode, use this API to poll the set of display modes
        /// that are validated against monitor capabilities, or all modes that match the desktop
        /// (if the desktop settings are not validated against the monitor).
        /// </para>
        /// <para>
        /// As shown, this API is designed to be called twice.
        /// First to get the number of modes available, and second to return a description of the modes.
        /// </para>
        /// <code>
        /// UINT num = 0;
        /// DXGI_FORMAT format = DXGI_FORMAT_R32G32B32A32_FLOAT;
        /// UINT flags         = DXGI_ENUM_MODES_INTERLACED;
        /// 
        /// pOutput->GetDisplayModeList( format, flags, &amp;num, 0);
        /// 
        /// ...
        /// 
        /// DXGI_MODE_DESC * pDescs = new DXGI_MODE_DESC[num];
        /// pOutput->GetDisplayModeList( format, flags, &amp;num, pDescs);
        /// </code>
        /// </remarks>
        [Obsolete("Starting with Direct3D 11.1, we recommend not to use GetDisplayModeList anymore to retrieve the matching display mode. " +
            "Instead, use IDXGIOutput1::GetDisplayModeList1, which supports stereo display mode")]
        public HRESULT GetDisplayModeList([In] DXGI_FORMAT EnumFormat, [In] DXGI_ENUM_MODES Flags, [In][Out] ref UINT pNumModes, [Out] DXGI_MODE_DESC[] pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_FORMAT, DXGI_ENUM_MODES, ref UINT, DXGI_MODE_DESC[], HRESULT>)_vTable[8])
                    (thisPtr, EnumFormat, Flags, ref pNumModes, pDesc);
            }
        }

        /// <summary>
        /// <para>
        /// Finds the display mode that most closely matches the requested display mode.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi/nf-dxgi-idxgioutput-findclosestmatchingmode"/>
        /// </para>
        /// </summary>
        /// <param name="pModeToMatch">
        /// The desired display mode (see <see cref="DXGI_MODE_DESC"/>).
        /// Members of <see cref="DXGI_MODE_DESC"/> can be unspecified indicating no preference for that member.
        /// A value of 0 for <see cref="DXGI_MODE_DESC.Width"/> or <see cref="DXGI_MODE_DESC.Height"/> indicates the value is unspecified.
        /// If either <see cref="DXGI_MODE_DESC.Width"/> or <see cref="DXGI_MODE_DESC.Height"/> are 0, both must be 0.
        /// A numerator and denominator of 0 in <see cref="DXGI_MODE_DESC.RefreshRate"/> indicate it is unspecified.
        /// Other members of <see cref="DXGI_MODE_DESC"/> have enumeration values indicating the member is unspecified.
        /// If <paramref name="pConcernedDevice"/> is <see cref="NULL"/>,
        /// <see cref="DXGI_MODE_DESC.Format"/> cannot be <see cref="DXGI_FORMAT_UNKNOWN"/>.
        /// </param>
        /// <param name="pClosestMatch">
        /// The mode that most closely matches <paramref name="pModeToMatch"/>.
        /// </param>
        /// <param name="pConcernedDevice">
        /// <para>
        /// A pointer to the Direct3D device interface.
        /// If this parameter is <see cref="NULL"/>,
        /// only modes whose format matches that of <paramref name="pClosestMatch"/> will be returned;
        /// otherwise, only those formats that are supported for scan-out by the device are returned.
        /// For info about the formats that are supported for scan-out by the device at each feature level:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// DXGI Format Support for Direct3D Feature Level 12.1 Hardware
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// DXGI Format Support for Direct3D Feature Level 12.0 Hardware
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// DXGI Format Support for Direct3D Feature Level 11.1 Hardware
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// DXGI Format Support for Direct3D Feature Level 11.0 Hardware
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Hardware Support for Direct3D 10Level9 Formats
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Hardware Support for Direct3D 10.1 Formats
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Hardware Support for Direct3D 10 Formats
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// Returns one of the following <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="FindClosestMatchingMode"/> behaves similarly to the <see cref="IDXGIOutput1.FindClosestMatchingMode1"/>
        /// except <see cref="FindClosestMatchingMode"/> considers only the mono display modes.
        /// <see cref="IDXGIOutput1.FindClosestMatchingMode1"/> considers only stereo modes
        /// if you set the <see cref="DXGI_MODE_DESC1.Stereo"/> member in the <see cref="DXGI_MODE_DESC1"/> structure
        /// that <paramref name="pModeToMatch"/> points to, and considers only mono modes if <see cref="DXGI_MODE_DESC1.Stereo"/> is not set.
        /// </para>
        /// <para>
        /// <see cref="IDXGIOutput1.FindClosestMatchingMode1"/> returns a matched display-mode set with only stereo modes or only mono modes.
        /// <see cref="FindClosestMatchingMode"/> behaves as though you specified the input mode as mono.
        /// </para>
        /// </remarks>
        public HRESULT FindClosestMatchingMode([In] in DXGI_MODE_DESC pModeToMatch, [Out] out DXGI_MODE_DESC pClosestMatch, [In] P<IUnknown> pConcernedDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in DXGI_MODE_DESC, out DXGI_MODE_DESC, P<IUnknown>, HRESULT>)_vTable[9])
                    (thisPtr, pModeToMatch, out pClosestMatch, pConcernedDevice);
            }
        }

        /// <summary>
        /// Halt a thread until the next vertical blank occurs.
        /// </summary>
        /// <returns>
        /// Returns one of the following <see cref="DXGI_ERROR"/>.
        /// </returns>
        /// <remarks>
        /// A vertical blank occurs when the raster moves from the lower right corner to the upper left corner to begin drawing the next frame.
        /// </remarks>
        public HRESULT WaitForVBlank()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[10])(thisPtr);
            }
        }

        /// <summary>
        /// Takes ownership of an output.
        /// </summary>
        /// <param name="pDevice">
        /// A pointer to the <see cref="IUnknown"/> interface of a device (such as an <see cref="ID3D10Device"/>).
        /// </param>
        /// <param name="Exclusive">
        /// Returns one of the <see cref="DXGI_ERROR"/> values.
        /// </param>
        /// <returns>
        /// <para>
        /// When you are finished with the output, call <see cref="ReleaseOwnership"/>.
        /// </para>
        /// <para>
        /// <see cref="TakeOwnership"/> should not be called directly by applications, since results will be unpredictable.
        /// It is called implicitly by the DXGI swap chain object during full-screen transitions,
        /// and should not be used as a substitute for swap-chain methods.
        /// </para>
        /// </returns>
        public HRESULT TakeOwnership([In] P<IUnknown> pDevice, [In] BOOL Exclusive)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IUnknown>, BOOL, HRESULT>)_vTable[11])(thisPtr, pDevice, Exclusive);
            }
        }

        /// <summary>
        /// Releases ownership of the output.
        /// </summary>
        /// <returns>
        /// If you are not using a swap chain, get access to an output by calling <see cref="TakeOwnership"/>
        /// and release it when you are finished by calling <see cref="ReleaseOwnership"/>.
        /// An application that uses a swap chain will typically not call either of these methods.
        /// </returns>
        public HRESULT ReleaseOwnership()
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, HRESULT>)_vTable[12])(thisPtr);
            }
        }

        /// <summary>
        /// Gets a description of the gamma-control capabilities.
        /// </summary>
        /// <param name="pGammaCaps">
        /// A pointer to a description of the gamma-control capabilities
        /// (see <see cref="DXGI_GAMMA_CONTROL_CAPABILITIES"/>).
        /// </param>
        /// <returns>
        /// Returns one of the <see cref="DXGI_ERROR"/> values.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Calling this method is only supported while in full-screen mode.
        /// </para>
        /// <para>
        /// For info about using gamma correction, see Using gamma correction.
        /// </para>
        /// </remarks>
        public HRESULT GetGammaControlCapabilities([Out] out DXGI_GAMMA_CONTROL_CAPABILITIES pGammaCaps)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_GAMMA_CONTROL_CAPABILITIES, HRESULT>)_vTable[13])(thisPtr, out pGammaCaps);
            }
        }

        /// <summary>
        /// Sets the gamma controls.
        /// </summary>
        /// <param name="pArray">
        /// A pointer to a <see cref="DXGI_GAMMA_CONTROL"/> structure that describes the gamma curve to set.
        /// </param>
        /// <returns>
        /// Returns one of the <see cref="DXGI_ERROR"/> values.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Calling this method is only supported while in full-screen mode.
        /// </para>
        /// <para>
        /// For info about using gamma correction, see Using gamma correction.
        /// </para>
        /// </remarks>
        public HRESULT SetGammaControl([In] DXGI_GAMMA_CONTROL[] pArray)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_GAMMA_CONTROL[], HRESULT>)_vTable[14])(thisPtr, pArray);
            }
        }

        /// <summary>
        /// Gets the gamma control settings.
        /// </summary>
        /// <param name="pArray">
        /// An array of gamma control settings (see <see cref="DXGI_GAMMA_CONTROL"/>).
        /// </param>
        /// <returns>
        /// Returns one of the <see cref="DXGI_ERROR"/> values.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Calling this method is only supported while in full-screen mode.
        /// </para>
        /// <para>
        /// For info about using gamma correction, see Using gamma correction.
        /// </para>
        /// </remarks>
        public HRESULT GetGammaControl([Out] DXGI_GAMMA_CONTROL[] pArray)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_GAMMA_CONTROL[], HRESULT>)_vTable[15])(thisPtr, pArray);
            }
        }

        /// <summary>
        /// Changes the display mode.
        /// </summary>
        /// <param name="pScanoutSurface">
        /// A pointer to a surface (see <see cref="IDXGISurface"/>) used for rendering an image to the screen.
        /// The surface must have been created as a back buffer (<see cref="DXGI_USAGE_BACK_BUFFER"/>).
        /// </param>
        /// <returns>
        /// Returns one of the <see cref="DXGI_ERROR"/> values.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="SetDisplaySurface"/> should not be called directly by applications, since results will be unpredictable.
        /// It is called implicitly by the DXGI swap chain object during full-screen transitions,
        /// and should not be used as a substitute for swap-chain methods.
        /// </para>
        /// <para>
        /// This method should only be called between <see cref="TakeOwnership"/> and <see cref="ReleaseOwnership"/> calls.
        /// </para>
        /// <para>
        /// Notes for Windows Store apps
        /// </para>
        /// <para>
        /// If a Windows Store app uses <see cref="SetDisplaySurface"/>,
        /// it fails with <see cref="DXGI_ERROR_NOT_CURRENTLY_AVAILABLE"/>.
        /// </para>
        /// </remarks>
        public HRESULT SetDisplaySurface([In] P<IDXGISurface> pScanoutSurface)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IDXGISurface>, HRESULT>)_vTable[16])(thisPtr, pScanoutSurface);
            }
        }

        /// <summary>
        /// Gets a copy of the current display surface.
        /// </summary>
        /// <param name="pDestination">
        /// A pointer to a destination surface (see <see cref="IDXGISurface"/>).
        /// </param>
        /// <returns>
        /// Returns one of the <see cref="DXGI_ERROR"/> values.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetDisplaySurfaceData"/> can only be called when an output is in full-screen mode.
        /// If the method succeeds, DXGI fills the destination surface.
        /// </para>
        /// <para>
        /// Use <see cref="GetDesc"/> to determine the size (width and height) of the output
        /// when you want to allocate space for the destination surface.
        /// This is true regardless of target monitor rotation.
        /// A destination surface created by a graphics component (such as Direct3D 10)
        /// must be created with CPU-write permission (see <see cref="D3D10_CPU_ACCESS_WRITE"/>).
        /// Other surfaces should be created with CPU read-write permission (see <see cref="D3D10_CPU_ACCESS_READ_WRITE"/>).
        /// This method will modify the surface data to fit the destination surface
        /// (stretch, shrink, convert format, rotate).
        /// The stretch and shrink is performed with point-sampling.
        /// </para>
        /// </remarks>
        [Obsolete("Starting with Direct3D 11.1, we recommend not to use GetDisplaySurfaceData anymore to retrieve the current display surface. " +
            "Instead, use IDXGIOutput1::GetDisplaySurfaceData1, which supports stereo display mode.")]
        public HRESULT GetDisplaySurfaceData([In] P<IDXGISurface> pDestination)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IDXGISurface>, HRESULT>)_vTable[17])(thisPtr, pDestination);
            }
        }

        /// <summary>
        /// Gets statistics about recently rendered frames.
        /// </summary>
        /// <param name="pStats">
        /// A pointer to frame statistics (see <see cref="DXGI_FRAME_STATISTICS"/>).
        /// </param>
        /// <returns>
        /// If this function succeeds, it returns <see cref="S_OK"/>.
        /// Otherwise, it might return <see cref="DXGI_ERROR_INVALID_CALL"/>.
        /// </returns>
        /// <remarks>
        /// <para>
        /// This API is similar to <see cref="IDXGISwapChain.GetFrameStatistics"/>.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// Calling this method is only supported while in full-screen mode.
        /// </para>
        /// </remarks>
        public HRESULT GetFrameStatistics([Out] out DXGI_FRAME_STATISTICS pStats)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, out DXGI_FRAME_STATISTICS, HRESULT>)_vTable[18])(thisPtr, out pStats);
            }
        }
    }
}
