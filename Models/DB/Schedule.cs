using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.DB
{
    public class Schedule
    {
        [Key]
        public int ScheduleID {get; set;}
        public int TransactionID {get; set;}
        public int NotificationID {get; set;}
        public int AccountID {get; set;}
        public string AccountUsername {get; set;}
        public Date ScheduleDate {get; set;}
        public string ScheduleTime {get; set;}
        public DateTime ScheduleCreateDate {get; set;}
        public DateTime ScehduleModDate {get; set;}
    }
}