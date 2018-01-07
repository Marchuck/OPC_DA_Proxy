using OPC_DA_Proxy.OpcDaClient;
using System.Net.Http.Headers;
using System.Web.Http;

namespace OPC_DA_Proxy
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            OpcDaRunner.getInstance().Connect();
            // Web API routes
            config.MapHttpAttributeRoutes();
             
            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional }
           );
            
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            
        }
    }
}
