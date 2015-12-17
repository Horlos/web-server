namespace WebServer.Headers
{
    /// <summary>
    /// Used to store all headers that aren't recognized.
    /// </summary>
    public class StringHeader : IHeader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringHeader"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public StringHeader(string name, string value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Gets or sets value.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets header name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string HeaderValue
        {
            get { return Value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Value;
        }
    }
}
