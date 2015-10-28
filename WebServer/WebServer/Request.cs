﻿namespace Webserver
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Cookies;
    using Headers;
    using Helpers;
    using Infrastructure;
    using Parameters;

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
        private bool _isDisposed;

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

            HeaderFactory headerFactory = HttpFactory.Current == null
                                              ? new HeaderFactory()
                                              : HttpFactory.Current.Create<HeaderFactory>();

            _headers = new HeaderCollection(headerFactory);
            if (!string.IsNullOrEmpty(path))
            {
                int pos = path.IndexOf("?", StringComparison.Ordinal);
                QueryString = pos != -1 ? UrlParser.Parse(path.Substring(pos + 1)) : new ParameterCollection();
            }

            Parameters = QueryString ?? new ParameterCollection();
            Uri = new Uri("http://not.specified.yet" + path);
        }

        /// <summary>
        /// Gets body stream.
        /// </summary>
        public Stream Body { get; private set; }

        /// <summary>
        /// Size of the body. MUST be specified before sending the header,
        /// unless property Chunked is set to <c>true</c>.
        /// </summary>
        /// <value>
        /// Any specifically assigned value or Body stream length.
        /// </value>
        public NumericHeader ContentLength
        {
            get
            {
                if (Body.Length > 0)
                    _contentLength.Value = Body.Length;
                return _contentLength;
            }

            set
            {
                if (value == null) return;

                _contentLength = value;

                if (_contentLength.Value <= 2000000)
                    return;

                _bodyFileName = Path.GetTempFileName();
                Body = new FileStream(_bodyFileName, FileMode.CreateNew);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ContentTypeHeader ContentType
        {
            get { return new ContentTypeHeader(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IHeaderCollection Headers
        {
            get { return _headers; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string HttpVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RequestMethodType Method { get; set; }

        /// <summary>
        /// Gets query string and form parameters
        /// </summary>
        public IParameterCollection Parameters { get; internal set; }

        /// <summary>
        /// Gets form parameters.
        /// </summary>
        public IParameterCollection Form
        {
            get
            {
                return _form;
            }

            internal set
            {
                _form = value;
                Parameters = new ParameterCollection(QueryString, _form);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IParameterCollection QueryString
        {
            get;
            private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsAjax
        {
            get { return default(bool); }
        }

        /// <summary>
        /// Gets cookies.
        /// </summary>
        public RequestCookieCollection Cookies
        {
            get { return _cookies ?? (_cookies = new RequestCookieCollection()); }

            private set { _cookies = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ConnectionHeader Connection
        {
            get { return new ConnectionHeader(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            get { return _headers.Count; }
        }

        /// <summary>
        /// 
        /// </summary>
        public IHeader[] Items { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public IHeader this[int i]
        {
            get { return _headers.Items[i]; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void Add(string name, IHeader value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="header"></param>
        public void Add(IHeader header)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IIterator<IHeader> GetIterator()
        {
            return _headers.GetIterator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IHeader> GetEnumerator()
        {
            return GetIterator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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
