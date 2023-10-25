using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TSUBAKI.Models.EntityManager;
using TSUBAKI.Models.ViewModel;
using TSUBAKI.Security;
using System.Security.Claims;

namespace TSUBAKI.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        [AuthorizeRoles("Client")]
        public ActionResult AccountSettings()
        {

            UserManager um = new UserManager();
            UsersModel user = um.GetAllUsers();
            return View(user);
        }

        [AuthorizeRoles("Client")]
        public ActionResult Dashboard()
        {
            BookManager bm = new BookManager();
            BooksModel sched = bm.GetAllAppointment();
            return View(sched);
        }

        [HttpPost]
        public ActionResult SignUp(UserModel user)
        {
            ModelState.Remove("AccountImage");
            ModelState.Remove("RoleName");

            if (ModelState.IsValid)
            {
                UserManager um = new UserManager();
                if (!um.IsLoginNameExist(user.AccountUsername))
                {
                    um.AddUserAccount(user);
                    // FormsAuthentication.SetAuthCookie(user.FirstName, false);
                    return RedirectToAction("", "Home");
                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginModel ulm)
        {
            if (ModelState.IsValid)
            {
                UserManager um = new UserManager();
                string storedHashedPassword = um.GetUserPassword(ulm.AccountUsername);

                if (string.IsNullOrEmpty(storedHashedPassword) || string.IsNullOrEmpty(ulm.Password))
                {
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                }
                else if (BCrypt.Net.BCrypt.Verify(ulm.Password, storedHashedPassword))
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, ulm.AccountUsername)
                    };

                    var userIdentity = new ClaimsIdentity(claims, "login");

                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    // Sign in the user using Cookie Authentication
                    HttpContext.SignInAsync(principal);

                    // Redirect to the desired action (e.g., "Users")
                    return RedirectToAction("Dashboard");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                }
                // If authentication fails or ModelState is invalid, redisplay the login form
                return View();
        }
            
        [HttpPost]
        public ActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}