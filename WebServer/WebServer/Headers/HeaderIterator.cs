using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.Infrastructure;

namespace WebServer.Headers
{
    public class HeaderIterator: IIterator<IHeader>
    {
        private HeaderCollection _headerCollection;

        public HeaderIterator(HeaderCollection headerCollection)
        {
            _headerCollection = headerCollection;
        }

        public IHeader First()
        {
            throw new NotImplementedException();
        }

        public IHeader Next()
        {
            throw new NotImplementedException();
        }

        public IHeader Current()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
