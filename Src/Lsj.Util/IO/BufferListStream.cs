using System;
using System.Collections.Concurrent;
using System.IO;

namespace Lsj.Util.IO
{
    /// <summary>
    /// A Stream that write and read once buffer list.
    /// </summary>
    public class BufferListStream : Stream
    {
        private int _currentBufferPos = 0;

        public ConcurrentQueue<byte[]> _buffers = new ConcurrentQueue<byte[]>();

        /// <summary>
        /// 
        /// </summary>
        public BufferListStream()
        {

        }

        /// <inheritdoc/>
        public override bool CanRead => true;

        /// <inheritdoc/>
        public override bool CanSeek => false;

        /// <inheritdoc/>
        public override bool CanWrite => true;

        /// <inheritdoc/>
        public override long Length => throw new NotSupportedException();

        /// <inheritdoc/>
        public override long Position { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }

        /// <inheritdoc/>
        public override void Flush()
        {
        }

        private object _readLockObject = new object();
        /// <inheritdoc/>
        public override int Read(byte[] buffer, int offset, int count)
        {
            lock (_readLockObject)
            {
                var write = 0;
                while (count > 0 && _buffers.TryPeek(out var bufferToRead))
                {
                    var avaliable = bufferToRead.Length - _currentBufferPos;
                    if (avaliable > count)
                    {
                        UnsafeHelper.Copy(bufferToRead, _currentBufferPos, buffer, offset, count);
                        write += count;
                        offset += count;
                        count -= count;
                        _currentBufferPos += count;
                    }
                    else
                    {
                        UnsafeHelper.Copy(bufferToRead, _currentBufferPos, buffer, offset, avaliable);
                        write += avaliable;
                        offset += avaliable;
                        count -= avaliable;
                        _currentBufferPos = 0;
                        _buffers.TryDequeue(out _);
                    }
                }
                return write;
            }
        }

        /// <inheritdoc/>
        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException();

        /// <inheritdoc/>
        public override void SetLength(long value) => throw new NotSupportedException();

        /// <inheritdoc/>
        public override void Write(byte[] buffer, int offset, int count)
        {
#if NET40
            var copiedBuffer = new byte[count];
            UnsafeHelper.Copy(buffer, copiedBuffer, count);
            AddBuffer(copiedBuffer);
#else
            AddBuffer(buffer.AsSpan(offset, count).ToArray());
#endif
        }

        /// <summary>
        /// Add new buffer to buffer list.
        /// </summary>
        /// <param name="buffer"></param>
        public void AddBuffer(byte[] buffer)
        {
            _buffers.Enqueue(buffer);
        }
    }
}
