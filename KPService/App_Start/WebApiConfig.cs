﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace KPService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // оставляем только JSON сериализатор
            config.Formatters.Clear();
            config.Formatters.Add(new System.Net.Http.Formatting.JsonMediaTypeFormatter());

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api10/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
