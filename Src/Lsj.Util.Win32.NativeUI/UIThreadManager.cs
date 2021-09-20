using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.PeekMessageFlags;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.NativeUI
{
    /// <summary>
    /// UI Thread Manager
    /// </summary>
    public class UIThreadManager
    {
        /// <summary>
        /// UIThreadManager of Current Thread 
        /// </summary>
        public static UIThreadManager? Current => _current;

        [ThreadStatic]
        static UIThreadManager? _current;

        struct ActionItem
        {
            public TaskCompletionSource<object?> taskCompletionSource;
            public Action action;
        }

        Thread _thread;
        BlockingCollection<ActionItem> _actionItems = new BlockingCollection<ActionItem>();

        /// <summary>
        /// Init a new UI thread and run message loop.
        /// </summary>
        public UIThreadManager()
        {
            if (_current != null)
            {
                throw new InvalidOperationException("Current thread has already a UIThreadManager");
            }
            _current = this;
            _thread = new Thread(() =>
            {
                MessageLoopImpl();
            });
            _thread.Name = "UIThreadManager Thread";
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
        }

        /// <summary>
        /// Run message loop in current thread.
        /// </summary>
        public UIThreadManager(Thread thread)
        {
            _thread = thread;
            MessageLoopImpl();
        }

        private void MessageLoopImpl()
        {
            while (true)
            {
                if (PeekMessage(out var msg, NULL, 0, 0, PM_REMOVE))
                {
                    if (msg.message == WM_QUIT)
                        break;
                    TranslateMessage(msg);
                    DispatchMessage(msg);
                }
                else if (_actionItems.TryTake(out var item))
                {
                    try
                    {
                        item.action.Invoke();
                    }
                    catch (Exception e)
                    {
                        item.taskCompletionSource.SetException(e);
                        continue;
                    }
                    item.taskCompletionSource.SetResult(null!);
                }
            }
        }

        /// <summary>
        /// Invoke action in UI thread and wait
        /// </summary>
        /// <param name="action"></param>
        public void Invoke(Action action)
        {
            var item = new ActionItem()
            {
                taskCompletionSource = new TaskCompletionSource<object?>(),
                action = action,
            };
            _actionItems.Add(item);
            item.taskCompletionSource.Task.Wait();
        }

        /// <summary>
        /// Invoke action in UI thread
        /// </summary>
        /// <param name="action"></param>
        public async Task InvokeAsync(Action action)
        {
            var item = new ActionItem()
            {
                taskCompletionSource = new TaskCompletionSource<object?>(),
                action = action,
            };
            _actionItems.Add(item);
            await item.taskCompletionSource.Task.ConfigureAwait(false);
#if NET40
            await TaskEx.Yield();
#else
            await Task.Yield();
#endif
        }
    }
}
