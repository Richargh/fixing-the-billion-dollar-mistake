package de.richargh.billiondollar.commons.json.internal;

import de.richargh.billiondollar.rent.dto.RenterDto;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

class JacksonJsonMapperTest {

    @Test
    @DisplayName("Can serialize a RenterDto")
    void CanSerialize() {
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
    void CanDeserialize() {
        // GIVEN
        var json = """
                {"id":"1","name":"Bart"}""";
        var testee = new JacksonJsonMapper();

        // WHEN
        var result = testee.toObject(json, RenterDto.class);

        // THEN
        assertThat(result).isEqualTo(new RenterDto("1", "Bart"));
    }
}
