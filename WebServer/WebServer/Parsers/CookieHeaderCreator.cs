namespace Webserver.Parsers
{
    using Cookies;
    using Headers;
    using Readers;

    /// <summary>
    /// Parses Cookie header.
    /// </summary>
    public class CookieHeaderCreator : IHeaderCreator
    {
        /// <summary>
        /// Parse a header
        /// </summary>
        /// <param name="name">Name of header.</param>
        /// <param name="reader">Reader containing value.</param>
        /// <returns>HTTP Header</returns>
        /// <exception cref="System.FormatException">Header value is not of the expected format.</exception>
        public IHeader Create(string name, ITextReader reader)
        {
            if (reader == null) return null;
            var cookies = new RequestCookieCollection();
            while (!reader.Eof)
            {
                string cookieName = reader.ReadToEnd("=;");

                if (reader.Current == '=')
                {
                    reader.Consume();
                    reader.ConsumeWhiteSpaces();

                    string value = reader.Current == '"' ? reader.ReadQuotedString() : reader.ReadToEnd(";");
                    cookies.Add(new RequestCookie(cookieName, value));
                } 

                reader.ConsumeWhiteSpaces(';');
            }

            return new CookieHeader(cookies);
        }
    }
}
