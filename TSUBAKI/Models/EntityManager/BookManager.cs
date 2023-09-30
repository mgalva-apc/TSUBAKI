using System;
using System.Linq;
using TSUBAKI.Models.DB;
using TSUBAKI.Models.ViewModel;

namespace TSUBAKI.Models.EntityManager
{
    public class BookManager
    {
        public void AddUserAccount(UserModel user)
        {
            using (MyDBContext db = new MyDBContext())
            {
                Schedule newSchedule = new Schedule
                {
                    LoginName = user.LoginName,
                    Month = user.Month,
                    Day = user.Day,
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
        public bool IsScheduleExist(string Month, string Day)
        {
            using (MyDBContext db = new MyDBContext())
            {
                return db.Schedule.Where(u => u.Month.Equals(Month) && u.Day.Equals(Day)).Any();
            }
        }
    }
}