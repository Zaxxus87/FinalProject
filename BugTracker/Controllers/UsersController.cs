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
    }
}
