using MiniServer.Server.HTTP.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MiniServer.Server.HTTP
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, ICollection<HttpHeader>> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, ICollection<HttpHeader>>();
        }

        public void Add(HttpHeader header)
        {
            if (!this.headers.ContainsKey(header.Key))
            {
                this.headers[header.Key] = new List<HttpHeader>();
            }
            this.headers[header.Key].Add(header);
        }

        public bool ContainsKey(string key)
        {
            return this.headers.ContainsKey(key);
        }

        public IEnumerator<ICollection<HttpHeader>> GetEnumerator()
        {
            return this.headers.Values.GetEnumerator();
        }

        public ICollection<HttpHeader> GetHeader(string key)
        {
            if (!this.headers.ContainsKey(key))
            {
                throw new InvalidOperationException($"The given key {key} is not present in the headers collection.");
            }

            return this.headers[key];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.headers.Values.GetEnumerator();
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var header in this.headers)
            {
                var headerKey = header.Key;

                foreach (var headerValue in header.Value)
                {
                    result.AppendLine($"{headerKey}: {headerValue.Value}");
                }
            }

            return result.ToString();
        }
    }
}