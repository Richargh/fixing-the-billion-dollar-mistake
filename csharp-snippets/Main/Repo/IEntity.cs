namespace Richargh.BillionDollar.Repo
{
    public interface IEntity<TId>
    {
        public TId Id { get; }
    }
}