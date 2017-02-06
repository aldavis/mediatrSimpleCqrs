using domain.Model.ProductRoot;

namespace domain.Model.OrderRoot
{
    public class OrderItem:IEntity<int>
    {
        public OrderItem(Product product,int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        protected OrderItem() { }

        public int Id { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; private set; }

        public int Quantity { get; private set; }
    }
}
