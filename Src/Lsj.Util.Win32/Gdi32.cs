using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.CharacterSets;
using static Lsj.Util.Win32.Enums.FontTypes;
using static Lsj.Util.Win32.Enums.GraphicsModes;
using static Lsj.Util.Win32.User32;
using static Lsj.Util.Win32.Enums.ExtTextOutFlags;
using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals;

namespace Lsj.Util.Win32
{
    /// <summary>
    /// Gdi32.dll
    /// </summary>
    public static class Gdi32
    {
        /// <summary>
        /// HGDI_ERROR
        /// </summary>
        public static readonly IntPtr HGDI_ERROR = new IntPtr(-1);

        /// <summary>
        /// CCHDEVICENAME
        /// </summary>
        public const int CCHDEVICENAME = 32;

        /// <summary>
        /// CCHFORMNAME
        /// </summary>
        public const int CCHFORMNAME = 32;

        /// <summary>
        /// LF_FACESIZE
        /// </summary>
        public const int LF_FACESIZE = 32;

        /// <summary>
        /// LF_FULLFACESIZE
        /// </summary>
        public const int LF_FULLFACESIZE = 64;

        /// <summary>
        /// MM_MAX_NUMAXES
        /// </summary>
        public const int MM_MAX_NUMAXES = 16;

        /// <summary>
        /// MM_MAX_AXES_NAMELEN
        /// </summary>
        public const int MM_MAX_AXES_NAMELEN = 16;

        /// <summary>
        /// <para>
        /// The EnumFontFamExProc function is an application defined callback function used with the <see cref="EnumFontFamiliesEx"/> function.
        /// It is used to process the fonts. It is called once for each enumerated font.
        /// The <see cref="FONTENUMPROC"/> type defines a pointer to this callback function.
        /// EnumFontFamExProc is a placeholder for the application defined function name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/previous-versions/dd162618(v=vs.85)
        /// </para>
        /// </summary>
        /// <param name="lpelfe">
        /// A pointer to an <see cref="LOGFONT"/> structure that contains information about the logical attributes of the font.
        /// To obtain additional information about the font, you can cast the result
        /// as an <see cref="ENUMLOGFONTEX"/> or <see cref="ENUMLOGFONTEXDV"/> structure.
        /// </param>
        /// <param name="lpntme">
        /// A pointer to a structure that contains information about the physical attributes of a font.
        /// The function uses the <see cref="NEWTEXTMETRICEX"/> structure for TrueType fonts;
        /// and the <see cref="TEXTMETRIC"/> structure for other fonts.
        /// This can be an <see cref="ENUMTEXTMETRIC"/> structure.
        /// </param>
        /// <param name="FontType">
        /// The type of the font. This parameter can be a combination of these values:
        /// <see cref="DEVICE_FONTTYPE"/>
        /// <see cref="RASTER_FONTTYPE"/>
        /// <see cref="TRUETYPE_FONTTYPE"/>
        /// </param>
        /// <param name="lParam">
        /// The application-defined data passed by the <see cref="EnumFontFamiliesEx"/> function.
        /// </param>
        /// <returns>
        /// The return value must be a nonzero value to continue enumeration; to stop enumeration, the return value must be zero.
        /// </returns>
        /// <remarks>
        /// An application must register this callback function by passing its address to the <see cref="EnumFontFamiliesEx"/> function.
        /// When the graphics mode on the device context is set to <see cref="GM_ADVANCED"/>
        /// using the <see cref="SetGraphicsMode"/> function and the <see cref="DEVICE_FONTTYPE"/> flag is passed to the FontType parameter,
        /// this function returns a list of type 1 and OpenType fonts on the system.
        /// When the graphics mode is not set to <see cref="GM_ADVANCED"/>,
        /// this function returns a list of type 1, OpenType, and TrueType fonts on the system.
        /// Unlike the EnumFontFamProc callback function, EnumFontFamExProc receives extended information about a font.
        /// The <see cref="ENUMLOGFONTEX"/> structure includes the localized name of the script (character set) and
        /// the <see cref="NEWTEXTMETRICEX"/> structure includes a font-coverage signature.
        /// </remarks>
        public delegate int FONTENUMPROC([In]IntPtr lpelfe, [In]IntPtr lpntme, [In]FontTypes FontType, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// The <see cref="CreateCompatibleBitmap"/> function creates a bitmap compatible with the device that is associated with the specified device context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createcompatiblebitmap
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to a device context.</param>
        /// <param name="nWidth">The bitmap width, in pixels.</param>
        /// <param name="nHeight">The bitmap height, in pixels.</param>
        /// <returns>
        /// If the function succeeds, the return value is a handle to the compatible bitmap (DDB).
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleBitmap", SetLastError = true)]
        public static extern IntPtr CreateCompatibleBitmap([In]IntPtr hdc, [In]int nWidth, [In]int nHeight);

        /// <summary>
        /// <para>
        /// The <see cref="CreateCompatibleDC"/> function creates a memory device context (DC) compatible with the specified device.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createcompatibledc
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to an existing DC. If this handle is NULL, the function creates a memory DC compatible with the application's current screen.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to a memory DC.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateCompatibleDC", SetLastError = true)]
        public static extern HDC CreateCompatibleDC([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="CreateDC"/> function creates a device context (DC) for a device using the specified name.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createdcw
        /// </para>
        /// </summary>
        /// <param name="pwszDriver">
        /// A pointer to a null-terminated character string that specifies either DISPLAY or the name of a specific display device.
        /// For printing, we recommend that you pass <see langword="null""/> to <paramref name="pwszDriver"/>
        /// because GDI ignores <paramref name="pwszDriver"/> for printer devices.
        /// </param>
        /// <param name="pwszDevice">
        /// A pointer to a null-terminated character string that specifies the name of the specific output device being used,
        /// as shown by the Print Manager (for example, Epson FX-80).
        /// It is not the printer model name. The <paramref name="pwszDevice"/> parameter must be used.
        /// To obtain valid names for displays, call <see cref="EnumDisplayDevices"/>.
        /// If <paramref name="pwszDriver"/> is DISPLAY or the device name of a specific display device,
        /// then <paramref name="pwszDevice"/> must be <see langword="null"/> or that same device name.
        /// If <paramref name="pwszDevice"/> is NULL, then a DC is created for the primary display device.
        /// If there are multiple monitors on the system, calling <code>CreateDC(TEXT("DISPLAY"),NULL,NULL,NULL)</code>
        /// will create a DC covering all the monitors.
        /// </param>
        /// <param name="pszPort">
        /// This parameter is ignored and should be set to <see langword="null"/>.
        /// It is provided only for compatibility with 16-bit Windows.
        /// </param>
        /// <param name="pdm">
        /// A pointer to a <see cref="DEVMODE"/> structure containing device-specific initialization data for the device driver.
        /// The <see cref="DocumentProperties"/> function retrieves this structure filled in for a specified device.
        /// The <paramref name="pdm"/> parameter must be <see langword="null"/> if the device driver is to use the default initialization
        /// (if any) specified by the user.
        /// If <paramref name="pwszDriver"/> is DISPLAY, <paramref name="pdm"/> must be <see langword="null"/>;
        /// GDI then uses the display device's current <see cref="DEVMODE"/>.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to a DC for the specified device.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// Note that the handle to the DC can only be used by a single thread at any one time.
        /// For parameters <paramref name="pwszDriver"/> and <paramref name="pwszDevice"/>,
        /// call <see cref="EnumDisplayDevices"/> to obtain valid names for displays.
        /// When you no longer need the DC, call the <see cref="DeleteDC"/> function.
        /// If <paramref name="pwszDriver"/> or <paramref name="pwszDevice"/> is DISPLAY,
        /// the thread that calls <see cref="CreateDC"/> owns the HDC that is created.
        /// When this thread is destroyed, the <see cref="HDC"/> is no longer valid.
        /// Thus, if you create the HDC and pass it to another thread, then exit the first thread, the second thread will not be able to use the HDC.
        /// When you call <see cref="CreateDC"/> to create the <see cref="HDC"/> for a display device, you must pass to <paramref name="pdm"/>
        /// either <see langword="null"/> or a pointer to <see cref="DEVMODE"/> that
        /// matches the current <see cref="DEVMODE"/> of the display device that <paramref name="pwszDevice"/> specifies.
        /// We recommend to pass <see langword="null"/> and not to try to exactly match the <see cref="DEVMODE"/> for the current display device.
        /// When you call <see cref="CreateDC"/> to create the <see cref="HDC"/> for a printer device, the printer driver validates the <see cref="DEVMODE"/>.
        /// If the printer driver determines that the <see cref="DEVMODE"/> is invalid (that is, printer driver can’t convert or consume the <see cref="DEVMODE"/>),
        /// the printer driver provides a default <see cref="DEVMODE"/> to create the <see cref="HDC"/> for the printer device.
        /// ICM: To enable ICM, set the <see cref="dmICMMethod"/> member of the <see cref="DEVMODE"/> structure
        /// (pointed to by the <see cref="pInitData"/> parameter) to the appropriate value.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateDCW", SetLastError = true)]
        public static extern HDC CreateDC([MarshalAs(UnmanagedType.LPWStr)][In]string pwszDriver,
            [MarshalAs(UnmanagedType.LPWStr)][In]string pwszDevice, [MarshalAs(UnmanagedType.LPWStr)][In]string pszPort,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<DEVMODE>))][In]StructPointerOrNullObject<DEVMODE> pdm);

