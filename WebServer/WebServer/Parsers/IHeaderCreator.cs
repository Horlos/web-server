namespace WebServer.Parsers
{
    using Headers;
    using Readers;

    /// <summary>
    /// Used to create <see cref="IHeader"/>.
    /// </summary>
    public interface IHeaderCreator
    {
        /// <summary>
        /// Create a header.
        /// </summary>
        /// <param name="name">Name of header.</param>
        /// <param name="reader">Reader containing value.</param>
        /// <returns>HTTP Header</returns>
        /// <exception cref="System.FormatException">Header value is not of the expected format.</exception>
        IHeader Create(string name, ITextReader reader);
    }
}
