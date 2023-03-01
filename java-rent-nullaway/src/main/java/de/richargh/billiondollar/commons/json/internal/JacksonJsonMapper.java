package de.richargh.billiondollar.commons.json.internal;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import de.richargh.billiondollar.commons.json.external.JsonMapper;
import de.richargh.billiondollar.commons.json.external.JsonMapperException;
import de.richargh.billiondollar.commons.json.external.JsonValidationException;
import jakarta.validation.ConstraintViolation;
import jakarta.validation.Validation;
import jakarta.validation.ValidatorFactory;

import java.util.Set;

public class JacksonJsonMapper implements JsonMapper {

    private final ObjectMapper objectMapper;

    private final ValidatorFactory factory = Validation.buildDefaultValidatorFactory();

    public JacksonJsonMapper() {
        this.objectMapper = new ObjectMapper();
    }

    @Override
    public String toJson(Object obj) {
        try {
            return this.objectMapper.writeValueAsString(obj);
        } catch (JsonProcessingException e) {
            throw new JsonMapperException(e);
        }
    }

    @Override
    public <T> T toObject(String json, Class<T> valueType) {
        T result;
        try {
            result = this.objectMapper.readValue(json, valueType);
        } catch (JsonProcessingException e) {
            throw new JsonMapperException(e);
        }

        var validator = factory.getValidator();
        Set<ConstraintViolation<Object>> violations = validator.validate(result);
        if (violations.isEmpty()) {
            return result;
        } else {
            throw new JsonValidationException(violations);
        }
    }
}
