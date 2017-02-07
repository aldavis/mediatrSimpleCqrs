using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using application.Infrastructure.Persistence;
using domain.Model;
using domain.Model.CustomerRoot;
using domain.Model.OrderRoot;
using domain.Model.ProductRoot;

namespace specs
{
    public class MockEntityFrameworkContext : IEntityFrameworkContext
    {
        public MockEntityFrameworkContext()
        {
            Products = new MockDbSet<Product>();
            Orders = new MockDbSet<Order>();
            OrderItems = new MockDbSet<OrderItem>();
            Customers = new MockDbSet<Customer>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public DbEntityEntry<T> Entity<T>(T entity) where T : class, IEntity<int>
        {
            return new object() as DbEntityEntry<T>;
        }

        public int SaveChanges()
        {
            return 1;
        }

        public Task<int> SaveChangesAsync()
        {
            return Task.FromResult(1);
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}