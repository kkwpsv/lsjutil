using Lsj.Util.Dynamic;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;


namespace Lsj.Util.WPF.Dialogs
{
    /// <summary>
    /// Font Dialog
    /// </summary>
    public class FontDialog
    {
        [Flags]
        enum CHOOSEFONTFLAGS
        {
            CF_SCREENFONTS = 0x00000001,
            CF_PRINTERFONTS = 0x00000002,
            CF_BOTH = (CF_SCREENFONTS | CF_PRINTERFONTS),
            CF_SHOWHELP = 0x00000004,
            CF_ENABLEHOOK = 0x00000008,
            CF_ENABLETEMPLATE = 0x00000010,
            CF_ENABLETEMPLATEHANDLE = 0x00000020,
            CF_INITTOLOGFONTSTRUCT = 0x00000040,
            CF_USESTYLE = 0x00000080,
            CF_EFFECTS = 0x00000100,
            CF_APPLY = 0x00000200,
            CF_ANSIONLY = 0x00000400,
            CF_SCRIPTSONLY = CF_ANSIONLY,
            CF_NOVECTORFONTS = 0x00000800,
            CF_NOOEMFONTS = CF_NOVECTORFONTS,
            CF_NOSIMULATIONS = 0x00001000,
            CF_LIMITSIZE = 0x00002000,
            CF_FIXEDPITCHONLY = 0x00004000,
            CF_WYSIWYG = 0x00008000,
            CF_FORCEFONTEXIST = 0x00010000,
            CF_SCALABLEONLY = 0x00020000,
            CF_TTONLY = 0x00040000,
            CF_NOFACESEL = 0x00080000,
            CF_NOSTYLESEL = 0x00100000,
            CF_NOSIZESEL = 0x00200000,
            CF_SELECTSCRIPT = 0x00400000,
            CF_NOSCRIPTSEL = 0x00800000,
            CF_NOVERTFONTS = 0x01000000,
            CF_INACTIVEFONTS = 0x02000000
        }
        enum FontCharSet : byte
        {
            ANSI_CHARSET = 0,
            DEFAULT_CHARSET = 1,
            SYMBOL_CHARSET = 2,
            SHIFTJIS_CHARSET = 128,
            HANGEUL_CHARSET = 129,
            HANGUL_CHARSET = 129,
            GB2312_CHARSET = 134,
            CHINESEBIG5_CHARSET = 136,
            OEM_CHARSET = 255,
            JOHAB_CHARSET = 130,
            HEBREW_CHARSET = 177,
            ARABIC_CHARSET = 178,
            GREEK_CHARSET = 161,
            TURKISH_CHARSET = 162,
            VIETNAMESE_CHARSET = 163,
            THAI_CHARSET = 222,
            EASTEUROPE_CHARSET = 238,
            RUSSIAN_CHARSET = 204,
            MAC_CHARSET = 77,
            BALTIC_CHARSET = 186,
        }
        enum FontPrecision : byte
        {
            OUT_DEFAULT_PRECIS = 0,
            OUT_STRING_PRECIS = 1,
            OUT_CHARACTER_PRECIS = 2,
            OUT_STROKE_PRECIS = 3,
            OUT_TT_PRECIS = 4,
            OUT_DEVICE_PRECIS = 5,
            OUT_RASTER_PRECIS = 6,
            OUT_TT_ONLY_PRECIS = 7,
            OUT_OUTLINE_PRECIS = 8,
            OUT_SCREEN_OUTLINE_PRECIS = 9,
            OUT_PS_ONLY_PRECIS = 10,
        }
        enum FontClipPrecision : byte
        {
            CLIP_DEFAULT_PRECIS = 0,
            CLIP_CHARACTER_PRECIS = 1,
            CLIP_STROKE_PRECIS = 2,
            CLIP_MASK = 0xf,
            CLIP_LH_ANGLES = (1 << 4),
            CLIP_TT_ALWAYS = (2 << 4),
            CLIP_DFA_DISABLE = (4 << 4),
            CLIP_EMBEDDED = (8 << 4),
        }
        enum FontQuality : byte
        {
            DEFAULT_QUALITY = 0,
            DRAFT_QUALITY = 1,
            PROOF_QUALITY = 2,
            NONANTIALIASED_QUALITY = 3,
            ANTIALIASED_QUALITY = 4,
            CLEARTYPE_QUALITY = 5,
            CLEARTYPE_NATURAL_QUALITY = 6,
        }
        [Flags]
        enum FontPitchAndFamily : byte
        {
            DEFAULT_PITCH = 0,
            FIXED_PITCH = 1,
            VARIABLE_PITCH = 2,
            FF_DONTCARE = (0 << 4),
            FF_ROMAN = (1 << 4),
            FF_SWISS = (2 << 4),
            FF_MODERN = (3 << 4),
            FF_SCRIPT = (4 << 4),
            FF_DECORATIVE = (5 << 4),
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct ChooseFontStruct
        {
            public int lStructSize;
            public IntPtr hwndOwner;
            public IntPtr hDC;
            public IntPtr lpLogFont;
            public int iPointSize;
            public int Flags;
            public int rgbColors;
            public int lCustData;
            public int lpfnHook;
            public string lpTemplateName;
            public IntPtr hInstance;
            public string lpszStyle;
            public short nFontType;
            public short __MISSING_ALIGNMENT__;
            public int nSizeMin;
            public int nSizeMax;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        struct LogFontStruct
        {
            public int lfHeight;
            public int lfWidth;
            public int lfEscapement;
            public int lfOrientation;
            public int lfWeight;
            [MarshalAs(UnmanagedType.U1)]
            public bool lfItalic;
            [MarshalAs(UnmanagedType.U1)]
            public bool lfUnderline;
            [MarshalAs(UnmanagedType.U1)]
            public bool lfStrikeOut;
            public FontCharSet lfCharSet;
            public FontPrecision lfOutPrecision;
            public FontClipPrecision lfClipPrecision;
            public FontQuality lfQuality;
            public FontPitchAndFamily lfPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string lfFaceName;
        }
        [DllImport("comdlg32.dll", CharSet = CharSet.Auto, EntryPoint = "ChooseFont")]
        private static extern bool ChooseFont(IntPtr lpcf);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        /// <summary>
        /// Font Family
        /// </summary>
        public FontFamily FontFamily { get; set; } = new FontFamily("微软雅黑");
        /// <summary>
        /// Font Style
        /// </summary>
        public FontStyle FontStyle { get; set; } = FontStyles.Normal;
        /// <summary>
        /// Font Size
        /// </summary>
        public double FontSize { get; set; } = 20;
        /// <summary>
        /// Font Weight
        /// </summary>
        public FontWeight FontWeight { get; set; } = FontWeights.Regular;

        /// <summary>
        /// ShowDialog
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public bool ShowDialog(Window owner = null)
        {
            var hDC = GetDC(IntPtr.Zero);
            var logFontStruct = new LogFontStruct
            {
                lfFaceName = FontFamily.Source,
                lfItalic = FontStyle == FontStyles.Italic,
                lfHeight = (int)(-FontSize * GetDeviceCaps(hDC, 90) / 72),
                lfWeight = FontWeight.ToOpenTypeWeight(),
                lfCharSet = FontCharSet.DEFAULT_CHARSET,
            };
            var ptrLogFontStruct = Marshal.AllocHGlobal(Marshal.SizeOf(logFontStruct));
            Marshal.StructureToPtr(logFontStruct, ptrLogFontStruct, false);

            var chooseFontStruct = new ChooseFontStruct
            {
                lStructSize = Marshal.SizeOf(typeof(ChooseFontStruct)),
                hDC = hDC,
                hwndOwner = owner != null ? new WindowInteropHelper(owner).Handle : IntPtr.Zero,
                Flags = (int)CHOOSEFONTFLAGS.CF_SCREENFONTS
                      | (int)CHOOSEFONTFLAGS.CF_FORCEFONTEXIST
                      | (int)CHOOSEFONTFLAGS.CF_INITTOLOGFONTSTRUCT
                      | (int)CHOOSEFONTFLAGS.CF_SCALABLEONLY
                      | (int)CHOOSEFONTFLAGS.CF_NOVERTFONTS
                      | (int)CHOOSEFONTFLAGS.CF_SELECTSCRIPT,
                lpLogFont = ptrLogFontStruct
            };

            var ptrChooseFontStruct = Marshal.AllocHGlobal(Marshal.SizeOf(chooseFontStruct));
            Marshal.StructureToPtr(chooseFontStruct, ptrChooseFontStruct, false);

            try
            {
                if (!ChooseFont(ptrChooseFontStruct))
                {
                    return false;
                }
                chooseFontStruct = Marshal.PtrToStructure(ptrChooseFontStruct, typeof(ChooseFontStruct)).Cast<ChooseFontStruct>();
                logFontStruct = Marshal.PtrToStructure(chooseFontStruct.lpLogFont, typeof(LogFontStruct)).Cast<LogFontStruct>();
                this.FontFamily = new FontFamily(logFontStruct.lfFaceName);
                this.FontStyle = logFontStruct.lfItalic ? FontStyles.Italic : FontStyles.Normal;
                this.FontSize = -logFontStruct.lfHeight * 72 / GetDeviceCaps(hDC, 90);
                this.FontWeight = FontWeight.FromOpenTypeWeight(logFontStruct.lfWeight);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Marshal.FreeHGlobal(ptrLogFontStruct);
                Marshal.FreeHGlobal(ptrChooseFontStruct);
            }
        }
    }
}
