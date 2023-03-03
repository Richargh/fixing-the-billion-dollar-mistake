package de.richargh.billiondollar.people.exposed;

public final class EmployeeIds {

    private EmployeeIds() {
        // prevents creation
    }

    public static EmployeeId anEmployeeId() {
        return new EmployeeId("1");
    }
}
