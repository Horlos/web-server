using System.Collections;
using System.Collections.Generic;

namespace WebServer.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Aggregate<T> : IAggregate<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IIterator<T> GetIterator()
        {
            return new Iterator<T>();
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
