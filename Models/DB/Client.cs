using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.DB
{
    public class Client
    {
        [Key]
        public int ClientID {get; set;}
        public int AccountID {get; set;}
        public string AccountUsername {get; set;}
        public string ClientFirstName {get; set;}
        public string ClientLastName {get; set;}
        public string ClientAddress {get; set;}
        public string ClientGender {get; set;}
        public string ClientEmail {get; set;}
        public int ClientConNum {get; set;}
        public Date ClientBirthday {get; set;}
        public int CreatedBy {get; set;}
        public DateTime CreatedDateTime {get; set;}
        public int ModifiedBy {get; set;}
        public DateTime ModifiedDateTime {get; set;}
    }
}