namespace WebServer.Infrastructure
{
    using System;
    using System.Collections;
    using System.Linq;

    public class Iterator<T> : IIterator<T>
    {
        private IAggregateCollection<T> _collection;
        private int _currentIndex;
        private int _step;
        private bool _isDisposed;

        public Iterator(IAggregateCollection<T> collection)
        {
            _step = 1;
            _currentIndex = 0;
            _collection = collection;
        }

        /// <summary>
        /// Gets or sets stepsize
        /// </summary>
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }

        public T Current
        {
            get
            {
                if (_collection.Count > 0 && _currentIndex > -1)
                    return _collection.Items.ElementAt(_currentIndex);
                return default(T);
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public T First
        {
            get
            {
                if (_collection.Count > 0)
                    return _collection.Items.First();
                return default(T);
            }
        }

        public T Last
        {
            get
            {
                if (_collection.Count > 0)
                    return _collection.Items.Last();
                return default(T);
            }
        }

        public T Next
        {
            get
            {
                if (!(_currentIndex + 1 >= _collection.Count))
                    return _collection.Items.ElementAt(_currentIndex + 1);
                return default(T);
            }
        }

        public bool MoveNext()
        {
            _currentIndex++;
            if (_currentIndex >= _collection.Items.Count)
            {
                _currentIndex--;
                return false;
            }

            return true;
        }

        public void Reset()
        {
            _currentIndex = 0;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _collection = null;
                    _isDisposed = true;
                }
            }
        }
    }
}
