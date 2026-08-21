using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.DirectX.Enums;
using Lsj.Util.Win32.DirectX.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.HRESULT;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.DirectX.Enums.D3D11_CPU_ACCESS_FLAG;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ENUM_MODES;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_ERROR;
using static Lsj.Util.Win32.DirectX.Enums.DXGI_FORMAT;
using static Lsj.Util.Win32.Enums.EventConstants;
using static Lsj.Util.Win32.Enums.WindowMessages;

namespace Lsj.Util.Win32.DirectX.ComInterfaces
{
    /// <summary>
    /// <para>
    /// An <see cref="IDXGIOutput1"/> interface represents an adapter output (such as a monitor).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/dxgi1_2/nn-dxgi1_2-idxgioutput1"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To determine the outputs that are available from the adapter, use <see cref="IDXGIAdapter.EnumOutputs"/>.
    /// To determine the specific output that the swap chain will update,
    /// use <see cref="IDXGISwapChain.GetContainingOutput"/>.
    /// You can then call <see cref="IUnknown.QueryInterface"/> from any <see cref="IDXGIOutput"/> object
    /// to obtain an <see cref="IDXGIOutput1"/> object.
    /// </remarks>
    [ComInterface(IID = "00cddea8-939b-4b83-a340-a685226666cc", BeginVTableSlotIndex = 19, EndVTableSlotIndex = 22,
        InheritedFromTypes = [typeof(IUnknown), typeof(IDXGIObject), typeof(IDXGIOutput)])]
    public unsafe struct IDXGIOutput1
    {
        nint* _vTable;

