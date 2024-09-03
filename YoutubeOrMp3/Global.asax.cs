using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BusinessLayer.Concrete;
using DataAccessLayer;
using YoutubeOrMp3.Controllers;

namespace YoutubeOrMp3
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Custom controller factory kullanımı
            ControllerBuilder.Current.SetControllerFactory(new CustomControllerFactory());
        }
    }

    public class CustomControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;

            if (controllerType == typeof(HomeController))
            {
                var fileRepository = new FileRepository();
                var youtubeManager = new YoutubeManager(fileRepository);
                return new HomeController(youtubeManager);
            }

            return (IController)Activator.CreateInstance(controllerType);
        }
    }
}
