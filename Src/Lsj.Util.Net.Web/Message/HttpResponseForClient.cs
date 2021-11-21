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

        public bool IsFinished { get; private set; } = false;

        private ContentType _contentType = ContentType.Unknown;
        private long? _contentLength = null;


        protected override unsafe bool InternalRead(byte* pts, int offset, int count, out int read)
        {
            if (_contentType == ContentType.Unknown)
            {
                var result = base.InternalRead(pts, offset, count, out read);
                if (result)
                {
                    if (count - read > 2)
                    {
                        if (*(pts + offset + read) == (byte)'\r' && *(pts + offset + read + 1) == (byte)'\n')
                        {
                            read += 2;
                        }
                        if (AnalyseContentType())
                        {
                            if (count - read > 0)
                            {
                                read += ReadContent(pts, offset + read, count - read);
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
                read = ReadContent(pts, offset, count);
                return true;
            }
        }

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

        private unsafe int ReadContent(byte* pts, int offset, int count)
        {
            var read = count;
            if ((_contentType & ContentType.Identity) != 0)
            {
                if ((_contentType & ContentType.Chunked) != 0)
                {
                    var buffer = GetChunkBuffer(pts, offset, count, out read);
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

                    var buffer = new byte[count];
                    fixed (byte* dst = buffer)
                    {
                        UnsafeHelper.Copy(pts, offset, dst, 0, count);
                    }
                    _content.Write(buffer);
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
                    var buffer = GetChunkBuffer(pts, offset, count, out read);
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
                    var buffer = new byte[count];
                    fixed (byte* dst = buffer)
                    {
                        UnsafeHelper.Copy(pts, offset, dst, 0, count);
                    }
                    var pos = _gzipRawStream.Position;
                    _gzipRawStream.Write(buffer);
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
        private unsafe byte[] GetChunkBuffer(byte* pts, int offset, int count, out int read)
        {
            read = 0;
            if (_exceptEndChunk)
            {
                if (*(pts + offset) == '\r' && *(pts + offset + 1) == '\n')
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
                for (int i = 0; i < count; i++)
                {
                    if (*(pts + offset + read + i) == '\r' && *(pts + offset + read + i + 1) == '\n')
                    {
                        var str = StringHelper.ReadStringFromBytePoint(pts + offset + read, i);
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

            var rest = count - read;
            if (rest > 0)
            {
                var toCopy = rest;
                if (rest + _currentChunkOffset > _currentChunk.Length)
                {
                    toCopy = _currentChunk.Length - _currentChunkOffset;
                }

                fixed (byte* ptr = _currentChunk)
                {
                    UnsafeHelper.Copy(pts, offset + read, ptr, _currentChunkOffset, toCopy);
                    _currentChunkOffset += toCopy;
                    read += toCopy;
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
