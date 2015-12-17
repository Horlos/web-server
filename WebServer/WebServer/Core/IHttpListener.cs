namespace WebServer
{
    using System;
    using System.Net;
    using NLog;

    /// <summary>
    /// Http listener
    /// </summary>
    public interface IHttpListener : IDisposable
    {
        /// <summary>
        /// A new request have been received.
        /// </summary>
        event EventHandler<RequestEventArgs> RequestReceived;

        /// <summary>
        /// Can be used to reject certain clients.
        /// </summary>
        event EventHandler<SocketFilterEventArgs> SocketAccepted;

        /// <summary>
        /// A HTTP exception have been thrown.
        /// </summary>
        /// <remarks>
        /// Fill the body with a user friendly error page, or redirect to somewhere else.
        /// </remarks>
        event EventHandler<ErrorPageEventArgs> ErrorPageRequested;

        /// <summary>
        /// Gets listener address.
        /// </summary>
        /// <value>
        /// 
        /// </value> 
        IPAddress Address { get; }

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
        /// <exception cref="InvalidOperationException">Listener have already been started.</exception>
        /// <exception cref="System.Net.Sockets.SocketException">Failed to start socket.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Invalid port number.</exception>
        void Start(int backlog);

        /// <summary>
        /// Stop listener.
        /// </summary>
        void Stop();
    }
}
