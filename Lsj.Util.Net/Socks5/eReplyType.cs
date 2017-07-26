using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Net.Socks5
{
    public enum ReplyType : byte
    {
        Succeeded = 0x00,
        GeneralFailure,
        NotAllowed,
        NetworkUnreachable,
        HostUnreachable,
        ConnectionRefused,
        TTLExpired,
        CommandNotSupported,
        AddressTypeNotSupported
    }
}
