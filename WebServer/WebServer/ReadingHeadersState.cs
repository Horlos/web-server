using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    public class ReadingHeadersState : ClientState
    {
        public ReadingHeadersState(ClientState clientState)
        {
            Client = clientState.Client;
        }
        public override void Process()
        {
            ProcessHeaders();
        }

        private void ProcessHeaders()
        {
            throw new NotImplementedException();
        }
    }
}
