using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Marshals;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32
{
    public static partial class Gdi32
    {
        /// <summary>
        /// <para>
        /// The <c>EnumICMProfilesProcCallback</c> callback is an application-defined callback function
        /// that processes color profile data from <see cref="EnumICMProfiles"/> .
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nc-wingdi-icmenumprocw"/>
        /// </para>
        /// </summary>
        /// <param name="unnamedParam1"></param>
        /// <param name="unnamedParam2"></param>
        /// <returns>
        /// This function must return a positive value to continue enumeration, or zero to stop enumeration.
        /// It may not return a negative value.
        /// </returns>
        public delegate int Icmenumproc([In] LPWSTR unnamedParam1, [In] LPARAM unnamedParam2);


        /// <summary>
        /// <para>
        /// The <see cref="CheckColorsInGamut"/> function determines
        /// whether a specified set of RGB triples lies in the output gamut of a specified device.
        /// The RGB triples are interpreted in the input logical color space.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-checkcolorsingamut"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Handle to the device context whose output gamut to be checked.
        /// </param>
        /// <param name="lpRGBTriple">
        /// Pointer to an array of RGB triples to check.
        /// </param>
        /// <param name="dlpBuffer">
        /// Pointer to the buffer in which the results are to be placed.
        /// This buffer must be at least as large as <paramref name="nCount"/> bytes.
        /// </param>
        /// <param name="nCount">
        /// The number of elements in the array of triples.
        /// </param>
        /// <returns>
        /// <para>
        /// If this function succeeds, the return value is a nonzero value.
        /// </para>
        /// <para>
        /// If this function fails, the return value is zero.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// The function places the test results in the buffer pointed to by <paramref name="dlpBuffer"/>.
        /// Each byte in the buffer corresponds to an RGB triple, and has an unsigned value
        /// between CM_IN_GAMUT (= 0) and CM_OUT_OF_GAMUT (= 255).
        /// The value 0 denotes that the color is in gamut, while a nonzero value denotes that it is out of gamut.
        /// For any integer <c>n</c> such that 0 &lt; <c>n</c> &lt; 255,
        /// a result value of <c>n</c> + 1 indicates that the corresponding color is at least as far out of gamut
        /// as would be indicated by a result value of <c>n</c>, as specified by the ICC Profile Format Specification.
        /// For more information on the ICC Profile Format Specification, see the sources listed in Further information .
        /// </para>
        /// <para>
        /// Note that for this function to succeed, WCS must be enabled for the device context handle
        /// that is passed in through the <paramref name="hdc"/> parameter.
        /// WCS can be enabled for a device context handle by calling the <see cref="SetICMMode"/> function.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CheckColorsInGamut", ExactSpelling = true)]
        public static extern BOOL CheckColorsInGamut([In] HDC hdc, [In] RGBTRIPLE[] lpRGBTriple, [In] LPVOID dlpBuffer, [In] DWORD nCount);

        /// <summary>
        /// <para>
        /// The <see cref="ColorMatchToTarget"/> function enables you to preview colors as they would appear on the target device.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-colormatchtotarget"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Specifies the device context for previewing, generally the screen.
        /// </param>
        /// <param name="hdcTarget">
        /// Specifies the target device context, generally a printer.
        /// </param>
        /// <param name="action">
        /// <para>
        /// A constant that can have one of the following values. 
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="CS_ENABLE"/>
        /// </term>
        /// <term>
        /// Map the colors to the target device's color gamut.
        /// This enables color proofing.
        /// All subsequent draw commands to the DC will render colors as they would appear on the target device.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CS_DISABLE"/>
        /// </term>
        /// <term>
        /// Disable color proofing.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="CS_DELETE_TRANSFORM"/>
        /// </term>
        /// <term>
        /// If color management is enabled for the target profile, disable it and delete the concatenated transform.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If this function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If this function fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="ColorMatchToTarget"/> can be used to proof the colors of a color output device on another color output device.
        /// Setting the <paramref name="action"/> parameter to <see cref="CS_ENABLE"/>
        /// causes all subsequent drawing commands to the DC to render colors as they would appear on the target device.
        /// If <paramref name="action"/> is set to <see cref="CS_DISABLE"/>, proofing is turned off.
        /// However, the current color transform is not deleted from the DC. It is just inactive.
        /// </para>
        /// <para>
        /// When <see cref="ColorMatchToTarget"/> is called, the color transform for the target device is performed first,
        /// and then the transform to the preview device is applied to the results of the first transform.
        /// This is used primarily for checking gamut mapping conditions.
        /// Before using this function, you must enable WCS for both device contexts.
        /// </para>
        /// <para>
        /// This function cannot be cascaded.
        /// While color mapping to the target is enabled by setting <paramref name="action"/> to <see cref="CS_ENABLE"/>,
        /// application changes to the color space or gamut mapping method are ignored.
        /// Those changes then take effect when color mapping to the target is disabled.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// A memory leak will not occur if an application does not delete a transform using <see cref="CS_DELETE_TRANSFORM"/>.
        /// The transform will be deleted when either the device context (DC) is closed,
        /// or when the application color space is deleted.
        /// However if the transform is not going to be used again,
        /// or if the application will not be performing any more color matching on the DC,
        /// it should explicitly delete the transform to free the memory it occupies.
        /// </para>
        /// <para>
        /// The <paramref name="action"/> parameter should only be set to <see cref="CS_DELETE_TRANSFORM"/>
        /// if color management is enabled before the <see cref="ColorMatchToTarget"/> function is called.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ColorMatchToTarget", ExactSpelling = true)]
        public static extern BOOL ColorMatchToTarget([In] HDC hdc, [In] HDC hdcTarget, [In] DWORD action);

        /// <summary>
        /// <para>
        /// The <see cref="ColorCorrectPalette"/> function corrects the entries of a palette
        /// using the WCS 1.0 parameters in the specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-colorcorrectpalette"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Specifies a device context whose WCS parameters to use.
        /// </param>
        /// <param name="hPal">
        /// Specifies the handle to the palette to be color corrected.
        /// </param>
        /// <param name="deFirst">
        /// Specifies the first entry in the palette to be color corrected.
        /// </param>
        /// <param name="num">
        /// Specifies the number of entries to color correct.
        /// </param>
        /// <returns>
        /// <para>
        /// If this function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If this function fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.Windows2000)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ColorCorrectPalette", ExactSpelling = true)]
        public static extern BOOL ColorCorrectPalette([In] HDC hdc, [In] HPALETTE hPal, [In] DWORD deFirst, [In] DWORD num);

        /// <summary>
        /// <para>
        /// The <see cref="CreateColorSpace"/> function creates a logical color space.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-createcolorspacew"/>
        /// </para>
        /// </summary>
        /// <param name="lplcs">
        /// Pointer to the <see cref="LOGCOLORSPACE"/> data structure.
        /// </param>
        /// <returns>
        /// <para>
        /// If this function succeeds, the return value is a handle that identifies a color space.
        /// </para>
        /// <para>
        /// If this function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// When the color space is no longer needed, use <see cref="DeleteColorSpace"/> to delete it.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateColorSpaceW", ExactSpelling = true)]
        public static extern HCOLORSPACE CreateColorSpace([In] in LOGCOLORSPACE lplcs);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteColorSpace"/> function removes and destroys a specified color space.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-deletecolorspace"/>
        /// </para>
        /// </summary>
        /// <param name="hcs">
        /// Specifies the handle to a color space to delete.
        /// </param>
        /// <returns>
        /// <para>
        /// If this function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If this function fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteColorSpace", ExactSpelling = true)]
        public static extern BOOL DeleteColorSpace([In] HCOLORSPACE hcs);

        /// <summary>
        /// <para>
        /// The <see cref="EnumICMProfiles"/> function enumerates the different output color profiles
        /// that the system supports for a given device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-enumicmprofilesw"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Specifies the device context.
        /// </param>
        /// <param name="proc">
        /// Specifies the procedure instance address of a callback function defined by the application.
        /// (See <c>EnumICMProfilesProcCallback</c>.)
        /// </param>
        /// <param name="param">
        /// Data supplied by the application that is passed to the callback function along with the color profile information.
        /// </param>
        /// <returns>
        /// This function returns zero if the application interrupted the enumeration.
        /// The return value is -1 if there are no color profiles to enumerate.
        /// Otherwise, the return value is the last value returned by the callback function.
        /// </returns>
        /// <remarks>
        /// The <see cref="EnumICMProfiles"/> function returns a list of profiles
        /// that are associated with a device context (DC), and whose settings match those of the DC.
        /// It is possible for a device context to contain device profiles
        /// that are not associated with particular hardware devices,
        /// or device profiles that do not match the settings of the DC.
        /// The sRGB profile is an example.
        /// The <see cref="SetICMProfile"/> function is used to associate these types of profiles with a DC.
        /// The <see cref="GetICMProfile"/> function can be used to retrieve a profile
        /// that is not enumerated by the <see cref="EnumICMProfiles"/> function.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumICMProfilesW", ExactSpelling = true)]
        public static extern int EnumICMProfiles([In] HDC hdc, [In] ICMENUMPROC proc, [In] LPARAM param);

        /// <summary>
        /// <para>
        /// The <see cref="GetColorSpace"/> function retrieves the handle to the input color space from a specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getcolorspace"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Specifies a device context that is to have its input color space handle retrieved.
        /// </param>
        /// <returns>
        /// <para>
        /// If the function succeeds, the return value is the current input color space handle.
        /// </para>
        /// <para>
        /// If this function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <see cref="GetColorSpace"/> obtains the handle to the input color space
        /// regardless of whether color management is enabled for the device context.
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetColorSpace", ExactSpelling = true)]
        public static extern HCOLORSPACE GetColorSpace([In] HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetDeviceGammaRamp"/> function gets the gamma ramp
        /// on direct color display boards having drivers that support downloadable gamma ramps in hardware.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// We strongly recommend that you don't use this API.
        /// Use of this API is subject to major limitations.
        /// See <see cref="SetDeviceGammaRamp"/> for more information.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getdevicegammaramp"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Specifies the device context of the direct color display board in question.
        /// </param>
        /// <param name="lpRamp">
        /// Points to a buffer where the function can place the current gamma ramp of the color display board.
        /// The gamma ramp is specified in three arrays of 256 <see cref="WORD"/> elements each,
        /// which contain the mapping between RGB values in the frame buffer and digital-analog-converter (DAC) values.
        /// The sequence of the arrays is red, green, blue.
        /// </param>
        /// <returns>
        /// <para>
        /// If this function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If this function fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDeviceGammaRamp", ExactSpelling = true)]
        public static extern BOOL GetDeviceGammaRamp([In] HDC hdc, LPVOID lpRamp);

        /// <summary>
        /// <para>
        /// The <see cref="GetICMProfile"/> function retrieves the file name of the current output color profile for a specified device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-geticmprofilew"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Specifies a device context from which to retrieve the color profile.
        /// </param>
        /// <param name="pBufSize">
        /// Pointer to a <see cref="DWORD"/> that contains the size of the buffer pointed to by <paramref name="pszFilename"/>.
        /// For the ANSI version of this function, the size is in bytes.
        /// For the Unicode version, the size is in <c>WCHAR</c>s.
        /// If this function is successful, on return this parameter contains the size of the buffer actually used.
        /// However, if the buffer is not large enough, this function returns <see cref="FALSE"/>.
        /// In this case, the <see cref="GetLastError"/> function returns <see cref="ERROR_INSUFFICIENT_BUFFER"/>
        /// and the <see cref="DWORD"/> pointed to by this parameter contains the size needed for the <paramref name="pszFilename"/> buffer.
        /// </param>
        /// <param name="pszFilename">
        /// Points to the buffer that receives the path name of the profile.
        /// </param>
        /// <returns>
        /// <para>
        /// If this function succeeds, the return value is <see cref="TRUE"/>.
        /// It also returns <see cref="TRUE"/> if the <paramref name="pszFilename"/> parameter is <see cref="NULL"/>
        /// and the size required for the buffer is copied into <paramref name="pBufSize"/>.
        /// </para>
        /// <para>
        /// If this function fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="GetICMProfile"/> obtains the file name of the current output profile
        /// regardless of whether or not color management is enabled for the device context.
        /// </para>
        /// <para>
        /// Given a device context, <see cref="GetICMProfile"/> will output, through the parameter <paramref name="pszFilename"/>,
        /// the path name of the file containing the color profile currently being used by the device context.
        /// It will also output, through the parameter <paramref name="pBufSize"/>,
        /// the length of the string containing the path name.
        /// </para>
        /// <para>
        /// It is possible that the profile name returned by <see cref="GetICMProfile"/>
        /// will not be in the list of profiles returned by <see cref="EnumICMProfiles"/>.
        /// The <see cref="EnumICMProfiles"/> function returns all color space profiles
        /// that are associated with a device context (DC) whose settings match that of the DC.
        /// If the <see cref="SetICMProfile"/> function is used to set the current profile,
        /// a profile may be associated with the DC that does not match its settings.
        /// For instance, the <see cref="SetICMProfile"/> function can be used
        /// to associate the device-independent sRGB profile with a DC.
        /// This profile will be used as the current WCS profile for that DC,
        /// and calls to <see cref="GetICMProfile"/> will return its file name.
        /// However, the profile will not appear in the list of profiles that is returned from <see cref="EnumICMProfiles"/>.
        /// </para>
        /// <para>
        /// If this function is called before any calls to the <see cref="SetICMProfile"/> function,
        /// it can be used to get the default profile for a device context.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetICMProfileW", ExactSpelling = true, SetLastError = true)]
        public static extern BOOL GetICMProfile([In] HDC hdc, [In][Out] ref DWORD pBufSize, [In] LPWSTR pszFilename);

        /// <summary>
        /// <para>
        /// The <see cref="GetLogColorSpace"/> function retrieves the color space definition identified by a specified handle.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-getlogcolorspacew"/>
        /// </para>
        /// </summary>
        /// <param name="hColorSpace">
        /// Specifies the handle to a color space.
        /// </param>
        /// <param name="lpBuffer">
        /// Points to a buffer to receive the <see cref="LOGCOLORSPACE"/> structure.
        /// </param>
        /// <param name="nSize">
        /// Specifies the maximum size of the buffer.
        /// </param>
        /// <returns>
        /// <para>
        /// If this function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If this function fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetLogColorSpaceW", ExactSpelling = true)]
        public static extern BOOL GetLogColorSpace([In] HCOLORSPACE hColorSpace, [Out] out LOGCOLORSPACE lpBuffer, [In] DWORD nSize);

        /// <summary>
        /// <para>
        /// The <see cref="SetColorSpace"/> function defines the input color space for a given device context.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setcolorspace"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Specifies the handle to a device context.
        /// </param>
        /// <param name="hcs">
        /// Identifies handle to the color space to set.
        /// </param>
        /// <returns>
        /// <para>
        /// If this function succeeds, the return value is a handle to the <paramref name="hcs"/> being replaced.
        /// </para>
        /// <para>
        /// If this function fails, the return value is <see cref="NULL"/>.
        /// </para>
        /// </returns>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetColorSpace", ExactSpelling = true)]
        public static extern HCOLORSPACE SetColorSpace([In] HDC hdc, [In] HCOLORSPACE hcs);

        /// <summary>
        /// <para>
        /// The <see cref="SetDeviceGammaRamp"/> function sets the gamma ramp on direct color display boards
        /// having drivers that support downloadable gamma ramps in hardware.
        /// </para>
        /// <para>
        /// Important
        /// </para>
        /// <para>
        /// We strongly recommend that you don't use this API.
        /// Use of this API is subject to major limitations:
        /// </para>
        /// <para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// <see cref="SetDeviceGammaRamp"/> implements heuristics to check
        /// whether a provided ramp will result in an unreadable screen.
        /// If a ramp violates those heuristics, then the function fails silently
        /// (that is, it returns <see cref="TRUE"/>, but it doesn't set your ramp).
        /// For that reason, you can't expect to use this function to set just any arbitrary gamma ramp.
        /// In particular, the heuristics prevent ramps that would result in nearly all pixels
        /// approaching a single value (such as fullscreen black/white) as this may prevent a user from recovering the screen.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Because of the function's global nature, any other application on the system could,
        /// at any time, overwrite any ramp that you've set.
        /// In some cases the operating system itself may reserve the use of this function,
        /// causing any existing ramp to be overwritten.
        /// The gamma ramp is also reset on most display events (connecting/disconnecting a monitor, resolution changes, etc.).
        /// So you can't be certain that any ramp you set is in effect.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// This API has undefined behavior in HDR modes.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// This API has undefined interaction with both built-in and third-party color calibration solutions.
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// <para>
        /// For color calibration, we recommend that you create an International Color Consortium (ICC) profile,
        /// and let the OS apply the profile.
        /// For advanced original equipment manufacturer (OEM) scenarios,
        /// there's a device driver model that you can use to customize color calibration more directly.
        /// See the Windows Color System for information on managing color profiles.
        /// </para>
        /// <para>
        /// For blue light filtering, Windows now provides built-in support called Night Light.
        /// We recommend directing users to this feature.
        /// </para>
        /// <para>
        /// For color adaptation (for example, adjusting color calibration based on ambient light sensors),
        /// Windows now provides built-in support, which we recommend for use by OEMs.
        /// </para>
        /// <para>
        /// For custom filter effects, there are a variety of built-in accessibility color filters to help with a range of cases.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-setdevicegammaramp"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Specifies the device context of the direct color display board in question.
        /// </param>
        /// <param name="lpRamp">
        /// Pointer to a buffer containing the gamma ramp to be set.
        /// The gamma ramp is specified in three arrays of 256 <see cref="WORD"/> elements each,
        /// which contain the mapping between RGB values in the frame buffer and digital-analog-converter (<c>DAC</c> ) values.
        /// The sequence of the arrays is red, green, blue.
        /// The RGB values must be stored in the most significant bits of each <see cref="WORD"/> to increase DAC independence.
        /// </param>
        /// <returns>
        /// <para>
        /// If this function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If this function fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// Direct color display modes do not use color lookup tables and are usually 16, 24, or 32 bit.
        /// Not all direct color video boards support loadable gamma ramps.
        /// <see cref="SetDeviceGammaRamp"/> succeeds only for devices with drivers
        /// that support downloadable gamma ramps in hardware.
        /// </para>
        /// <para>
        /// Note
        /// </para>
        /// <para>
        /// This API can take a non-trivial amount of time to execute.
        /// It may take as long as 200ms to return on some hardware.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetDeviceGammaRamp", ExactSpelling = true)]
        public static extern BOOL SetDeviceGammaRamp([In] HDC hdc, [In] LPVOID lpRamp);

        /// <summary>
        /// <para>
        /// The <see cref="SetICMProfile"/> function sets a specified color profile
        /// as the output profile for a specified device context (DC).
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-seticmprofilew"/>
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// Specifies a device context in which to set the color profile.
        /// </param>
        /// <param name="lpFileName">
        /// Specifies the path name of the color profile to be set.
        /// </param>
        /// <returns>
        /// <para>
        /// If this function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If this function fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// </returns>
        /// <remarks>
        /// <para>
        /// <see cref="SetICMProfile"/> associates a color profile with a device context.
        /// It becomes the output profile for that device context.
        /// The color profile does not have to be associated with any particular device.
        /// Device-independent profiles such as sRGB can also be used.
        /// If the color profile is not associated with a hardware device,
        /// it will be returned by <see cref="GetICMProfile"/>, but not by <see cref="EnumICMProfiles"/>.
        /// </para>
        /// <para>
        /// Note that under Windows 95 or later, the PostScript device driver for printers assumes a CMYK color model.
        /// Therefore, all PostScript printers must use a CMYK color profile.
        /// Windows 2000 does not have this limitation.
        /// </para>
        /// <para>
        /// <see cref="SetICMProfile"/> supports only RGB profiles in compatible DCs.
        /// </para>
        /// </remarks>
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetICMProfileW", ExactSpelling = true)]
        public static extern BOOL SetICMProfile([In] HDC hdc, [In] LPWSTR lpFileName);

        /// <summary>
        /// <para>
        /// The <see cref="UpdateICMRegKey"/> function manages color profiles and Color Management Modules in the system.
        /// </para>
        /// <para>
        /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/wingdi/nf-wingdi-updateicmregkeyw"/>
        /// </para>
        /// </summary>
        /// <param name="reserved">
        /// Reserved, must be set to zero.
        /// </param>
        /// <param name="lpszCMID">
        /// Points to a string that specifies the ICC profile identifier for the color management DLL to use with the profile.
        /// </param>
        /// <param name="lpszFileName">
        /// Points to a fully qualified ICC color profile file name or to a <see cref="DEVMODE"/> structure.
        /// </param>
        /// <param name="command">
        /// <para>
        /// Specifies a function to execute.
        /// It can have one of the following values. 
        /// </para>
        /// <para>
        /// <list type="table">
        /// <listheader>
        /// <term>
        /// Value
        /// </term>
        /// <term>
        /// Meaning
        /// </term>
        /// </listheader>
        /// <item>
        /// <term>
        /// <see cref="ICM_ADDPROFILE"/>
        /// </term>
        /// <term>
        /// Installs the ICC profile in the system.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ICM_DELETEPROFILE"/>
        /// </term>
        /// <term>
        /// Uninstalls the ICC profile from the system, but does not delete the file.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ICM_QUERYPROFILE"/>
        /// </term>
        /// <term>
        /// Determines whether the profile is already installed in the system.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ICM_SETDEFAULTPROFILE"/>
        /// </term>
        /// <term>
        /// Makes the profile first among equals.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ICM_REGISTERICMATCHER"/>
        /// </term>
        /// <term>
        /// Registers a CMM in the system.
        /// The <paramref name="lpszFileName"/> parameter points to a fully qualified path for the CMM DLL.
        /// The <paramref name="lpszCMID"/> parameter points to a <see cref="DWORD"/> identifying the CMM.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ICM_UNREGISTERICMATCHER"/>
        /// </term>
        /// <term>
        /// Unregisters the CMM from the system.
        /// The <paramref name="lpszCMID"/> parameter points to a <see cref="DWORD"/> identifying the CMM.
        /// </term>
        /// </item>
        /// <item>
        /// <term>
        /// <see cref="ICM_QUERYMATCH"/>
        /// </term>
        /// <term>
        /// Determines whether a profile exists based on the <see cref="DEVMODE"/> structure
        /// pointed to by the <paramref name="lpszFileName"/> parameter.
        /// </term>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <returns>
        /// <para>
        /// If this function succeeds, the return value is <see cref="TRUE"/>.
        /// </para>
        /// <para>
        /// If this function fails, the return value is <see cref="FALSE"/>.
        /// </para>
        /// </returns>
        [Obsolete("Obsolete; retained for backward compatibility")]
        [WindowsVersionRequirement(WindowsVersion.WindowsNT40)]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "UpdateICMRegKeyW", ExactSpelling = true)]
        public static extern BOOL UpdateICMRegKey([In] DWORD reserved, [In] LPWSTR lpszCMID, [In] LPWSTR lpszFileName, [In] UINT command);
    }
}
