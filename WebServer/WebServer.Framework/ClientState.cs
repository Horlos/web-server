using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    public abstract class ClientState
    {
        private HttpClient _client;

        public HttpClient Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public abstract void Process();
    }
}
