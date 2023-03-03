package de.richargh.billiondollar.people;

import de.richargh.billiondollar.people.exposed.Employee;
import de.richargh.billiondollar.people.internal.InMemoryCompany;

public class NotebookUseCaseComposer {

    private InMemoryCompany company = new InMemoryCompany();

    private NotebookUseCaseComposer() {
    }

    public static NotebookUseCaseComposer aNotebookUseCase() {
        return new NotebookUseCaseComposer();
    }

    public NotebookUseCaseComposer withEmployees(Employee... employees) {
        this.company = new InMemoryCompany(employees);
        return this;
    }

    public NotebookUseCase compose() {
        return new NotebookUseCase(company);
    }
}
