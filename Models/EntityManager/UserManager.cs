using System;
using System.Linq;
using System.Globalization;
using TSUBAKI.Models.DB;
using TSUBAKI.Models.ViewModel;

namespace TSUBAKI.Models.EntityManager
{
    public class UserManager
    {
        private (string hashedPassword, string salt) HashPassword(string password)
                {
                    string salt = BCrypt.Net.BCrypt.GenerateSalt();
                    string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);
                    return (hashedPassword, salt);
                }
        
        public void AddUserAccount(UserModel user)
        {
            using (MyDBContext db = new MyDBContext())
            {
                // Hashing password
                (string hashedPassword, string salt) = HashPassword(user.Password);

                Account newAccount = new Account
                {
                    AccountUsername = user.AccountUsername,
                    AccountPassword = hashedPassword,
                    Salt = salt,
                    AccountType = "C",
                    AccountEmail = user.AccountEmail,
                    AccountImage = user.AccountImage,
                    AccountCreateDate = DateTime.Now,
                    AccountModDate = DateTime.Now
                };

                db.Account.Add(newAccount);
                db.SaveChanges();

                int newAccountId = db.Account.First(a => a.AccountUsername == newAccount.AccountUsername).AccountID;

                Client newClient = new Client
                {
                    AccountID = newAccountId,
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

                int roleId = db.Role.First(r => r.RoleName == "Client").RoleID;
 
                UserRole userRole = new UserRole
                {
                    AccountID = newAccountId,
                    LookUpRoleID = roleId,
                    IsActive = true,
                    CreatedBy = newAccountId,
                    CreatedDateTime = DateTime.Now,
                    ModifiedBy = newAccountId,
                    ModifiedDateTime = DateTime.Now,
                };
 
                db.UserRole.Add(userRole);
                db.SaveChanges();
            }
        }

        public bool VerifyPassword(string userName, string currentPassword)
        {
            using (MyDBContext db = new MyDBContext())
            {
                Account user = db.Account.FirstOrDefault(u => u.AccountUsername == userName);
                
                if (user != null)
                {
                    // Retrieve the salt and hashed password from the database
                    string salt = user.Salt;
                    string storedHashedPassword = user.AccountPassword;
                    
                    // Hash the current password with the retrieved salt
                    string hashedPassword = HashPassword(currentPassword, salt);
                    
                    // Compare the newly hashed password with the stored hashed password
                    return hashedPassword == storedHashedPassword;
                }
                
                return false; // User not found
            }
        }
        private string HashPassword(string password, string salt)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
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

        public UsersModel GetSpecificUsers(string UserName)
        {
            UsersModel list = new UsersModel();
 
            using (MyDBContext db = new MyDBContext())
            {
                var users = from a in db.Account
                            join c in db.Client
                                on a.AccountID equals c.AccountID
                            join s in db.Staff
                                on a.AccountID equals s.AccountID
                            join ur in db.UserRole
                                        on a.AccountID equals ur.AccountID
                            join r in db.Role
                                        on ur.LookUpRoleID equals r.RoleID
                            where a.AccountUsername == UserName
                            select new { a, c, s, ur, r};
 
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
                    RoleID = records.ur.LookUpRoleID,
                    RoleName = records.r.RoleName 
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