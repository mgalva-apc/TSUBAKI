using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.ViewModel
{
    public class UserModel
    {
        [Key]
        public int UserID {get; set;}
        [Required(ErrorMessage = "*")]
        [Display(Name = "Login Name")]
        public string LoginName {get; set;}
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string PasswordEncryptedText {get; set;}
        [Required(ErrorMessage = "*")]
        [Display(Name = "First Name")]
        public string FirstName {get; set;}
        [Required(ErrorMessage = "*")]
        [Display(Name = "Last Name")]
        public string LastName {get; set;}
        public string Gender {get; set;}
        [Required(ErrorMessage = "*")]
        [Display(Name = "Created By")]
        public int CreatedBy {get; set;}
    }
}