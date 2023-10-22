using System.ComponentModel.DataAnnotations;

namespace TSUBAKI.Models.ViewModel
{
    public class BookModel
    {
        [Key]
        public int ScheduleID {get; set;}

        [Required(ErrorMessage = "*")]
        [Display(Name = "Login Name")]
        public string LoginName {get; set;}

        public string Month {get; set;}

        public string Day {get; set;}

        public string TimeSlot {get; set;}

        [Required(ErrorMessage = "*")]
        [Display(Name = "Created By")]
        public int CreatedBy {get; set;}
    }

    public class BooksModel
    {
        public List<BookModel> Appointments { get; set; }
    }
}