using System;
using System.Linq;
using TSUBAKI.Models.DB;
using TSUBAKI.Models.ViewModel;

namespace TSUBAKI.Models.EntityManager
{
    public class UserManager
    {
        public void AddUserAccount(UserModel user)
        {
            using (MyDBContext db = new MyDBContext())
            {
                Users newUser = new Users
                {
                    LoginName = user.LoginName,
                    PasswordEncryptedText = user.PasswordEncryptedText,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    CreatedBy = 1,
                    CreatedDateTime = DateTime.Now,
                    ModifiedBy = 1,
                    ModifiedDateTime = DateTime.Now
                };

                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }
        public List<Users> GetAllUsers()
        {
            List<Users> users = new List<Users>();

            using (MyDBContext db = new MyDBContext())
            {
                return users = db.Users.ToList();
            }   
        }
        public bool IsLoginNameExist(string LoginName)
        {
            using (MyDBContext db = new MyDBContext())
            {
                return db.Users.Where(u => u.LoginName.Equals(LoginName)).Any();
            }
        }
    }
}