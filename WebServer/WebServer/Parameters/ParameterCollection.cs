namespace WebServer.Parameters
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Infrastructure;

    /// <summary>
    /// Collection of parameters.
    /// </summary>
    public class ParameterCollection : IParameterCollection
    {
        private readonly Dictionary<string, IParameter> _items = new Dictionary<string, IParameter>(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterCollection"/> class.
        /// </summary>
        /// <param name="collections">Collections to merge.</param>
        /// <remarks>
        /// Later collections will overwrite parameters from earlier collections.
        /// </remarks>
        public ParameterCollection(params IParameterCollection[] collections)
        {
            if (collections != null)
                foreach (IParameterCollection collection in collections)
                {
                    if (collection != null)
                    {
                        foreach (IParameter p in collection)
                        {
                            foreach (string value in p)
                                Add(p.Name, value);
                        }
                    }
                }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return _items.Count; }
        }

        public ICollection<IParameter> Items
        {
            get { return _items.Values; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string this[string name]
        {
            get
            {
                IParameter param = GetParameter(name);
                return param != null ? param.Value : null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IParameter GetParameter(string name)
        {
            IParameter parameter;
            return _items.TryGetValue(name, out parameter) ? parameter : null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Add(string name, string value)
        {
            IParameter parameter;
            if (_items.TryGetValue(name, out parameter))
                parameter.Items.Add(value);
            else
            {
                parameter = new Parameter(name, value);
                _items.Add(name, parameter);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Exists(string name)
        {
            return _items.ContainsKey(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IIterator<IParameter> GetIterator()
        {
            return new Iterator<IParameter>(this);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<IParameter> GetEnumerator()
        {
            return GetIterator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
