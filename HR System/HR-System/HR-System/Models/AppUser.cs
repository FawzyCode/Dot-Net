using Microsoft.AspNetCore.Identity;

namespace HR_System.Models
{
    public class AppUser :IdentityUser
    {
        public string FirstName {  get; set; }=string.Empty;
        public string LastName { get; set; } = string.Empty;

        public virtual ICollection<Request> Requests { get; set; }

    }
}
