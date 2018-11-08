using System;
using Lsj.Util.Logs;

namespace Lsj.Util
{
    /// <summary>
    /// Disposable Class
    /// </summary>
    public class DisposableClass : IDisposable
    {
        /// <summary>
        /// Finalize
        /// </summary>
        ~DisposableClass()
        {
            Dispose(false);
        }

        private bool IsDisposed = false;

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool flag)
        {
            if (!IsDisposed)
            {
                try
                {
                    if (flag)
                    {
                        CleanUpManagedResources();
                    }
                    CleanUpUnmanagedResources();
                }
                catch (Exception e)
                {
                    LogProvider.Default.Error(e);
                }
            }
            IsDisposed = true;
        }
        /// <summary>
        /// Clean Up Unmanaged Resources
        /// </summary>
        protected virtual void CleanUpUnmanagedResources() => Static.DoNothing();

        /// <summary>
        /// Clean Up Managed Resources
        /// </summary>
        protected virtual void CleanUpManagedResources() => Static.DoNothing();
    }
}
