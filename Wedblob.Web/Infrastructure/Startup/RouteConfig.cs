﻿using Wedblob.Web.Infrastructure.Startup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Wedblob.Web.Infrastructure.Startup
{
    public class RouteConfig : IStartupTask
    {
        public readonly RouteCollection Routes;

        public RouteConfig(RouteCollection routes)
        {
            this.Routes = routes;
        }

        public void Execute()
        {
            Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            Routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Default", action = "Index" }
            );


            Routes.MapRoute(
               name: "RSVPServiceIndex",
               url: "api/rsvp",
               defaults: new { controller = "RSVP", action = "Index" },
               constraints: new { httpMethod = new HttpMethodConstraint(new[] { "GET" }) }
           );

            Routes.MapRoute(
                name: "RSVPServiceGet",
                url: "api/rsvp/{tag}",
                defaults: new { controller = "RSVP", action = "Get" },
                constraints: new { httpMethod = new HttpMethodConstraint(new[] { "GET" }) }
            );

            Routes.MapRoute(
                name: "RSVPServicePut",
                url: "api/rsvp/{tag}",
                defaults: new { controller = "RSVP", action = "Put"},
                constraints: new { httpMethod = new HttpMethodConstraint(new[] { "PUT" }) }
            );

            Routes.MapRoute(
               name: "RSVPServicePost",
               url: "api/rsvp/",
               defaults: new { controller = "RSVP", action = "Post" },
               constraints: new { httpMethod = new HttpMethodConstraint(new[] { "POST" }) }
           );
        }

        public int ExecutionOrder
        {
            get { return 0; }
        }
    }
}
