package de.richargh.billiondollar.people.exposed;

import de.richargh.billiondollar.commons.annotations.Nullable;

public record Employee(EmployeeId id, String name, @Nullable Notebook notebook) {

    public Employee withoutNotebook() {
        return new Employee(id, name, null);
    }
}
