using Richargh.BillionDollar.Classic.Common.Error;

namespace Richargh.BillionDollar.Classic
{
    public interface IEmailProvider
    {
        /// <exception cref="MyEmailException">When the email cannot be sent.</exception>
        public void SendEmail(EmployeeId employeeId, string subject, string body);


        /// <exception cref="MyEmailException">When the email cannot be sent.</exception>        
        public void SendEmail(EmailAddress emailAddress, string subject, string body);
    }
}