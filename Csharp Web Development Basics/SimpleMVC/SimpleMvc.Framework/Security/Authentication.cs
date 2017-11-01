namespace SimpleMvc.Framework.Security
{
    public class Authentication
    {
        internal Authentication()
        {
            this.IsAuthenticated = false;
        }

        internal Authentication(string name)
        {
            this.Name = name;
            this.IsAuthenticated = true;
        }

        public bool IsAuthenticated { get; private set; }

        public string Name { get; private set; }
    }
}
