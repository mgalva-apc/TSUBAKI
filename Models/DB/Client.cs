using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.DB
{
    public class Client
    {
        [Key]
        public int ClientID {get; set;}
        public int AccountID {get; set;}
        public string ClientFirstName {get; set;}
        public string ClientLastName {get; set;}
        public string ClientAddress {get; set;}
        public string ClientGender {get; set;}
        public string ClientConNum {get; set;}
        public DateTime ClientBirthday {get; set;}
        public DateTime ClientCreateDate {get; set;}
        public DateTime ClientModDate {get; set;}
    }
}