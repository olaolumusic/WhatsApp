using System.Threading;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Facebook;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net.Http;
using ResourceCentre.Providers;
using WhatsApp;
using WhatsApp.App_Start;
using System.Configuration;

[assembly: OwinStartup(typeof(Startup))]
namespace WhatsApp
{
    /// <summary>
    /// Startup Owin Configs
    /// </summary>
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        internal static IDataProtectionProvider DataProtectionProvider { get; private set; }

        public static string PublicClientId { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            var hubConfig = new HubConfiguration
            {
                EnableDetailedErrors = true
            };
            app.MapSignalR(hubConfig);

            DataProtectionProvider = app.GetDataProtectionProvider();

            ConfigureAuth(app);

        }

        /// <summary>
        /// app
        /// </summary>
        /// <param name="app"></param>
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request

            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);
            app.UseOAuthAuthorizationServer(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    OnApplyRedirect = ctx =>
                    {
                        if (!IsApiRequest(ctx.Request))
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }
                    },
                    OnValidateIdentity = SecurityStampValidator.
                    OnValidateIdentity<ApplicationUserManager, ApplicationUser>(TimeSpan.FromMinutes(30),
                    (manager, user) => user.GenerateUserIdentityAsync(manager, DefaultAuthenticationTypes.ExternalCookie))
                }
            });
            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            #region --  Initialize Microsoft Credentials from Config --
            //var microsoftCliendId = SystemSettingService.GetMicrosoftClientId();
            //var microsoftSecret = SystemSettingService.GetMicrosoftSecret();
            //// Microsoft
            //app.UseMicrosoftAccountAuthentication(new MicrosoftAccountAuthenticationOptions()
            //{
            //    ClientId = microsoftCliendId,
            //    ClientSecret = microsoftSecret,
            //    Scope = { "wl.basic", "wl.emails" }
            //});
            #endregion

            #region --  Initialize Twitter Credentials from Config --
            //var twitterCliendId = SystemSettingService.GetTwitterClientId();
            //var twitterSecret = SystemSettingService.GetTwitterSecret();

            //app.UseTwitterAuthentication(new TwitterAuthenticationOptions
            //{
            //    ConsumerKey = twitterCliendId,
            //    ConsumerSecret = twitterSecret,
            //    BackchannelCertificateValidator = new CertificateSubjectKeyIdentifierValidator(new[]
            //              {
            //                "A5EF0B11CEC04103A34A659048B21CE0572D7D47", // VeriSign Class 3 Secure Server CA - G2
            //                "0D445C165344C1827E1D20AB25F40163D8BE79A5", // VeriSign Class 3 Secure Server CA - G3
            //                "7FD365A7C2DDECBBF03009F34339FA02AF333133", // VeriSign Class 3 Public Primary Certification Authority - G5
            //                "39A55D933676616E73A761DFA16A7E59CDE66FAD", // Symantec Class 3 Secure Server CA - G4
            //                "01C3968ACDBD57AE7DFAFF9552311608CF23A9F9", //DigiCert SHA2 High Assurance Server C‎A 
            //                "B13EC36903F8BF4701D498261A0802EF63642BC3" //DigiCert High Assurance EV Root CA
            //            })
            //});

            #endregion

            #region --  Initialize Facebook Credentials from Config --
            var facebookCliendId = "fwefewrewre"; //SystemSettingService.GetFacebookClientId();
            var facebookSecret = "erererer"; //SystemSettingService.GetFacebookSecret();



            app.UseFacebookAuthentication(new FacebookAuthenticationOptions
            {
                AppId = facebookCliendId,
                AppSecret = facebookSecret,
                Scope = { "email", "user_about_me", "user_photos", "user_location" },
                SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie,
                BackchannelHttpHandler = new FacebookBackChannelHandler(),
                UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,name,email,user_about_me,first_name,last_name,user_photos,location"
            });

            #endregion

            #region --  Initialize Google Credentials from Config
            var googleCliendId = ConfigurationManager.AppSettings["GoogleCliendId"]; //SystemSettingService.GetGoogleClientId();
            var googleSecret = ConfigurationManager.AppSettings["GoogleSecret"];//SystemSettingService.GetGoogleSecret();

            var google = new GoogleOAuth2AuthenticationOptions
            {
                ClientId = googleCliendId,
                ClientSecret = googleSecret,
                Provider = new GoogleOAuth2AuthenticationProvider
                {
                    OnAuthenticated = context =>
                    {
                        var pictureUrl = context.User["image"].Value<string>("url");
                        context.Identity.AddClaim(new Claim("urn:google:email", context.Identity.FindFirstValue(ClaimTypes.Email)));
                        //This following line is need to retrieve the profile image
                        context.Identity.AddClaim(new Claim("urn:google:accesstoken", context.AccessToken, ClaimValueTypes.String, "Google"));
                        context.Identity.AddClaim(new Claim("pictureUrl", pictureUrl));
                        return Task.FromResult(0);
                    }
                }
            };
            google.Scope.Add("https://www.googleapis.com/auth/plus.login");
            google.Scope.Add("https://www.googleapis.com/auth/userinfo.email");
            google.Scope.Add("email");
            app.UseGoogleAuthentication(google);

            #endregion
        }
        private static bool IsApiRequest(IOwinRequest request)
        {
            var apiPath = VirtualPathUtility.ToAbsolute("~/api/");
            return request.Uri.LocalPath.StartsWith(apiPath);
        }
        public class FacebookBackChannelHandler : HttpClientHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                // Replace the RequestUri so it's not malformed
                if (!request.RequestUri.AbsolutePath.Contains("/oauth"))
                {
                    request.RequestUri = new Uri(request.RequestUri.AbsoluteUri.Replace("?access_token", "&access_token"));
                }

                return await base.SendAsync(request, cancellationToken);
            }
        }
    }
}
