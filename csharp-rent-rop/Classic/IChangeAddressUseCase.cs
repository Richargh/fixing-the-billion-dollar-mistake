using Richargh.BillionDollar.Classic.Common.Web;

namespace Richargh.BillionDollar.Classic
{
    public interface IChangeAddressUseCase
    {
        public IResponse ChangeAddress(Request request);
    }
}