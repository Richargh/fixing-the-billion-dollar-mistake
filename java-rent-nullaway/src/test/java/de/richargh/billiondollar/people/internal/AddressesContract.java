package de.richargh.billiondollar.people.internal;

import de.richargh.billiondollar.people.exposed.EmployeeId;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static de.richargh.billiondollar.people.exposed.AddressBuilder.anAddress;
import static de.richargh.billiondollar.people.exposed.EmployeeIds.anEmployeeId;
import static org.assertj.core.api.Assertions.assertThat;

public abstract class AddressesContract {

    protected abstract Addresses makeTestee();

    @Test
    @DisplayName("Addresses are initially empty")
    void count1() {
        // GIVEN
        var testee = makeTestee();

        // WHEN
        var result = testee.count();

        // THEN
        assertThat(result).isZero();
    }

    @Test
    @DisplayName("Address size reflects how many elements were added")
    void count2() {
        // GIVEN
        var anAddress = anAddress().build();
        var testee = makeTestee();

        // WHEN
        testee.put(new EmployeeId("1"), anAddress);

        // THEN
        var result = testee.count();
        assertThat(result).isEqualTo(1);
    }

    @Test
    @DisplayName("Should not be able to able to get an address for a person that does not exist")
    void negativeGet() {
        // GIVEN
        var testee = makeTestee();

        // WHEN
        var result = testee.getById(anEmployeeId());

        // THEN
        assertThat(result).isEmpty();
    }

    @Test
    @DisplayName("Should be able to able to get an address for a person that exists")
    void positiveGet() {
        // GIVEN
        var anAddress = anAddress().build();
        var testee = makeTestee();

        // WHEN
        testee.put(anEmployeeId(), anAddress);

        // THEN
        var result = testee.getById(anEmployeeId());
        assertThat(result).hasValue(anAddress);
    }
}
