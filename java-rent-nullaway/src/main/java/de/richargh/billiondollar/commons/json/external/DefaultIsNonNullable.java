package de.richargh.billiondollar.commons.json.external;

import jakarta.validation.Constraint;
import jakarta.validation.Payload;

import java.lang.annotation.Documented;
import java.lang.annotation.Retention;
import java.lang.annotation.Target;

import static java.lang.annotation.ElementType.ANNOTATION_TYPE;
import static java.lang.annotation.ElementType.TYPE;
import static java.lang.annotation.RetentionPolicy.RUNTIME;

@Target({TYPE, ANNOTATION_TYPE})
@Retention(RUNTIME)
@Constraint(validatedBy = {DefaultIsNonNullableValidator.class})
@Documented
public @interface DefaultIsNonNullable {

    String message() default "Default is non-nullable violated";

    Class<?>[] groups() default {};

    Class<? extends Payload>[] payload() default {};
}
