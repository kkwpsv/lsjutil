using Lsj.Util.Net.Web.Protocol;
using Lsj.Util.Text;
using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;

namespace Lsj.Util.Net.Web.Message
{
    /// <summary>
    /// HttpResponse for client
    /// </summary>
    public class HttpResponseForClient : HttpResponse
    {
        /// <summary>
        /// ContentLength
        /// </summary>
        public override long ContentLength => _contentLength ?? 0;

        /// <summary>
        /// IsFinished
        /// </summary>
        public bool IsFinished { get; private set; } = false;

        private ContentType _contentType = ContentType.Unknown;
        private long? _contentLength = null;


        /// <inheritdoc/>
        protected override unsafe bool InternalRead(Span<byte> buffer, out int read)
        {
            if (_contentType == ContentType.Unknown)
            {
                var result = base.InternalRead(buffer, out read);
                if (result)
                {
                    if (buffer.Length - read > 2)
                    {
                        if (buffer[read] == ASCIIChar.CR && buffer[read + 1] == ASCIIChar.LF)
                        {
                            read += 2;
                        }
                        if (AnalyseContentType())
                        {
                            if (buffer.Length - read > 0)
                            {
                                read += ReadContent(buffer.Slice(read));
                            }
                            return true;
                        }
                        else
                        {
                            throw new NotSupportedException("Not supported content");
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                read = ReadContent(buffer);
                return true;
            }
        }

        /// <summary>
        /// End Read
        /// </summary>
        public void EndRead()
        {
            if ((_contentType & ContentType.Identity) != 0 && _contentLength == null)
            {
                _contentLength = Content.Length;
                IsFinished = true;
            }
            else if ((_contentType & ContentType.Gzip) != 0 && _contentLength == null)
            {
                _contentLength = _gzipRawStream.Length;
                IsFinished = true;
            }
        }

        MemoryStream _gzipRawStream;
        GZipStream _gzipStream;

        private unsafe int ReadContent(Span<byte> content)
        {
            var read = content.Length;
            var count = content.Length;
            if ((_contentType & ContentType.Identity) != 0)
            {
                if ((_contentType & ContentType.Chunked) != 0)
                {
                    var buffer = GetChunkBuffer(content, out read);
                    if (buffer != null)
                    {
                        _content.Write(buffer);
                    }
                }
                else
                {
                    if (_contentLength != null)
                    {
                        var rest = _contentLength.Value - _content.Length;
                        if (rest < count)
                        {
                            count = (int)rest;
                        }
                    }
#if NETCOREAPP3_0_OR_GREATER
                    _content.Write(content.Slice(0, count));
#else
                    _content.Write(content.Slice(0, count).ToArray());
#endif
                }

                if (_contentLength != null && _content.Length == _contentLength)
                {
                    IsFinished = true;
                }
                return read;
            }
            else if ((_contentType & ContentType.Gzip) != 0)
            {
                if (_gzipStream == null)
                {
                    _gzipRawStream = new MemoryStream();
                    _gzipStream = new GZipStream(_gzipRawStream, CompressionMode.Decompress);
                }
                if ((_contentType & ContentType.Chunked) != 0)
                {
                    var buffer = GetChunkBuffer(content, out read);
                    if (buffer != null)
                    {
                        var pos = _gzipRawStream.Position;
                        _gzipRawStream.Write(buffer);
                        _gzipRawStream.Position = pos;
                    }
                }
                else
                {
                    if (_contentLength != null)
                    {
                        var rest = _contentLength.Value - _gzipRawStream.Length;
                        if (rest < count)
                        {
                            count = (int)rest;
                        }
                    }
                    var pos = _gzipRawStream.Position;
#if NETCOREAPP3_0_OR_GREATER
                    _gzipRawStream.Write(content.Slice(0, count));
#else
                    _gzipRawStream.Write(content.Slice(0, count).ToArray());
#endif
                    _gzipRawStream.Position = pos;
                }

                _gzipStream.CopyTo(_content);

                if (_contentLength != null)
                {
                    if (_gzipRawStream.Length == _contentLength)
                    {
                        IsFinished = true;
                    }
                }
                return read;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        int _currentChunkOffset;
        byte[] _currentChunk;
        bool _exceptEndChunk;
        private unsafe byte[] GetChunkBuffer(Span<byte> buffer, out int read)
        {
            read = 0;
            if (_exceptEndChunk)
            {
                if (buffer[0] == ASCIIChar.CR && buffer[1] == ASCIIChar.LF)
                {
                    read += 2;
                    _exceptEndChunk = false;
                }
                else
                {
                    throw new InvalidDataException("Invalid chunk, missing end.");
                }
            }
            if (_currentChunk == null)
            {
                for (int i = 0; i < buffer.Length; i++)
                {
                    if (buffer[read + i] == ASCIIChar.CR && buffer[read + i + 1] == ASCIIChar.LF)
                    {
                        var str = StringHelper.ReadStringFromByteSpan(buffer.Slice(read, i));
                        if (int.TryParse(str, NumberStyles.HexNumber, null, out var length))
                        {
                            if (length == 0)
                            {
                                read += i + 2;
                                EndRead();
                                return null;
                            }
                            else
                            {
                                _currentChunk = new byte[length];
                                _currentChunkOffset = 0;
                                read += i + 2;
                                break;
                            }
                        }
                        else
                        {
                            throw new InvalidDataException("Invalid chunk, parse length error.");
                        }
                    }
                }
            }

            var rest = buffer.Length - read;
            if (rest > 0)
            {
                var toCopy = rest;
                if (rest + _currentChunkOffset > _currentChunk.Length)
                {
                    toCopy = _currentChunk.Length - _currentChunkOffset;
                }

                fixed (byte* ptr = _currentChunk)
                {
                    fixed (byte* pts = buffer)
                    {
                        UnsafeHelper.Copy(pts, read, ptr, _currentChunkOffset, toCopy);
                        _currentChunkOffset += toCopy;
                        read += toCopy;
                    }
                }

                if (_currentChunkOffset == _currentChunk.Length)
                {
                    var result = _currentChunk;
                    _currentChunk = null;
                    _exceptEndChunk = true;
                    return result;
                }
            }
            return null;
        }

        private bool AnalyseContentType()
        {
            switch (Headers[HttpHeaders.ContentEncoding])
            {
                case "identity":
                case "":
                    _contentType = ContentType.Identity;
                    if (Headers[HttpHeaders.TransferEncoding] == "chunked")
                    {
                        _contentType |= ContentType.Chunked;
                        return true;
                    }
                    else
                    {
                        _contentLength = Headers[HttpHeaders.ContentLength].ConvertToLongWithNull();
                        return _contentLength != null || HttpVersion == new Version(1, 0) || Headers[HttpHeaders.Connection].ToLower() == "close";
                    }
                case "gzip":
                    _contentType = ContentType.Gzip;
                    if (Headers[HttpHeaders.TransferEncoding] == "chunked")
                    {
                        _contentType |= ContentType.Chunked;
                        return true;
                    }
                    else
                    {
                        _contentLength = Headers[HttpHeaders.ContentLength].ConvertToLongWithNull();
                        return _contentLength != null || HttpVersion == new Version(1, 0) || Headers[HttpHeaders.Connection].ToLower() == "close";
                    }
                default:
                    return false;
            }
        }

        [Flags]
        enum ContentType : uint
        {
            Unknown = 0,
            Identity = 0x01,
            Gzip = 0x02,
            Chunked = 0x80000000,
        }
    }
}
