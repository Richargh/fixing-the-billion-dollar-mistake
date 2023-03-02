package de.richargh.billiondollar.people.exposed;

import de.richargh.billiondollar.commons.error.BusinessException;

public record CountryCode(String rawValue) {

    public CountryCode {
        if (rawValue.length() != 2) throw new BusinessException("Country Code must be exactly two letters long");
    }

    public static CountryCode Germany = new CountryCode("DE");
}
