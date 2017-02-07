using System.Linq;
using System.Threading.Tasks;
using application.Infrastructure.Persistence;
using application.Orders.Add;
using Autofac;
using domain.Model.CustomerRoot;
using domain.Model.OrderRoot;
using domain.Model.ProductRoot;
using Machine.Specifications;
using MediatR;
using Xunit;

namespace specs
{
    public class AddOrderSpecs
    {

        [Fact]
        public async Task when_adding_order_results_should_not_be_null()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<SpecsModule>();

            var container = builder.Build();

            var mediator = container.Resolve<IMediator>();
            var context = container.Resolve<IEntityFrameworkContext>();

            var product = new Product("TP1",101.25m,null,500) {Id = 1};
            context.Products.Add(product);

            var customer = new Customer("Charlie Brown") {Id = 1};
            context.Customers.Add(customer);

            var order = new Order(customer);
            order.AddItem(new OrderItem(product,2));


            var response = await mediator.Send(new AddOrderRequest(order));

            response.OrderTotal.ShouldBeGreaterThan(0);

        }

    }
}

