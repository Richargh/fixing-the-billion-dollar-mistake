package de.richargh.billiondollar.people.internal;

import de.richargh.billiondollar.people.exposed.Address;
import de.richargh.billiondollar.people.exposed.EmployeeId;

import java.util.Map;
import java.util.Optional;
import java.util.concurrent.ConcurrentHashMap;

public class InMemoryAddresses implements Addresses {

    private final Map<EmployeeId, Address> allAddresses = new ConcurrentHashMap<>();

    @Override
    public long count() {
        return allAddresses.size();
    }

    @Override
    public void put(EmployeeId id, Address address) {
        allAddresses.put(id, address);
    }

    @Override
    public Optional<Address> getById(EmployeeId employeeId) {
        return Optional.ofNullable(allAddresses.get(employeeId));
    }
}
