namespace WebServer.Infrastructure
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAggregateCollection<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets number of parameters.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 
        /// </summary>
        ICollection<T> Items { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IIterator<T> GetIterator();
    }

    public interface IAggregateCollection<in TKey, TValue> : IAggregateCollection<TValue>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TValue this[TKey key] { get; }
    }
}
