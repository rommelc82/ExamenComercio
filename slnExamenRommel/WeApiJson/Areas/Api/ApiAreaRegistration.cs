using System.Web.Mvc;

namespace WeApiJson.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "AccesoOrdenPago",
                "Api/OrdenPago",
                new {Controller = "OrdenPago", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Api_default",
                "Api/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
