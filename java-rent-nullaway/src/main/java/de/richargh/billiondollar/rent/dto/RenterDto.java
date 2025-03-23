package de.richargh.billiondollar.rent.dto;

import de.richargh.billiondollar.commons.json.external.DefaultIsNonNullable;
import org.jspecify.annotations.NonNull;
import org.jspecify.annotations.NullMarked;

@NullMarked
@DefaultIsNonNullable
public record RenterDto(@NonNull String id, @NonNull String name) {

}
