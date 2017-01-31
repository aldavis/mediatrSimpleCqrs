namespace domain.Model
{
    public class Order:IEntity<int>
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal CalculateTotal()
        {
            if (Customer.AllowedDiscountAmount != 0)
            {
                return Product.Price;
            }

            return Product.Price - Customer.AllowedDiscountAmount;
        }
    }
}
