package de.richargh.billiondollar.commons.json.external;

import jakarta.validation.ConstraintValidator;
import jakarta.validation.ConstraintValidatorContext;

import java.lang.reflect.Field;
import java.util.Arrays;

public class DefaultIsNonNullableValidator implements ConstraintValidator<DefaultIsNonNullable, Object> {

    @Override
    public void initialize(DefaultIsNonNullable constraintAnnotation) {
    }

    @Override
    public boolean isValid(Object obj, ConstraintValidatorContext context) {
        if (obj == null) {
            return true;
        }
        for (Field declaredField : obj.getClass()
                .getDeclaredFields()) {

            if (isNull(declaredField, obj) && isNotNullable(declaredField)) {
                return false;
            }
        }
        return true;
    }

    private boolean isNull(Field field, Object obj) {
        field.setAccessible(true);
        try {
            return field.get(obj) == null;
        } catch (IllegalAccessException e) {
            throw new RuntimeException(e);
        }
    }

    private boolean isNotNullable(Field field) {
        return !isNullabe(field);
    }

    private boolean isNullabe(Field field) {
        return Arrays.stream(field.getDeclaredAnnotations())
                .anyMatch(it -> it.annotationType()
                        .getName()
                        .contains("Nullable"));
    }
}