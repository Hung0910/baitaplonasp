using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BanDongHo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Route cho trang đăng nhập
            routes.MapRoute(
                name: "Admin_Login",
                url: "",
                defaults: new { controller = "Account", action = "Login", area = "Admin" },
                namespaces: new[] { "BanDongHo.Areas.Admin.Controllers" }
            );

            // Route cho các controller trong khu vực Admin
            routes.MapRoute(
            name: "Admin_Defaultrount",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Statistical", action = "GetStatistical", id = UrlParameter.Optional },
            namespaces: new[] { "BanDongHo.Areas.Admin.Controllers" }
        );


        }
    }

}
