using Lsj.Util.Win32.DirectX.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.DirectX.BaseTypes
{
    /// <summary>
    /// <para>
    /// An application-defined 64-bit value used to mark a set of rendering operations.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/Direct2D/d2d1-tag"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// To set a tag before a series of rendering operations, use the <see cref="ID2D1RenderTarget.SetTags"/> method.
    /// To retrieve the current tag, use the <see cref="ID2D1RenderTarget.GetTags"/> method.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct D2D1_TAG
    {
        [FieldOffset(0)]
        private ulong _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator ulong(D2D1_TAG val) => val._value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        public static implicit operator D2D1_TAG(ulong val) => new D2D1_TAG { _value = val };
    }
}
