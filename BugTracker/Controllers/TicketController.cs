using BugTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketRepo _repo;

        public TicketController(ITicketRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var tickets = _repo.GetAllTickets();
            return View(tickets);
        }

        public IActionResult InsertTicket()
        {
            return View(new Ticket());
        }

        public IActionResult InsertTicketToDataBase(Ticket ticketToInsert)
        {
            _repo.AddTicket(ticketToInsert);

            return RedirectToAction("Index");
        }
    }
}
