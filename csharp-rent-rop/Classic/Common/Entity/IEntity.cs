namespace Richargh.BillionDollar.Classic.Common.Entity
{
    public interface IEntity<TId>
    {
        public TId Id { get; }
    }
}