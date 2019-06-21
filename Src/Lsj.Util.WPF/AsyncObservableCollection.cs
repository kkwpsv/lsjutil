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
    public class AsyncObservableCollection<T> : ObservableCollection<T>
    {
        private SynchronizationContext _creatorSynchronizationContext = SynchronizationContext.Current;

        public AsyncObservableCollection()
        {
        }

        public AsyncObservableCollection(List<T> list) : base(list)
        {
        }

        public AsyncObservableCollection(IEnumerable<T> collection) : base(collection)
        {
        }

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
