using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json.Converters;
using ShoppingSystemWebAPI.Filters;
using ShoppingSystemWebAPI.MessageHandlers;
using ShoppingCartEFDataLayer.Repositories;
using ShoppingSystemWebAPI.Authentication;

namespace ShoppingSystemWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ShoppingApiRoute",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Filters.Add(new ApiExceptionHandlerAttribute());

            config.Filters.Add(new ValidateModelStateAttribute());

            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new StringEnumConverter());

            config.MessageHandlers.Add(new AuthMessageHandler(new AuthRepository()));
        }
    }
}
