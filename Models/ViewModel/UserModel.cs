using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSUBAKI.Models.ViewModel
{
    public class UserModel
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID {get; set;}
        public int ClientID {get; set;}
        public int StaffID {get; set;}

        [Required(ErrorMessage = "* This field is required")]
        [StringLength(20, ErrorMessage = "Maximum length is 20 characters.")]
        [Display(Name = "Username")]
        public string AccountUsername {get; set;}

        [Required(ErrorMessage = "* This field is required")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one letter, one digit, and one special character.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Account Type")]
        public string AccountType {get; set;}

        [Required(ErrorMessage = "* This field is required")]
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w+$", ErrorMessage = "Needs to be a valid email address.")]
        [StringLength(150, ErrorMessage = "Maximum length is 150 characters.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Account Email")]
        public string AccountEmail {get; set;}

        [Required(AllowEmptyStrings = true)]
        public string AccountImage { get; set; }

        [Required(ErrorMessage = "* This field is required")]
        [StringLength(50, ErrorMessage = "Maximum length is 50 characters.")]
        [Display(Name = "Client First Name")]
        public string ClientFirstName {get; set;}

        [Required(ErrorMessage = "* This field is required")]
        [StringLength(50, ErrorMessage = "Maximum length is 50 characters.")]
        [Display(Name = "Client Last Name")]
        public string ClientLastName {get; set;}

        [Required(ErrorMessage = "* This field is required")]
        [StringLength(75, ErrorMessage = "Maximum length is 75 characters.")]
        [Display(Name = "Client Address")]
        public string ClientAddress {get; set;}

        [Display(Name = "Client Gender")]
        public string ClientGender {get; set;}

        [Required(ErrorMessage = "* This field is required")]
        [RegularExpression(@"^[0-9]{8,}$", ErrorMessage = "Numbers Only")]
        [StringLength(12, ErrorMessage = "Maximum length is 12 characters.")]
        [Display(Name = "Client Contact Number")]
        public string ClientConNum {get; set;}

        public DateTime ClientBirthday {get; set;}

        public int RoleID { get; set; }
        public string RoleName { get; set; }
        
        [Required(ErrorMessage = "* This field is required")]
        [Display(Name = "Created By")]
        public int CreatedBy {get; set;}
    }

    public class UsersModel
    {
        public List<UserModel> Users { get; set; }
    }

    public class UserLoginModel
    {
        [Key]
        public int AccountID { get; set; }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Username")]
        public string AccountUsername { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}