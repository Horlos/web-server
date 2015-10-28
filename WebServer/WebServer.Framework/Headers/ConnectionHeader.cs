namespace Webserver.Headers
{
    /// <summary>
    /// 
    /// </summary>
    public class ConnectionHeader : IHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return "Connection"; }
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
