package de.richargh.billiondollar.people;

import de.richargh.billiondollar.people.exposed.Budget;
import de.richargh.billiondollar.people.exposed.EmployeeId;
import de.richargh.billiondollar.people.exposed.NotebookType;
import de.richargh.billiondollar.people.internal.Company;
import de.richargh.billiondollar.people.internal.NotebookMakers;
import de.richargh.billiondollar.people.internal.Notebooks;

public class NotebookUseCase {

    private final Company company;
    private final NotebookMakers notebookMakers;

    private final Notebooks notebooks;

    public NotebookUseCase(Company company, NotebookMakers makers, Notebooks notebooks) {
        this.company = company;
        this.notebookMakers = makers;
        this.notebooks = notebooks;
    }

    public String findNotebookModel(EmployeeId id) {
        var employee = company.getById(id);
        if (employee == null) return EMPLOYEE_DOES_NOT_EXIST;

        /* ... */
        return employee.notebook() != null
                ? employee.notebook().model()
                : EMPLOYEE_DOES_NOT_HAVE_A_NOTEBOOK;
    }

    public Budget pickNotebook(EmployeeId employeeId, NotebookType type) {
        throw new RuntimeException();
//        var json = """
//                { "foo": "bar" }""";
//        var employee = company.getById(employeeId)
//                .orElseThrow(EmployeeDoesNotExistException::new);
//
//        var notebook = notebooks.firstAvailable(type);
//
//        if(employee.notebook() == null && employee.budget() != null && notebook != null)
//            company.put(employeeId, employee.withNotebook(notebook, employee.budget().minus(notebook.cost())));
//        /* ... */
//        return employee.notebook() != null
//                ? employee.notebook().model()
//                : EMPLOYEE_DOES_NOT_HAVE_A_NOTEBOOK;
    }

    public void startNotebookRepair(EmployeeId id) {
//        var employee = company.getById(id);
//        if (employee == null) return;
//        /* ... */
//        company.put(id, employee.withoutNotebook());
    }

    public static final String EMPLOYEE_DOES_NOT_EXIST = "Employee does not exist";

    public static final String EMPLOYEE_DOES_NOT_HAVE_A_NOTEBOOK = "Employee does not have a Notebook";
}
