using Lsj.Util.Logs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lsj.Util.Net.Async
{
    public class StreamProcessor : IStreamProcessor
    {
        private Log log;
        protected readonly TcpAsyncClient m_client;
        private FSM send_fsm;
        private FSM receive_fsm;
        private SocketAsyncEventArgs send_event;
        protected byte[] m_tcpSendBuffer;
        protected Queue m_tcpQueue;
        protected bool m_sendingTcp;
        protected int m_firstPkgOffset = 0;
        private int m_lastSent = 0;
        public StreamProcessor(TcpAsyncClient client,Log log)
        {
            this.m_client = client;
            this.m_tcpSendBuffer = client.SendBuffer;
            this.m_tcpQueue = new Queue(256);
            this.send_event = new SocketAsyncEventArgs();
            this.send_event.UserToken = this;
            this.send_event.Completed += AsyncTcpSendCallback;
            this.send_event.SetBuffer(this.m_tcpSendBuffer, 0, 0);
            this.send_fsm = new FSM(2059198199, 1501, "send_fsm");
            this.receive_fsm = new FSM(2059198199, 1501, "receive_fsm");
        }




        public void SetFsm(int adder, int muliter)
        {
            this.send_fsm.Setup(adder, muliter);
            this.receive_fsm.Setup(adder, muliter);
        }
        public void SendTCP(GSPacketIn packet)
        {
            if (packet.Length > packet.Buffer.Length)
            {
                throw new Exception(Marshal.ToHexDump(string.Format("Error package:  buffer:{0}     length:{1}", packet.Buffer.Length, packet.Length), packet.Buffer, 0, (packet.Buffer.Length > 128) ? 128 : packet.Buffer.Length));
            }
            packet.WriteHeader();
            packet.Offset = 0;
            if (this.m_client.Socket.Connected)
            {
                try
                {
                    Statistics.BytesOut += (long)packet.Length;
                    Statistics.PacketsOut += 1L;
                    if (StreamProcessor.log.IsDebugEnabled)
                    {
                        //StreamProcessor.log.Debug(Marshal.ToHexDump(string.Format("Send Pkg to {0} :", this.m_client.TcpEndpoint), packet.Buffer, 0, packet.Length));
                        // StreamProcessor.log.Debug(string.Format("Send Pkg to {0} :", this.m_client.TcpEndpoint));
                    }
                    object syncRoot;
                    Monitor.Enter(syncRoot = this.m_tcpQueue.SyncRoot);
                    try
                    {
                        this.m_tcpQueue.Enqueue(packet);
                        if (this.m_sendingTcp)
                        {
                            return;
                        }
                        this.m_sendingTcp = true;
                    }
                    finally
                    {
                        Monitor.Exit(syncRoot);
                    }
                    this.m_firstPkgOffset = 0;
                    if (this.m_client.AsyncPostSend)
                    {
                        ThreadPool.QueueUserWorkItem(new WaitCallback(StreamProcessor.AsyncSendTcpImp), this);
                    }
                    else
                    {
                        StreamProcessor.AsyncTcpSendCallback(this, this.send_event);
                    }
                }
                catch (Exception e)
                {
                    StreamProcessor.log.Error("SendTCP", e);
                    StreamProcessor.log.WarnFormat("It seems <{0}> went linkdead. Closing connection. (SendTCP, {1}: {2})", this.m_client, e.GetType(), e.Message);
                    this.m_client.Disconnect();
                }
            }
        }
        private static void AsyncSendTcpImp(object state)
        {
            StreamProcessor proc = state as StreamProcessor;
            BaseClient client = proc.m_client;
            try
            {
                StreamProcessor.AsyncTcpSendCallback(proc, proc.send_event);
            }
            catch (Exception ex)
            {
                StreamProcessor.log.Error("AsyncSendTcpImp", ex);
                client.Disconnect();
            }
        }
        private static void AsyncTcpSendCallback(object sender, SocketAsyncEventArgs e)
        {
            StreamProcessor proc = (StreamProcessor)e.UserToken;
            BaseClient client = proc.m_client;
            Queue q = proc.m_tcpQueue;
            if (q != null && client.Socket.Connected)
            {
                int plen = 0;
                int blen = 0;
                int count = 0;
                int firstOffset = 0;
                int sent = e.BytesTransferred;
                byte[] data = proc.m_tcpSendBuffer;
                try
                {
                    if (e.Count != 0 && e.Count != sent && e.SocketError == SocketError.Success)
                    {
                        if (e.Count > sent)
                        {
                            count = e.Count - sent;
                            Array.Copy(data, sent, data, 0, count);
                        }
                    }
                    proc.m_lastSent = e.BytesTransferred;
                    e.SetBuffer(0, 0);
                    object syncRoot;
                    Monitor.Enter(syncRoot = q.SyncRoot);
                    try
                    {
                        firstOffset = proc.m_firstPkgOffset;
                        if (q.Count > 0)
                        {
                            do
                            {
                                PacketIn pak = (PacketIn)q.Peek();
                                plen = pak.Length;
                                blen = pak.Buffer.Length;
                                int len;
                                if (client.Encryted)
                                {
                                    int key = proc.send_fsm.getState();
                                    len = pak.CopyTo(data, count, firstOffset, key + firstOffset);
                                }
                                else
                                {
                                    len = pak.CopyTo(data, count, firstOffset);
                                }
                                firstOffset += len;
                                count += len;
                                if (pak.Length <= firstOffset)
                                {
                                    q.Dequeue();
                                    firstOffset = 0;
                                    if (client.Encryted)
                                    {
                                        proc.send_fsm.UpdateState();
                                    }
                                }
                                if (data.Length == count)
                                {
                                    break;
                                }
                            }
                            while (q.Count > 0);
                        }
                        proc.m_firstPkgOffset = firstOffset;
                        if (count <= 0)
                        {
                            proc.m_sendingTcp = false;
                            return;
                        }
                    }
                    finally
                    {
                        Monitor.Exit(syncRoot);
                    }
                    e.SetBuffer(0, count);
                    e.SocketError = SocketError.SocketError;
                    int start = Environment.TickCount;
                    //if (StreamProcessor.log.IsDebugEnabled)
                    //{
                    //StreamProcessor.log.Debug(string.Format("Send To ({0}) {1} bytes", client.TcpEndpoint, e.Count));
                    //}
                    if (!client.Socket.SendAsync(e))
                    {
                        e.SetBuffer(0, 0);
                        StreamProcessor.AsyncTcpSendCallback(sender, e);
                    }
                    int took = Environment.TickCount - start;
                    if (took > 100)
                    {
                        StreamProcessor.log.WarnFormat("AsyncTcpSendCallback.BeginSend took {0}ms! (TCP to client: {1})", took, client.TcpEndpoint);
                    }
                }
                catch (Exception ex)
                {
                    StreamProcessor.log.Error("AsyncTcpSendCallback", ex);
                    StreamProcessor.log.ErrorFormat("First_offset:{0},Count:{1},data:{2},package len:{3} buffer len:{4}", new object[]
                    {
                        firstOffset,
                        count,
                        data.Length,
                        plen,
                        blen
                    });
                    StreamProcessor.log.WarnFormat("It seems <{0}> went linkdead. Closing connection. (SendTCP, {1}: {2})", client, ex.GetType(), ex.Message);
                    client.Disconnect();
                }
            }
        }




        public void ReceiveBytes(int numBytes)
        {
            Monitor.Enter(this);
            try
            {
                int bufferSize = this.m_client.PacketBufSize + numBytes;
                if (bufferSize < (int)GSPacketIn.HDR_SIZE)
                {
                    this.m_client.PacketBufSize = bufferSize;
                }
                else
                {
                    byte[] buffer = this.m_client.PacketBuf;
                    if (bufferSize > buffer.Length)
                    {
                        StreamProcessor.log.ErrorFormat("Error Buffersize: num {0}   buffersize:{1}  old buffer size:{2} buffer length:{3}", new object[]
                        {
                            numBytes,
                            bufferSize,
                            this.m_client.PacketBufSize,
                            buffer.Length
                        });
                        bufferSize = buffer.Length;
                    }
                    this.m_client.PacketBufSize = 0;
                    int curOffset = 0;
                    int dataleft = bufferSize;
                    while (dataleft >= (int)GSPacketIn.HDR_SIZE && curOffset >= 0)
                    {
                        int packetLength = 0;
                        if (this.m_client.Encryted)
                        {
                            int key = this.receive_fsm.getState();
                            int i = this.receive_fsm.count;
                            while (curOffset + 4 <= bufferSize)
                            {
                                int header = ((int)((byte)((int)buffer[curOffset] ^ (key++ & 16711680) >> 16)) << 8) + (int)((byte)((int)buffer[curOffset + 1] ^ (key++ & 16711680) >> 16));
                                if (header == (int)GSPacketIn.HEADER)
                                {
                                    packetLength = ((int)((byte)((int)buffer[curOffset + 2] ^ (key++ & 16711680) >> 16)) << 8) + (int)((byte)((int)buffer[curOffset + 3] ^ (key++ & 16711680) >> 16));
                                    break;
                                }
                                curOffset++;
                            }
                        }
                        else
                        {
                            while (curOffset + 4 <= bufferSize)
                            {
                                int header = ((int)buffer[curOffset] << 8) + (int)buffer[curOffset + 1];
                                if (header == (int)GSPacketIn.HEADER)
                                {
                                    packetLength = ((int)buffer[curOffset + 2] << 8) + (int)buffer[curOffset + 3];
                                    break;
                                }
                                curOffset++;
                            }
                        }
                        dataleft = bufferSize - curOffset;
                        if (packetLength < (int)GSPacketIn.HDR_SIZE || packetLength > buffer.Length)
                        {
                            StreamProcessor.log.Error(string.Concat(new object[]
                            {
                                "packetLength:",
                                packetLength,
                                ",GSPacketIn.HDR_SIZE:",
                                GSPacketIn.HDR_SIZE,
                                ",offset:",
                                curOffset,
                                ",bufferSize:",
                                bufferSize,
                                ",numBytes:",
                                numBytes
                            }));
                            StreamProcessor.log.ErrorFormat("Err pkg from {0}:", this.m_client.TcpEndpoint);
                            StreamProcessor.log.Error(Marshal.ToHexDump("===> error buffer", buffer, curOffset, (dataleft > 48) ? 48 : dataleft));
                            if (this.m_client.Strict && packetLength != 0)
                            {
                                StreamProcessor.log.Error("Disconnect the client in [Strict] mode.");
                                this.m_client.PacketBufSize = 0;
                                this.m_client.Disconnect();
                                return;
                            }
                            curOffset += 2;
                            dataleft = bufferSize - curOffset;
                        }
                        else
                        {
                            if (dataleft < packetLength)
                            {
                                break;
                            }
                            int size = (packetLength <= 1024) ? 1024 : packetLength;
                            GSPacketIn pkg = new GSPacketIn(new byte[size], size);
                            if (this.m_client.Encryted)
                            {
                                pkg.CopyFrom(buffer, curOffset, 0, packetLength, this.receive_fsm.getState());
                                this.receive_fsm.UpdateState();
                            }
                            else
                            {
                                pkg.CopyFrom(buffer, curOffset, 0, packetLength);
                            }
                            pkg.ReadHeader();
                            if (pkg.CheckSum == pkg.CalculateChecksum())
                            {
                                pkg.ClearChecksum();
                                //if (StreamProcessor.log.IsDebugEnabled)
                                //{
                                //StreamProcessor.log.Debug(Marshal.ToHexDump("Recieve Packet:", pkg.Buffer, 0, packetLength));
                                //}
                                try
                                {
                                    //StreamProcessor.log.Debug("Receive Packet!");
                                    this.m_client.OnRecvPacket(pkg);
                                }
                                catch (Exception e)
                                {
                                    if (StreamProcessor.log.IsErrorEnabled)
                                    {
                                        StreamProcessor.log.Error("HandlePacket(pak)", e);
                                    }
                                }
                                curOffset += packetLength;
                                dataleft = bufferSize - curOffset;
                            }
                            else
                            {
                                curOffset += 2;
                                dataleft = bufferSize - curOffset;
                            }
                        }
                    }
                    if (dataleft > 0)
                    {
                        Array.Copy(buffer, curOffset, buffer, 0, dataleft);
                        this.m_client.PacketBufSize = dataleft;
                    }
                }
            }
            finally
            {
                Monitor.Exit(this);
            }
        }
        public void Dispose()
        {
            this.send_event.Dispose();
            this.m_tcpQueue.Clear();
        }
    }
}
