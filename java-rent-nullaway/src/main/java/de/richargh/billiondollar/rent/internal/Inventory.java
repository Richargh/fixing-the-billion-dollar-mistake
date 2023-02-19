package de.richargh.billiondollar.rent.internal;

import de.richargh.billiondollar.rent.exposed.Item;
import de.richargh.billiondollar.rent.exposed.ItemId;
import de.richargh.billiondollar.rent.exposed.RenterId;

import java.util.Map;
import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class Inventory {

    private final Map<ItemId, Item> items;

    public Inventory(Item... items) {
        this.items = Stream.of(items)
                .collect(Collectors.toMap(Item::id, item -> item));
    }

    public Optional<Item> findById(ItemId id) {
        return Optional.ofNullable(items.get(id));
    }

    public boolean rent(Item item, RenterId renterId) {
        Item rentedItem = new Item(item.id(), item.name(), renterId);
        items.put(rentedItem.id(), rentedItem);
        return true;
    }
}
