using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Socks5
{
    /// <summary>
    /// Reply Type
    /// </summary>
    public enum ReplyType : byte
    {
        /// <summary>
        /// Succeeded
        /// </summary>
        Succeeded = 0x00,
        /// <summary>
        /// GeneralFailu
        /// </summary>
        GeneralFailure,
        /// <summary>
        /// NotAllowed
        /// </summary>
        NotAllowed,
        /// <summary>
        /// NetworkUnreachable
        /// </summary>
        NetworkUnreachable,
        /// <summary>
        /// HostUnreachable
        /// </summary>
        HostUnreachable,
        /// <summary>
        /// ConnectionRefused
        /// </summary>
        ConnectionRefused,
        /// <summary>
        /// TTLExpired
        /// </summary>
        TTLExpired,
        /// <summary>
        /// CommandNotSupported
        /// </summary>
        CommandNotSupported,
        /// <summary>
        /// AddressTypeNotSupported
        /// </summary>
        AddressTypeNotSupported
    }
}
