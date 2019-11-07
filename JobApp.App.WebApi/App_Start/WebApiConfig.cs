using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.WebApi;

using JobApp.App.Core.DependencyInjection;
using System.Web.Http.Dependencies;
using System.Web.Http.Cors;

namespace JobApp.App.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            AppInjection.Configure(container);

            config.DependencyResolver = new UnityDependencyResolver(container);

            var cors = new EnableCorsAttribute("http://localhost:4200", "*", "*");
            cors.SupportsCredentials = true;

            config.EnableCors(cors);
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "BrowseDataEndPoint",
                routeTemplate: "api/{controller}/{action}/{page}/{pageSize}/{sort}/{sortDirection}/{filterData}",
                defaults: new { page = RouteParameter.Optional, pageSize = RouteParameter.Optional, sort = RouteParameter.Optional, sortDirection = RouteParameter.Optional, filterData = RouteParameter.Optional }
            );

            //int page, int pageSize, string sortData, string filterData
        }
    }
}
