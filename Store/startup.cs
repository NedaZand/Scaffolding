using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Store.Data;
using Store.Service.User;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(Store.startup))]

namespace Store
{
    public class startup
    {
        public void Configuration(IAppBuilder app)
        {
         
            app.CreatePerOwinContext<StoreContext>(StoreContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}
