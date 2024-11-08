using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Login_Register.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "username or email is required.")]
        [MaxLength(16, ErrorMessage = "Max 16 characters allowed.")]
        [DisplayName("username or email")]
        public string usernameOremail { get; set; }

        [Required(ErrorMessage = "password is required.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Max 20 or min 5 characters allowed.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
