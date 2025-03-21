package de.richargh.billiondollar.people;

import de.richargh.billiondollar.people.exposed.Employee;
import de.richargh.billiondollar.people.internal.*;

public class NotebookUseCaseComposer {

    private Company company = new InMemoryCompany();
    private NotebookMakers makers = new InMemoryNotebookMakers();
    private Notebooks notebooks = new InMemoryNotebooks();

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
        return new NotebookUseCase(company, makers, notebooks);
    }
}
