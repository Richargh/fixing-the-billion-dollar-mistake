package de.richargh.billiondollar.rent.exposed;

import edu.umd.cs.findbugs.annotations.Nullable;

public class Item {

    private final ItemId id;

    private final String name;

    @Nullable
    private final RenterId rentedBy;

    // Primary Constructor
    public Item(ItemId id, String name, @Nullable RenterId rentedBy) {
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
        return rentedBy != null;
    }
}
