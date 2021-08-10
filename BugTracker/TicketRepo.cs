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
            _conn.Execute("INSERT INTO ticket (SubmittedBy, AssignedTo, Status, Project, Description)" +
                " VALUES (@SubmittedBy, @AssignedTo, @Status, @Project, @Description);",
                 new { SubmittedBy = newTicket.SubmittedBy, AssignedTo = 0, Status = "Open", 
                     Project = newTicket.Project, Description = newTicket.Description});
        }

        public IEnumerable<Ticket> GetAllTickets()
        {
            var users = _conn.Query<Users>("SELECT * From user;");
            var tickets = _conn.Query<Ticket>("Select * From ticket;");
            foreach(Ticket tick in tickets)
            {
                foreach(Users user in users)
                {
                    if (user.UserID == tick.AssignedTo)
                        tick.AssignedToName = $"{user.FirstName} {user.LastName}";
                    if (user.UserID == tick.SubmittedBy)
                        tick.SubmittedByName = $"{user.FirstName} {user.LastName}";
                }              
            }

            return tickets;
        }

        public IEnumerable<string> GetAllVerifiedUsers()
        {
            var verifiedUserList = new List<string>();
            var users = _conn.Query<Users>("SELECT * From user;");
            foreach (Users user in users)
            {
                verifiedUserList.Add($"{user.FirstName} {user.LastName}");
            }
            return verifiedUserList;
        }

        //Need to create a way to find the id based of a first name/last name of a user

        public Ticket GetTicket(int id)
        {
            var ticket = _conn.QuerySingle<Ticket>("SELECT * FROM ticket WHERE TicketID = @id",
                new { id = id });
            var users = _conn.Query<Users>("SELECT * From user;");
            foreach (Users user in users)
            {
                if (user.UserID == ticket.AssignedTo)
                    ticket.AssignedToName = $"{user.FirstName} {user.LastName}";
                if (user.UserID == ticket.SubmittedBy)
                    ticket.SubmittedByName = $"{user.FirstName} {user.LastName}";
            }

            return ticket;
        }

        public void UpdateTicket (Ticket ticket)
        {
            _conn.Execute("UPDATE ticket SET AssignedTo = @assignedTo, Status = @status WHERE TicketID = @id",
                new {assignedTo = ticket.AssignedTo, status = ticket.Status, id = ticket.TicketID });
        }

        public void DeleteTicket(Ticket ticket)
        {
            _conn.Execute("DELETE FROM ticket WHERE TicketID = @id",
                new {id = ticket.TicketID });
        }


     
    }
}
