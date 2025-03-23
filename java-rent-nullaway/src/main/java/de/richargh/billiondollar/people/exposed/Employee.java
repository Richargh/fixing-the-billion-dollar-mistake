package de.richargh.billiondollar.people.exposed;

import org.jspecify.annotations.Nullable;

public record Employee(
        EmployeeId id,
        String name,
        @Nullable Notebook notebook,
        @Nullable Budget budget) {

    public Employee withNotebook(Notebook notebook, Budget budget) {
        return new Employee(id, name, notebook, budget);
    }

    public Employee withoutNotebook() {
        return new Employee(id, name, null, budget);
    }

    public boolean hasNotebook() {
        return notebook != null;
    }
}
