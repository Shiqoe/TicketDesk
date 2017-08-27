// TicketDesk - Attribution notice
// Contributor(s):
//
//      Stephen Redd (https://github.com/stephenredd)
//
// This file is distributed under the terms of the Microsoft Public 
// License (Ms-PL). See http://opensource.org/licenses/MS-PL
// for the complete terms of use. 
//
// For any distribution that contains code from this file, this notice of 
// attribution must remain intact, and a copy of the license must be 
// provided to the recipient.

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using TicketDesk.Localization.Identity;
using TicketDesk.Localization;

namespace TicketDesk.Web.Identity.Model
{
    public class TicketDeskUser:IdentityUser
    {
        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Validation))]
        [StringLength(100, ErrorMessageResourceName = "FieldMaximumLength", ErrorMessageResourceType = typeof(Validation))]
        [Display(Name = "DisplayName", ResourceType = typeof(Strings))]
        public string DisplayName { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Validation))]
        [StringLength(100, ErrorMessageResourceName = "FieldMaximumLength", ErrorMessageResourceType = typeof(Validation))]
        [Display(Name = "Department", ResourceType = typeof(Strings))]
        public string Department { get; set; }

        [Required(ErrorMessageResourceName = "FieldRequired", ErrorMessageResourceType = typeof(Validation))]
        [StringLength(100, ErrorMessageResourceName = "FieldMinimumLength", ErrorMessageResourceType = typeof(Validation), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Strings))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Strings))]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessageResourceName = "ConfirmationDoNotMatch", ErrorMessageResourceType = typeof(Strings))]
        public string ConfirmPassword { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<TicketDeskUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim(ClaimTypes.GivenName, DisplayName));
            return userIdentity;
        }
    
    }
}
