package de.richargh.billiondollar.people.internal;

public class InMemoryAddressesTest extends AddressesContract {

    @Override
    protected Addresses makeTestee() {
        return new InMemoryAddresses();
    }
}
