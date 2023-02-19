package de.richargh.billiondollar.testfixtures.rent;

import de.richargh.billiondollar.rent.exposed.Renter;
import de.richargh.billiondollar.rent.exposed.RenterId;

public final class RenterFactory {

    private RenterFactory() {
        // non-instantiatable utility class
    }

    public static Renter aRenter() {
        return new Renter(new RenterId("1"), "Lisa");
    }
}
