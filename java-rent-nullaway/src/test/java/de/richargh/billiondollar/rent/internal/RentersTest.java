package de.richargh.billiondollar.rent.internal;

import de.richargh.billiondollar.rent.exposed.Renter;
import de.richargh.billiondollar.rent.exposed.RenterId;
import de.richargh.billiondollar.testfixtures.rent.RenterFactory;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import java.util.Optional;

import static org.assertj.core.api.Assertions.assertThat;

public class RentersTest {

    @Test
    @DisplayName("Initial Renters should be empty")
    public void isEmpty() {
        // given
        Renters testee = new Renters();

        // when
        Optional<Renter> result = testee.findById(new RenterId("1"));

        // then
        assertThat(result).isEmpty();
    }

    @Test
    @DisplayName("should find renter if she's known")
    public void findExistingItem() {
        // given
        Renter renter = RenterFactory.aRenter();
        Renters testee = new Renters(renter);

        // when
        Optional<Renter> result = testee.findById(renter.id());

        // then
        assertThat(result).contains(renter);
    }
}
