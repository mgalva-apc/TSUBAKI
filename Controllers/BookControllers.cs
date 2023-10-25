using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using TSUBAKI.Models.EntityManager;
using TSUBAKI.Models.ViewModel;
using TSUBAKI.Security;
using System.Security.Claims;

namespace TSUBAKI.Controllers
{
    public class BookController : Controller
    {
        [AuthorizeRoles("Staff", "Client")]
        public ActionResult Booking()
        {
            return View();
        }

        [AuthorizeRoles("Staff", "Client")]
        public ActionResult ViewAppoint()
        {
            BookManager bm = new BookManager();
            BooksModel schedule = bm.GetAllAppointment();
            return View(schedule);
        }

        [HttpPost]
        public ActionResult Booking(BookModel schedule)
        {
            if(ModelState.IsValid)
            {
                BookManager BM = new BookManager();
                if(!BM.IsScheduleExist(schedule.ScheduleDate, schedule.ScheduleTimeslot))
                {
                    BM.AddSchedule(schedule);
                    return RedirectToAction("", "Home");
                }
                else
                    ModelState.AddModelError("", "Appointment schedule already taken.");
            }
            return View ();
        }           

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] BookModel schedData)
        {
            BookManager bm = new BookManager();
            if (!bm.IsScheduleExist(schedData.ScheduleDate, schedData.ScheduleTimeslot))
            {
                bm.UpdateSchedule(schedData);
                return RedirectToAction("Index"); // Redirect to a relevant action after successful update.
            }
            // Handle the case when the schedule doesn't exist, e.g., return a relevant error view.
            return RedirectToAction("ScheduleNotFound");
        }
    }
}