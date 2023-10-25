using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.ViewModel
{
    public class BookModel
    {
        [Key]
        public int ScheduleID {get; set;}
        public int TransactionID {get; set;}
        public int NotificationID {get; set;}
        public int AccountID {get; set;}
        public int StaffID {get; set;}
        public int ClientID {get; set;}

        [Required(ErrorMessage = "*")]
        [Display(Name = "Username")]
        public string AccountUsername {get; set;}
        public DateTime ScheduleDate {get; set;}
        public string ScheduleTimeslot {get; set;}

        [Required(ErrorMessage = "*")]
        [Display(Name = "Transaction Name")]
        public string TransName {get; set;}

        [Required(ErrorMessage = "*")]
        [Display(Name = "Transaction Type")]
        public string TransType {get; set;}

        public DateTime TransStartDate {get; set;}
        public DateTime TransEndDate {get; set;}
    }

    public class BooksModel
    {
        public List<BookModel> Schedules { get; set; }
    }
}