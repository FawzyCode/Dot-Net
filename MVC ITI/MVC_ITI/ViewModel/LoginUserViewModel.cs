using System.ComponentModel.DataAnnotations;

namespace MVC_ITI.ViewModel
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage ="*")]
        public string UserName { get; set; }=string.Empty;

        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;


        [Display(Name ="Remember Me!!")]
        public bool RememberMe {  get; set; }
    }
}
