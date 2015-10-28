namespace Webserver.Parsers
{
    using System;
    using System.Globalization;
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
            if (reader == null) return null;
            string temp = reader.ReadToEnd();
            int value;
            if (!int.TryParse(temp, out value))
                throw new FormatException(string.Format("Header '{0}' do not contain a numerical value ('{1}').", name, temp, CultureInfo.CurrentCulture));
            return new NumericHeader(name, value);
        }
    }
}
