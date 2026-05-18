using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Routing;

using Api.Converters;


namespace Api
{
    public static class WebApiConfig
    {
        #region Methods
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "HomeApi",
                routeTemplate: "Home",
                defaults: new { controller = "Home", action = "Index" });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" }
            );

            WebApiConfig.Setup(config);
        }
        #endregion

        #region Assistants
        private static void Setup(HttpConfiguration config)
        {
            JsonMediaTypeFormatter json = config.Formatters.JsonFormatter;
            json.SerializerSettings.Converters.Add(new DataConverter());

            config.Formatters.Clear();
            config.Formatters.Add(json);
        }
        #endregion
    }
}
