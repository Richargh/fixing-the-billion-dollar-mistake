using System;

namespace Richargh.BillionDollar.Classic
{
    public class LoggingEmailProvider : IEmailProvider
    {
        public void SendEmail(EmployeeId employeeId, string subject, string body)
        {
            Console.WriteLine($"Notifying Employee {employeeId} of {subject}");
        }
        
        public void SendEmail(EmailAddress emailAddress, string subject, string body)
        {
            Console.WriteLine($"Notifying Email address {emailAddress} of {subject}");
        }
    }
}