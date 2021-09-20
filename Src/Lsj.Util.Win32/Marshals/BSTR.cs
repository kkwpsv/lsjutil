using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.OleAut32;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// BSTR
    /// </summary>
    public class BSTR : CriticalHandle
    {
        IntPtr _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public BSTR(string str) : base(IntPtr.Zero)
        {
            if (str != null)
            {
                _value = SysAllocString(str);
                SetHandle(_value);
            }
            else
            {
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handle"></param>
        public BSTR(IntPtr handle) : base(IntPtr.Zero)
        {
            SetHandle(handle);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public override bool IsInvalid => IsClosed;

        /// <inheritdoc/>
        protected override bool ReleaseHandle()
        {
            if (_value != NULL)
            {
                SysFreeString(_value);
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator BSTR(string val) => new BSTR(val);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator BSTR(IntPtr val) => new BSTR(val);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(BSTR val) => val.handle;
    }
}
