using System;
using System.Threading;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.NativeUI
{
    /// <summary>
    /// UI Thread Manager
    /// </summary>
    public class UIThreadManager
    {
        Thread _thread;

        /// <summary>
        /// 
        /// </summary>
        public UIThreadManager()
        {
            _thread = new Thread(() =>
            {
                MessageLoopImpl();
            });
            _thread.SetApartmentState(ApartmentState.STA);
        }

        /// <summary>
        /// 
        /// </summary>
        public UIThreadManager(Thread thread)
        {
            _thread = thread;
            MessageLoopImpl();
        }

        private void MessageLoopImpl()
        {
            while (GetMessage(out var msg, NULL, 0, 0))
            {
                TranslateMessage(msg);
                DispatchMessage(msg);
            }
        }
    }
}
