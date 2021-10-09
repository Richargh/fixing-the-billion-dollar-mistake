package de.richargh.billiondollar;

public final class RenterFactory {
    private RenterFactory(){
        // non-instaniable utility class
    }

    public static Renter aRenter(){
        return new Renter(new RenterId("1"), "Lisa");
    }
}
