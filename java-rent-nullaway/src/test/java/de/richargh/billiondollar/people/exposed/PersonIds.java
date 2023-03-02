package de.richargh.billiondollar.people.exposed;

public final class PersonIds {

    private PersonIds() {
        // prevents creation
    }

    public static PersonId aPersonId() {
        return new PersonId("1");
    }
}
