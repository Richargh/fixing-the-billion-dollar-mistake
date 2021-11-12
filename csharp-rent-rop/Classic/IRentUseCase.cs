using Richargh.BillionDollar.Classic.Common.Web;

namespace Richargh.BillionDollar.Classic
{
    public interface IRentUseCase
    {
        public IResponse Rent(NotebookType type, EmployeeId eId);
    }
}