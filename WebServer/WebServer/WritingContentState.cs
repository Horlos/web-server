using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    public class WritingContentState : ClientState
    {
        public WritingContentState(ClientState clientState)
        {
            Client = clientState.Client;
        }
        public override void Process()
        {
            ProcessRequestCompleted();
        }

        private void ProcessRequestCompleted()
        {
            throw new NotImplementedException();
        }
    }
}
