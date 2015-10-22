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

        public IHeader First { get; }

        public IHeader Last { get; }

        public IHeader Next { get; }

        public IHeader Current { get; }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
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
