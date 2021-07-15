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
        public int SubmittedBy { get; set; }
        public int AssignedTo { get; set; }
        public string Status { get; set; }
        public string Project { get; set; }
        public string Description { get; set; }
        public string AssignedToName { get; set; }
        public string SubmittedByName { get; set; }
    }
}
