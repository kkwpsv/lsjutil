using Lsj.Util.IL;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Marshals.ByValStringStructs
{
    /// <summary>
    /// By Val String Struct For Size <see cref="MAX_PATH"/>
    /// </summary>
    [DebuggerDisplay("{ToString()}")]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = MAX_PATH * sizeof(char))]
    public unsafe struct ByValStringStructForSizeMAX_PATH
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
        public static implicit operator ByValStringStructForSizeMAX_PATH(string val)
        {
            if (val.Length > MAX_PATH - 1)
            {
                throw new ArgumentException("String too long");
            }
            var result = new ByValStringStructForSizeMAX_PATH();
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
        public static implicit operator string(ByValStringStructForSizeMAX_PATH val) => val.ToString();
    }
}
