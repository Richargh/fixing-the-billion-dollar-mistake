package de.richargh.billiondollar.rent;

import de.richargh.billiondollar.rent.exposed.Item;
import de.richargh.billiondollar.rent.exposed.Renter;
import de.richargh.billiondollar.rent.exposed.RenterId;
import de.richargh.billiondollar.rent.internal.Inventory;
import de.richargh.billiondollar.rent.internal.Renters;
import de.richargh.billiondollar.testfixtures.rent.ItemFactory;
import de.richargh.billiondollar.testfixtures.rent.RenterFactory;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

public class RentUseCaseTest {

    @Test
    @DisplayName("renting should be possible, when renter and item are valid")
    public void allValid() {
        // given
        Item item = ItemFactory.anAvailableItem();
        Renter renter = RenterFactory.aRenter();
        Inventory inventory = new Inventory(item);
        Renters renters = new Renters(renter);
        RentUseCase testee = new RentUseCase(inventory, renters);

        // when
        boolean isSuccess = testee.rent(item.id(), renter.id());

        // then
        assertThat(isSuccess).isTrue();
    }

    @Test
    @DisplayName("renting should not be possible, when item is unavailable")
    public void itemUnavailable() {
        // given
        Item item = ItemFactory.anUnavailableItem();
        Renter renter = RenterFactory.aRenter();
        Inventory inventory = new Inventory(item);
        Renters renters = new Renters(renter);
        RentUseCase testee = new RentUseCase(inventory, renters);

        // when
        boolean isSuccess = testee.rent(item.id(), renter.id());

        // then
        assertThat(isSuccess).isFalse();
    }

    @Test
    @DisplayName("renting should not be possible, when renter is unknown")
    public void renterUnknown() {
        // given
        Item item = ItemFactory.anAvailableItem();
        Inventory inventory = new Inventory(item);
        Renters renters = new Renters();
        RentUseCase testee = new RentUseCase(inventory, renters);

        // when
        boolean isSuccess = testee.rent(item.id(), new RenterId("1"));

        // then
        assertThat(isSuccess).isFalse();
    }
}
