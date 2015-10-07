using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Infrastructure;

namespace WebServer.Headers
{
    public class HeaderCollection: IHeaderCollection
    {
        private readonly Dictionary<string, IHeader> _headers =
            new Dictionary<string, IHeader>(StringComparer.OrdinalIgnoreCase);

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
            if (value?.Name == null)
                throw new ArgumentNullException("value");

            _headers[name] = value;
        }

        #region IHeaderCollection Members

        public IIterator<IHeader> GetIterator()
        {
            return new HeaderIterator(this);
        }

        public IHeader this[string name]
        {
            get
            {
                IHeader header;
                return _headers.TryGetValue(name, out header) ? header : null;
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

        #endregion
    }
}
