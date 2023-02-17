package de.richargh.billiondollar;

import java.util.Optional;

public class RentScopeBuilder {

    private Optional<Item> item = Optional.empty();

    private Optional<Renter> renter = Optional.empty();

    public RentScopeBuilder withItem(Item item) {
        this.item = Optional.of(item);
        return this;
    }

    public RentScopeBuilder withRenter(Renter renter) {
        this.renter = Optional.of(renter);
        return this;
    }

    public Optional<RentScope> build() {
        if (item.isPresent() && renter.isPresent()) {
            return Optional.of(new RentScope(item.get(), renter.get()));
        } else {
            return Optional.empty();
        }
    }
}
