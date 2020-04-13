using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ShoppingCartDataLayer.Factories;
using ShoppingCartEFDataLayer.Factories;


namespace ShoppingSystemWebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DataStoreFactory.Initialize(userRepositoryFactory : new UserRepositoryFactory(),
                cartRepositoryFactory : new CartRepositoryFactory(),
                itemRepositoryFactory : new ItemRepositoryFactory(),
                cartItemRepositoryFactory : new CartItemRepositoryFactory(),
                orderItemRepositoryFactory:new OrderItemRepositoryFactory(),
                orderRepositoryFactory : new OrderRepositoryFactory());
        }
    }
}
