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

        [Required(ErrorMessage = "*")]
        [Display(Name = "Month")]
        public string Month {get; set;}

        [Required(ErrorMessage = "*")]
        [Display(Name = "Day")]
        public string Day {get; set;}

        [Required(ErrorMessage = "*")]
        [Display(Name = "Created By")]
        public int CreatedBy {get; set;}
    }
}