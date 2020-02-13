using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lsj.Util.Win32.Marshals
{
    /// <summary>
    /// String Handle
    /// </summary>
    public class StringHandle : CriticalHandle
    {
        private bool _needRelease = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public StringHandle(IntPtr val) : this(val, true)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <param name="needRelease"></param>
        public StringHandle(IntPtr val, bool needRelease) : base(val)
        {
            _needRelease = needRelease;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public StringHandle(string val) : this(val, true)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <param name="needRelease"></param>
        public StringHandle(string val, bool needRelease) : base(IntPtr.Zero)
        {
            if (val != null)
            {
                SetHandle(Marshal.StringToHGlobalUni(val));
                _needRelease = needRelease;
            }
        }

        /// <summary>
        /// IsRelease
        /// </summary>
        public override bool IsInvalid => IsClosed;

        /// <summary>
        /// String Val
        /// </summary>
        public string StringVal => handle != IntPtr.Zero ? Marshal.PtrToStringUni(handle) : null;

        internal IntPtr InternalGetHandle() => handle;

        /// <summary>
        /// Release Handle
        /// </summary>
        /// <returns></returns>
        protected override bool ReleaseHandle()
        {
            if (handle != IntPtr.Zero)
            {
                if (_needRelease)
                {
                    Marshal.FreeHGlobal(handle);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator StringHandle(string val) => new StringHandle(val);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator StringHandle(IntPtr val) => new StringHandle(val);
    }
}
