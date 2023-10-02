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

        public ActionResult ViewAppoint()
        {
            BookManager bm = new BookManager();
            BooksModel appointment = bm.GetAllAppointment();

            return View(appointment);
        }

        [HttpPost]
        public ActionResult Booking(BookModel appointment)
        {
            if(ModelState.IsValid)
            {
                BookManager BM = new BookManager();
                if(!BM.IsScheduleExist(appointment.Month, appointment.Day, appointment.TimeSlot))
                {
                    BM.AddSchedule(appointment);
                    return RedirectToAction("", "Home");
                }
                else
                    ModelState.AddModelError("", "Appointment schedule already taken.");
            }
            return View ();
        }
            
        [HttpGet]
        public ActionResult GetAppointments()
        {
            var appointment = new BookManager().GetAllAppointment();
            return View();
        }
    }
}