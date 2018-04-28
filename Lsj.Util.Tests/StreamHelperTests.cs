using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lsj.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Lsj.Util.Tests
{
    [TestClass()]
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
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadAllTest_CannotSeek()
        {
            new StreamCannotSeek().ReadAll();
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadAllTest_CannotRead()
        {
            new StreamCannotRead().ReadAll();
        }
        [TestMethod()]
        public void ReadAllTest_Empty()
        {
            var x = new StreamEmpty().ReadAll();
            Assert.AreEqual(x.Length, 0);
        }
        [TestMethod()]
        public void ReadAllTest()
        {
            var x = new StreamTest().ReadAll();
            Assert.AreEqual(x.Length, 10);
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(x[i], i);
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadAllWithoutSeekTest_CannotRead()
        {
            new StreamCannotRead().ReadAllWithoutSeek();
        }
        [TestMethod()]
        public void ReadAllWithoutSeekTest_Empty()
        {
            var x = new StreamEmpty().ReadAllWithoutSeek();
            Assert.AreEqual(x.Length, 0);
        }
        [TestMethod()]
        public void ReadAllWithoutSeekTest()
        {
            var x = new StreamTest().ReadAllWithoutSeek();
            Assert.AreEqual(x.Length, 10);
            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(x[i], i);
            }
        }
    }
}