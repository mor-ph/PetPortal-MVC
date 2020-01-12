using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_proj.ViewModels.Home
{
    public class LoginVM // registerVM za registraciqta?
    {
        [DisplayName("Username:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Username { get; set; }
        [DisplayName("Password:")]
        [Required(ErrorMessage = "This field is Required!")]
        public string Password { get; set; }
    }
}