        /// <summary>
        /// <para>
        /// The <see cref="CreateIC"/> function creates an information context for the specified device.
        /// The information context provides a fast way to get information about the device without creating a device context (DC).
        /// However, GDI drawing functions cannot accept a handle to an information context.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createicw
        /// </para>
        /// </summary>
        /// <param name="pszDriver">
        /// A pointer to a null-terminated character string that specifies the name of the device driver (for example, Epson).
        /// </param>
        /// <param name="pszDevice">
        /// A pointer to a null-terminated character string that specifies the name of the specific output device being used,
        /// as shown by the Print Manager (for example, Epson FX-80).
        /// It is not the printer model name.
        /// The <paramref name="pszDevice"/> parameter must be used.
        /// </param>
        /// <param name="pszPort">
        /// This parameter is ignored and should be set to <see langword="null"/>.
        /// It is provided only for compatibility with 16-bit Windows.
        /// </param>
        /// <param name="pdm">
        /// A pointer to a <see cref="DEVMODE"/> structure containing device-specific initialization data for the device driver.
        /// The <see cref="DocumentProperties"/> function retrieves this structure filled in for a specified device.
        /// The <see cref="lpdvmInit"/> parameter must be <see langword="null""/> if the device driver is to use the default initialization
        /// (if any) specified by the user.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is the handle to an information context.
        /// If the function fails, the return value is <see cref="NULL"/>.
        /// </returns>
        /// <remarks>
        /// When you no longer need the information DC, call the <see cref="DeleteDC"/> function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateICW", SetLastError = true)]
        public static extern HDC CreateIC([MarshalAs(UnmanagedType.LPWStr)][In]string pszDriver,
            [MarshalAs(UnmanagedType.LPWStr)][In]string pszDevice, [MarshalAs(UnmanagedType.LPWStr)][In]string pszPort,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<DEVMODE>))][In]StructPointerOrNullObject<DEVMODE> pdm);

        /// <summary>
        /// <para>
        /// The <see cref="CreateSolidBrush"/> function creates a logical brush that has the specified solid color.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-createsolidbrush
        /// </para>
        /// </summary>
        /// <param name="color">
        /// The color of the brush. To create a COLORREF color value, use the <see cref="RGB"/> macro.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies a logical brush.
        /// If the function fails, the return value is <see cref="IntPtr.Zero"/>.
        /// </returns>
        /// <remarks>
        /// When you no longer need the HBRUSH object, call the <see cref="DeleteObject"/> function to delete it.
        /// A solid brush is a bitmap that the system uses to paint the interiors of filled shapes.
        /// After an application creates a brush by calling <see cref="CreateSolidBrush"/>,
        /// it can select that brush into any device context by calling the <see cref="SelectObject"/> function.
        /// To paint with a system color brush, an application should use <see cref="GetSysColorBrush"/> (nIndex)
        /// instead of <see cref="CreateSolidBrush"/>(<see cref="GetSysColor"/>(nIndex)),
        /// because <see cref="GetSysColorBrush"/> returns a cached brush instead of allocating a new one.
        /// ICM: No color management is done at brush creation.
        /// However, color management is performed when the brush is selected into an ICM-enabled device context.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateSolidBrush", SetLastError = true)]
        public static extern IntPtr CreateSolidBrush([In]uint color);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteDC"/> function deletes the specified device context (DC).
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-deletedc
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to the device context.</param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteDC", SetLastError = true)]
        public static extern BOOL DeleteDC([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="DeleteObject"/> function deletes a logical pen, brush, font, bitmap, region, or palette, 
        /// freeing all system resources associated with the object.
        /// After the object is deleted, the specified handle is no longer valid.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-deleteobject
        /// </para>
        /// </summary>
        /// <param name="hObject">A handle to a logical pen, brush, font, bitmap, region, or palette.</param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the specified handle is not valid or is currently selected into a DC, the return value is <see langword="false"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeleteObject", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In]IntPtr hObject);

        /// <summary>
        /// <para>
        /// The EnumFonts function enumerates the fonts available on a specified device.
        /// For each font with the specified typeface name, the <see cref="EnumFonts"/> function retrieves information about that font
        /// and passes it to the application defined callback function.
        /// This callback function can process the font information as desired.
        /// Enumeration continues until there are no more fonts or the callback function returns zero.
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context from which to enumerate the fonts.
        /// </param>
        /// <param name="lpLogfont">
        /// A pointer to a null-terminated string that specifies the typeface name of the desired fonts.
        /// If <paramref name="lpLogfont"/> is NULL, <see cref="EnumFonts"/> randomly selects and enumerates one font of each available typeface.
        /// </param>
        /// <param name="lpProc">
        /// A pointer to the application definedcallback function. For more information, see <see cref="FONTENUMPROC"/>.
        /// </param>
        /// <param name="lParam">
        /// A pointer to any application-defined data. The data is passed to the callback function along with the font information.
        /// </param>
        /// <returns>
        /// The return value is the last value returned by the callback function. Its meaning is defined by the application.
        /// </returns>
        /// <remarks>
        /// Use <see cref="EnumFontFamiliesEx"/> instead of <see cref="EnumFonts"/>.
        /// The <see cref="EnumFontFamiliesEx"/> function differs from the <see cref="EnumFonts"/> function in that
        /// it retrieves the style names associated with a TrueType font.
        /// With <see cref="EnumFontFamiliesEx"/>, you can retrieve information about font styles
        /// that cannot be enumerated using the <see cref="EnumFonts"/> function.
        /// The fonts for many East Asian languages have two typeface names: an English name and a localized name.
        /// <see cref="EnumFonts"/>, <see cref="EnumFontFamilies"/>, and <see cref="EnumFontFamiliesEx"/> return the English typeface name 
        /// if the system locale does not match the language of the font.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            " Applications should use the EnumFontFamiliesEx function.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumFontsW", SetLastError = true)]
        public static extern int EnumFonts([In]IntPtr hdc, [MarshalAs(UnmanagedType.LPWStr)][In]string lpLogfont,
            [In]FONTENUMPROC lpProc, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// The <see cref="EnumFontFamilies"/> function enumerates the fonts in a specified font family that are available on a specified device.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-enumfontfamiliesw
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context from which to enumerate the fonts.
        /// </param>
        /// <param name="lpLogfont">
        /// A pointer to a null-terminated string that specifies the family name of the desired fonts.
        /// If <paramref name="lpLogfont"/> is NULL, <see cref="EnumFontFamilies"/> selects and enumerates one font of each available type family.
        /// </param>
        /// <param name="lpProc">
        /// A pointer to the application defined callback function. For information, see <see cref="FONTENUMPROC"/>.
        /// </param>
        /// <param name="lParam">
        /// A pointer to application-supplied data. The data is passed to the callback function along with the font information.
        /// </param>
        /// <returns>
        /// The return value is the last value returned by the callback function. Its meaning is implementation specific.
        /// </returns>
        /// <remarks>
        /// For each font having the typeface name specified by the <paramref name="lpLogfont"/> parameter,
        /// the <see cref="EnumFontFamilies"/> function retrieves information about that font and passes it to the function
        /// pointed to by the <paramref name="lpProc"/> parameter.
        /// The application defined callback function can process the font information as desired.
        /// Enumeration continues until there are no more fonts or the callback function returns zero.
        /// When the graphics mode on the device context is set to ,<see cref="GM_ADVANCED"/> using the <see cref="SetGraphicsMode"/> function
        /// and the <see cref="DEVICE_FONTTYPE"/> flag is passed to the FontType parameter,
        /// this function returns a list of type 1 and OpenType fonts on the system.
        /// When the graphics mode is not set to <see cref="GM_ADVANCED"/>, this function returns a list of type 1,
        /// OpenType, and TrueType fonts on the system.
        /// The fonts for many East Asian languages have two typeface names: an English name and a localized name.
        /// <see cref="EnumFonts"/>, <see cref="EnumFontFamilies"/>, and <see cref="EnumFontFamiliesEx"/> return the English typeface name
        /// if the system locale does not match the language of the font.
        /// </remarks>
        [Obsolete("This function is provided only for compatibility with 16-bit versions of Windows." +
            " Applications should use the EnumFontFamiliesEx function.")]
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumFontFamiliesW", SetLastError = true)]
        public static extern int EnumFontFamilies([In]IntPtr hdc, [MarshalAs(UnmanagedType.LPWStr)][In]string lpLogfont,
            [In]FONTENUMPROC lpProc, [In]IntPtr lParam);

        /// <summary>
        /// <para>
        /// The <see cref="EnumFontFamiliesEx"/> function enumerates all uniquely-named fonts in the system
        /// that match the font characteristics specified by the <see cref="LOGFONT"/> structure.
        /// <see cref="EnumFontFamiliesEx"/> enumerates fonts based on typeface name, character set, or both.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-enumfontfamiliesexw
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context from which to enumerate the fonts.
        /// </param>
        /// <param name="lpLogfont">
        /// A pointer to a <see cref="LOGFONT"/> structure that contains information about the fonts to enumerate.
        /// The function examines the following members.
        /// <see cref="LOGFONT.lfCharSet"/>
        /// If set to <see cref="DEFAULT_CHARSET"/>, the function enumerates all uniquely-named fonts in all character sets.
        /// (If there are two fonts with the same name, only one is enumerated.)
        /// If set to a valid character set value, the function enumerates only fonts in the specified character set.
        /// <see cref="LOGFONT.lfFaceName"/>
        /// If set to an empty string, the function enumerates one font in each available typeface name.
        /// If set to a valid typeface name, the function enumerates all fonts with the specified name.
        /// <see cref="LOGFONT.lfPitchAndFamily"/>
        /// Must be set to zero for all language versions of the operating system.
        /// </param>
        /// <param name="lpProc">
        /// A pointer to the application defined callback function.
        /// For more information, see the <see cref="FONTENUMPROC"/> function.
        /// </param>
        /// <param name="lParam">
        /// An application defined value.
        /// The function passes this value to the callback function along with font information.
        /// </param>
        /// <param name="dwFlags">
        /// This parameter is not used and must be zero.
        /// </param>
        /// <returns>
        /// The return value is the last value returned by the callback function.
        /// This value depends on which font families are available for the specified device.
        /// </returns>
        /// <remarks>
        /// The <see cref="EnumFontFamiliesEx"/> function does not use tagged typeface names to identify character sets.
        /// Instead, it always passes the correct typeface name and a separate character set value to the callback function.
        /// The function enumerates fonts based on the values of
        /// the <see cref="LOGFONT.lfCharSet"/> and <see cref="LOGFONT.lfFaceName"/> members in the <see cref="LOGFONT"/> structure.
        /// As with <see cref="EnumFontFamilies"/>, <see cref="EnumFontFamiliesEx"/> enumerates all font styles.
        /// Not all styles of a font cover the same character sets.
        /// For example, Fontorama Bold might contain ANSI, Greek, and Cyrillic characters, but Fontorama Italic might contain only ANSI characters.
        /// For this reason, it's best not to assume that a specified font covers a specific character set, even if it is the ANSI character set.
        /// The following table shows the results of various combinations of values for <see cref="LOGFONT.lfCharSet"/> and <see cref="LOGFONT.lfFaceName"/>.
        /// <see cref="LOGFONT.lfCharSet"/> = <see cref="DEFAULT_CHARSET"/>
        /// <see cref="LOGFONT.lfFaceName"/> = '\0'
        /// Enumerates all uniquely-named fonts within all character sets.If there are two fonts with the same name, only one is enumerated.
        /// <see cref="LOGFONT.lfCharSet"/> = <see cref="DEFAULT_CHARSET"/>
        /// <see cref="LOGFONT.lfFaceName"/> =  a specific font
        /// Enumerates all character sets and styles in a specific font.
        /// <see cref="LOGFONT.lfCharSet"/> = a specific character set
        /// <see cref="LOGFONT.lfFaceName"/> = '\0'
        /// Enumerates all styles of all fonts in the specific character set.
        /// <see cref="LOGFONT.lfCharSet"/> = a specific character set
        /// <see cref="LOGFONT.lfFaceName"/> =  a specific font
        /// Enumerates all styles of a font in a specific character set.
        /// The following code sample shows how these values are used.
        /// <code>
        /// // To enumerate all styles and charsets of all fonts: 
        /// lf.lfFaceName[0] = '\0';
        /// lf.lfCharSet = DEFAULT_CHARSET;
        /// HRESULT hr;
        /// 
        /// // To enumerate all styles and character sets of the Arial font: 
        /// hr = StringCchCopy((LPSTR) lf.lfFaceName, LF_FACESIZE, "Arial" );
        /// if (FAILED(hr))
        /// {
        ///     // TODO: write error handler 
        /// }
        /// 
        /// lf.lfCharSet = DEFAULT_CHARSET;
        /// </code>
        /// <code>
        /// // To enumerate all styles of all fonts for the ANSI character set 
        /// lf.lfFaceName[0] = '\0';
        /// lf.lfCharSet = ANSI_CHARSET;
        /// 
        /// // To enumerate all styles of Arial font that cover the ANSI charset 
        /// hr = StringCchCopy((LPSTR) lf.lfFaceName, LF_FACESIZE, "Arial" );
        /// if (FAILED(hr))
        /// {
        ///     // TODO: write error handler 
        /// }
        ///     
        /// lf.lfCharSet = ANSI_CHARSET;
        /// </code>
        /// The callback functions for <see cref="EnumFontFamilies"/> and <see cref="EnumFontFamiliesEx"/> are very similar.
        /// The main difference is that the <see cref="ENUMLOGFONTEX"/> structure includes a script field.
        /// Note, based on the values of <see cref="LOGFONT.lfCharSet"/> and <see cref="LOGFONT.lfFaceName"/>,
        /// <see cref="EnumFontFamiliesEx"/> will enumerate the same font as many times as there are distinct character sets in the font.
        /// This can create an extensive list of fonts which can be burdensome to a user.
        /// For example, the Century Schoolbook font can appear for the Baltic, Western, Greek, Turkish, and Cyrillic character sets.
        /// To avoid this, an application should filter the list of fonts.
        /// The fonts for many East Asian languages have two typeface names: an English name and a localized name.
        /// <see cref="EnumFonts"/>, <see cref="EnumFontFamilies"/>, and <see cref="EnumFontFamiliesEx"/> return the English typeface name
        /// if the system locale does not match the language of the font.
        /// When the graphics mode on the device context is set to <see cref="GM_ADVANCED"/> using the <see cref="SetGraphicsMode"/> function
        /// and the <see cref="DEVICE_FONTTYPE"/> flag is passed to the FontType parameter,
        /// this function returns a list of type 1 and OpenType fonts on the system.
        /// When the graphics mode is not set to <see cref="GM_ADVANCED"/>,
        /// this function returns a list of type 1, OpenType, and TrueType fonts on the system.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "EnumFontFamiliesExW", SetLastError = true)]
        public static extern int EnumFontFamiliesEx([In]IntPtr hdc, [In]ref LOGFONT lpLogfont, [In]FONTENUMPROC lpProc,
            [In]IntPtr lParam, [In]uint dwFlags);

        /// <summary>
        /// <para>
        /// The <see cref="ExtTextOut"/> function draws text using the currently selected font, background color, and text color.
        /// You can optionally provide dimensions to be used for clipping, opaquing, or both.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-exttextoutw
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="x">
        /// The x-coordinate, in logical coordinates, of the reference point used to position the string.
        /// </param>
        /// <param name="y">
        /// The y-coordinate, in logical coordinates, of the reference point used to position the string.
        /// </param>
        /// <param name="options">
        /// Specifies how to use the application-defined rectangle.
        /// This parameter can be one or more of the following values.
        /// <see cref="ETO_CLIPPED"/>, <see cref="ETO_GLYPH_INDEX"/>, <see cref="ETO_IGNORELANGUAGE"/>, <see cref="ETO_NUMERICSLATIN"/>,
        /// <see cref="ETO_NUMERICSLOCAL"/>, <see cref="ETO_OPAQUE"/>, <see cref="ETO_PDY"/>, <see cref="ETO_RTLREADING"/>
        /// The <see cref="ETO_GLYPH_INDEX"/> and <see cref="ETO_RTLREADING"/> values cannot be used together.
        /// Because <see cref="ETO_GLYPH_INDEX"/> implies that all language processing has been completed,
        /// the function ignores the <see cref="ETO_RTLREADING"/> flag if also specified.
        /// </param>
        /// <param name="lprect">
        /// A pointer to an optional <see cref="RECT"/> structure that specifies the dimensions, in logical coordinates,
        /// of a rectangle that is used for clipping, opaquing, or both.
        /// </param>
        /// <param name="lpString">
        /// A pointer to a string that specifies the text to be drawn
        /// The string does not need to be zero-terminated, since <paramref name="c"/> specifies the length of the string.
        /// </param>
        /// <param name="c">
        /// The length of the string pointed to by <paramref name="lpString"/>.
        /// This value may not exceed 8192.
        /// </param>
        /// <param name="lpDx">
        /// A pointer to an optional array of values that indicate the distance between origins of adjacent character cells.
        /// For example, lpDx[i] logical units separate the origins of character cell i and character cell i + 1.
        /// </param>
        /// <returns>
        /// If the string is drawn, the return value is <see langword="true"/>.
        /// However, if the ANSI version of <see cref="ExtTextOut"/> is called with <see cref="ETO_GLYPH_INDEX"/>,
        /// the function returns <see langword="true"/> even though the function does nothing.
        /// If the function fails, the return value is <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// The current text-alignment settings for the specified device context determine how the reference point is used to position the text.
        /// The text-alignment settings are retrieved by calling the <see cref="GetTextAlign"/> function.
        /// The text-alignment settings are altered by calling the <see cref="SetTextAlign"/> function.
        /// You can use the following values for text alignment.
        /// Only one flag can be chosen from those that affect horizontal and vertical alignment.
        /// In addition, only one of the two flags that alter the current position can be chosen.
        /// <see cref="TA_BASELINE"/>, <see cref="TA_BOTTOM"/>, <see cref="TA_TOP"/>, <see cref="TA_CENTER"/>, <see cref="TA_LEFT"/>,
        /// <see cref="TA_RIGHT"/>, <see cref="TA_NOUPDATECP"/>, <see cref="TA_RTLREADING"/>, <see cref="TA_UPDATECP"/>
        /// If the <paramref name="lpDx"/> parameter is <see cref="IntPtr.Zero"/>,
        /// the <see cref="ExtTextOut"/> function uses the default spacing between characters.
        /// The character-cell origins and the contents of the array pointed to by the <paramref name="lpDx"/> parameter are specified in logical units.
        /// A character-cell origin is defined as the upper-left corner of the character cell.
        /// By default, the current position is not used or updated by this function.
        /// However, an application can call the <see cref="SetTextAlign"/> function with the fMode parameter set to <see cref="TA_UPDATECP"/>
        /// to permit the system to use and update the current position each time
        /// the application calls <see cref="ExtTextOut"/> for a specified device context.
        /// When this flag is set, the system ignores the X and Y parameters on subsequent <see cref="ExtTextOut"/> calls.
        /// For the ANSI version of <see cref="ExtTextOut"/>, the <paramref name="lpDx"/> array has the same number of INT values
        /// as there are bytes in <paramref name="lpString"/>.
        /// For DBCS characters, you can apportion the dx in the <paramref name="lpDx"/> entries between the lead byte and the trail byte,
        /// as long as the sum of the two bytes adds up to the desired dx.
        /// For DBCS characters with the Unicode version of <see cref="ExtTextOut"/>, each Unicode glyph gets a single pdx entry.
        /// Note, the alpDx values from <see cref="GetTextExtentExPoint"/> are not the same as
        /// the <paramref name="lpDx"/> values for <see cref="ExtTextOut"/>.
        /// To use the alpDx values in <paramref name="lpDx"/>, you must first process them.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "ExtTextOutW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ExtTextOut([In]IntPtr hdc, [In]int x, [In]int y, [In]ExtTextOutFlags options,
            [MarshalAs(UnmanagedType.LPStruct)][In]RECT lprect, [MarshalAs(UnmanagedType.LPWStr)]string lpString, [In]uint c, [In]IntPtr lpDx);

        /// <summary>
        /// <para>
        /// The <see cref="GetBoundsRect"/> function obtains the current accumulated bounding rectangle for a specified device context.
        /// The system maintains an accumulated bounding rectangle for each application. An application can retrieve and set this rectangle.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getboundsrect
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context whose bounding rectangle the function will return.
        /// </param>
        /// <param name="lprect">
        /// A pointer to the <see cref="RECT"/> structure that will receive the current bounding rectangle.
        /// The application's rectangle is returned in logical coordinates, and the bounding rectangle is returned in screen coordinates.
        /// </param>
        /// <param name="flags">
        /// Specifies how the <see cref="GetBoundsRect"/> function will behave. This parameter can be the following value.
        /// <see cref="DCB_RESET"/>: 
        /// Clears the bounding rectangle after returning it.If this flag is not set, the bounding rectangle will not be cleared.
        /// </param>
        /// <returns>
        /// The return value specifies the state of the accumulated bounding rectangle; it can be one of the following values.
        /// 0: An error occurred. The specified device context handle is invalid.
        /// <see cref="DCB_DISABLE"/>: Boundary accumulation is off.
        /// <see cref="DCB_ENABLE"/>: Boundary accumulation is on.
        /// <see cref="DCB_RESET"/>: The bounding rectangle is empty.
        /// <see cref="DCB_SET"/>: The bounding rectangle is not empty.
        /// </returns>
        /// <remarks>
        /// The <see cref="DCB_SET"/> value is a combination of the bit values <see cref="DCB_ACCUMULATE"/> and <see cref="DCB_RESET"/>.
        /// Applications that check the <see cref="DCB_RESET"/> bit to determine whether the bounding rectangle is empty
        /// must also check the <see cref="DCB_ACCUMULATE"/> bit.
        /// The bounding rectangle is empty only if the <see cref="DCB_RESET"/> bit is 1 and the <see cref="DCB_ACCUMULATE"/> bit is 0.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetBoundsRect", SetLastError = true)]
        public static extern UINT GetBoundsRect([In]HDC hdc, [Out]out RECT lprect, [In]BoundsAccumulationFlags flags);

        /// <summary>
        /// <para>
        /// The <see cref="GetMapMode"/> function retrieves the current mapping mode.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getmapmode
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the mapping mode.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The following are the various mapping modes.
        /// <see cref="MM_ANISOTROPIC"/>:
        /// Logical units are mapped to arbitrary units with arbitrarily scaled axes.
        /// Use the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions to specify the units, orientation, and scaling required.
        /// <see cref="MM_HIENGLISH"/>: Each logical unit is mapped to 0.001 inch. Positive x is to the right; positive y is up.
        /// <see cref="MM_HIMETRIC"/>: Each logical unit is mapped to 0.01 millimeter. Positive x is to the right; positive y is up.
        /// <see cref="MM_ISOTROPIC"/>:
        /// Logical units are mapped to arbitrary units with equally scaled axes; that is, one unit along the x-axis is equal to one unit along the y-axis.
        /// Use the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions to specify the units and the orientation of the axes.
        /// Graphics device interface makes adjustments as necessary to ensure the x and y units remain the same size.
        /// (When the windows extent is set, the viewport will be adjusted to keep the units isotropic).
        /// <see cref="MM_LOENGLISH"/>: Each logical unit is mapped to 0.01 inch. Positive x is to the right; positive y is up.
        /// <see cref="MM_LOMETRIC"/>: Each logical unit is mapped to 0.1 millimeter. Positive x is to the right; positive y is up.
        /// <see cref="MM_TEXT"/>: Each logical unit is mapped to one device pixel. Positive x is to the right; positive y is down.
        /// <see cref="MM_TWIPS"/>: 
        /// Each logical unit is mapped to one twentieth of a printer's point (1/1440 inch, also called a "twip").
        /// Positive x is to the right; positive y is up.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMapMode", SetLastError = true)]
        public static extern MappingModes GetMapMode([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="GetBValue"/> macro retrieves an intensity value for the blue component of a red, green, blue (RGB) value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getrvalue
        /// </para>
        /// </summary>
        /// <param name="rgb">
        /// Specifies an RGB color value.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The intensity value is in the range 0 through 255.
        /// </remarks>
        public static byte GetBValue(uint rgb) => (byte)((rgb >> 16) & 0xff);

        /// <summary>
        /// <para>
        /// The <see cref="GetDeviceCaps"/> function retrieves device-specific information for the specified device.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getdevicecaps
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to the DC.</param>
        /// <param name="nIndex">The item to be returned.</param>
        /// <returns>
        /// The return value specifies the value of the desired item.
        /// When <paramref name="nIndex"/> is <see cref="DeviceCapIndexes.BITSPIXEL"/> and the device has 15bpp or 16bpp, the return value is 16.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetDeviceCaps", SetLastError = true)]
        public static extern int GetDeviceCaps([In]IntPtr hdc, [In]DeviceCapIndexes nIndex);

        /// <summary>
        /// <para>
        /// The <see cref="GetGValue"/> macro retrieves an intensity value for the green component of a red, green, blue (RGB) value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getrvalue
        /// </para>
        /// </summary>
        /// <param name="rgb">
        /// Specifies an RGB color value.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The intensity value is in the range 0 through 255.
        /// </remarks>
        public static byte GetGValue(uint rgb) => (byte)((rgb >> 8) & 0xff);

        /// <summary>
        /// <para>
        /// The <see cref="GetRValue"/> macro retrieves an intensity value for the red component of a red, green, blue (RGB) value.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-getrvalue
        /// </para>
        /// </summary>
        /// <param name="rgb">
        /// Specifies an RGB color value.
        /// </param>
        /// <returns></returns>
        /// <remarks>
        /// The intensity value is in the range 0 through 255.
        /// </remarks>
        public static byte GetRValue(uint rgb) => (byte)(rgb & 0xff);

        /// <summary>
        /// <para>
        /// The <see cref="GetTextExtentPoint32"/> function computes the width and height of the specified string of text.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-gettextextentpoint32w
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="lpString">
        /// A pointer to a buffer that specifies the text string.
        /// The string does not need to be null-terminated, because the c parameter specifies the length of the string.
        /// </param>
        /// <param name="c">
        /// The length of the string pointed to by lpString.
        /// </param>
        /// <param name="psizl">
        /// A pointer to a <see cref="SIZE"/> structure that receives the dimensions of the string, in logical units.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see langword="true"/>.
        /// If the function fails, the return value is <see langword="false"/>.
        /// </returns>
        /// <remarks>
        /// The <see cref="GetTextExtentPoint32"/> function uses the currently selected font to compute the dimensions of the string.
        /// The width and height, in logical units, are computed without considering any clipping.
        /// Because some devices kern characters, the sum of the extents of the characters in a string may not be equal to the extent of the string.
        /// The calculated string width takes into account the intercharacter spacing set by the <see cref="SetTextCharacterExtra"/> function
        /// and the justification set by <see cref="SetTextJustification"/>.
        /// This is true for both displaying on a screen and for printing.
        /// However, if lpDx is set in <see cref="ExtTextOut"/>, <see cref="GetTextExtentPoint32"/> does not take into account
        /// either intercharacter spacing or justification.
        /// In addition, for EMF, the print result always takes both intercharacter spacing and justification into account.
        /// When dealing with text displayed on a screen, the calculated string width takes into account the intercharacter spacing set
        /// by the <see cref="SetTextCharacterExtra"/> function and the justification set by <see cref="SetTextJustification"/>.
        /// However, if lpDx is set in <see cref="ExtTextOut"/>, <see cref="GetTextExtentPoint32"/> does not take into account
        /// either intercharacter spacing or justification. However, when printing with EMF:
        /// The print result ignores intercharacter spacing, although <see cref="GetTextExtentPoint32"/> takes it into account.
        /// The print result takes justification into account, although <see cref="GetTextExtentPoint32"/> ignores it.
        /// When this function returns the text extent, it assumes that the text is horizontal, that is, that the escapement is always 0.
        /// This is true for both the horizontal and vertical measurements of the text.
        /// Even if you use a font that specifies a nonzero escapement, this function doesn't use the angle while it computes the text extent.
        /// The app must convert it explicitly.
        /// However, when the graphics mode is set to <see cref="GM_ADVANCED"/> and the character orientation is 90 degrees from the print orientation,
        /// the values that this function return do not follow this rule.
        /// When the character orientation and the print orientation match for a given string,
        /// this function returns the dimensions of the string in the <see cref="SIZE"/> structure as { cx : 116, cy : 18 }.
        /// When the character orientation and the print orientation are 90 degrees apart for the same string,
        /// this function returns the dimensions of the string in the <see cref="SIZE"/> structure as { cx : 18, cy : 116 }.
        /// <see cref="GetTextExtentPoint32"/> doesn't consider "\n" (new line) or "\r\n" (carriage return and new line) characters
        /// when it computes the height of a text string.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetTextExtentPoint32W", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetTextExtentPoint32([In]IntPtr hdc, [MarshalAs(UnmanagedType.LPWStr)][In]string lpString,
            [In] int c, [Out]out SIZE psizl);

        /// <summary>
        /// <para>
        /// The <see cref="RestoreDC"/> function restores a device context (DC) to the specified state.
        /// The DC is restored by popping state information off a stack created by earlier calls to the <see cref="SaveDC"/> function.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-restoredc
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC.
        /// </param>
        /// <param name="nSavedDC">
        /// The saved state to be restored.
        /// If this parameter is positive, <paramref name="nSavedDC"/> represents a specific instance of the state to be restored.
        /// If this parameter is negative, <paramref name="nSavedDC"/> represents an instance relative to the current state.
        /// For example, -1 restores the most recently saved state.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value is <see cref="BOOL.TRUE"/>.
        /// If the function fails, the return value is <see cref="BOOL.FALSE"/>.
        /// </returns>
        /// <remarks>
        /// Each DC maintains a stack of saved states.
        /// The <see cref="SaveDC"/> function pushes the current state of the DC onto its stack of saved states.
        /// That state can be restored only to the same DC from which it was created.
        /// After a state is restored, the saved state is destroyed and cannot be reused.
        /// Furthermore, any states saved after the restored state was created are also destroyed and cannot be used.
        /// In other words, the <see cref="RestoreDC"/> function pops the restored state (and any subsequent states) from the state information stack.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "RestoreDC", SetLastError = true)]
        public static extern BOOL RestoreDC([In]HDC hdc, [In]int nSavedDC);

        /// <summary>
        /// <para>
        /// The <see cref="SaveDC"/> function saves the current state of the specified device context (DC) by copying data describing selected objects
        /// and graphic modes (such as the bitmap, brush, palette, font, pen, region, drawing mode, and mapping mode) to a context stack.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-savedc
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the DC whose state is to be saved.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies the saved state.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The <see cref="SaveDC"/> function can be used any number of times to save any number of instances of the DC state.
        /// A saved state can be restored by using the <see cref="RestoreDC"/> function.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SaveDC", SetLastError = true)]
        public static extern int SaveDC([In]HDC hdc);

        /// <summary>
        /// <para>
        /// The <see cref="SelectObject"/> function selects an object into the specified device context (DC).
        /// The new object replaces the previous object of the same type.
        /// </para> 
        /// <para>
        ///  From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-selectobject
        /// </para>
        /// </summary>
        /// <param name="hdc">A handle to the DC.</param>
        /// <param name="hgdiobj">A handle to the object to be selected.</param>
        /// <returns>
        /// If the selected object is not a region and the function succeeds, the return value is a handle to the object being replaced.
        /// If the selected object is a region and the function succeeds, 
        /// the return value is one of the following values: <see cref="RegionFlags.SIMPLEREGION"/>, <see cref="RegionFlags.COMPLEXREGION"/>,
        /// <see cref="RegionFlags.NULLREGION" />
        /// If an error occurs and the selected object is not a region, the return value is <see cref="IntPtr.Zero"/>.
        /// Otherwise, it is <see cref="HGDI_ERROR"/>.
        /// </returns>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SelectObject", SetLastError = true)]
        public static extern IntPtr SelectObject([In]IntPtr hdc, [In]IntPtr hgdiobj);

        /// <summary>
        /// <para>
        /// The <see cref="SetBoundsRect"/> function controls the accumulation of bounding rectangle information for the specified device context.
        /// The system can maintain a bounding rectangle for all drawing operations.
        /// An application can examine and set this rectangle.
        /// The drawing boundaries are useful for invalidating bitmap caches.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setboundsrect
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context for which to accumulate bounding rectangles.
        /// </param>
        /// <param name="lprect">
        /// A pointer to a <see cref="RECT"/> structure used to set the bounding rectangle.
        /// Rectangle dimensions are in logical coordinates.
        /// This parameter can be <see langword="null"/>.
        /// </param>
        /// <param name="flags">
        /// Specifies how the new rectangle will be combined with the accumulated rectangle.
        /// This parameter can be one of more of the following values.
        /// <see cref="DCB_ACCUMULATE"/>:
        /// Adds the rectangle specified by the <paramref name="lprect"/> parameter to the bounding rectangle (using a rectangle union operation).
        /// Using both <see cref="DCB_RESET"/> and <see cref="DCB_ACCUMULATE"/> sets the bounding rectangle
        /// to the rectangle specified by the <paramref name="lprect"/> parameter.
        /// <see cref="DCB_DISABLE"/>: Turns off boundary accumulation.
        /// <see cref="DCB_ENABLE"/>: Turns on boundary accumulation, which is disabled by default.
        /// <see cref="DCB_RESET"/>: Clears the bounding rectangle.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value specifies the previous state of the bounding rectangle.
        /// This state can be a combination of the following values.
        /// <see cref="DCB_DISABLE"/>: Boundary accumulation is off.
        /// <see cref="DCB_ENABLE"/>: Boundary accumulation is on. <see cref="DCB_ENABLE"/> and <see cref="DCB_DISABLE"/> are mutually exclusive.
        /// <see cref="DCB_RESET"/>: Bounding rectangle is empty.
        /// <see cref="DCB_SET"/>: Bounding rectangle is not empty. <see cref="DCB_SET"/> and <see cref="DCB_RESET"/> are mutually exclusive.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The <see cref="DCB_SET"/> value is a combination of the bit values <see cref="DCB_ACCUMULATE"/> and <see cref="DCB_RESET"/>.
        /// Applications that check the <see cref="DCB_RESET"/> bit to determine whether the bounding rectangle is empty
        /// must also check the <see cref="DCB_ACCUMULATE"/> bit.
        /// The bounding rectangle is empty only if the <see cref="DCB_RESET"/> bit is 1 and the <see cref="DCB_ACCUMULATE"/> bit is 0.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetBoundsRect", SetLastError = true)]
        public static extern BoundsAccumulationFlags SetBoundsRect([In]HDC hdc,
            [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(StructPointerOrNullObjectMarshaler<RECT>))][In]StructPointerOrNullObject<RECT> lprect,
            [In]BoundsAccumulationFlags flags);

        /// <summary>
        /// <para>
        /// The SetMapMode function sets the mapping mode of the specified device context.
        /// The mapping mode defines the unit of measure used to transform page-space units into device-space units,
        /// and also defines the orientation of the device's x and y axes.
        /// </para>
        /// <para>
        /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/wingdi/nf-wingdi-setmapmode
        /// </para>
        /// </summary>
        /// <param name="hdc">
        /// A handle to the device context.
        /// </param>
        /// <param name="iMode">
        /// The new mapping mode. This parameter can be one of the following values.
        /// <see cref="MM_ANISOTROPIC"/>:
        /// Logical units are mapped to arbitrary units with arbitrarily scaled axes.
        /// Use the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions to specify the units, orientation, and scaling.
        /// <see cref="MM_HIENGLISH"/>:
        /// Each logical unit is mapped to 0.001 inch. Positive x is to the right; positive y is up.
        /// <see cref="MM_HIMETRIC"/>:
        /// Each logical unit is mapped to 0.01 millimeter. Positive x is to the right; positive y is up.
        /// <see cref="MM_ISOTROPIC"/>:
        /// Logical units are mapped to arbitrary units with equally scaled axes; that is, one unit along the x-axis is equal to one unit along the y-axis.
        /// Use the <see cref="SetWindowExtEx"/> and <see cref="SetViewportExtEx"/> functions to specify the units and the orientation of the axes.
        /// Graphics device interface (GDI) makes adjustments as necessary to ensure the x and y units remain the same size
        /// (When the window extent is set, the viewport will be adjusted to keep the units isotropic).
        /// <see cref="MM_LOENGLISH"/>:
        /// Each logical unit is mapped to 0.01 inch. Positive x is to the right; positive y is up.
        /// <see cref="MM_LOMETRIC"/>:
        /// Each logical unit is mapped to 0.1 millimeter. Positive x is to the right; positive y is up.
        /// <see cref="MM_TEXT"/>:
        /// Each logical unit is mapped to one device pixel. Positive x is to the right; positive y is down.
        /// <see cref="MM_TWIPS"/>:
        /// Each logical unit is mapped to one twentieth of a printer's point (1/1440 inch, also called a twip). Positive x is to the right; positive y is up.
        /// </param>
        /// <returns>
        /// If the function succeeds, the return value identifies the previous mapping mode.
        /// If the function fails, the return value is zero.
        /// </returns>
        /// <remarks>
        /// The <see cref="MM_TEXT"/> mode allows applications to work in device pixels, whose size varies from device to device.
        /// The <see cref="MM_HIENGLISH"/>, <see cref="MM_HIMETRIC"/>, <see cref="MM_LOENGLISH"/>, <see cref="MM_LOMETRIC"/>,
        /// and <see cref="MM_TWIPS"/> modes are useful for applications drawing in physically meaningful units (such as inches or millimeters).
        /// The <see cref="MM_ISOTROPIC"/> mode ensures a 1:1 aspect ratio.
        /// The <see cref="MM_ANISOTROPIC"/> mode allows the x-coordinates and y-coordinates to be adjusted independently.
        /// </remarks>
        [DllImport("gdi32.dll", CharSet = CharSet.Unicode, EntryPoint = "SetMapMode", SetLastError = true)]
        public static extern int SetMapMode([In]HDC hdc, [In]int iMode);
    }
}
