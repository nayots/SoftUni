using Problem5_BorderControl.Interfaces;

namespace Problem5_BorderControl.Models
{
    public class Robot : IBeing
    {
        public Robot(string model, string id)
        {
            this.Id = id;
            this.Model = model;
        }

        public string Id { get; private set; }
        public string Model { get; private set; }
    }
}