using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.DB
{
    public class Schedule
    {
        [Key]
        public int ScheduleID {get; set;}
        public string LoginName {get; set;}
        public string Month {get; set;}
        public string Day {get; set;}
        public string Year {get; set;}
        public int CreatedBy {get; set;}
        public DateTime CreatedDateTime {get; set;}
        public int ModifiedBy {get; set;}
        public DateTime ModifiedDateTime {get; set;}
    }
}