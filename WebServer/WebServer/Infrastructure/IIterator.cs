using System;

namespace WebServer.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IIterator<out T> : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T First();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Current();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        T Next();

        /// <summary>
        /// 
        /// </summary>
        void Reset();
    }
}
