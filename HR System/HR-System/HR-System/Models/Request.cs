using HR_System.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Description { get; set; }=string.Empty;

        public Status Status { get; set; }=Status.Pending;

        //[ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; } 
    }
}
