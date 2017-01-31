using System.Reflection;
using System.Web.Http;
using application;
using Autofac;
using Autofac.Integration.WebApi;

namespace webApi
{
    public class AutoFacContainerBuilder
    {
        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<ApplicationModule>();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}