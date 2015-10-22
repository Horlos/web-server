namespace WebServer
{
    using System;

    /// <summary>
    /// Used to create all key types in the HTTP server.
    /// </summary>
    /// <remarks>
    /// <para>Should have factory methods at least for the following types: </para>
    /// <para>Check the default implementations to see which constructor 
    /// parameters you will get.</para>
    /// </remarks>
    public class HttpFactory : IHttpFactory
    {
        /// <summary>
        /// 
        /// </summary>
        public static IHttpFactory Current { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="constructorArguments"></param>
        /// <returns></returns>
        public T Get<T>(params object[] constructorArguments) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
