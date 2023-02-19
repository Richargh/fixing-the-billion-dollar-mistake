package de.richargh.billiondollar.commons.json;

import de.richargh.billiondollar.commons.json.external.JsonMapper;
import de.richargh.billiondollar.commons.json.internal.JacksonJsonMapper;

public class JsonMapperFacade {

    public static JsonMapper createMapper() {
        return new JacksonJsonMapper();
    }
}
