using System.ComponentModel.DataAnnotations;

namespace MVC_ITI.ViewModel
{
    public class RoleViewModel
    {
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }=string.Empty;
    }
}
