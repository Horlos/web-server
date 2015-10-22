namespace WebServer.Cookies
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure;

    /// <summary>
    /// A list of request cookies.
    /// </summary>
    public class RequestCookieCollection : Aggregate<RequestCookie>
    {
        private readonly IDictionary<string, RequestCookie> _items = new Dictionary<string, RequestCookie>();

        /// <summary>
        ///  Gets the count of cookies in the collection.
        /// </summary>
        public override int Count
        {
            get { return _items.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public override RequestCookie[] Items { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public override RequestCookie this[int i]
        {
            get { return _items.Values.ElementAtOrDefault(i); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerator<RequestCookie> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IIterator<RequestCookie> GetIterator()
        {
            throw new System.NotImplementedException();
        }

        public RequestCookieCollection() : this(0)
        {
        }

        public RequestCookieCollection(int size) : base(size)
        {
        }
    }
}
