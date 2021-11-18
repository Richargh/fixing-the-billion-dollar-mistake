using Richargh.BillionDollar.Classic.Common.Web;

namespace Richargh.BillionDollar.Classic
{
    public interface IRegisterEmployeeUseCase
    {
        public IResponse RegisterEmployee(Request request);
    }
}