package de.richargh.billiondollar;

import java.util.Map;
import java.util.Optional;
import java.util.stream.*;

public class Inventory {

    private final Map<ItemId, Item> items;

    public Inventory(Item... items){
        this.items = Stream.of(items).collect(Collectors.toMap(Item::id, item -> item));
    }

    public Optional<Item> findById(ItemId id){
        return Optional.ofNullable(items.get(id));
    }

    public boolean rent(Item item, RenterId renterId){
        Item rentedItem = new Item(item.id(), item.name(), Optional.of(renterId));
        items.put(rentedItem.id(), rentedItem);
        return true;
    }

}
