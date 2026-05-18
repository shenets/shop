using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Routing;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace Site
{
    public static class WebApiConfig
    {
        #region Methods
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "HomeApi",
                routeTemplate: "Api/Home");

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "Api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional });

            WebApiConfig.Setup(config);
        }
        #endregion

        #region Assistants
        private static void Setup(HttpConfiguration config)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Formatting = Formatting.Indented;
            settings.TypeNameHandling = TypeNameHandling.Objects;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            JsonMediaTypeFormatter formatter = config.Formatters.JsonFormatter;
            formatter.SerializerSettings = settings;

            config.Formatters.Clear();
            config.Formatters.Add(formatter);
        }
        #endregion
    }
}
