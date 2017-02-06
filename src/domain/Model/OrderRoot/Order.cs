using System.Collections.Generic;
using System.Linq;
using domain.Model.CustomerRoot;

namespace domain.Model.OrderRoot
{
    public class Order:IEntity<int>
    {
        public Order(Customer customer)
        {
            Customer = customer;
            Items = new List<OrderItem>();
        }

        protected Order() { }

        public int Id { get; set; }

        public virtual Customer Customer { get; }

        public virtual IList<OrderItem> Items { get; }

        public void AddItem(OrderItem item)
        {
            if (item.Product.Available(item.Quantity))
            {
                Items.Add(item);
            }
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public decimal CalculateTotal()
        {
            if (Customer.AllowedDiscountAmount != 0)
            {
                return Items.Sum(item => item.Product.Price);
            }

            return Items.Sum(item => item.Product.Price) - Customer.AllowedDiscountAmount;
        }
    }
}
