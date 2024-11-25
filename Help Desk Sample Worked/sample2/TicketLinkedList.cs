using System;
using System.Collections.Generic;
using System.Linq;

namespace HelpDesk
{
    public class TicketLinkedList
    {
        private LinkedList<Ticket> waitingList;
        private List<Ticket> assignedTickets;

        public TicketLinkedList()
        {
            waitingList = new LinkedList<Ticket>();
            assignedTickets = new List<Ticket>();
        }

        public void AddToWaitingList(Ticket ticket)
        {
            waitingList.AddLast(ticket);
        }

        public void AssignAgent(Ticket ticket, string agentName)
        {
            ticket.Agent = agentName;
            ticket.ResolvedDateTime = DateTime.Now;
            waitingList.Remove(ticket);
            assignedTickets.Add(ticket);
        }

        public IEnumerable<Ticket> GetWaitingList()
        {
            return waitingList.OrderBy(ticket => ticket.OpenedDateTime);
        }

        public IEnumerable<Ticket> GetAssignedTicketsSortedByDateTime()
        {
            return assignedTickets.OrderBy(ticket => ticket.OpenedDateTime);
        }
    }
}
