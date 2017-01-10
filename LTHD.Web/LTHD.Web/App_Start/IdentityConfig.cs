using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using LTHD.Web.Infrastructure.Identity;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(LTHD.Web.IdentityConfig))]
namespace LTHD.Web
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app) {
            app.CreatePerOwinContext<StoreIdentityDbContext>(StoreIdentityDbContext.Create);
            app.CreatePerOwinContext<StoreUserManager>(StoreUserManager.Create);
            app.CreatePerOwinContext<StoreRoleManager>(StoreRoleManager.Create);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });

            app.UseOAuthBearerTokens(new OAuthAuthorizationServerOptions
            {
                Provider = new StoreAuthProvider(),
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Authenticate")
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseFacebookAuthentication(
               appId: "1635800973354460",
               appSecret: "de721a934ce10c14b02aaba080c5dd23"
            );
        }
    }
}