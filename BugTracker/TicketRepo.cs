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

        public void AddTicket(Ticket newTicket)
        {
            _conn.Execute("INSERT INTO Ticket (SubmittedBy, AssignedTo, Status, Project, Description)" +
                " VALUES (@SubmittedBy, @AssignedTo, @Status, @Project, @Description);",
                 new { SubmittedBy = newTicket.SubmittedBy, AssignedTo = 0, Status = "Open", 
                     Project = newTicket.Project, Description = newTicket.Description});
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            return _conn.Query<Ticket>("Select * From Ticket;");
        }

        public Ticket GetTicket(int id)
        {
            return _conn.QuerySingle<Ticket>("SELECT * FROM Ticket WHERE TicketID = @id",
                new { id = id });
        }
    }
}
