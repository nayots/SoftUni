namespace Problem8_Pet_Clinics.Models
{
    public class Room
    {
        public Pet SickPet { get; set; }

        public override string ToString()
        {
            if (this.SickPet is null)
            {
                return $"Room empty";
            }
            else
            {
                return this.SickPet.ToString();
            }
        }
    }
}