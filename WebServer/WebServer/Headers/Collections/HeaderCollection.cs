namespace WebServer.Headers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Infrastructure;

    public class HeaderCollection : IHeaderCollection
    {
        private readonly HeaderFactory _factory;

        private readonly Dictionary<string, IHeader> _headers =
            new Dictionary<string, IHeader>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderCollection"/> class.
        /// </summary>
        /// <param name="factory">Factory used to created headers.</param>
        public HeaderCollection(HeaderFactory factory)
        {
            _factory = factory;
        }

        public int Count
        {
            get { return _headers.Count; }
        }

        public ICollection<IHeader> Items
        {
            get { return _headers.Values; }
        }

        public IHeader this[string name]
        {
            get
            {
                IHeader header;
                return _headers.TryGetValue(name.ToLower(), out header) ? header : null;
            }

            set
            {
                if (value == null)
                    _headers.Remove(name);
                else
                    _headers[name] = value;
            }
        }

        /// <summary>
        /// Add a header.
        /// </summary>
        /// <param name="name">Header name</param>
        /// <param name="value">Header value</param>
        /// <remarks>
        /// Will try to parse the header and create a <see cref="IHeader"/> object.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><c>name</c> or <c>value</c> is <c>null</c>.</exception>
        public void Add(string name, IHeader value)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (value == null || value.Name == null)
                throw new ArgumentNullException("value");

            _headers[name] = value;
        }

        public IHeader Create()
        {
            return _factory.CreateHeader(string.Empty, string.Empty);
        }

        public IIterator<IHeader> GetIterator()
        {
            return new HeaderIterator(this);
        }

        /// <summary>
        /// Get a header 
        /// </summary>
        /// <typeparam name="T">Type that it should be cast to</typeparam>
        /// <param name="headerName">Name of header</param>
        /// <returns>Header if found and casted properly; otherwise <c>null</c>.</returns>
        public T Get<T>(string headerName) where T : class, IHeader
        {
            IHeader header;
            if (_headers.TryGetValue(headerName, out header))
                return header as T;
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IHeader> GetEnumerator()
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
