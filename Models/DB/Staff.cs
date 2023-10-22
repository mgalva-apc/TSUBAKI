using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.DB
{
    public class Staff
    {
        [Key]
        public int StaffID {get; set;}
        public int AccountID {get; set;}
        public string AccountUsername {get; set;}
        public string StaffFirstName {get; set;}
        public string StaffLastName {get; set;}
        public string StaffRole {get; set;}
        public string StaffGender {get; set;}
        public string StaffEmail {get; set;}
        public int StaffConNum {get; set;}
        public Date StaffBirthday {get; set;}
        public int CreatedBy {get; set;}
        public DateTime CreatedDateTime {get; set;}
        public int ModifiedBy {get; set;}
        public DateTime ModifiedDateTime {get; set;}
    }
}