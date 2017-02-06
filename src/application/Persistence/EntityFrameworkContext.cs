using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using domain.Model;
using domain.Model.CustomerRoot;
using domain.Model.OrderRoot;
using domain.Model.ProductRoot;

namespace application.Persistence
{
    public class EntityFrameworkContext:DbContext,IEntityFrameworkContext
    {
        public EntityFrameworkContext():base("DefaultConnection"){}

        public DbEntityEntry<T> Entity<T>(T entity) where T : class, IEntity<int>
        {
            return Entry(entity);
        }

        public static EntityFrameworkContext Create()
        {
            return new EntityFrameworkContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new ForeignKeyNamingConvention());

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
