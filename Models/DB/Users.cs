using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.DB
{
    public class Users
    {
        [Key]
        public int UserID {get; set;}
        public string LoginName {get; set;}
        public string PasswordEncryptedText {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Gender {get; set;}
        public int CreatedBy {get; set;}
        public DateTime CreatedDateTime {get; set;}
        public int ModifiedBy {get; set;}
        public DateTime ModifiedDateTime {get; set;}
    }
}