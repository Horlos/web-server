using System;
using System.Collections;
using WebServer.Infrastructure;

namespace WebServer.Headers
{
    public class HeaderIterator : IIterator<IHeader>
    {
        private HeaderCollection _headerCollection;

        public HeaderIterator(HeaderCollection headerCollection)
        {
            _headerCollection = headerCollection;
        }

        public IHeader First { get {return new ConnectionHeader();} }

        public IHeader Last { get { return new ConnectionHeader(); } }

        public IHeader Next { get { return new ConnectionHeader(); } }

        public IHeader Current { get { return new ConnectionHeader(); } }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            return default(bool);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        #region IDisposable

        private bool _isDisposed;

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool dispose)
        {
            if (!_isDisposed)
            {
                if (dispose)
                {
                    _isDisposed = true;
                    GC.SuppressFinalize(this);
                }
            }
        }

        #endregion IDisposable
    }
}
