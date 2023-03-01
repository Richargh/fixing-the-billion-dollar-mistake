package de.richargh.billiondollar.rent.dto;

import de.richargh.billiondollar.commons.annotations.Nullable;
import de.richargh.billiondollar.commons.json.external.DefaultIsNonNullable;

@DefaultIsNonNullable
public record ItemDto(String id, String name, @Nullable String rentedById) {

}
