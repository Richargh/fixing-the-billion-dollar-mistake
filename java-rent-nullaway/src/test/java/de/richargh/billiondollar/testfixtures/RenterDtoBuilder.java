package de.richargh.billiondollar.testfixtures;

import de.richargh.billiondollar.rent.dto.RenterDto;

public class RenterDtoBuilder {

    public RenterDto build() {
        return new RenterDto("1", "Bart");
    }
}
