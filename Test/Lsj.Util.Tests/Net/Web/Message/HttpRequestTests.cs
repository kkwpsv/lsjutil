using Lsj.Util.Net.Web.Message;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Lsj.Util.Tests.Net.Web.Message
{
    [TestClass]
    public class HttpRequestTests
    {
        [TestMethod]
        public void ParseRequestTest()
        {
            var request = new HttpRequest();
            var bytes = Encoding.ASCII.GetBytes("GET /index.htm HTTP/1.1\r\nHost: localhost\r\n\r\n");
            var read = 0;
            request.Read(bytes, ref read);
            Assert.AreEqual(bytes.Length, read);
            Assert.AreEqual(new Version(1, 1), request.HttpVersion);
            Assert.AreEqual("index.htm", request.Uri.FileName);
            Assert.IsTrue(request.IsReadFinish);
            Assert.IsFalse(request.IsError);

            request = new HttpRequest();
            bytes = Encoding.ASCII.GetBytes("GET /index.htm\r\n");
            read = 0;
            request.Read(bytes, ref read);
            Assert.AreEqual(bytes.Length, read);
            Assert.AreEqual(new Version(0, 9), request.HttpVersion);
            Assert.AreEqual("index.htm", request.Uri.FileName);

            request = new HttpRequest();
            bytes = Encoding.ASCII.GetBytes("GET /\r\n");
            read = 0;
            request.Read(bytes, ref read);
            Assert.AreEqual(bytes.Length, read);
            Assert.AreEqual(new Version(0, 9), request.HttpVersion);
            Assert.AreEqual("", request.Uri.FileName);
        }
    }
}
