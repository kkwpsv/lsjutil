using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.OleAut32;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// <para>
    /// A BSTR is a pointer to a null-terminated character string in which the string length is stored with the string.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-dtyp/692a42a9-06ce-4394-b9bc-5d2a50440168"/>
    /// </para>
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
        /// <param name="needFinalize"></param>
        public BSTR(IntPtr handle, bool needFinalize = false) : base(IntPtr.Zero)
        {
            SetHandle(handle);
            if (!needFinalize)
            {
                GC.SuppressFinalize(this);
            }
        }

        private BSTR() : base(IntPtr.Zero)
        {

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
