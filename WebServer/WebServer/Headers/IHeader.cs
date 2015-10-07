namespace WebServer.Headers
{
    /// <summary>
    /// Header in a message
    /// </summary>
    public interface IHeader
    {
        /// <summary>
        /// Gets header name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets value as it would be sent back to client.
        /// </summary>
        string HeaderValue { get; }
    }
}
