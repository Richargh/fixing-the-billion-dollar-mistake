package de.richargh.billiondollar.commons.json.internal;

import de.richargh.billiondollar.commons.json.external.JsonValidationException;
import de.richargh.billiondollar.rent.dto.ItemDto;
import de.richargh.billiondollar.rent.dto.RenterDto;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;
import static org.assertj.core.api.Assertions.catchThrowable;

class JacksonJsonMapperTest {

    @Test
    @DisplayName("Can serialize a RenterDto that has no nullable fields")
    void CanSerializeAllNonNullable() {
        // GIVEN
        var dto = new RenterDto("1", "Bart");
        var testee = new JacksonJsonMapper();

        // WHEN
        var result = testee.toJson(dto);

        // THEN
        assertThat(result).isEqualTo("""
                                             {"id":"1","name":"Bart"}""");
    }

    @Test
    @DisplayName("Can deserialize a RenterDto that has no nullable fields")
    void CanDeserializeAllNonNullable() {
        // GIVEN
        var json = """
                {"id":"1","name":"Bart"}""";
        var testee = new JacksonJsonMapper();

        // WHEN
        var result = testee.toObject(json, RenterDto.class);

        // THEN
        assertThat(result).isEqualTo(new RenterDto("1", "Bart"));
    }

    @Test
    @DisplayName("Cannot deserialize a RenterDto when name field is null but not marked as nullable")
    void CannotDeserializeBecauseFieldIsNonNullable() {
        // GIVEN
        var json = """
                {"id":"1","name":null}""";
        var testee = new JacksonJsonMapper();

        // WHEN
        var thrown = catchThrowable(() -> testee.toObject(json, RenterDto.class));

        // THEN
        assertThat(thrown).isInstanceOf(JsonValidationException.class);
    }

    @Test
    @DisplayName("Cannot deserialize RenterDto, when id field is null and not marked as nullable")
    void CannotDeserializeBecauseFieldNotMarkedAsNullable() {
        // GIVEN
        var json = """
                {"id":null,"name":"Burt"}""";
        var testee = new JacksonJsonMapper();

        // WHEN
        var thrown = catchThrowable(() -> testee.toObject(json, RenterDto.class));

        // THEN
        assertThat(thrown).isInstanceOf(JsonValidationException.class);
    }

    @Test
    @DisplayName("Cannot deserialize an ItemDto when a non-nullable field is null")
    void CannotDeserializeWhenNonNullableIsNull() {
        // GIVEN
        var json = """
                {"id":null,"name":"Coffee Mug","rentedById":"r1"}""";
        var testee = new JacksonJsonMapper();

        // WHEN
        var thrown = catchThrowable(() -> testee.toObject(json, ItemDto.class));

        // THEN
        assertThat(thrown).isInstanceOf(JsonValidationException.class);
    }

    @Test
    @DisplayName("Can deserialize an ItemDto when a nullable field is null")
    void CanDeserializeWhenNullableIsNull() {
        // GIVEN
        var json = """
                {"id":null,"name":"Coffee Mug","rentedById":"r1"}""";
        var testee = new JacksonJsonMapper();

        // WHEN
        var thrown = catchThrowable(() -> testee.toObject(json, ItemDto.class));

        // THEN
        assertThat(thrown).isInstanceOf(JsonValidationException.class);
    }
}
