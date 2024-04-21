using System.ComponentModel.DataAnnotations;

namespace NZZwalks.Models.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Roles {  get; set; }
    }
}
