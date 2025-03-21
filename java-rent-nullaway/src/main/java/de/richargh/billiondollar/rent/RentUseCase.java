package de.richargh.billiondollar.rent;

import de.richargh.billiondollar.rent.exposed.*;
import de.richargh.billiondollar.rent.internal.Inventory;
import de.richargh.billiondollar.rent.internal.Renters;

import java.util.Optional;

public class RentUseCase {

    private final Inventory inventory;

    private final Renters renters;

    public RentUseCase(Inventory inventory, Renters renters) {
        this.inventory = inventory;
        this.renters = renters;
    }

    public RentResult rent(ItemId itemId, RenterId renterId) {
        return inventory.findById(itemId)
                .flatMap(this::isAvailable)
                .flatMap(item -> rentScope(item, renters.findById(renterId)))
                .map(rentScope -> inventory.rent(rentScope.item(), rentScope.renter().id()))
                .map((it) -> RentResult.RENTED)
                .orElse(RentResult.NOT_RENTED);
    }

    private Optional<Item> isAvailable(Item item) {
        if (item.isAvailable()) {
            return Optional.empty();
        } else {
            return Optional.of(item);
        }
    }

    private Optional<RentScope> rentScope(Item item, Optional<Renter> renter) {
        return renter.map(value -> new RentScope(item, value));
    }
}

record RentScope(Item item, Renter renter) {

}