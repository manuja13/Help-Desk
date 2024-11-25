using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Queue<HelpDeskTicket> waitingListQueue = new Queue<HelpDeskTicket>();
        LinkedList<HelpDeskTicket> AssignedList = new LinkedList<HelpDeskTicket>();



        while (true)
        {
            Console.WriteLine("1. Open a new ticket");
            Console.WriteLine("2. Assign tickets to agents");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());



            switch (choice)
            {
                case 1:
                    OpenNewTicket(waitingListQueue);
                    break;
                case 2:
                    AssignTicketsToAgents(waitingListQueue, AssignedList);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }



    static void OpenNewTicket(Queue<HelpDeskTicket> waitingQueue)
    {
        Console.WriteLine("Enter ticket details:");
        HelpDeskTicket ticket = new HelpDeskTicket();



        ticket.SerialNumber = waitingQueue.Count + 1;
        Console.Write("User: ");
        ticket.User = Console.ReadLine();
        Console.Write("Location: ");
        ticket.Location = Console.ReadLine();
        Console.Write("Tele No: ");
        ticket.TeleNo = Console.ReadLine();
        Console.Write("Email Address: ");
        ticket.EmailAddress = Console.ReadLine();
        ticket.OpenedDateTime = DateTime.Now;
        Console.Write("Case Description: ");
        ticket.CaseDescription = Console.ReadLine();



        waitingQueue.Enqueue(ticket);
        Console.WriteLine("Ticket opened successfully! Serial No: " + ticket.SerialNumber);
    }



    static void AssignTicketsToAgents(Queue<HelpDeskTicket> waitingQueue, LinkedList<HelpDeskTicket> assignedList)
    {
        if (waitingQueue.Count == 0)
        {
            Console.WriteLine("No tickets in the waiting list.");
            return;
        }



        Console.WriteLine("Assigning tickets to agents:");



        while (waitingQueue.Count > 0)
        {
            HelpDeskTicket ticket = waitingQueue.Dequeue();
            // Simulate assigning an agent (you can implement your agent assignment logic)
            ticket.Agent = "AgentName";
            ticket.ResolvedDateTime = DateTime.Now;



            assignedList.AddLast(ticket);
            Console.WriteLine($"Ticket #{ticket.SerialNumber} assigned to {ticket.Agent}. Resolved at {ticket.ResolvedDateTime}");
        }
    }
}