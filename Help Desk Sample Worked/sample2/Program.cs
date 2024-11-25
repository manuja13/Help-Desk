using System;
using System.Linq;

namespace HelpDesk
{
    class Program
    {
        static void Main(string[] args)
        {
            TicketLinkedList ticketManager = new TicketLinkedList();

            int serialNumber = 1;

            while (true)
            {
                Console.WriteLine("Enter ticket:");

                Console.Write("User: ");
                string user = Console.ReadLine();

                Console.Write("Location: ");
                string location = Console.ReadLine();

                Console.Write("Tel Number: ");
                string telNumber = Console.ReadLine();

                Console.Write("Email Id: ");
                string emailId = Console.ReadLine();

                DateTime openedDateTime = DateTime.Now;

                Console.Write("Case Description: ");
                string caseDescription = Console.ReadLine();

                Ticket ticket = new Ticket(serialNumber, user, location, telNumber, emailId, openedDateTime, caseDescription);
                ticketManager.AddToWaitingList(ticket);

                Console.WriteLine("Ticket opened!");

                Console.Write("Do you want to open another ticket or modify an existing one? (open/modify/finish): ");
                string response = Console.ReadLine().ToLower();

                if (response == "finish")
                {
                    // Agent assignment logic can be added here when an agent is assigned.
                    AssignAgents(ticketManager);

                    Console.WriteLine("\nList of assigned tickets sorted by Opened Date and Time:");
                    var assignedTickets = ticketManager.GetAssignedTicketsSortedByDateTime();
                    foreach (var assignedTicket in assignedTickets)
                    {
                        Console.WriteLine($"Serial Number: {assignedTicket.SerialNumber}");
                        Console.WriteLine($"User: {assignedTicket.User}");
                        Console.WriteLine($"Location: {assignedTicket.Location}");
                        Console.WriteLine($"Tel Number: {assignedTicket.TelNumber}");
                        Console.WriteLine($"Email Id: {assignedTicket.EmailId}");
                        Console.WriteLine($"Opened Date: {assignedTicket.OpenedDateTime.ToShortDateString()}");
                        Console.WriteLine($"Opened Time: {assignedTicket.OpenedDateTime.ToLongTimeString()}");
                        Console.WriteLine($"Case Description: {assignedTicket.CaseDescription}");
                        Console.WriteLine($"Assigned Agent: {assignedTicket.Agent}");
                        Console.WriteLine($"Resolved Date: {assignedTicket.ResolvedDateTime?.ToShortDateString()}");
                        Console.WriteLine($"Resolved Time: {assignedTicket.ResolvedDateTime?.ToLongTimeString()}");
                        Console.WriteLine("--------------------------------------------------------");
                    }

                    break; // Exit the loop when finished.
                }
                else if (response == "modify")
                {
                    Console.WriteLine("Enter the details of the ticket you want to modify:");

                    Console.Write("User: ");
                    string modifyUser = Console.ReadLine();

                    Console.Write("Email Id: ");
                    string modifyEmailId = Console.ReadLine();

                    Console.Write("Case Description: ");
                    string modifyCaseDescription = Console.ReadLine();

                    Ticket ticketToModify = ticketManager.GetWaitingList().FirstOrDefault(t =>
                        t.User == modifyUser && t.EmailId == modifyEmailId && t.CaseDescription == modifyCaseDescription);

                    if (ticketToModify != null)
                    {
                        // Update the case description of the ticket.
                        Console.Write("Updated Case Description: ");
                        ticketToModify.CaseDescription = Console.ReadLine();

                        // Update the opened date and time to the current date and time.
                        ticketToModify.OpenedDateTime = DateTime.Now;

                        Console.WriteLine($"Ticket {ticketToModify.SerialNumber} modified successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Ticket not found. Please check your input.");
                    }
                }

                serialNumber++;
            }
        }

        static void AssignAgents(TicketLinkedList ticketManager)
        {
            Console.WriteLine("\nAssigning Agents to Tickets...");
            var waitingList = ticketManager.GetWaitingList().ToList();

            foreach (var ticket in waitingList)
            {
                Console.WriteLine($"Assign an agent to Ticket {ticket.SerialNumber}:");
                Console.Write("Agent Name: ");
                string agentName = Console.ReadLine();

                ticketManager.AssignAgent(ticket, agentName);
                Console.WriteLine($"Ticket {ticket.SerialNumber} assigned to Agent {agentName}");
            }
        }
    }
}
