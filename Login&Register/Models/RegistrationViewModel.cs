using System.ComponentModel.DataAnnotations;

namespace Login_Register.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "username is required.")]
        [MaxLength(16, ErrorMessage = "Max 16 characters allowed.")]
        public string username { get; set; }

        [Required(ErrorMessage = "password is required.")]
        [StringLength(20, MinimumLength =5 ,ErrorMessage = "Max 20 or min 5 characters allowed.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Compare("password", ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword {  get; set; }

        [Required(ErrorMessage = "realname is required.")]
        public string realname { get; set; }

        [Required(ErrorMessage = "email is required.")]
        [MaxLength(36, ErrorMessage = "Max 36 characters allowed.")]
        //[EmailAddress(ErrorMessage = "Please Enter Valid Email.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Max 36 characters allowed.")]
        public string email { get; set; }

        [Required(ErrorMessage = "phone is required.")]
        public string phone { get; set; }
    }
}
