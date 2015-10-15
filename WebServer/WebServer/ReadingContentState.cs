using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    public class ReadingContentState : ClientState
    {
        public ReadingContentState(ClientState clientState)
        {
            Client = clientState.Client;
        }
        public override void Process()
        {
            ProcessContent();
        }

        private void ProcessContent()
        {
            throw new NotImplementedException();
        }
    }
}
