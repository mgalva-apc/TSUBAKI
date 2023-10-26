using System;
using System.Linq;
using System.Globalization;
using TSUBAKI.Models.DB;
using TSUBAKI.Models.ViewModel;

namespace TSUBAKI.Models.EntityManager
{
    public class BookManager
    {
        public void AddSchedule(BookModel schedule)
        {
            using (MyDBContext db = new MyDBContext())
            {
                int accountId = db.Account.Where(account => account.AccountUsername == schedule.ClientUsername).Select(account => account.AccountID).FirstOrDefault();
                
                Schedule newSchedule = new Schedule
                {
                    AccountID = accountId,
                    ClientUsername = schedule.ClientUsername,
                    ScheduleDate = schedule.ScheduleDate,
                    ScheduleTimeslot = schedule.ScheduleTimeslot,
                    ScheduleCreateDate = DateTime.Now,
                    ScheduleModDate = DateTime.Now
                };
                db.Schedule.Add(newSchedule);
                db.SaveChanges();
            }
        }

        public void UpdateSchedule(BookModel schedule)
        {
            using (MyDBContext db = new MyDBContext())
            {
                // Check if a schedule with the given month, day and timeslot already exists
                Schedule existingSchedule = db.Schedule.FirstOrDefault(a => a.ScheduleID == schedule.ScheduleID);

                if (existingSchedule != null)
                {
                    // Update the existing schedule
                    existingSchedule.ScheduleModDate = DateTime.Now;

                    // You can also update other properties of the schedule as needed
                    existingSchedule.ScheduleDate = schedule.ScheduleDate;
                    existingSchedule.ScheduleTimeslot = schedule.ScheduleTimeslot;

                    db.SaveChanges();
                }
                else
                {
                    Schedule newSched = new Schedule
                    {
                        ClientUsername = schedule.ClientUsername,
                        ScheduleDate = schedule.ScheduleDate,
                        ScheduleTimeslot = schedule.ScheduleTimeslot,
                        ScheduleCreateDate = DateTime.Now,
                        ScheduleModDate = DateTime.Now
                    };
                    db.Schedule.Add(newSched);
                    db.SaveChanges();
                }
            }
        }
        public BooksModel GetAllAppointment()
        {
            BooksModel list = new BooksModel();
            using (MyDBContext db = new MyDBContext())
            {
                list.Schedules = db.Schedule.Select(records => new BookModel()
                {
                    ScheduleID = records.ScheduleID,
                    ClientUsername = records.ClientUsername,
                    ScheduleDate = records.ScheduleDate,
                    ScheduleTimeslot = records.ScheduleTimeslot,
                }).ToList();
            }
            return list;
        }
        public bool IsScheduleExist(string ScheduleDate, string ScheduleTimeslot)
        {
            using (MyDBContext db = new MyDBContext())
            {
                return db.Schedule.Any(a => a.ScheduleDate.Equals(ScheduleDate) && a.ScheduleTimeslot.Equals(ScheduleTimeslot));
            }
        }
    }
}