package de.richargh.billiondollar.people;

import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static de.richargh.billiondollar.people.NotebookUseCaseComposer.aNotebookUseCase;
import static de.richargh.billiondollar.people.exposed.EmployeeBuilder.anEmployee;
import static de.richargh.billiondollar.people.exposed.EmployeeIds.anEmployeeId;
import static org.assertj.core.api.Assertions.assertThat;

class NotebookUseCaseTest {

    @Test
    @DisplayName("Should not find notebook maker when Employee does not exist")
    void negativeEmployee() {
        // given
        var testee = aNotebookUseCase().compose();

        // when
        String result = testee.findNotebookMaker(anEmployeeId());

        // then
        assertThat(result).isEqualTo(NotebookUseCase.EMPLOYEE_DOES_NOT_EXIST);
    }

    @Test
    @DisplayName("Should not find notebook when Employee does not have a notebook")
    void negativeNotebook() {
        // given
        var employee = anEmployee().withoutNotebook()
                .build();
        var testee = aNotebookUseCase().withEmployees(employee)
                .compose();

        // when
        String result = testee.findNotebookMaker(anEmployeeId());

        // then
        assertThat(result).isEqualTo(NotebookUseCase.EMPLOYEE_DOES_NOT_HAVE_A_NOTEBOOK);
    }
}