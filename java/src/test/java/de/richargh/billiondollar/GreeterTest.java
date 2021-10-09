package de.richargh.billiondollar;

import org.junit.jupiter.api.Test;

import static org.assertj.core.api.Assertions.assertThat;

import org.junit.jupiter.api.DisplayName;

public class GreeterTest {

    @Test
    @DisplayName("Greeting should contain passed name")
    public void containsName(){
        // given
        Greeter testee = new Greeter();

        // when
        String result = testee.greet("Ben");

        // then
        assertThat(result).isEqualTo("Hello Ben!");
    }

}
