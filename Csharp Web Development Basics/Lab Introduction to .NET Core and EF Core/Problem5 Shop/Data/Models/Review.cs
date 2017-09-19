namespace Problem5Shop.Data.Models
{
    public class Review
    {
        public Review(int customerId, int itemId)
        {
            this.CustomerId = customerId;
            this.ItemId = itemId;
        }

        public int Id { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }
    }
}