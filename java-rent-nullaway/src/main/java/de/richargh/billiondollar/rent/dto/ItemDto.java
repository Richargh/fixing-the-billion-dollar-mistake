package de.richargh.billiondollar.rent.dto;

import de.richargh.billiondollar.commons.json.external.DefaultIsNonNullable;
import org.jspecify.annotations.Nullable;

@DefaultIsNonNullable
public record ItemDto(String id, String name, @Nullable String rentedById) {

}
