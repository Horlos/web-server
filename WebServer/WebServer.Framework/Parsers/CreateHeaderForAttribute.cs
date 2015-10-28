namespace Webserver.Parsers
{
    using System;

    /// <summary>
    /// Used to define which headers a parse is for.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class CreateHeaderForAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateHeaderForAttribute"/> class.
        /// </summary>
        /// <param name="headerName">Name of the header.</param>
        public CreateHeaderForAttribute(string headerName)
        {
            HeaderName = headerName;
        }

        /// <summary>
        /// Gets name of header that this parser is for.
        /// </summary>
        public string HeaderName { get; private set; }
    }
}