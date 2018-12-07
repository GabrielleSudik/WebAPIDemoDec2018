using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

//this page does not exist in a normal mvc project
//usually just bundle, filter and route configs
//see the line "routeTemplate" below?
//it sets how the get/post/put/delete routes are written
//ie, "/api/values/2" , id is set to optional on next line.

namespace WebAPIDemoDec2018
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
