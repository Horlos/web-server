using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    public class WritingHeadersState : ClientState
    {
        public WritingHeadersState(ClientState clientState)
        {
            Client = clientState.Client;
        }
        public override void Process()
        {
           WriteResponseContent();
        }

        private void WriteResponseContent()
        {
            throw new NotImplementedException();
        }
    }
}
