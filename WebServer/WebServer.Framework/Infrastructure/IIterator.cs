namespace Webserver.Infrastructure
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIterator<out T> : IEnumerator<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T First { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Last { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Next { get; }
    }
}
