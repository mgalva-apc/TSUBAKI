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

        [Required(ErrorMessage = "*")]
        [Display(Name = "Username")]
        public string AccountUsername {get; set;}

        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string Password { get; set; }
        /*
        [Required(ErrorMessage = "*")]
        [Display(Name = "Password")]
        public string AccountPassword {get; set;}
        */
        [Display(Name = "Account Type")]
        public string AccountType {get; set;}

        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Account Email")]
        public string AccountEmail {get; set;}

        [Required(AllowEmptyStrings = true)]
        public string AccountImage { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "Maximum length is 50 characters.")]
        [Display(Name = "Client First Name")]
        public string ClientFirstName {get; set;}

        [Required(ErrorMessage = "*")]
        [StringLength(50, ErrorMessage = "Maximum length is 50 characters.")]
        [Display(Name = "Client Last Name")]
        public string ClientLastName {get; set;}

        [Required(ErrorMessage = "*")]
        [Display(Name = "Client Address")]
        public string ClientAddress {get; set;}

        [Display(Name = "Client Gender")]
        public string ClientGender {get; set;}

        [Required(ErrorMessage = "*")]
        [Display(Name = "Client Contact Number")]
        public string ClientConNum {get; set;}

        public DateTime ClientBirthday {get; set;}
/*
        
        [Required(ErrorMessage = "*")]
        [Display(Name = "Staff First Name")]
        public string StaffFirstName {get; set;}

        [Required(ErrorMessage = "*")]
        [Display(Name = "Staff Last Name")]
        public string StaffLastName {get; set;}

        public string StaffRole {get; set;}

        public string StaffGender {get; set;}

        [Required(ErrorMessage = "*")]
        [Display(Name = "Staff Contact Number")]
        public int StaffConNum {get; set;}

        public DateTime StaffBirthday {get; set;}
*/
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        
        [Required(ErrorMessage = "*")]
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