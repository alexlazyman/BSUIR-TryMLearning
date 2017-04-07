﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace TryMLearning.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.Initialize();
            UnityConfig.RegisterComponents();
            SwaggerConfig.Register();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
