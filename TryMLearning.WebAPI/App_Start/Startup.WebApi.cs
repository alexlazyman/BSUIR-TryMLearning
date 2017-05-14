using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TryMLearning.WebAPI.App_Helpers;

namespace TryMLearning.WebAPI
{
    public partial class Startup
    {
        public void InitializeWebApi(HttpConfiguration config)
        {
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Ignore the Serializable attribute on models when converting the model to json
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                new CamelCasePropertyNamesContractResolver { IgnoreSerializableAttribute = true };

            // We consider date to be stored in UTC format so the convertion should be avoided
            config.Formatters.JsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Unspecified;

            // Do not serialize props with null value to reduce traffic amount
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            config.Filters.Add(new ApplicationExceptionAttribute());
        }
    }
}
