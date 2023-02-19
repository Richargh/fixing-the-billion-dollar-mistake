package de.richargh.billiondollar.testfixtures.rent;

import de.richargh.billiondollar.rent.exposed.Item;
import de.richargh.billiondollar.rent.exposed.ItemId;
import de.richargh.billiondollar.rent.exposed.RenterId;

public final class ItemFactory {

    private ItemFactory() {
        // non-instantiatable utility class
    }

    public static Item anAvailableItem() {
        return new Item(new ItemId("1"), "Refactoring 2nd", null);
    }

    public static Item anUnavailableItem() {
        return new Item(new ItemId("1"), "Refactoring 2nd", new RenterId("1"));
    }
}
