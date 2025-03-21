package de.richargh.billiondollar.people.exposed;

/*
 * Generated via IntelliJ Builder-Generator Plugin.
 */
public final class NotebookBuilder {

    private NotebookId id = aNotebookId();

    private NotebookType type = NotebookType.Cheap;

    private String model = "BELL";

    private final NotebookMakerId makerId = aNotebookMakerId();

    private NotebookBuilder() {
    }

    public static NotebookBuilder aNotebook() {
        return new NotebookBuilder();
    }

    public NotebookBuilder withId(NotebookId id) {
        this.id = id;
        return this;
    }

    public Notebook build() {
        return new Notebook(id, type, model, makerId);
    }

    public static NotebookId aNotebookId() {
        return new NotebookId("1");
    }

    public static NotebookMakerId aNotebookMakerId() {
        return new NotebookMakerId("1");
    }
}
