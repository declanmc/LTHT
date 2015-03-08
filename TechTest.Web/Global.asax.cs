using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TechTest.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
                                         .ContractResolver = new DefaultContractResolver();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings
                                            .ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
    }
}
