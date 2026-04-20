namespace Lsj.Util.Win32.DirectX.Enums
{
    /// <summary>
    /// <para>
    /// This document lists the error codes used by Direct2D.
    /// The Direct2D Error Handling Policies topic has more info on handling errors like these.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/direct2d/direct2d-error-codes"/>
    /// </para>
    /// </summary>
    public enum D2DERR : uint
    {
        /// <summary>
        /// A presentation error has occurred that may be recoverable.
        /// The caller needs to re-create the render target then attempt to render the frame again.
        /// </summary>
        D2DERR_RECREATE_TARGET = 0x8899000C,
    }
}
