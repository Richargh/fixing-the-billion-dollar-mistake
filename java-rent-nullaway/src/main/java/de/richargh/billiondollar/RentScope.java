package de.richargh.billiondollar;

public class RentScope {

    private final Item item;

    private final Renter renter;

    public RentScope(Item item, Renter renter) {
        this.item = item;
        this.renter = renter;
    }

    public Item item() {
        return item;
    }

    public Renter renter() {
        return renter;
    }
}
