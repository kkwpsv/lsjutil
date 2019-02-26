using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lsj.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics.CodeAnalysis;

namespace Lsj.Util.Tests
{
    [TestClass]
    public class StreamHelperTests
    {
        public class StreamCannotSeek : Stream
        {
            public override bool CanRead => throw new NotImplementedException();

            public override bool CanSeek => false;

            public override bool CanWrite => throw new NotImplementedException();

            public override long Length => throw new NotImplementedException();

            public override long Position
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public override void Flush() => throw new NotImplementedException();
            public override int Read(byte[] buffer, int offset, int count) => throw new NotImplementedException();
            public override long Seek(long offset, SeekOrigin origin) => throw new NotImplementedException();
            public override void SetLength(long value) => throw new NotImplementedException();
            public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();
        }
        public class StreamCannotRead : Stream
        {
            public override bool CanRead => false;

            public override bool CanSeek => true;

            public override bool CanWrite => throw new NotImplementedException();

            public override long Length => 0;

            public override long Position
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public override void Flush() => throw new NotImplementedException();
            public override int Read(byte[] buffer, int offset, int count) => throw new NotImplementedException();
            public override long Seek(long offset, SeekOrigin origin)
            {
                return 0;
            }
            public override void SetLength(long value) => throw new NotImplementedException();
            public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();
        }
        public class StreamEmpty : Stream
        {
            public override bool CanRead => true;

            public override bool CanSeek => true;

            public override bool CanWrite => throw new NotImplementedException();

            public override long Length => 0;

            public override long Position
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public override void Flush() => throw new NotImplementedException();
            public override int Read(byte[] buffer, int offset, int count)
            {
                return 0;
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                return 0;
            }
            public override void SetLength(long value) => throw new NotImplementedException();
            public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();
        }
        public class StreamTest : Stream
        {
            byte[] data = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            public override bool CanRead => true;

            public override bool CanSeek => true;

            public override bool CanWrite => throw new NotImplementedException();

            public override long Length => 10;

            public override long Position
            {
                get;
                set;
            } = 0;

            public override void Flush() => throw new NotImplementedException();
            public override int Read(byte[] buffer, int offset, int count)
            {
                var result = 0;
                for (int i = 0; i < count && Position < Length; i++, Position++, result++)
                {
                    buffer[i] = data[Position];
                }
                return result;
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                return 0;
            }
            public override void SetLength(long value) => throw new NotImplementedException();
            public override void Write(byte[] buffer, int offset, int count) => throw new NotImplementedException();
        }
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void ReadAllTest()
        {
            var x = new StreamEmpty().ReadAll();
            Assert.AreEqual(x.Length, 0);
            x = new StreamTest().ReadAll();
            Assert.AreEqual(x.Length, 10);
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(x[i], i);
            }
            try
            {
                new StreamCannotSeek().ReadAll();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
            }
            try
            {
                new StreamCannotRead().ReadAll();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void ReadAllWithoutSeekTest()
        {
            var x = new StreamEmpty().ReadAllWithoutSeek();
            Assert.AreEqual(x.Length, 0);
            x = new StreamTest().ReadAllWithoutSeek();
            Assert.AreEqual(x.Length, 10);
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(x[i], i);
            }
            try
            {
                new StreamCannotRead().ReadAllWithoutSeek();
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void WriteTest()
        {
            var stream = new MemoryStream();
            stream.Write(new byte[] { 0, 1, 2, 3, 4, 5 });
            Assert.AreEqual(stream.Length, 6);
            var content = stream.ReadAll();
            Assert.AreEqual(content[0], 0);
            Assert.AreEqual(content[1], 1);
            Assert.AreEqual(content[2], 2);
            Assert.AreEqual(content[3], 3);
            Assert.AreEqual(content[4], 4);
            Assert.AreEqual(content[5], 5);
            stream = new MemoryStream();
            stream.Write(new byte[] { 0, 1, 2, 3, 4, 5 }, 3);
            Assert.AreEqual(stream.Length, 3);
            content = stream.ReadAll();
            Assert.AreEqual(content[0], 3);
            Assert.AreEqual(content[1], 4);
            Assert.AreEqual(content[2], 5);

        }
    }
}