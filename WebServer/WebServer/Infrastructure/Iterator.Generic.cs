using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer.Infrastructure
{
    public class Iterator<T> : IIterator<T>
    {

        public T Current { get; }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public T First { get; }

        public T Last { get; }

        public T Next { get; }

      
        public bool MoveNext()
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
