using Lsj.Util.IL;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Marshals.ByValStructs
{
    /// <summary>
    /// By Val String Struct For Size 80
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 80 * sizeof(char))]
    public unsafe struct ByValStringStructForSize80
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
        public static implicit operator ByValStringStructForSize80(string val)
        {
            if (val.Length > 80 - 1)
            {
                throw new ArgumentException("String too long");
            }
            var result = new ByValStringStructForSize80();
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
        public static implicit operator string(ByValStringStructForSize80 val) => val.ToString();
    }
}
