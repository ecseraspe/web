using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Youffer.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Download",
              url: "Download",
              defaults: new { controller = "Common", action = "Download", id = UrlParameter.Optional }
              );

            routes.MapRoute(
                name: "Contact",
                url: "Contact",
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Terms",
                url: "Terms",
                defaults: new { controller = "Home", action = "TermsandCondition", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "What Is Youffer",
                url: "WhatIsYouffer",
                defaults: new { controller = "Home", action = "WhatIsYouffer", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "How It Works",
                url: "HowItWorks",
                defaults: new { controller = "Home", action = "HowItWorks", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Privacy Policy",
                url: "PrivacyPolicy",
                defaults: new { controller = "Home", action = "PrivacyPolicy", id = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
