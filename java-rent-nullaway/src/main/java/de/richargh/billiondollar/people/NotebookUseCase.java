package de.richargh.billiondollar.people;

import de.richargh.billiondollar.people.exposed.EmployeeId;
import de.richargh.billiondollar.people.internal.Company;

public class NotebookUseCase {

    private final Company company;

    public NotebookUseCase(Company company) {
        this.company = company;
    }

    public String findNotebookMaker(EmployeeId id) {
        var employee = company.getById(id);
        if (employee == null) return EMPLOYEE_DOES_NOT_EXIST;
        /* ... */
        return employee.notebook() != null ? employee.notebook()
                .maker() : EMPLOYEE_DOES_NOT_HAVE_A_NOTEBOOK;
    }

    public void startNotebookRepair(EmployeeId id) {
        var employee = company.getById(id);
        if (employee == null) return;
        /* ... */
        company.put(id, employee.withoutNotebook());
    }

    public static final String EMPLOYEE_DOES_NOT_EXIST = "Employee does not exist";

    public static final String EMPLOYEE_DOES_NOT_HAVE_A_NOTEBOOK = "Employee does not have a Notebook";
}
