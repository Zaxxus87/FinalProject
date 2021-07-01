using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Ticket
    {
        public Ticket()
        {

        }
        public int TicketID { get; set; }
        public string SubmittedBy { get; set; }
        public string AssignedTo { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string Project { get; set; }
        public string Description { get; set; }
    }
}
