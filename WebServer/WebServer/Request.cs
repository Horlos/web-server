using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebServer.Cookies;
using WebServer.Headers;
using WebServer.Helpers;
using WebServer.Infrastructure;
using WebServer.Parameters;

namespace WebServer
{
    /// <summary>
    /// 
    /// </summary>
    public class Request : IRequest, IDisposable
    {
        private readonly HeaderCollection _headers;
        private NumericHeader _contentLength = new NumericHeader("Content-Length", 0);
        private RequestCookieCollection _cookies;
        private IParameterCollection _form;
        private string _bodyFileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="path">The path.</param>
        /// <param name="version">The version.</param>
        public Request(RequestMethodType method, string path, string version)
        {
            Body = new MemoryStream();
            Method = method;
            HttpVersion = version;
            Encoding = Encoding.UTF8;

            // HttpFactory is not set during tests.
            HeaderFactory headerFactory = HttpFactory.Current == null
                                              ? new HeaderFactory()
                                              : HttpFactory.Current.Get<HeaderFactory>();

            _headers = new HeaderCollection(headerFactory);

            // Parse query string.
            int pos = path.IndexOf("?", StringComparison.Ordinal);
            QueryString = pos != -1 ? UrlParser.Parse(path.Substring(pos + 1)) : new ParameterCollection();

            Parameters = QueryString;
            Uri = new Uri("http://not.specified.yet" + path);
        }

        public Stream Body { get; }

        public NumericHeader ContentLength { get; }

        public ContentTypeHeader ContentType { get; }

        public Encoding Encoding { get; set; }

        public IHeaderCollection Headers { get; }

        public void Add(string name, IHeader value)
        {
            throw new NotImplementedException();
        }

        public void Add(IHeader header)
        {
            throw new NotImplementedException();
        }

        public string HttpVersion { get; set; }

        public Uri Uri { get; set; }

        public RequestMethodType Method { get; set; }

        public IParameterCollection Parameters { get; }

        public IParameterCollection QueryString { get; }

        public bool IsAjax { get; }

        public RequestCookieCollection Cookies { get; }

        public ConnectionHeader Connection { get; }


        public IIterator<IHeader> GetIterator()
        {
            return _headers.GetIterator();
        }

        public int Count { get; }
        public IHeader[] Items { get; set; }

        public IHeader this[int i]
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerator<IHeader> GetEnumerator()
        {
            return GetIterator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
