namespace WebServer.Parameters
{
    using System.Collections;
    using System.Collections.Generic;
    using Infrastructure;

    /// <summary>
    /// 
    /// </summary>
    public class Parameter : IParameter
    {
        private readonly List<string> _values = new List<string>();

        public Parameter(string name, params string[] values)
        {
            Name = name;
            _values.AddRange(values);
        }

        /// <summary>
        /// Gets last value.
        /// </summary>
        /// <remarks>
        /// Parameters can have multiple values. This property will always get the last value in the list.
        /// </remarks>
        /// <value>String if any value exist; otherwise <c>null</c>.</value>
        public string Value
        {
            get { return GetIterator().Last; }
        }

        /// <summary>
        /// Gets or sets name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return _values.Count; }
        }

        /// <summary>
        /// Gets a list of all values.
        /// </summary>
        public ICollection<string> Items
        {
            get { return _values; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public string this[int i]
        {
            get { return _values[i]; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IIterator<string> GetIterator()
        {
            return new Iterator<string>(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<string> GetEnumerator()
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
