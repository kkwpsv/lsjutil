using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lsj.Util.WPF
{
    /// <summary>
    /// Async Observable Collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AsyncObservableCollection<T> : ObservableCollection<T>
    {
        private readonly SynchronizationContext _creatorSynchronizationContext = SynchronizationContext.Current;

        /// <summary>
        /// 
        /// </summary>
        public AsyncObservableCollection()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public AsyncObservableCollection(List<T> list) : base(list)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        public AsyncObservableCollection(IEnumerable<T> collection) : base(collection)
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
