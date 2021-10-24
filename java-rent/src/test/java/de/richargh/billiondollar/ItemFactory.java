package de.richargh.billiondollar;

import java.lang.StackWalker.Option;
import java.util.Optional;

public final class ItemFactory {
    private ItemFactory(){
        // non-instaniable utility class
    }

    public static Item anAvailableItem(){
        return new Item(new ItemId("1"), "Refactoring 2nd", Optional.empty());
    }

    public static Item anUnavailableItem(){
        return new Item(new ItemId("1"), "Refactoring 2nd", Optional.of(new RenterId("1")));
    }
}
