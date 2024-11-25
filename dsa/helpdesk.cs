using System;
using System.Collections.Generic;



class HelpDeskTicket
{
    public int SerialNumber { get; set; }
    public string User { get; set; }
    public string Location { get; set; }
    public string TeleNo { get; set; }
    public string EmailAddress { get; set; }
    public DateTime OpenedDateTime { get; set; }
    public string CaseDescription { get; set; }
    public string Agent { get; set; }
    public DateTime? ResolvedDateTime { get; set; }
}
