using System.Collections.Generic;

namespace WebServer.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAggregate<T> : IEnumerable<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IIterator<T> GetIterator();

        /// <summary>
        /// Gets number of parameters.
        /// </summary>
        int Count { get; }

        T[] Items { get; }

        T this[int i] { get; }
    }
}
