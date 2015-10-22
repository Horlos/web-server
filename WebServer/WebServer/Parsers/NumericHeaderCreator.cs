namespace WebServer.Parsers
{
    using System;
    using Headers;
    using Readers;

    /// <summary>
    /// Create <see cref="NumericHeader"/>.
    /// </summary>
    public class NumericHeaderCreator : IHeaderCreator
    {
        /// <summary>
        /// Create a <see cref="NumericHeader"/> header.
        /// </summary>
        /// <param name="name">Name of header.</param>
        /// <param name="reader">Reader containing value.</param>
        /// <returns>HTTP Header</returns>
        /// <exception cref="FormatException">Header value is not of the expected format.</exception>
        public IHeader Create(string name, ITextReader reader)
        {
            string temp = reader.ReadToEnd();
            int value;
            if (!int.TryParse(temp, out value))
                throw new FormatException($"Header '{name}' do not contain a numerical value ('{temp}').");
            return new NumericHeader(name, value);
        }
    }
}