        /// <summary>
        /// Gets the display modes that match the requested format and other input options.
        /// </summary>
        /// <param name="EnumFormat">
        /// A <see cref="DXGI_FORMAT"/>-typed value for the color format.
        /// </param>
        /// <param name="Flags">
        /// A combination of <see cref="DXGI_ENUM_MODES"/>-typed values that are combined by using a bitwise OR operation.
        /// The resulting value specifies options for display modes to include.
        /// You must specify <see cref="DXGI_ENUM_MODES_SCALING"/> to expose the display modes that require scaling.
        /// Centered modes that require no scaling and correspond directly to the display output are enumerated by default.
        /// </param>
        /// <param name="pNumModes">
        /// A pointer to a variable that receives the number of display modes
        /// that <see cref="GetDisplayModeList1"/> returns in the memory block to which <paramref name="pDesc"/> points.
        /// Set <paramref name="pDesc"/> to <see langword="null"/> so that <paramref name="pNumModes"/>
        /// returns the number of display modes that match the format and the options.
        /// Otherwise, <paramref name="pNumModes"/> returns the number of display modes returned in <paramref name="pDesc"/>.
        /// </param>
        /// <param name="pDesc">
        /// A pointer to a list of display modes; set to <see langword="null"/> to get the number of display modes.
        /// </param>
        /// <returns>
        /// Returns one of the error codes described in the <see cref="DXGI_ERROR"/> topic.
        /// It is rare, but possible, that the display modes available can change immediately after calling this method,
        /// in which case <see cref="DXGI_ERROR_MORE_DATA"/> is returned (if there is not enough room for all the display modes).
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetDisplayModeList1"/> is updated from <see cref="IDXGIOutput.GetDisplayModeList"/>
        /// to return a list of <see cref="DXGI_MODE_DESC1"/> structures, which are updated mode descriptions.
        /// <see cref="IDXGIOutput.GetDisplayModeList"/> behaves as though it calls <see cref="GetDisplayModeList1"/>
        /// because <see cref="IDXGIOutput.GetDisplayModeList"/> can return all of the modes
        /// that are specified by <see cref="DXGI_ENUM_MODES"/>, including stereo mode.
        /// However, <see cref="IDXGIOutput.GetDisplayModeList"/> returns a list of <see cref="DXGI_MODE_DESC"/> structures,
        /// which are the former mode descriptions and do not indicate stereo mode.
        /// </para>
        /// <para>
        /// The <see cref="GetDisplayModeList1"/> method does not enumerate stereo modes
        /// unless you specify the <see cref="DXGI_ENUM_MODES_STEREO"/> flag in the <paramref name="Flags"/> parameter.
        /// If you specify <see cref="DXGI_ENUM_MODES_STEREO"/>, stereo modes are included in the list of returned modes
        /// that the <paramref name="pDesc"/> parameter points to.
        /// In other words, the method returns both stereo and mono modes.
        /// </para>
        /// <para>
        /// In general, when you switch from windowed to full-screen mode,
        /// a swap chain automatically chooses a display mode that meets (or exceeds)
        /// the resolution, color depth, and refresh rate of the swap chain.
        /// To exercise more control over the display mode, use <see cref="GetDisplayModeList1"/>
        /// to poll the set of display modes that are validated against monitor capabilities,
        /// or all modes that match the desktop (if the desktop settings are not validated against the monitor).
        /// </para>
        /// <para>
        /// The following example code shows that you need to call <see cref="GetDisplayModeList1"/> twice.
        /// First call <see cref="GetDisplayModeList1"/> to get the number of modes available,
        /// and second call <see cref="GetDisplayModeList1"/> to return a description of the modes.
        /// </para>
        /// <code>
        /// UINT num = 0;
        /// DXGI_FORMAT format = DXGI_FORMAT_R32G32B32A32_FLOAT;
        /// UINT flags         = DXGI_ENUM_MODES_INTERLACED;
        /// 
        /// pOutput->GetDisplayModeList1( format, flags, &amp;num, 0);
        /// 
        /// ...
        /// 
        /// DXGI_MODE_DESC1 * pDescs = new DXGI_MODE_DESC1[num];
        /// pOutput->GetDisplayModeList1( format, flags, &amp;num, pDescs);
        /// </code>
        /// </remarks>
        public HRESULT GetDisplayModeList1([In] DXGI_FORMAT EnumFormat, [In] DXGI_ENUM_MODES Flags, [In][Out] ref UINT pNumModes, [Out] DXGI_MODE_DESC1[] pDesc)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, DXGI_FORMAT, DXGI_ENUM_MODES, ref UINT, DXGI_MODE_DESC1[], HRESULT>)_vTable[19])
                    (thisPtr, EnumFormat, Flags, ref pNumModes, pDesc);
            }
        }

        /// <summary>
        /// Finds the display mode that most closely matches the requested display mode.
        /// </summary>
        /// <param name="pModeToMatch">
        /// A pointer to the <see cref="DXGI_MODE_DESC1"/> structure that describes the display mode to match.
        /// Members of <see cref="DXGI_MODE_DESC1"/> can be unspecified, which indicates no preference for that member.
        /// A value of 0 for <see cref="DXGI_MODE_DESC1.Width"/> or <see cref="DXGI_MODE_DESC1.Height"/> indicates that the value is unspecified.
        /// If either <see cref="DXGI_MODE_DESC1.Width"/> or <see cref="DXGI_MODE_DESC1.Height"/> is 0, both must be 0.
        /// A numerator and denominator of 0 in <see cref="DXGI_MODE_DESC1.RefreshRate"/> indicate it is unspecified.
        /// Other members of <see cref="DXGI_MODE_DESC1"/> have enumeration values that indicate that the member is unspecified.
        /// If <paramref name="pConcernedDevice"/> is <see cref="NULL"/>,
        /// the <see cref="DXGI_MODE_DESC1.Format"/> member of <see cref="DXGI_MODE_DESC1"/> cannot be <see cref="DXGI_FORMAT_UNKNOWN"/>.
        /// </param>
        /// <param name="pClosestMatch">
        /// A pointer to the <see cref="DXGI_MODE_DESC1"/> structure that receives a description of the display mode
        /// that most closely matches the display mode described at <paramref name="pModeToMatch"/>.
        /// </param>
        /// <param name="pConcernedDevice">
        /// <para>
        /// A pointer to the Direct3D device interface.
        /// If this parameter is <see cref="NULL"/>, <see cref="FindClosestMatchingMode1"/> returns only modes
        /// whose format matches that of <paramref name="pModeToMatch"/>;
        /// otherwise, <see cref="FindClosestMatchingMode1"/> returns only those formats
        /// that are supported for scan-out by the device.
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
        /// Returns one of the error codes described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        /// <remarks>
        /// <para>
        /// Direct3D devices require UNORM formats.
        /// </para>
        /// <para>
        /// <see cref="FindClosestMatchingMode1"/> finds the closest matching available display mode
        /// to the mode that you specify in <paramref name="pModeToMatch"/>.
        /// </para>
        /// <para>
        /// If you set the <see cref="DXGI_MODE_DESC1.Stereo"/> member in the <see cref="DXGI_MODE_DESC1"/> structure
        /// to which <paramref name="pModeToMatch"/> points to specify a stereo mode as input,
        /// <see cref="FindClosestMatchingMode1"/> considers only stereo modes.
        /// <see cref="FindClosestMatchingMode1"/> considers only mono modes if <see cref="DXGI_MODE_DESC1.Stereo"/> is not set.
        /// </para>
        /// <para>
        /// <see cref="FindClosestMatchingMode1"/> resolves similarly ranked members of display modes
        /// (that is, all specified, or all unspecified, and so on) in the following order:
        /// </para>
        /// <para>
        /// <list type="number">
        /// <item>
        /// <description>
        /// <see cref="DXGI_MODE_DESC1.ScanlineOrdering"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_MODE_DESC1.Scaling"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_MODE_DESC1.Format"/>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Resolution
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_MODE_DESC1.RefreshRate"/>
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// When <see cref="FindClosestMatchingMode1"/> determines the closest value for a particular member,
        /// it uses previously matched members to filter the display mode list choices, and ignores other members.
        /// For example, when <see cref="FindClosestMatchingMode1"/> matches Resolution,
        /// it already filtered the display mode list by a certain <see cref="DXGI_MODE_DESC1.ScanlineOrdering"/>,
        /// <see cref="DXGI_MODE_DESC1.Scaling"/>, and <see cref="DXGI_MODE_DESC1.Format"/>,
        /// while it ignores <see cref="DXGI_MODE_DESC1.RefreshRate"/>.
        /// This ordering doesn't define the absolute ordering for every usage scenario of <see cref="FindClosestMatchingMode1"/>,
        /// because the application can choose some values initially, which effectively changes the order of resolving members.
        /// </para>
        /// <para>
        /// <see cref="FindClosestMatchingMode1"/> matches members of the display mode one at a time, generally in a specified order.
        /// </para>
        /// <para>
        /// If a member is unspecified, <see cref="FindClosestMatchingMode1"/> gravitates
        /// toward the values for the desktop related to this output.
        /// If this output is not part of the desktop,
        /// <see cref="FindClosestMatchingMode1"/> uses the default desktop output to find values.
        /// If an application uses a fully unspecified display mode,
        /// <see cref="FindClosestMatchingMode1"/> typically returns a display mode
        /// that matches the desktop settings for this output.
        /// </para>
        /// <para>
        /// Because unspecified members are lower priority than specified members,
        /// <see cref="FindClosestMatchingMode1"/> resolves unspecified members later than specified members.
        /// </para>
        /// </remarks>
        public HRESULT FindClosestMatchingMode1([In] in DXGI_MODE_DESC1 pModeToMatch, [Out] out DXGI_MODE_DESC1 pClosestMatch, [In] P<IUnknown> pConcernedDevice)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, in DXGI_MODE_DESC1, out DXGI_MODE_DESC1, P<IUnknown>, HRESULT>)_vTable[20])
                    (thisPtr, pModeToMatch, out pClosestMatch, pConcernedDevice);
            }
        }

        /// <summary>
        /// Copies the display surface (front buffer) to a user-provided resource.
        /// </summary>
        /// <param name="pDestination">
        /// A pointer to a resource interface that represents the resource
        /// to which <see cref="GetDisplaySurfaceData1"/> copies the display surface.
        /// </param>
        /// <returns>
        /// Returns one of the error codes described in the <see cref="DXGI_ERROR"/> topic.
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetDisplaySurfaceData1"/> is similar to <see cref="IDXGIOutput.GetDisplaySurfaceData"/>
        /// except <see cref="GetDisplaySurfaceData1"/> takes an <see cref="IDXGIResource"/>
        /// and <see cref="IDXGIOutput.GetDisplaySurfaceData"/> takes an <see cref="IDXGISurface"/>.
        /// </para>
        /// <para>
        /// <see cref="GetDisplaySurfaceData1"/> returns an error if the input resource is not a 2D texture
        /// (represented by the <see cref="ID3D11Texture2D"/> interface) with an array size
        /// (<see cref="D3D11_TEXTURE2D_DESC.ArraySize"/> member of the <see cref="D3D11_TEXTURE2D_DESC"/> structure)
        /// that is equal to the swap chain buffers.
        /// </para>
        /// <para>
        /// The original <see cref="IDXGIOutput.GetDisplaySurfaceData"/>
        /// and the updated <see cref="GetDisplaySurfaceData1"/> behave exactly the same.
        /// <see cref="GetDisplaySurfaceData1"/> was required because textures
        /// with an array size equal to 2 (<see cref="D3D11_TEXTURE2D_DESC.ArraySize"/> = 2)
        /// do not implement <see cref="IDXGISurface"/>.
        /// </para>
        /// <para>
        /// You can call <see cref="GetDisplaySurfaceData1"/> only when an output is in full-screen mode.
        /// If <see cref="GetDisplaySurfaceData1"/> succeeds, it fills the destination resource.
        /// </para>
        /// <para>
        /// Use <see cref="IDXGIOutput.GetDesc"/> to determine the size (width and height) of the output
        /// when you want to allocate space for the destination resource.
        /// This is true regardless of target monitor rotation.
        /// A destination resource created by a graphics component (such as Direct3D 11)
        /// must be created with CPU write permission (see <see cref="D3D11_CPU_ACCESS_WRITE"/>).
        /// Other surfaces can be created with CPU read-write permission
        /// (<see cref="D3D11_CPU_ACCESS_READ"/> | <see cref="D3D11_CPU_ACCESS_WRITE"/>).
        /// <see cref="GetDisplaySurfaceData1"/> modifies the surface data to fit the destination resource
        /// (stretch, shrink, convert format, rotate).
        /// <see cref="GetDisplaySurfaceData1"/> performs the stretch and shrink with point sampling.
        /// </para>
        /// </remarks>
        public HRESULT GetDisplaySurfaceData1([In] P<IDXGIResource> pDestination)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IDXGIResource>, HRESULT>)_vTable[21])(thisPtr, pDestination);
            }
        }

        /// <summary>
        /// Creates a desktop duplication interface from the <see cref="IDXGIOutput1"/> interface that represents an adapter output.
        /// </summary>
        /// <param name="pDevice">
        /// A pointer to the Direct3D device interface that you can use to process the desktop image.
        /// This device must be created from the adapter to which the output is connected.
        /// </param>
        /// <param name="ppOutputDuplication">
        /// A pointer to a variable that receives the new <see cref="IDXGIOutputDuplication"/> interface.
        /// </param>
        /// <returns>
        /// <para>
        /// <see cref="DuplicateOutput"/> returns:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="S_OK"/> if <see cref="DuplicateOutput"/> successfully created the desktop duplication interface.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <para>
        /// <see cref="E_INVALIDARG"/> for one of the following reasons:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// The specified device (<paramref name="pDevice"/>) is invalid,
        /// was not created on the correct adapter, or was not created from <see cref="IDXGIFactory1"/>
        /// (or a later version of a DXGI factory interface that inherits from <see cref="IDXGIFactory1"/>).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// The calling application is already duplicating this desktop output.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="E_ACCESSDENIED"/> if the application does not have access privilege to the current desktop image.
        /// For example, only an application that runs at LOCAL_SYSTEM can access the secure desktop.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_UNSUPPORTED"/> if the created <see cref="IDXGIOutputDuplication"/> interface
        /// does not support the current desktop mode or scenario.
        /// For example, 8bpp and non-DWM desktop modes are not supported.
        /// If <see cref="DuplicateOutput"/> fails with <see cref="DXGI_ERROR_UNSUPPORTED"/>,
        /// the application can wait for system notification of desktop switches and mode changes
        /// and then call <see cref="DuplicateOutput"/> again after such a notification occurs.
        /// For more information, refer to <see cref="EVENT_SYSTEM_DESKTOPSWITCH"/>
        /// and mode change notification (<see cref="WM_DISPLAYCHANGE"/>).
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_NOT_CURRENTLY_AVAILABLE"/> if DXGI reached the limit
        /// on the maximum number of concurrent duplication applications (default of four).
        /// Therefore, the calling application cannot create any desktop duplication interfaces until the other applications close.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see cref="DXGI_ERROR_SESSION_DISCONNECTED"/> if <see cref="DuplicateOutput"/> failed
        /// because the session is currently disconnected.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Other error codes are described in the <see cref="DXGI_ERROR"/> topic.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// Platform Update for Windows 7:
        /// On Windows 7 or Windows Server 2008 R2 with the Platform Update for Windows 7 installed,
        /// <see cref="DuplicateOutput"/> fails with <see cref="E_NOTIMPL"/>.
        /// For more info about the Platform Update for Windows 7, see Platform Update for Windows 7.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// If an application wants to duplicate the entire desktop,
        /// it must create a desktop duplication interface on each active output on the desktop.
        /// This interface does not provide an explicit way to synchronize the timing of each output image.
        /// Instead, the application must use the time stamp of each output, and then determine how to combine the images.
        /// </para>
        /// <para>
        /// For <see cref="DuplicateOutput"/> to succeed,
        /// you must create <paramref name="pDevice"/> from <see cref="IDXGIFactory1"/>
        /// or a later version of a DXGI factory interface that inherits from <see cref="IDXGIFactory1"/>.
        /// </para>
        /// <para>
        /// If the current mode is a stereo mode,
        /// the desktop duplication interface provides the image for the left stereo image only.
        /// </para>
        /// <para>
        /// By default, only four processes can use a <see cref="IDXGIOutputDuplication"/> interface
        /// at the same time within a single session.
        /// A process can have only one desktop duplication interface on a single desktop output;
        /// however, that process can have a desktop duplication interface for each output that is part of the desktop.
        /// </para>
        /// <para>
        /// For improved performance, consider using <see cref="DuplicateOutput1"/>.
        /// </para>
        /// </remarks>
        public HRESULT DuplicateOutput([In] P<IUnknown> pDevice, [Out] out P<IDXGIOutputDuplication> ppOutputDuplication)
        {
            fixed (void* thisPtr = &this)
            {
                return ((delegate* unmanaged[Stdcall]<void*, P<IUnknown>, out P<IDXGIOutputDuplication>, HRESULT>)_vTable[22])(thisPtr, pDevice, out ppOutputDuplication);
            }
        }
    }
}
