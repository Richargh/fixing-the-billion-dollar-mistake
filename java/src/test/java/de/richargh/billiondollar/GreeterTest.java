package de.maibornwolff.kata;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class GreeterTest {

    @Test
    public void shouldSayHi(){
        // given
        Greeter sut = new Greeter();

        // when
        String result = sut.greet();

        // then
        assertEquals("Hi", result);
    }

}
