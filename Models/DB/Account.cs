using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.DB
{
    public class Account
    {
        [Key]
        public int AccountID {get; set;}
        public string AccountUsername {get; set;}
        public string AccountPassword {get; set;}
        public string Salt {get; set;}
        public string AccountType {get; set;}
        public string AccountEmail {get; set;}
        public string AccountImage {get; set;}
        public DateTime AccountCreateDate {get; set;}
        public DateTime AccountModDate {get; set;}
    }
}