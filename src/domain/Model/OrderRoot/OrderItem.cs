using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Required]
        public int OrderId { get; set; }
        
        public Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; private set; }

        public int Quantity { get; private set; }
    }
}
