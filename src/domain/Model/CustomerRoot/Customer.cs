using System.Collections.Generic;
using domain.Model.OrderRoot;

namespace domain.Model.CustomerRoot
{
    public class Customer:IEntity<int>
    {
        public Customer(string name, decimal allowableDiscout = 0)
        {
            Name = name;
            AllowedDiscountAmount = allowableDiscout;
            Orders = new List<Order>();
        }

        protected Customer()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }

        public string Name { get; private set; }

        public decimal AllowedDiscountAmount { get; private set; }

        public virtual IList<Order> Orders { get; set; }

        public decimal AccountBalance { get; private set; }

        public void CreditAccount(decimal amount)
        {
            AccountBalance += amount;
        }

        public void DebitAccount(decimal amount)
        {
            AccountBalance -= amount;
        }
    }
}
