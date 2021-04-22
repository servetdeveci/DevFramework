using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DevFramework.Core.Utilities.Mvc.Infrastructor;
using DevFramework.Northwind.Business.DependencyResolvers.Ninject;
using System.Web.Security;
using DevFramework.Core.CrossCuttingConcerns.Security.Web;
using System.Security.Principal;
using System.Threading;

namespace DevFramework.Northwind.MvcWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // İlk controller factory. Burada veri direkt businnes module uzerinden productmanager aracılığı ile aktarılıyor
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new BusinessModule(), new AutoMapperModule()));

            // yukarıdaki örnekte bir serviceContract olmadığı için yeni bir serviceModule oluşturup productManager a onun uzerinden gidioruz. Boylelikle arada proxy de kurulmuş oluyor
            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(new ServiceModule(), new AutoMapperModule()));

        }

        public override void Init()
        {
            PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            base.Init();
        }

        private void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null)
                {
                    return;
                }
                var encTicket = authCookie.Value;
                if (String.IsNullOrEmpty(encTicket))
                {
                    return;
                }
                var ticket = FormsAuthentication.Decrypt(encTicket);
                var securityUtilies = new SecurityUtilities();
                var identity = securityUtilies.FormsAuthTicketToIdentity(ticket);
                var principal = new GenericPrincipal(identity, identity.Roles);

                HttpContext.Current.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch
            {
            }
        }
    }
}
