package de.richargh.billiondollar;

import java.util.Optional;

public class Item {

    private final ItemId id;

    private final String name;

    private final Optional<RenterId> rentedBy;

    // Primary Constructor
    public Item(ItemId id, String name, Optional<RenterId> rentedBy) {
        this.id = id;
        this.name = name;
        this.rentedBy = rentedBy;
    }

    public ItemId id() {
        return id;
    }

    public String name() {
        return name;
    }

    public boolean isRented() {
        return !rentedBy.isEmpty();
    }
}
