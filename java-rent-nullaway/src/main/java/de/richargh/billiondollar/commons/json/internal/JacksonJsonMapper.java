package de.richargh.billiondollar.commons.json.internal;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import de.richargh.billiondollar.commons.json.external.JsonMapper;
import de.richargh.billiondollar.commons.json.external.JsonMapperException;

public class JacksonJsonMapper implements JsonMapper {

    private final ObjectMapper objectMapper;

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
        try {
            return this.objectMapper.readValue(json, valueType);
        } catch (JsonProcessingException e) {
            throw new JsonMapperException(e);
        }
    }
}
