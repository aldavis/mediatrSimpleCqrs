using System.Data.Entity.Migrations;
using System.Linq;
using domain.Model.CustomerRoot;
using domain.Model.ProductRoot;

namespace application.Infrastructure.Persistence.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<EntityFrameworkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EntityFrameworkContext context)
        {
            if (!context.Products.Any())
            {
                var productOne = new Product("TP1", 102.25m, "Test Product One");
                var productTwo = new Product("TP2", 10.25m, "Test Product Two",5,3,10);

                context.Products.Add(productOne);
                context.Products.Add(productTwo);

                context.SaveChanges();
            }

            if (context.Customers.Any()) return;

            var customerOne = new Customer("Test Customer One", 10);
            var customerTwo = new Customer("Test Customer Two");

            customerOne.CreditAccount(2500);
            customerTwo.CreditAccount(5500);

            context.Customers.Add(customerOne);
            context.Customers.Add(customerTwo);

            context.SaveChanges();
        }
    }
}
