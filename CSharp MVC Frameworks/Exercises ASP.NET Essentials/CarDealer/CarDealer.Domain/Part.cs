namespace CarDealer.Domain
{
    using System.Collections.Generic;

    public class Part
    {
        public Part()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public double? Price { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
