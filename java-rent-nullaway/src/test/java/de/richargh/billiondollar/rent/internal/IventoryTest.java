package de.richargh.billiondollar.rent.internal;

import de.richargh.billiondollar.rent.exposed.Item;
import de.richargh.billiondollar.rent.exposed.ItemId;
import de.richargh.billiondollar.rent.exposed.RenterId;
import de.richargh.billiondollar.testfixtures.rent.ItemFactory;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import java.util.Optional;

import static org.assertj.core.api.Assertions.assertThat;

public class IventoryTest {

    @Test
    @DisplayName("Initial Inventory should be empty")
    public void isEmpty() {
        // given
        Inventory testee = new Inventory();

        // when
        Optional<Item> result = testee.findById(new ItemId("1"));

        // then
        assertThat(result).isEmpty();
    }

    @Test
    @DisplayName("should find item if it's in the inventory")
    public void findExistingItem() {
        // given
        Item item = ItemFactory.anAvailableItem();
        Inventory testee = new Inventory(item);

        // when
        Optional<Item> result = testee.findById(item.id());

        // then
        assertThat(result).contains(item);
    }

    @Test
    @DisplayName("should mark an item as rented")
    public void markItemAsRented() {
        // given
        RenterId renterId = new RenterId("1");
        Item item = ItemFactory.anAvailableItem();
        Inventory testee = new Inventory(item);

        // when
        testee.rent(item, renterId);

        // then
        Optional<Item> result = testee.findById(item.id());
        assertThat(result.get()
                           .isRented()).isTrue();
    }
}
