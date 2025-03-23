package de.richargh.billiondollar.rent.exposed;

import org.jspecify.annotations.Nullable;

public record Item(ItemId id, String name, @Nullable RenterId rentedBy) {

    public boolean isAvailable() {
        return rentedBy != null;
    }
}
