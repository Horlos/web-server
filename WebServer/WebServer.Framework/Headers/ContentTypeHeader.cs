namespace Webserver.Headers
{
    /// <summary>
    /// 
    /// </summary>
    public class ContentTypeHeader : IHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return "Content-Type"; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string HeaderValue
        {
            get { return default(string); }
        }
    }
}
