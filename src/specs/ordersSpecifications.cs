using System.Threading.Tasks;
using application;
using application.Orders.Add;
using Autofac;
using Machine.Specifications;
using MediatR;

namespace specs
{
    public class when_adding_new_order
    {
        static IMediator _mediator;
        static Task<AddOrderResult> _result;

        Establish context = () =>
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ApplicationModule>();
            var container = builder.Build();

            _mediator = container.Resolve<IMediator>();
        };

        Because of = () => _result = _mediator.Send(new AddOrderRequest("1","jkjk",1));

        It should_return_add_order_result = () => _result.Result.ShouldNotBeNull();
    }
}
