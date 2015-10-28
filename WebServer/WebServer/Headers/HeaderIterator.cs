namespace Webserver.Headers
{
    using System;
    using System.Collections;
    using System.Linq;
    using Infrastructure;

    /// <summary>
    /// 
    /// </summary>
    public class HeaderIterator : IIterator<IHeader>
    {
        private HeaderCollection _headerCollection;
        private bool _isDisposed;

        public HeaderIterator(HeaderCollection headerCollection)
        {
            _headerCollection = headerCollection;
        }

        public IHeader First
        {
            get { return _headerCollection.Items.First(); }
        }

        public IHeader Last
        {
            get { return new ConnectionHeader(); }
        }

        public IHeader Next
        {
            get { return new ConnectionHeader(); }
        }

        public IHeader Current
        {
            get { return new ConnectionHeader(); }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool MoveNext()
        {
            return default(bool);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dispose"></param>
        private void Dispose(bool dispose)
        {
            if (!_isDisposed)
            {
                if (dispose)
                {
                    _isDisposed = true;
                }
            }
        }
    }
}
