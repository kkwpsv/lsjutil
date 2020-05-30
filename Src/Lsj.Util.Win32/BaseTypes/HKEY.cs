using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// A handle to a menu.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/winprog/windows-data-types
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HKEY : IPointer
    {
        /// <summary>
        /// HKEY_CLASSES_ROOT
        /// </summary>
        public static readonly HKEY HKEY_CLASSES_ROOT = new HKEY { _value = new IntPtr(unchecked((int)0x80000000)) };

        /// <summary>
        /// HKEY_CURRENT_USER
        /// </summary>
        public static readonly HKEY HKEY_CURRENT_USER = new HKEY { _value = new IntPtr(unchecked((int)0x80000001)) };

        /// <summary>
        /// HKEY_LOCAL_MACHINE
        /// </summary>
        public static readonly HKEY HKEY_LOCAL_MACHINE = new HKEY { _value = new IntPtr(unchecked((int)0x80000002)) };

        /// <summary>
        /// HKEY_USERS
        /// </summary>
        public static readonly HKEY HKEY_USERS = new HKEY { _value = new IntPtr(unchecked((int)0x80000003)) };

        /// <summary>
        /// HKEY_PERFORMANCE_DATA
        /// </summary>
        public static readonly HKEY HKEY_PERFORMANCE_DATA = new HKEY { _value = new IntPtr(unchecked((int)0x80000004)) };

        /// <summary>
        /// HKEY_PERFORMANCE_TEXT
        /// </summary>
        public static readonly HKEY HKEY_PERFORMANCE_TEXT = new HKEY { _value = new IntPtr(unchecked((int)0x80000050)) };

        /// <summary>
        /// HKEY_PERFORMANCE_NLSTEXT
        /// </summary>
        public static readonly HKEY HKEY_PERFORMANCE_NLSTEXT = new HKEY { _value = new IntPtr(unchecked((int)0x80000060)) };

        /// <summary>
        /// HKEY_CURRENT_CONFIG
        /// </summary>
        public static readonly HKEY HKEY_CURRENT_CONFIG = new HKEY { _value = new IntPtr(unchecked((int)0x80000005)) };

        /// <summary>
        /// HKEY_DYN_DATA
        /// </summary>
        public static readonly HKEY HKEY_DYN_DATA = new HKEY { _value = new IntPtr(unchecked((int)0x80000006)) };

        /// <summary>
        /// HKEY_CURRENT_USER_LOCAL_SETTINGS
        /// </summary>
        public static readonly HKEY HKEY_CURRENT_USER_LOCAL_SETTINGS = new HKEY { _value = new IntPtr(unchecked((int)0x80000007)) };

        private HANDLE _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <inheritdoc/>
        public IntPtr ToIntPtr() => _value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HANDLE(HKEY val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HKEY(HANDLE val) => new HKEY { _value = val };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator IntPtr(HKEY val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator HKEY(IntPtr val) => new HKEY { _value = val };
    }
}
