using BugTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker
{
    public interface ITicketRepo
    {
        public IEnumerable<Ticket> GetAllTickets();
        public Ticket GetTicket(int id);
        public void AddTicket(Ticket newTicket);
    }
}
