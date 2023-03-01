package de.richargh.billiondollar.commons.json.external;

import jakarta.validation.ConstraintViolation;

import java.util.Set;

public class JsonValidationException extends RuntimeException {

    public <T> JsonValidationException(Set<ConstraintViolation<Object>> violations) {
        super(String.join(",", violations.stream()
                .map(it -> "(" + it.getPropertyPath() + ") " + it.getMessage())
                .toList()));
    }
}