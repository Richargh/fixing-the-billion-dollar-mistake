package de.richargh.billiondollar.people.exposed;

public record Notebook(
        NotebookId id,
        NotebookType type,
        String model,
        NotebookMakerId makerId) {
}
