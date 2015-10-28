namespace Webserver.Infrastructure
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Aggregate<T> : IAggregate<T> where T : class
    {
        private T[] _items;

        public Aggregate(int size)
        {
            _items = new T[size];
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual T[] Items
        {
            get { return _items; }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual int Count
        {
            get { return _items.Length; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public virtual T this[int index]
        {
            get { return _items[index]; }
            set { Add(value); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IIterator<T> GetIterator()
        {
            return new Iterator<T>(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public virtual void Add(T item)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerator<T> GetEnumerator()
        {
            return GetIterator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
