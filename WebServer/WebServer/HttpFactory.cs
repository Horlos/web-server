using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServer
{
    public class HttpFactory : IHttpFactory
    {
        public static IHttpFactory Current { get; set; }

        public T Get<T>(params object[] constructorArguments) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
