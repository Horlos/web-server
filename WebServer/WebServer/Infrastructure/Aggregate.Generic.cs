using System.Collections;
using System.Collections.Generic;

namespace WebServer.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Aggregate<T> : IAggregate<T> where T: class
    {
        private T[] _items;

        public Aggregate(int size)
        {
            _items = new T[size];
        }

        public T[] Items { get { return _items; } }

        public int Count { get { return _items.Length; } }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IIterator<T> GetIterator()
        {
            return new Iterator<T>(this);
        }

        public T this[int index]
        {
            get { return _items[index]; }
            set { Add(value); }
        }

        public void Add(T item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return GetIterator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
