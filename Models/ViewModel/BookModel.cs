using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TSUBAKI.Models.ViewModel
{
    public class BookModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleID {get; set;}
        public int TransID {get; set;}
        public int NotificationID {get; set;}
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountID {get; set;}
        public int StaffID {get; set;}
        public int ClientID {get; set;}

        [Required(ErrorMessage = "*")]
        [Display(Name = "Username")]
        public string ClientUsername {get; set;}
        [Display(Name = "Schedule Date")]
        public DateTime ScheduleDate {get; set;}
        [Display(Name = "Schedule Timeslot")]
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