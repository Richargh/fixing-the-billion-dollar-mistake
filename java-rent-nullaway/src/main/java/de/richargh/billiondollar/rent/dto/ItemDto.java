package de.richargh.billiondollar.rent.dto;

import javax.annotation.Nullable;

public record ItemDto(String id, String name, @Nullable String rentedById) {

}
