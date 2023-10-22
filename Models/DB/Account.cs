using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.DB
{
    public class Account
    {
        [Key]
        public int AccountID {get; set;}
        public string AccountUsername {get; set;}
        public string AccountPassword {get; set;}
        public string AccountType {get; set;}
        public string AccountEmail {get; set;}
        public string AccountImage {get; set;}
        public int CreatedBy {get; set;}
        public DateTime CreatedDateTime {get; set;}
        public int ModifiedBy {get; set;}
        public DateTime ModifiedDateTime {get; set;}
    }
}