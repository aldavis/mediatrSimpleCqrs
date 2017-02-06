using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using domain.Model;
using domain.Model.CustomerRoot;
using domain.Model.OrderRoot;
using domain.Model.ProductRoot;

namespace application.Persistence
{
    public interface IEntityFrameworkContext :IDisposable
    {
        DbEntityEntry<T> Entity<T>(T entity) where T : class, IEntity<int>;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        DbSet<Order> Orders { get; set; }

        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Customer> Customers { get; set; }

        DbSet<Product> Products { get; set; }
    }
}