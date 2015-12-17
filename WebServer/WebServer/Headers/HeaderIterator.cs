namespace WebServer.Headers
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
        private int _currentIndex;
        private bool _isDisposed;

        public HeaderIterator(HeaderCollection headerCollection)
        {
            _headerCollection = headerCollection;
        }

        public IHeader First
        {
            get
            {
                if (_headerCollection.Items.Count > 0)
                    return _headerCollection.Items.First();
                return null;
            }
        }

        public IHeader Last
        {
            get
            {
                if (_headerCollection.Items.Count > 0)
                    return _headerCollection.Items.Last();
                return null;
            }
        }

        public IHeader Next
        {
            get
            {
                if (!(_currentIndex + 1 >= _headerCollection.Items.Count))
                    return _headerCollection.Items.ElementAt(_currentIndex + 1);
                return null;
            }
        }

        public IHeader Current
        {
            get
            {
                if (_headerCollection.Count > 0 && _currentIndex > -1)
                    return _headerCollection.Items.ElementAt(_currentIndex);
                return null;
            }
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
            _currentIndex++;
            if (_currentIndex >= _headerCollection.Items.Count)
            {
                _currentIndex--;
                return false;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Reset()
        {
            _currentIndex = 0;
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
                    _headerCollection = null;
                    _isDisposed = true;
                }
            }
        }
    }
}
