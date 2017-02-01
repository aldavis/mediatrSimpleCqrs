using System.Web.Http;

namespace webApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            AutoFacContainerBuilder.BuildContainer();
        }
    }
}
