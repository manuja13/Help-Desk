using System;

namespace HelpDesk
{
    public class Ticket
    {
        public int SerialNumber { get; set; }
        public string User { get; set; }
        public string Location { get; set; }
        public string TelNumber { get; set; }
        public string EmailId { get; set; }
        public DateTime OpenedDateTime { get; set; }
        public string CaseDescription { get; set; }
        public string Agent { get; set; }
        public DateTime? ResolvedDateTime { get; set; }

        public Ticket(int serialNumber, string user, string location, string telNumber, string emailId,
            DateTime openedDateTime, string caseDescription)
        {
            SerialNumber = serialNumber;
            User = user;
            Location = location;
            TelNumber = telNumber;
            EmailId = emailId;
            OpenedDateTime = openedDateTime;
            CaseDescription = caseDescription;
        }
    }
}
