using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using System;

namespace Lsj.Util.Win32.NativeUI
{
    /// <summary>
    /// AccessibilityEventHooker
    /// </summary>
    public class AccessibilityEventHooker
    {
        private HWINEVENTHOOK _hook;
        private WINEVENTPROC _hookProc;
        private readonly EventConstants _min;
        private readonly EventConstants _max;

        /// <summary>
        /// OnEvent
        /// </summary>
        public event EventHandler<AccessibilityEventArgs>? OnEvent;

        /// <summary>
        /// AccessibilityEventHooker
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public AccessibilityEventHooker(EventConstants min, EventConstants max)
        {
            _min = min;
            _max = max;
            _hookProc = (User32.Wineventproc)HookProc;
        }

        /// <summary>
        /// Start
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// This object should keep alive until stop.
        /// </remarks>
        public bool Start()
        {
            if (_hook != Constants.NULL)
            {
                return false;
            }

            _hook = User32.SetWinEventHook(_min, _max, Constants.NULL, _hookProc, 0, 0, SetWinEventHookFlags.WINEVENT_OUTOFCONTEXT);
            return _hook != Constants.NULL;
        }

        private void HookProc(HWINEVENTHOOK hWinEventHook, EventConstants @event, HWND hwnd, LONG idObject, LONG idChild, DWORD idEventThread, DWORD dwmsEventTime)
        {
            OnEvent?.Invoke(this, new AccessibilityEventArgs(@event, hwnd, idObject, idChild, idEventThread, dwmsEventTime));
        }

        /// <summary>
        /// Stop
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// Must call at same thread with <see cref="Start"/>
        /// </remarks>
        public bool Stop()
        {
            var result = User32.UnhookWinEvent(_hook);
            _hook = Constants.NULL;
            return result;
        }
    }

    /// <summary>
    /// AccessibilityEventArgs
    /// </summary>
    public class AccessibilityEventArgs : EventArgs
    {
        /// <summary>
        /// AccessibilityEventArgs
        /// </summary>
        /// <param name="event"></param>
        /// <param name="hwnd"></param>
        /// <param name="idObject"></param>
        /// <param name="idChild"></param>
        /// <param name="idEventThread"></param>
        /// <param name="dwmsEventTime"></param>
        internal AccessibilityEventArgs(EventConstants @event, HWND hwnd, LONG idObject, LONG idChild, DWORD idEventThread, DWORD dwmsEventTime)
        {
            Event = @event;
            WindowHandle = hwnd;
            ObjectId = idObject;
            ChildId = idChild;
            ThreadId = idEventThread;
            EventTime = dwmsEventTime;
        }

        /// <summary>
        /// Event
        /// </summary>
        public EventConstants Event { get; }

        /// <summary>
        /// WindowHandle
        /// </summary>
        public HWND WindowHandle { get; }

        /// <summary>
        /// ObjectId
        /// </summary>
        public LONG ObjectId { get; }

        /// <summary>
        /// ChildId
        /// </summary>
        public LONG ChildId { get; }

        /// <summary>
        /// ThreadId
        /// </summary>
        public DWORD ThreadId { get; }

        /// <summary>
        /// EventTime
        /// </summary>
        public DWORD EventTime { get; }
    }

}
