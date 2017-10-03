namespace MiniServer.Server.HTTP
{
    public class HttpHeader
    {
        public HttpHeader(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            string result = $"{this.Key}: {this.Value}";
            return result;
        }
    }
}