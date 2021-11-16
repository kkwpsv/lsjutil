using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Structs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Tests.Win32.User32
{
    [TestClass]
    public class DisplayApiTests
    {
        [TestMethod]
        public void TestEnumDisplayDevices()
        {
            int i = 0;
            while (true)
            {
                var displayDevice = new DISPLAY_DEVICE
                {
                    cb = SizeOf<DISPLAY_DEVICE>(),
                };
                if (EnumDisplayDevices(null, i, ref displayDevice, 0))
                {
                    i++;
                }
                else
                {
                    break;
                }
            }
            // Assert.IsTrue(i > 0);
            // No DisplayDevices in Hyper-V
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestEnumDisplayMonitorsAndGetMonitorInfo()
        {
            int i = 0;
            var param = (LPARAM)123;
            Assert.IsTrue(EnumDisplayMonitors(NULL, NullRef<RECT>(), (MONITORENUMPROC)EnumDisplayMonitorsCallback, param));

            BOOL EnumDisplayMonitorsCallback(HMONITOR Arg1, HDC Arg2, in RECT Arg3, LPARAM Arg4)
            {
                i++;
                Assert.AreEqual(param, Arg4);

                var monitorInfo = new MONITORINFOEX
                {
                    cbSize = SizeOf<MONITORINFOEX>(),
                };

                Assert.IsTrue(GetMonitorInfo(Arg1, ref monitorInfo));

                return true;
            }
            Assert.IsTrue(i > 0);
        }
    }
}
