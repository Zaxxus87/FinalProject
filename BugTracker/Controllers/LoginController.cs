using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class LoginController : Controller
    {

        private readonly IUsersRepo _repo;

        public LoginController(IUsersRepo repo)
        {
            _repo = repo;  
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(Users user)
        {
            var userList = _repo.GetAllUsers();
            
            if (userList.Any(x => x.FirstName == user.FirstName && x.LastName == user.LastName && x.Password == user.Password))
            {
                var actualUser = _repo.GetUserByFirstAndLastName(user.FirstName, user.LastName);
                if (actualUser.Title == "Developer")
                {
                    return RedirectToAction("Index", "Ticket");
                }
                else if (actualUser.Title == "Admin")
                {
                    return RedirectToAction("AdminTicket", "Ticket");
                }
                else
                {
                    return View("LoginSuccess", user);
                }
                
            }
            else
            {
                return View("LoginFailure", user);
            }
        }

        public IActionResult CreateUser()
        {
            return View("CreateUser");
        }
    }
}
