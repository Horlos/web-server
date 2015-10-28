namespace Webserver.Infrastructure
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAggregate<T> : IEnumerable<T>
    {
        /// <summary>
        /// Gets number of parameters.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 
        /// </summary>
        T[] Items { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        T this[int i] { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IIterator<T> GetIterator();
    }
}
