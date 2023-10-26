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
            DateTime myDateTime = schedule.ScheduleDate;
            string ScheduleDate = myDateTime.ToString("MM/dd/yyyy");

            ModelState.Remove("StaffID");
            ModelState.Remove("TransName");
            ModelState.Remove("TransType");
            ModelState.Remove("TransEndDate");
            ModelState.Remove("AccountImage");
            ModelState.Remove("StaffID");
            ModelState.Remove("AccountType");
            ModelState.Remove("ClientBirthday");
            ModelState.Remove("RoleName");
            ModelState.Remove("AccountEmail");
            if(ModelState.IsValid)
            {
                BookManager BM = new BookManager();
                if(!BM.IsScheduleExist(ScheduleDate, schedule.ScheduleTimeslot))
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
            DateTime myDateTime = schedData.ScheduleDate; // Correct the variable name to schedData
            string ScheduleDate = myDateTime.ToString("MM/dd/yyyy");

            BookManager bm = new BookManager();
            if (!bm.IsScheduleExist(ScheduleDate, schedData.ScheduleTimeslot))
            {
                bm.UpdateSchedule(schedData);
                return RedirectToAction("Index"); // Redirect to a relevant action after successful update.
            }
            // Handle the case when the schedule doesn't exist, e.g., return a relevant error view.
            return RedirectToAction("ScheduleNotFound");
        }
    }
}