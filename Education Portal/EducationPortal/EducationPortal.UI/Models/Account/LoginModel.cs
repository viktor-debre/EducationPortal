using System.ComponentModel.DataAnnotations;

namespace EducationPortal.UI.Models.Account
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Not specified name")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Not specified password")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Password must be more than 4 characters")]
        public string Password { get; set; }
    }
}
