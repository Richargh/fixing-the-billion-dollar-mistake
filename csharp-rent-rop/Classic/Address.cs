namespace Richargh.BillionDollar.Classic
{
    public record Address(Town Town, Street? Street);

    public record Town(string RawValue);

    public record Street(string RawValue);
}