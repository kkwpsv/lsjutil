using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Win32.NativeUI.Dialogs
{
    /// <summary>
    /// File Type Item for <see cref="FileDialog"/>
    /// </summary>
    public class FileDialogFileTypeItem
    {
        /// <summary>
        /// Name
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Pattern
        /// Like *.bmp;*.jpg
        /// </summary>
        public string? Pattern { get; set; }
    }
}
