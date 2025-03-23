package de.richargh.billiondollar.commons.json.internal;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import de.richargh.billiondollar.rent.dto.RenterDto;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

@DisplayName("Test Standard Jackson Object Mapper Behavior")
public class StandardObjectMapperTest {

    @DisplayName("Does sadly deserialize non-nullable field to null")
    @Test
    void DoesSadlyDeserializeNonNullableFieldToNull() throws JsonProcessingException {
        // GIVEN
        var json = """
                { "name": "Alex" }""";
        var mapper = new ObjectMapper();

        // WHEN
        var result = mapper.readValue(json, RenterDto.class);

        // THEN
        System.out.println(result);
        assertThat(result.id()).isNull(); // should not be but is in fact standard jackson behavior
    }
}
