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
            foreach(var item in tickets)
            {
                _repo.GetTicket(item.TicketID);
            }
            return View(tickets);
        }

        public IActionResult AdminTicket()
        {
            var tickets = _repo.GetAllTickets();
            foreach (var item in tickets)
            {
                _repo.GetTicket(item.TicketID);
            }
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

        public IActionResult ViewTicket(int id)
        {
            var tick = _repo.GetTicket(id);
            return View(tick);
        }

        public IActionResult UpdateTicket(int id)
        {
            var tick = _repo.GetTicket(id);
            if (tick == null)
            {
                return View("TicketNotFound");
            }

            return View(tick);
        }

        public IActionResult UpdateTicketToDataBase(Ticket ticket)
        {
            _repo.UpdateTicket(ticket);

            return RedirectToAction("ViewTicket", new { id = ticket.TicketID });
        }

        public IActionResult DeleteTicket(Ticket ticket)
        {
            _repo.DeleteTicket(ticket);

            return RedirectToAction("Index");
        }
    }
}
