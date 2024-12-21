using System.ComponentModel.DataAnnotations;

namespace MVC_ITI.ViewModel
{
    public class RegisterUserViewModel
    {
        public string UserName { get; set; }=string.Empty;


        [DataType(DataType.Password)]   
        public string Password { get; set; } = string.Empty;



        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;

        public string Address {  get; set; } = string.Empty;

    }
}
