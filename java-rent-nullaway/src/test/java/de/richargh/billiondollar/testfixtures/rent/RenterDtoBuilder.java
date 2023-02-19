package de.richargh.billiondollar.testfixtures.rent;

import de.richargh.billiondollar.rent.dto.RenterDto;

public class RenterDtoBuilder {

    public RenterDto build() {
        return new RenterDto("1", "Bart");
    }
}
