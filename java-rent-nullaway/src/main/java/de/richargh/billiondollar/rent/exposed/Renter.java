package de.richargh.billiondollar.rent.exposed;

public class Renter {

    private final RenterId id;

    private final String name;

    public Renter(RenterId id, String name) {
        this.id = id;
        this.name = name;
    }

    public RenterId id() {
        return id;
    }

    public String name() {
        return name;
    }
}
