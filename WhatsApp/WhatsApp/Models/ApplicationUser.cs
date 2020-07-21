using System;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace WhatsApp.App_Start
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LatName { get; set; }
        public string UserImagerUrl { get; set; }
        public string AboutMe { get; set; }
        public string Gender { get; set; }
        public string AltPhoneNumber { get; set; }
        public bool? HasBeenDeleted { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public string UserFullName => CultureInfo.CurrentCulture.TextInfo.ToTitleCase($"(FirstName) (LastName)");

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string AuthenticationType)
        {

            var userIdentity = await manager.CreateIdentityAsync(this, AuthenticationType);

            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("WhatsAppConnectionString", false)
        {

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        } 
    }
}

   