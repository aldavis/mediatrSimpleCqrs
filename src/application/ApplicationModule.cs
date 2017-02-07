using System.Collections.Generic;
using System.Reflection;
using application.Infrastructure.Authentication;
using application.Infrastructure.Logging;
using application.Orders.Add;
using Autofac;
using Autofac.Features.Variance;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Module = Autofac.Module;

namespace application
{
    public class ApplicationModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //register all validators
            AssemblyScanner
               .FindValidatorsInAssemblyContaining<AddOrderValidator>()
               .ForEach(x => builder.RegisterType(x.ValidatorType).As(x.InterfaceType).SingleInstance());

            builder.RegisterType<Logger>().AsSelf();

            RegisterMediatR(builder);

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .InstancePerRequest();
        }

        void RegisterMediatR(ContainerBuilder builder)
        {
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(ApplicationModule).GetTypeInfo().Assembly).AsImplementedInterfaces();

            //register pipeline behaviors(order of registration matters in some cases)
            builder.RegisterGeneric(typeof(AuthenticationBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            

            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t =>
                {
                    object o;
                    return c.TryResolve(t, out o) ? o : null;
                };
            });
            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });
        }
    }
}
