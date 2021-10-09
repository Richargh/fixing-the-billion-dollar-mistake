package de.richargh.billiondollar;

import java.util.Optional;

public class RentUseCase {

    private final Inventory inventory;
    private final Renters renters;
    
    public RentUseCase(Inventory inventory, Renters renters) {
        this.inventory = inventory;
        this.renters = renters;
    }

    public boolean rent(ItemId itemId, RenterId renterId){
        boolean isRented = inventory
            .findById(itemId)
            .flatMap(item -> notRented(item))
            .flatMap(item -> rentScope(item, renters.findById(renterId)))
            .map(rentScope -> inventory.rent(rentScope.item(), rentScope.renter().id()))
            .isPresent();
            
        return isRented;
    }

    private Optional<Item> notRented(Item item){
        if(item.isRented())
            return Optional.empty();
        else
            return Optional.of(item);
    }

    private Optional<RentScope> rentScope(Item item, Optional<Renter> renter){
        if(renter.isPresent())
            return Optional.of(new RentScope(item, renter.get()));
        else
            return Optional.empty();
    }

}
