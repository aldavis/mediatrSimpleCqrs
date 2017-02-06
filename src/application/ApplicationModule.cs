using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Reflection;
using application.Orders.Add;
using Autofac;
using Autofac.Features.Variance;
using MediatR;
using Module = Autofac.Module;

namespace application
{
    public class ApplicationModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //dont like this
            builder.RegisterType<AddOrderValidator>().AsSelf();

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
            builder.RegisterInstance(Console.Out).As<TextWriter>();
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
