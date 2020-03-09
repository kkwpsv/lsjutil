using Lsj.Util.Win32.Structs;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Comdlg32;

namespace Lsj.Util.Win32.NativeUI.Dialogs
{
    /// <summary>
    /// Font Dialog
    /// </summary>
    public class FontDialog : BaseDialog<LOGFONT>
    {
        /// <summary>
        /// Set if you want use custom <see cref="CHOOSEFONT"/>
        /// </summary>
        public CHOOSEFONT? CHOOSEFONT { get; set; }

        bool _needReleaseLogFont = false;

        /// <summary>
        /// Ensure <see cref="CHOOSEFONT"/>
        /// </summary>
        /// <param name="owner"></param>
        protected virtual void EnsureCHOOSEFONT(IntPtr owner)
        {
            if (CHOOSEFONT == null)
            {
                _needReleaseLogFont = false;
                CHOOSEFONT = new CHOOSEFONT
                {
                    lStructSize = (uint)Marshal.SizeOf(typeof(CHOOSEFONT)),
                    hwndOwner = owner,
                };
            }
        }

        /// <summary>
        /// Show Dialog
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public override ShowDialogResult ShowDialog(IntPtr owner)
        {
            EnsureCHOOSEFONT(owner);
            var chooseFont = CHOOSEFONT.Value;
            try
            {
                if (!ChooseFont(ref chooseFont))
                {
                    return ShowDialogResult.Cancel;
                }
#if NET40 || NET45
                var logFontStruct = (LOGFONT)Marshal.PtrToStructure(chooseFont.lpLogFont, typeof(LOGFONT));
#else
                var logFontStruct = Marshal.PtrToStructure<LOGFONT>(chooseFont.lpLogFont);
#endif
                Result = logFontStruct;
                return ShowDialogResult.OK;
            }
            finally
            {
                if (_needReleaseLogFont)
                {
                    Marshal.FreeHGlobal(chooseFont.lpLogFont);
                }
            }
        }
    }
}
