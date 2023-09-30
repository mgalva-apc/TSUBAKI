using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using TSUBAKI.Models.EntityManager;
using TSUBAKI.Models.ViewModel;

namespace TSUBAKI.Controllers
{
    public class BookController : Controller
    {
        public ActionResult Booking()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Schedule(BookModel appointment)
        {
            if(ModelState.IsValid)
            {
                BookManager BM = new BookManager();
                if(!BM.IsScheduleExist(appointment.Month, appointment.Day, appointment.TimeSlot))
                {
                    BM.AddSchedule(appointment);
                    //FormsAuthentication.SetAuthCookie(user.FirstName, false);
                    return RedirectToAction("", "Home");
                }
                else
                    ModelState.AddModelError("", "Appointment schedule already taken.");
            }
            return View();
        }
            
        [HttpGet]
        public ActionResult GetAllAppointments()
        {
            var appointment = new BookManager().GetAllAppointments();
            return View();
        }
    }
}