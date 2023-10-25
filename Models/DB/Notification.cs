using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.DB
{
    public class Notification
    {
        [Key]
        public int NotifID {get; set;}
        public string NotifContent {get; set;}
        public DateTime NotifSendDate {get; set;}
        public int StaffID {get; set;}
        public int ClientID {get; set;}
        public int DocuID {get; set;}
        public int TransID {get; set;}
    }
}