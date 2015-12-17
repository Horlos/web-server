namespace WebServer.Exceptions
{
    using System;

    /// <summary>
    /// Something failed during parsing.
    /// </summary>
    public class ParserException : BadRequestException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParserException"/> class.
        /// </summary>
        /// <param name="exception">Exception description.</param>
        public ParserException(string exception) : base(exception)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParserException"/> class.
        /// </summary>
        /// <param name="exception">Exception description.</param>
        /// <param name="inner">Inner exception.</param>
        public ParserException(string exception, Exception inner)
            : base(exception, inner)
        {
        }
    }
}
