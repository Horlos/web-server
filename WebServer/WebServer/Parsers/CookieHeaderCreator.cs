namespace WebServer.Parsers
{
    using Cookies;
    using Headers;
    using Readers;

    /// <summary>
    /// Parses Cookie header.
    /// </summary>
    public class CookieHeaderCreator:IHeaderCreator
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
            //key: "value"; key: "value"

            var cookies = new RequestCookieCollection();
            while (!reader.EoF)
            {
                // read name
                string cookieName = reader.ReadToEnd("=;");

                // cookie with value?
                if (reader.Current == '=')
                {
                    reader.Consume();
                    reader.ConsumeWhiteSpaces();

                    // is value quoted or not?
                    string value = reader.Current == '"' ? reader.ReadQuotedString() : reader.ReadToEnd(";");
                    cookies.Add(new RequestCookie(cookieName, value));
                }
                //else
                //    cookies.Add(new RequestCookie(cookieName, string.Empty));

                // consume whitespaces and cookie separator
                reader.ConsumeWhiteSpaces(';');
            }

            return new CookieHeader(cookies);
        }

    }
}
