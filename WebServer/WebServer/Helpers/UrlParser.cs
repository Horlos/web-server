namespace Webserver.Helpers
{
    using Parameters;

    /// <summary>
    /// Parses query string
    /// </summary>
    public static class UrlParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public static ParameterCollection Parse(string queryString)
        {
            if (string.IsNullOrEmpty(queryString))
                return null;

            return new ParameterCollection();
        }
    }
}
