package de.richargh.billiondollar.people.internal;

import de.richargh.billiondollar.commons.annotations.Nullable;
import de.richargh.billiondollar.people.exposed.Employee;
import de.richargh.billiondollar.people.exposed.EmployeeId;

import java.util.Arrays;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;

public class InMemoryCompany implements Company {

    private final Map<EmployeeId, Employee> allEmployees = new ConcurrentHashMap<>();

    public InMemoryCompany(Employee... employees) {
        Arrays.stream(employees)
                .forEach(it -> allEmployees.put(it.id(), it));
    }

    @Override
    public @Nullable Employee getById(EmployeeId employeeId) {
        return allEmployees.get(employeeId);
    }

    @Override
    public void put(EmployeeId employeeId, Employee employee) {
        allEmployees.put(employeeId, employee);
    }
}
