using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Net.Async
{
    public interface IStreamProcessor
    {
        void SetFsm(int adder, int muliter);
        void SendTCP(GSPacketIn pkg);
        void ReceiveBytes(int numBytes);
        void Dispose();
    }
}
