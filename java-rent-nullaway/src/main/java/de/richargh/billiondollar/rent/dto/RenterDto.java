package de.richargh.billiondollar.rent.dto;

import de.richargh.billiondollar.commons.json.external.DefaultIsNonNullable;

@DefaultIsNonNullable
public record RenterDto(String id, String name) {

}
