using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.DB
{
    public class Document
    {
        [Key]
        public int DocuID {get; set;}
        public string DocuName {get; set;}
        public string DocuType {get; set;}
        public string DocuContent {get; set;}
        public DateTime DocuCreateDate {get; set;}
        public DateTime DocuModDate {get; set;}
        public int StaffID {get; set;}
        public int ClientID {get; set;}
        public int TransID {get; set;}
    }
}