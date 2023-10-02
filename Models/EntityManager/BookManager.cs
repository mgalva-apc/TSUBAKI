using System;
using System.Linq;
using TSUBAKI.Models.DB;
using TSUBAKI.Models.ViewModel;

namespace TSUBAKI.Models.EntityManager
{
    public class BookManager
    {
        public void AddSchedule(BookModel appointment)
        {
            using (MyDBContext db = new MyDBContext())
            {
                Schedule newSchedule = new Schedule
                {
                    LoginName = appointment.LoginName,
                    Month = appointment.Month,
                    Day = appointment.Day,
                    TimeSlot = appointment.TimeSlot,
                    CreatedBy = 1,
                    CreatedDateTime = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDateTime = DateTime.Now
                };
                db.Schedule.Add(newSchedule);
                db.SaveChanges();
            }
        }
        public List<Schedule> GetAllAppointments()
        {
            List<Schedule> appointment = new List<Schedule>();

            using (MyDBContext db = new MyDBContext())
            {
                return appointment = db.Schedule.ToList();
            }   
        }
        public BooksModel GetAllAppointment()
        {
            BooksModel list = new BooksModel();

            using (MyDBContext db = new MyDBContext())
            {

                list.Appointments = db.Schedule.Select(records => new BookModel()
                {
                    LoginName = records.LoginName,
                    Month = records.Month,
                    Day = records.Day,
                    TimeSlot = records.TimeSlot,  
                    CreatedBy = records.CreatedBy
                }).ToList();
            }

            return list;
        }
        public bool IsScheduleExist(string Month, string Day, string TimeSlot)
        {
            using (MyDBContext db = new MyDBContext())
            {
                return db.Schedule.Where(a => a.Month.Equals(Month) && a.Day.Equals(Day) && a.TimeSlot.Equals(TimeSlot)).Any();
            }
        }
    }
}