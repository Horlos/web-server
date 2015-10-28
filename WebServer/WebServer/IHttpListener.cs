namespace Webserver
{
    using System.Net;
    using NLog;

    /// <summary>
    /// Http listener
    /// </summary>
    public interface IHttpListener
    {
        /// <summary>
        /// Gets listener address.
        /// </summary>
        /// <value>
        /// 
        /// </value> 
        IPAddress Address { get; }

        /// <summary>
        /// Gets if listener is secure.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        bool IsSecure { get; }

        /// <summary>
        /// Gets if listener have been started.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        bool IsStarted { get; }

        /// <summary>
        /// Gets or sets logger.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        ILogger Logger { get; set; }

        /// <summary>
        /// Gets listening port.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        int Port { get; }

        /// <summary>
        /// Gets the maximum content size.
        /// </summary>
        /// <value>The content length limit.</value>
        /// <remarks>
        /// Used when responding to 100-continue.
        /// </remarks>
        /// <value>
        /// 
        /// </value>
        int ContentLengthLimit { get; set; }

        /// <summary>
        /// Start listener.
        /// </summary>
        /// <param name="backlog">Number of pending accepts.</param>
        /// <exception cref="System.InvalidOperationException">Listener have already been started.</exception>
        /// <exception cref="System.Net.Sockets.SocketException">Failed to start socket.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Invalid port number.</exception>
        void Start(int backlog);

        /// <summary>
        /// Stop listener.
        /// </summary>
        void Stop();
    }
}
