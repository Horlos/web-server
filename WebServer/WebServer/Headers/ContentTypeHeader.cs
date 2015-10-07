using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Headers
{
    public class ContentTypeHeader : IHeader
    {
        public string Name { get; }
        public string HeaderValue { get; }
    }
}
