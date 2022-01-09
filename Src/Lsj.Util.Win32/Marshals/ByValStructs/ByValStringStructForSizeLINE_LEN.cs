using Lsj.Util.IL;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Marshals.ByValStructs
{
    /// <summary>
    /// By Val String Struct For Size <see cref="LINE_LEN"/>
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = LINE_LEN * sizeof(char))]
    public unsafe struct ByValStringStructForSizeLINE_LEN
    {
        char _firstChar;

        /// <inheritdoc/>
        public override string ToString()
        {
            fixed (char* charPtr = &_firstChar)
            {
                return new string(charPtr);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ByValStringStructForSizeLINE_LEN(string val)
        {
            if (val.Length > LINE_LEN - 1)
            {
                throw new ArgumentException("String too long");
            }
            var result = new ByValStringStructForSizeLINE_LEN();
            fixed (char* strPtr = val)
            {
                Unsafe.CopyBlock(&result, strPtr, (uint)(val.Length * sizeof(char)));
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator string(ByValStringStructForSizeLINE_LEN val) => val.ToString();
    }
}
