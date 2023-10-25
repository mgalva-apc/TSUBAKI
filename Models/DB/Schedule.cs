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
        public DateTime ScheduleDate {get; set;}
        public string ScheduleTimeslot {get; set;}
        public DateTime ScheduleCreateDate {get; set;}
        public DateTime ScheduleModDate {get; set;}
    }
}