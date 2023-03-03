using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using Lsj.Util.Win32.Structs;
using System;
using System.Collections.Generic;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.WindowMessages;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.NativeUI
{
    partial class Win32Window
    {
        List<Func<HWND, WindowMessages, WPARAM, LPARAM, LRESULT?>> _hookLists = new List<Func<HWND, WindowMessages, WPARAM, LPARAM, LRESULT?>>();

        /// <summary>
        /// Add MessageHook
        /// Only work without override WindowProc
        /// </summary>
        /// <param name="hook"></param>
        public void AddMessageHook(Func<HWND, WindowMessages, WPARAM, LPARAM, LRESULT?> hook)
        {
            if (_wndProc == null)
            {
                throw new NotSupportedException();
            }
            _hookLists.Add(hook);
        }

        /// <summary>
        /// Add MessageHook
        /// Only work without override WindowProc
        /// </summary>
        public void RemoveMessageHook(Func<HWND, WindowMessages, WPARAM, LPARAM, LRESULT?> hook)
        {
            if (_wndProc == null)
            {
                throw new NotSupportedException();
            }
            _hookLists.Remove(hook);
        }

        /// <summary>
        /// Window Proc
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        protected virtual LRESULT WindowProc(HWND hWnd, WindowMessages msg, WPARAM wParam, LPARAM lParam)
        {
            try
            {
                foreach (var hook in _hookLists)
                {
                    var result = hook.Invoke(hWnd, msg, wParam, lParam);
                    if (result != null)
                    {
                        return result.Value;
                    }
                }
                switch (msg)
                {
                    case WindowMessages.WM_CREATE:
                        return OnCreate(hWnd, wParam, ref UnsafePInvokeExtensions.AsStructRef<CREATESTRUCT>(lParam));
                    case WindowMessages.WM_DESTROY:
                        return OnDestroy(hWnd, wParam, lParam);
                    case WindowMessages.WM_PAINT:
                        return OnPaint(hWnd, wParam, lParam);
                    default:
                        return CallDefaultOrHookedWindowProc(hWnd, msg, wParam, lParam);
                }
            }
            catch
            {
                //The finally in Main won't run if exception is thrown in this method.
                //This may be because this method was called by system code.
                //So we must handle exception here.
                DestroyWindow(_handle);
                return 0;
            }
        }

        /// <summary>
        /// On <see cref="WM_CREATE"/>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="wParam"></param>
        /// <param name="createStruct"></param>
        /// <returns></returns>
        protected virtual LRESULT OnCreate(HWND hWnd, WPARAM wParam, ref CREATESTRUCT createStruct)
        {
            return CallDefaultOrHookedWindowProc(hWnd, WindowMessages.WM_CREATE, wParam, UnsafePInvokeExtensions.AsPointer(ref createStruct));
        }

        /// <summary>
        /// On <see cref="WM_DESTROY"/>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        protected virtual LRESULT OnDestroy(HWND hWnd, WPARAM wParam, LPARAM lParam)
        {
            return CallDefaultOrHookedWindowProc(hWnd, WindowMessages.WM_DESTROY, wParam, lParam);
        }

        /// <summary>
        /// On <see cref="WM_PAINT"/>
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        protected virtual LRESULT OnPaint(HWND hWnd, WPARAM wParam, LPARAM lParam)
        {
            return CallDefaultOrHookedWindowProc(hWnd, WindowMessages.WM_PAINT, wParam, lParam);
        }

        private LRESULT CallDefaultOrHookedWindowProc(HWND hWnd, WindowMessages msg, WPARAM wParam, LPARAM lParam)
        {
            if (_hookedWndProc != NULL)
            {
                return CallWindowProc((WNDPROC)_hookedWndProc, hWnd, msg, wParam, lParam);
            }
            else
            {
                return DefWindowProc(hWnd, msg, wParam, lParam);
            }
        }
    }
}
