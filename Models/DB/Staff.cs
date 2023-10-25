using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.DB
{
    public class Staff
    {
        [Key]
        public int StaffID {get; set;}
        public int AccountID {get; set;}
        public string StaffFirstName {get; set;}
        public string StaffLastName {get; set;}
        public string StaffRole {get; set;}
        public string StaffGender {get; set;}
        public int StaffConNum {get; set;}
        public DateTime StaffBirthday {get; set;}
        public DateTime StaffCreateDate {get; set;}
        public DateTime StaffModDate {get; set;}
    }
}