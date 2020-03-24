using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace Lsj.Util.WPF
{
    /// <summary>
    /// ObservableQueue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableQueue<T> : ICollection<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        /// <summary>
        /// ObservableQueue
        /// </summary>
        public ObservableQueue() : this(-1)
        {

        }

        /// <summary>
        /// ObservableQueue
        /// </summary>
        /// <param name="capacity"></param>
        public ObservableQueue(int capacity)
        {
            if (capacity < -1)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            _capacity = capacity;
        }

        private Queue<T> _queue = new Queue<T>();

        private int _capacity;

        /// <summary>
        /// Capacity
        /// </summary>
        public int Capacity
        {
            get => _capacity;
            set
            {
                if (value != _capacity)
                {
                    if (value < -1)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    if (value != -1 && value < Count)
                    {
                        var removed = new List<T>();
                        while (Count > value)
                        {
                            removed.Add(_queue.Dequeue());
                        }
                        OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removed));
                        OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
                    }
                    _capacity = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(Capacity)));
                }
            }
        }

        /// <summary>
        /// Count
        /// </summary>
        public int Count => _queue.Count;

        /// <summary>
        /// IsReadOnly
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// CollectionChanged
        /// </summary>

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        /// <summary>
        /// PropertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Dequeue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            var result = _queue.Dequeue();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, result));
            OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
            return result;
        }

        /// <summary>
        /// Enqueue
        /// </summary>
        public void Enqueue(T value)
        {
            _queue.Enqueue(value);
            if (_capacity != -1 && _queue.Count > _capacity)
            {
                _queue.Dequeue();
            }
            else
            {
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
            }
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        /// <summary>
        /// Peek
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            return _queue.Peek();
        }

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item) => Enqueue(item);

        /// <summary>
        /// Clear
        /// </summary>
        public void Clear()
        {
            if (_queue.Count != 0)
            {
                _queue.Clear();
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(Count)));
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(T item) => _queue.Contains(item);

        /// <summary>
        /// CopyTo
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(T[] array, int arrayIndex) => _queue.CopyTo(array, arrayIndex);

        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() => _queue.GetEnumerator();

        /// <summary>
        /// Remove
        /// Always throw InvalidOperationException()
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(T item) => throw new InvalidOperationException();

        /// <summary>
        /// GetEnumerator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// OnCollectionChanged
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }

        /// <summary>
        /// OnPropertyChanged
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
    }
}
