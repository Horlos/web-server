namespace Webserver
{
    using System.IO;
    using System.Text;
    using Headers;
    using Infrastructure;

    /// <summary>
    /// 
    /// </summary>
    public interface IMessage : IAggregate<IHeader>
    {
        /// <summary>
        /// Gets body stream.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        Stream Body { get; }

        /// <summary>
        /// Size of the body. MUST be specified before sending the header,
        /// unless property Chunked is set to <c>true</c>.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        NumericHeader ContentLength { get; }

        /// <summary>
        /// Kind of content in the body
        /// </summary>
        /// <remarks>
        /// Default is <c>text/html</c>
        /// </remarks>
        /// <value>
        /// 
        /// </value>
        ContentTypeHeader ContentType { get; }

        /// <summary>
        /// Gets or sets encoding
        /// </summary>
        /// <value>
        /// 
        /// </value>
        Encoding Encoding { get; set; }

        /// <summary>
        /// Gets headers.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        IHeaderCollection Headers { get; }

        /// <summary>
        /// Add a new header.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        void Add(string name, IHeader value);

        /// <summary>
        /// Add a new header.
        /// </summary>
        /// <param name="header">Header to add.</param>
        void Add(IHeader header);
    }
}
