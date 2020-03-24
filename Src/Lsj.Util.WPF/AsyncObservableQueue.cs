using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Threading;

namespace Lsj.Util.WPF
{
    /// <summary>
    /// Async Observable Queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsyncObservableQueue<T> : ObservableQueue<T>
    {
        private readonly SynchronizationContext _creatorSynchronizationContext = SynchronizationContext.Current;

        /// <summary>
        /// 
        /// </summary>
        public AsyncObservableQueue()
        {
        }

        /// <summary>
        /// OnCollectionChanged
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (SynchronizationContext.Current == _creatorSynchronizationContext)
            {
                base.OnCollectionChanged(e);
            }
            else
            {
                _creatorSynchronizationContext.Post(_ => base.OnCollectionChanged(e), null);
            }
        }

        /// <summary>
        /// OnPropertyChanged
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (SynchronizationContext.Current == _creatorSynchronizationContext)
            {
                base.OnPropertyChanged(e);
            }
            else
            {
                _creatorSynchronizationContext.Post(_ => base.OnPropertyChanged(e), null);
            }
        }
    }
}
