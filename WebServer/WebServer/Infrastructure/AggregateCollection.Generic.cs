namespace WebServer.Infrastructure
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class AggregateCollection<TKey, TValue> : IAggregateCollection<TKey, TValue>
        where TValue : class
    {
        private readonly IDictionary<TKey, TValue> _items;

        public AggregateCollection()
        {
            _items = new Dictionary<TKey, TValue>();
        }

        public AggregateCollection(IDictionary<TKey, TValue> items)
        {
            _items = items;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<TValue> Items
        {
            get { return _items.Values; }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual int Count
        {
            get { return _items.Values.Count; }
        }

        /// <summary>
        /// Gets or sets a value
        /// </summary>
        /// <param name="key">parameter name</param>
        /// <returns>value if found; otherwise <c>null</c>.</returns>
        public virtual TValue this[TKey key]
        {
            get
            {
                TValue item;
                return _items.TryGetValue(key, out item) ? item : null;
            }

            set
            {
                Add(key, value);
            }
        }

        /// <summary>
        /// Add a parameter
        /// </summary>
        /// <param name="key">name</param>
        /// <param name="value">value</param>
        /// <remarks>
        /// Existing parameter with the same name will be replaced.
        /// </remarks>
        public virtual void Add(TKey key, TValue value)
        {
            if (_items.ContainsKey(key))
                _items[key] = value;
            else
                _items.Add(key, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual IIterator<TValue> GetIterator()
        {
            return new Iterator<TValue>(this);
        }

        /// <summary>
        /// Gets a collection enumerator on the cookie list.
        /// </summary>
        /// <returns>collection enumerator</returns>
        public virtual IEnumerator<TValue> GetEnumerator()
        {
            return GetIterator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var pair in _items)
                sb.AppendFormat("{0}={1};", pair.Key, pair.Value);
            return sb.ToString();
        }
    }
}
