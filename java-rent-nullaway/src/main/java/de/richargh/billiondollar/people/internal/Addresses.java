package de.richargh.billiondollar.people.internal;

import de.richargh.billiondollar.people.exposed.Address;
import de.richargh.billiondollar.people.exposed.PersonId;

import java.util.Optional;

public interface Addresses {

    long count();

    void put(PersonId id, Address address);

    Optional<Address> getById(PersonId personId);
}
