package de.richargh.billiondollar.commons.json.internal;

import de.richargh.billiondollar.rent.dto.ItemDto;
import de.richargh.billiondollar.rent.dto.RenterDto;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

class JacksonJsonMapperTest {

    @Test
    @DisplayName("Can serialize a RenterDto")
    void CanSerializeSimple() {
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
    @DisplayName("Can deserialize a RenterDto")
    void CanDeserializeSimple() {
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
    @DisplayName("Can serialize an ItemDto with a missing nullable")
    void CanSerializeMissingNullable() {
        // GIVEN
        var dto = new ItemDto("1", "Coffee Mug", null);
        var testee = new JacksonJsonMapper();

        // WHEN
        var result = testee.toJson(dto);

        // THEN
        assertThat(result).isEqualTo("""
                                             {"id":"1","name":"Coffee Mug","rentedById":null}""");
    }

    @Test
    @DisplayName("Can serialize an ItemDto with an existing nullable")
    void CanSerializeExistingNullable() {
        // GIVEN
        var dto = new ItemDto("1", "Coffee Mug", "r1");
        var testee = new JacksonJsonMapper();

        // WHEN
        var result = testee.toJson(dto);

        // THEN
        assertThat(result).isEqualTo("""
                                             {"id":"1","name":"Coffee Mug","rentedById":"r1"}""");
    }

    @Test
    @DisplayName("Can deserialize an ItemDto with a missing nullable")
    void CanDeserializeMissingNullable() {
        // GIVEN
        var json = """
                {"id":"1","name":"Coffee Mug","rentedById":null}""";
        var testee = new JacksonJsonMapper();

        // WHEN
        var result = testee.toObject(json, ItemDto.class);

        // THEN
        assertThat(result).isEqualTo(new ItemDto("1", "Coffee Mug", null));
    }

    @Test
    @DisplayName("Can deserialize an ItemDto with an existing nullable")
    void CanDeserializeExistingNullable() {
        // GIVEN
        var json = """
                {"id":"1","name":"Coffee Mug","rentedById":"r1"}""";
        var testee = new JacksonJsonMapper();

        // WHEN
        var result = testee.toObject(json, ItemDto.class);

        // THEN
        assertThat(result).isEqualTo(new ItemDto("1", "Coffee Mug", "r1"));
    }
}
