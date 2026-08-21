using System;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPointer
    {
        /// <summary>
        /// To <see cref="IntPtr"/>
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        IntPtr ToIntPtr();

        /// <summary>
        /// To <see cref="nint"/>
        /// </summary>
        /// <returns></returns>
        nint ToNint();
    }
}
