namespace Richargh.BillionDollar.Classic
{
    public interface IEmailProvider
    {
        public void SendEmail(EmployeeId employeeId, string subject, string body);
    }
}