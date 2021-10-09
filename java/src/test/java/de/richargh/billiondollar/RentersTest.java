package de.richargh.billiondollar;

import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.DisplayName;
import static org.assertj.core.api.Assertions.assertThat;

import java.util.Optional;

public class RentersTest {

    @Test
    @DisplayName("Initial Renters should be empty")
    public void isEmpty(){
        // given
        Renters testee = new Renters();

        // when
        Optional<Renter> result = testee.findById(new RenterId("1"));

        // then
        assertThat(result).isEmpty();
    }

    @Test
    @DisplayName("should find renter if she's known")
    public void findExistingItem(){
        // given
        RenterId id = new RenterId("1");
        Renter renter = new Renter(id, "Lisa");
        Renters testee = new Renters(renter);

        // when
        Optional<Renter> result = testee.findById(id);

        // then
        assertThat(result).contains(renter);
    }
}
