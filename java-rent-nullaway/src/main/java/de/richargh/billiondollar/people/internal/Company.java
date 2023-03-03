package de.richargh.billiondollar.people.internal;

import de.richargh.billiondollar.commons.annotations.Nullable;
import de.richargh.billiondollar.people.exposed.Employee;
import de.richargh.billiondollar.people.exposed.EmployeeId;

public interface Company {

    @Nullable
    Employee getById(EmployeeId employeeId);

    void put(EmployeeId employeeId, Employee employee);
}
