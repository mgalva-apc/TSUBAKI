using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.DB
{
    public class Transaction
    {
        [Key]
        public int TransID {get; set;}
        public string TransName {get; set;}
        public string TransStatus {get; set;}
        public string TransType {get; set;}
        public DateTime TransStartDate {get; set;}
        public DateTime TransEndDate {get; set;}
        public int StaffID {get; set;}
        public int ClientID {get; set;}
    }
}