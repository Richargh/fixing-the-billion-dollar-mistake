package de.richargh.billiondollar.commons.json.external;

public interface JsonMapper {

    String toJson(Object obj);

    <T> T toObject(String json, Class<T> valueType);
}
