using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Headers
{
    /// <summary>
    /// 
    /// </summary>
    public class ConnectionHeader : IHeader
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 
        /// </summary>
        public string HeaderValue { get; }
    }
}
