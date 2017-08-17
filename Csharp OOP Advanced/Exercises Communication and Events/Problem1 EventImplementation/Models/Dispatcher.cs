namespace Problem1_EventImplementation.Models
{
    public delegate void NameChangeEventHandler(object sender, NameChangeArgs args);

    public class Dispatcher
    {
        private string name;

        public event NameChangeEventHandler NameChange;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                OnNameChange(new NameChangeArgs(value));
            }
        }

        public void OnNameChange(NameChangeArgs args)
        {
            NameChange?.Invoke(this, args);
        }
    }
}