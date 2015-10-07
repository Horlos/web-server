using System.Collections.Generic;

namespace WebServer.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAggregate<out T> : IEnumerable<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IIterator<T> GetIterator();
    }
}
