namespace WebServer.Parsers
{
    using Headers;
    using Readers;

    /// <summary>
    /// Create <see cref="StringHeader"/>.
    /// </summary>
    public class StringHeaderCreator : IHeaderCreator
    {
        /// <summary>
        /// Create a <see cref="StringHeader"/> header.
        /// </summary>
        /// <param name="name">Name of header.</param>
        /// <param name="reader">Reader containing value.</param>
        /// <returns>HTTP Header</returns>
        /// <exception cref="System.FormatException">Header value is not of the expected format.</exception>
        public IHeader Create(string name, ITextReader reader)
        {
            var value = reader.ReadToEnd();
            return new StringHeader(name, value);
        }
    }
}
