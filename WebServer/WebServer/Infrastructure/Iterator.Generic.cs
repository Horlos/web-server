using System;
using System.Collections;

namespace WebServer.Infrastructure
{
    public class Iterator<T> : IIterator<T> where T : class
    {
        private IAggregate<T> _collection;
        private int _currentIndex = 0;
        private int _step = 1;

        public Iterator(IAggregate<T> collection)
        {
            _collection = collection;
        }

        // Gets or sets stepsize
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
                    return _collection.Items[_currentIndex];
                return null;
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
                    return _collection.Items[0];
                return null;
            }
        }

        public T Last
        {
            get
            {
                var count = _collection.Count;
                if (count > 0)
                    return _collection.Items[count - 1];
                return null;
            }
        }

        public T Next
        {
            get
            {
                if (!(_currentIndex + 1 >= _collection.Count))
                    return _collection[_currentIndex + 1];
                return null;
            }
        }


        public bool MoveNext()
        {
            _currentIndex++;
            if (_currentIndex >= _collection.Items.Length)
                return false;
            return true;
        }

        public void Reset()
        {
            _currentIndex = 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
