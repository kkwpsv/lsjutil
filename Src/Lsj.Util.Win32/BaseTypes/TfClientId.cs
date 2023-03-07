using Lsj.Util.Win32.ComInterfaces;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.BaseTypes
{
    /// <summary>
    /// <para>
    /// The <see cref="TfClientId"/> data type is used to identify the client.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/tsf/tfclientid"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// Within TSF, applications and text services are generally referred to as clients.
    /// Each client receives a unique identifier that it uses to identify itself when calling various TSF manager methods.
    /// This identifier is of the <see cref="TfClientId"/> type.
    /// The <see cref="TfClientId"/> data type is supplied by the TSF manager.
    /// An application obtains a <see cref="TfClientId"/> value when it calls <see cref="ITfThreadMgr.Activate"/>.
    /// The <see cref="TfClientId"/> value for a text service is passed to the <see cref="ITfTextInputProcessor.Activate"/> method.
    /// Any object that does not fit the above categories can obtain a client identifier by calling <see cref="ITfClientId.GetClientId"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Explicit, Size = 4)]
    public struct TfClientId
    {
        [FieldOffset(0)]
        private uint _value;

        /// <inheritdoc/>
        public override string ToString() => _value.ToString();
    }
}
