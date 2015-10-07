using System;
using System.Collections.Generic;

namespace WebServer.Infrastructure
{
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
