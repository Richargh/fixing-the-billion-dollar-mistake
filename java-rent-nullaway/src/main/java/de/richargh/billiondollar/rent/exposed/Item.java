package de.richargh.billiondollar.rent.exposed;

import de.richargh.billiondollar.commons.annotations.Nullable;

public record Item(ItemId id, String name, @Nullable RenterId rentedBy) {

    public boolean isRented() {
        return rentedBy != null;
    }
}
