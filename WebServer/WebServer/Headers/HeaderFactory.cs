using WebServer.Readers;

namespace WebServer.Headers
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Parsers;

    /// <summary>
    /// Used to build headers.
    /// </summary>
    public class HeaderFactory
    {
        private readonly Dictionary<string, IHeaderCreator> _parsers =
            new Dictionary<string, IHeaderCreator>(StringComparer.OrdinalIgnoreCase);

        private readonly ObjectPool<StringReader> _readers =
            new ObjectPool<StringReader>(() => new StringReader(string.Empty));

        private readonly IHeaderCreator _stringCreator = new StringHeaderCreator();


        /// <summary>
        /// Add a parser
        /// </summary>
        /// <param name="name">Header that the parser is for.</param>
        /// <param name="creator">Parser implementation</param>
        /// <remarks>
        /// Will replace any existing parser for the specified header.
        /// </remarks>
        public void Add(string name, IHeaderCreator creator)
        {
            _parsers[name] = creator;
        }

        /// <summary>
        /// Add all default (built-in) parsers.
        /// </summary>
        /// <remarks>
        /// Will not replace previously added parsers.
        /// </remarks>
        public void AddDefaultParsers()
        {
            Type interfaceType = typeof(IHeaderCreator);
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsInterface || type.IsAbstract)
                    continue;

                if (!interfaceType.IsAssignableFrom(type))
                    continue;

                CreateParser(type);
            }
        }

        /// <summary>
        /// Create a header parser
        /// </summary>
        /// <param name="type"><see cref="IHeaderCreator"/> implementation.</param>
        /// <remarks>
        /// <para>
        /// Uses <see cref="CreateHeaderForAttribute"/> attribute to find which headers
        /// the parser is for.
        /// </para>
        /// <para>Will not replace previously added parsers.</para>
        /// </remarks>
        private void CreateParser(Type type)
        {
            var parser = (IHeaderCreator)Activator.CreateInstance(type);

            object[] attributes = type.GetCustomAttributes(true);
            foreach (object attr in attributes)
            {
                var attribute = attr as CreateHeaderForAttribute;
                if (attribute == null)
                    continue;

                if (_parsers.ContainsKey(attribute.HeaderName))
                    continue;

                _parsers[attribute.HeaderName] = parser;
            }
        }

        /// <summary>
        /// Parse a header.
        /// </summary>
        /// <param name="name">Name of header</param>
        /// <param name="value">Header value</param>
        /// <returns>Header.</returns>
        /// <exception cref="FormatException">Value is not a well formatted header value.</exception>
        public IHeader CreateHeader(string name, string value)
        {
            IHeaderCreator creator;
            if (!_parsers.TryGetValue(name, out creator))
                creator = _stringCreator;

            StringReader reader = _readers.Dequeue();
            reader.Assign(value);
            try
            {
                return creator.Create(name, reader);
            }
            finally
            {
                _readers.Enqueue(reader);
            }
        }
    }
}
