using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace KPService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            UseOnlyJSONSerializer();

            GlobalConfiguration.Configure(WebApiConfig.Register); 
        }

        private static void UseOnlyJSONSerializer()
        {
            // Set serializer settings
            // read more http://www.asp.net/web-api/overview/formats-and-model-binding/json-and-xml-serialization
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);     // using JSON only (without XML)
            var jsonSettings = GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Newtonsoft.Json.Formatting.Indented;                  // indented JSON
            jsonSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;   // only UTC time in JSON fields
        }
    }
}
