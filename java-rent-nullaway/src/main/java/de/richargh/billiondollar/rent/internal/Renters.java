package de.richargh.billiondollar.rent.internal;

import de.richargh.billiondollar.rent.exposed.Renter;
import de.richargh.billiondollar.rent.exposed.RenterId;

import java.util.Map;
import java.util.Optional;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class Renters {

    private final Map<RenterId, Renter> renters;

    public Renters(Renter... renters) {
        this.renters = Stream.of(renters)
                .collect(Collectors.toMap(Renter::id, user -> user));
    }

    public Optional<Renter> findById(RenterId id) {
        return Optional.ofNullable(renters.get(id));
    }
}
