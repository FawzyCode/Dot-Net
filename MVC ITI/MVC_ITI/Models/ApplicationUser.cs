using Microsoft.AspNetCore.Identity;

namespace MVC_ITI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address {  get; set; }
    }
}
