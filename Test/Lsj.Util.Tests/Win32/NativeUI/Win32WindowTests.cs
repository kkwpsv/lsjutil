using Lsj.Util.Win32.NativeUI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Lsj.Util.Win32.Enums.WindowStyles;
using static Lsj.Util.Win32.Enums.WindowStylesEx;

namespace Lsj.Util.Tests.Win32.NativeUI
{
    [TestClass]
    public class Win32WindowTests
    {
        [TestMethod]
        public void TestCreateWin32Window()
        {
            var win = new Win32Window();
            Assert.IsTrue(win.Handle != IntPtr.Zero);
        }

        [TestMethod]
        public void TestWin32WindowStyle()
        {
            var win = new Win32Window();
            win.WindowStyles |= WS_POPUP;
            Assert.IsTrue(win.WindowStyles.HasFlag(WS_POPUP));
            win.WindowStylesEx |= WS_EX_NOACTIVATE;
            Assert.IsTrue(win.WindowStylesEx.HasFlag(WS_EX_NOACTIVATE));
        }
    }
}
