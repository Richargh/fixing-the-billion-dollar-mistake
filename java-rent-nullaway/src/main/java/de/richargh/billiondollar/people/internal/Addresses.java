package de.richargh.billiondollar.people.internal;

import de.richargh.billiondollar.people.exposed.Address;
import de.richargh.billiondollar.people.exposed.EmployeeId;

import java.util.Optional;

public interface Addresses {

    long count();

    void put(EmployeeId id, Address address);

    Optional<Address> getById(EmployeeId employeeId);
}
