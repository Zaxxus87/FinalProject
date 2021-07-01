using BugTracker.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker
{
    public class TicketRepo : ITicketRepo
    { 
        private readonly IDbConnection _conn;

        public TicketRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _conn.Query<Ticket>("Select * From Ticket;");
        }
    }
}
