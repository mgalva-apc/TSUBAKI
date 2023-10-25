using System;
using System.Linq;
using System.Globalization;
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
                Account newAccount = new Account
                {
                    AccountUsername = user.AccountUsername,
                    AccountPassword = user.AccountPassword,
                    AccountType = user.AccountType,
                    AccountEmail = user.AccountEmail,
                    AccountImage = user.AccountImage,
                    AccountCreateDate = DateTime.Now,
                    AccountModDate = DateTime.Now
                };

                db.Account.Add(newAccount);
                db.SaveChanges();

                int newAccountId = db.Client.First(c => c.AccountUsername == newAccount.AccountUsername).ClientID;

                Client newClient = new Client
                {
                    ClientID = newAccountId,
                    ClientFirstName = user.ClientFirstName,
                    ClientLastName = user.ClientLastName,
                    ClientAddress = user.ClientAddress,
                    ClientGender = user.ClientGender,
                    ClientConNum = user.ClientConNum,
                    ClientCreateDate = DateTime.Now,
                    ClientModDate = DateTime.Now
                };

                db.Client.Add(newClient);
                db.SaveChanges();
            }
        }
        public UsersModel GetAllUsers()
        {
            UsersModel list = new UsersModel();
 
            using (MyDBContext db = new MyDBContext())
            {
                var users = from a in db.Account
                            join c in db.Client
                                on a.AccountID equals c.AccountID
                            join s in db.Staff
                                on a.AccountID equals s.AccountID
                            select new { a, c, s};
 
                list.Users = users.Select(records => new UserModel()
                {
                    AccountImage = records.a.AccountImage ?? string.Empty,
                    AccountID = records.a.AccountID,
                    ClientID = records.c.ClientID,
                    StaffID = records.s.StaffID,
                    AccountUsername = records.a.AccountUsername,
                    ClientFirstName = records.c.ClientFirstName,
                    ClientLastName = records.c.ClientLastName,
                    AccountEmail = records.a.AccountEmail,
                    ClientAddress = records.c.ClientAddress,
                    ClientConNum = records.c.ClientConNum,
                    ClientGender = records.c.ClientGender,
                    
                }).ToList();
            }
            return list;
        }
        public bool IsLoginNameExist(string userName)
        {
            using (MyDBContext db = new MyDBContext())
            {
                return db.Account.Where(u => u.AccountUsername.Equals(userName)).Any();
            }
        }
 
        public string GetUserPassword(string userName)
        {
            using (MyDBContext db = new MyDBContext())
            {
                var user = db.Account.FirstOrDefault(o => o.AccountUsername.ToLower().Equals(userName)); // Get the first matching user

                if (user != null && user.AccountPassword != null)
                {
                    return user.AccountPassword;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public bool IsUserInRole(string userName, string roleName)
        {
            using (MyDBContext db = new MyDBContext())
            {
                Account su = db.Account.Where(o => o.AccountUsername.ToLower().Equals(userName))?.FirstOrDefault();
 
                if (su != null)
                {
                    var roles = from ur in db.UserRole
                                join r in db.Role on ur.LookUpRoleID equals
                                r.RoleID
                                where r.RoleName.Equals(roleName) &&
                                ur.AccountID.Equals(su.AccountID)
                                select r.RoleName;
                    if (roles != null)
                    {
                        return roles.Any();
                    }
                }
                return false;
            }
        }
    }
}