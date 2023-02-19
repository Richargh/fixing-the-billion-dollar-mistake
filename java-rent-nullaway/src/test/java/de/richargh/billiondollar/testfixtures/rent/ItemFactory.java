package de.richargh.billiondollar.testfixtures.rent;

import de.richargh.billiondollar.rent.exposed.Item;
import de.richargh.billiondollar.rent.exposed.ItemId;
import de.richargh.billiondollar.rent.exposed.RenterId;

import java.util.Optional;

public final class ItemFactory {

    private ItemFactory() {
        // non-instantiatable utility class
    }

    public static Item anAvailableItem() {
        return new Item(new ItemId("1"), "Refactoring 2nd", Optional.empty());
    }

    public static Item anUnavailableItem() {
        return new Item(new ItemId("1"), "Refactoring 2nd", Optional.of(new RenterId("1")));
    }
}
