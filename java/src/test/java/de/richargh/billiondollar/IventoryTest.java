package de.richargh.billiondollar;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.DisplayName;
import static org.assertj.core.api.Assertions.assertThat;

import java.util.Optional;

public class IventoryTest {

    @Test
    @DisplayName("Initial Inventory should be empty")
    public void isEmpty(){
        // given
        Inventory testee = new Inventory();

        // when
        Optional<Item> result = testee.findById(new ItemId("1"));

        // then
        assertThat(result).isEmpty();
    }

    @Test
    @DisplayName("should find item if it's in the inventory")
    public void findExistingItem(){
        // given
        ItemId id = new ItemId("1");
        Item item = new Item(id, "Ben");
        Inventory testee = new Inventory(item);

        // when
        Optional<Item> result = testee.findById(id);

        // then
        assertThat(result).contains(item);
    }
}
