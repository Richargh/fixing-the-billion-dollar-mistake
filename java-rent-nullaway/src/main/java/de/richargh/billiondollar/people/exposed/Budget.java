package de.richargh.billiondollar.people.exposed;

import de.richargh.billiondollar.commons.types.Money;

import java.time.Instant;

public record Budget(Money money, Instant until) {
}
