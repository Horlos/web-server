using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebServer.Exceptions;

namespace WebServer
{
    public class ReadingPrologState : ClientState
    {
        private static readonly Regex PrologRegex = new Regex("^([A-Z]+) ([^ ]+) (HTTP/[^ ]+)$", RegexOptions.Compiled);

        public ReadingPrologState(ClientState clientState)
        {
            Client = clientState.Client;
        }
        public override void Process()
        {
            ProcessProlog();
        }

        private void ProcessProlog()
        {
            throw new NotImplementedException();
        }
    }
}
