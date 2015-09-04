using System.Web.Mvc;

namespace WebApplication.Areas.UserArea
{
    public class UserAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "UserArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "UserArea_default",
                "{controller}/{action}/{id}",
                new { controlle = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}