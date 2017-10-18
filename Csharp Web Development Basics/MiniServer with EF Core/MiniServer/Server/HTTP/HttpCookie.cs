using System;

namespace MiniServer.Server.HTTP
{
    public class HttpCookie
    {
        public HttpCookie(string key, string value, int expires = 3)
        {
            Key = key;
            Value = value;
            Expires = DateTime.UtcNow.AddDays(expires);
        }

        public HttpCookie(string key, string value, bool isNew, int expires = 3) : this(key, value, expires)
        {
            IsNew = isNew;
        }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public DateTime Expires { get; private set; }

        public bool IsNew { get; private set; } = true;

        public override string ToString()
        {
            return $"{this.Key}={this.Value}; Expires={this.Expires.ToLongTimeString()}";
        }
    }
}