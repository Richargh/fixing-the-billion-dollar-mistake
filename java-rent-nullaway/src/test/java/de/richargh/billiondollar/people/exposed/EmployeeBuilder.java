package de.richargh.billiondollar.people.exposed;

import org.jspecify.annotations.Nullable;

import static de.richargh.billiondollar.people.exposed.NotebookBuilder.aNotebook;

public final class EmployeeBuilder {

    private EmployeeId id = EmployeeIds.anEmployeeId();

    private String name = "John";

    private @Nullable Notebook notebook = aNotebook().build();

    private @Nullable Budget budget = null;

    private EmployeeBuilder() {
    }

    public static EmployeeBuilder anEmployee() {
        return new EmployeeBuilder();
    }

    public EmployeeBuilder withId(EmployeeId id) {
        this.id = id;
        return this;
    }

    public EmployeeBuilder withName(String name) {
        this.name = name;
        return this;
    }

    public EmployeeBuilder withNotebook(Notebook notebook) {
        this.notebook = notebook;
        return this;
    }

    public EmployeeBuilder withoutNotebook() {
        this.notebook = null;
        return this;
    }

    public Employee build() {
        return new Employee(id, name, notebook, budget);
    }
}
