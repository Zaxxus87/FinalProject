using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepo _repo;

        public UsersController(IUsersRepo repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var users = _repo.GetAllUsers();
            return View(users);
        }

        public IActionResult ViewUser(int id)
        {
            var user = _repo.GetUser(id);
            return View(user);
        }

        public IActionResult InsertUserToDataBase(Users userToInsert)
        {
            _repo.InsertUser(userToInsert);

            return RedirectToAction("Index", "Login");
        }

        public IActionResult UpdateUser(int id)
        {
            var user = _repo.GetUser(id);

            if (user == null)
            {
                return View("UserNotFound");
            }

            return View(user);
        }

        public IActionResult UpdateUserToDatabase(Users user)
        {
            _repo.UpdateUser(user);

            return RedirectToAction("ViewUser", new { id = user.UserID });
        }

        public IActionResult DeleteUser(Users user)
        {
            _repo.DeleteUser(user);

            return RedirectToAction("Index");
        }
    }
}
