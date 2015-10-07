using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    public class ClosedState : ClientState
    {
        public ClosedState(ClientState clientState)
        {
            Client = clientState.Client;
        }
        public override void Process()
        {
            throw new InvalidOperationException("Invalid state");
        }
    }
}
