namespace CarDealer.Domain
{
    public class Sale
    {
        public int Id { get; set; }

        public virtual Car Car { get; set; }
        
        public virtual Customer Customer { get; set; }

        public double Discount { get; set; }
    }
}
