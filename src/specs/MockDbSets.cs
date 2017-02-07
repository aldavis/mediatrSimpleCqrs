using domain.Model.CustomerRoot;
using domain.Model.OrderRoot;
using domain.Model.ProductRoot;

namespace specs
{
    public class MockProductDbSet : MockDbSet<Product>{}

    public class MockOrderDbSet : MockDbSet<Order> { }

    public class MockOrderItemDbSet : MockDbSet<OrderItem> { }

    public class MockCustomerDbSet : MockDbSet<Customer> { }
}