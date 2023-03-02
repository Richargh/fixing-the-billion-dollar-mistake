package de.richargh.billiondollar.people.internal;

import de.richargh.billiondollar.people.exposed.Address;
import de.richargh.billiondollar.people.exposed.PersonId;

import java.util.Map;
import java.util.Optional;
import java.util.concurrent.ConcurrentHashMap;

public class InMemoryAddresses implements Addresses {

    private final Map<PersonId, Address> allAddresses = new ConcurrentHashMap<>();

    @Override
    public long count() {
        return allAddresses.size();
    }

    @Override
    public void put(PersonId id, Address address) {
        allAddresses.put(id, address);
    }

    @Override
    public Optional<Address> getById(PersonId personId) {
        return Optional.ofNullable(allAddresses.get(personId));
    }
}
