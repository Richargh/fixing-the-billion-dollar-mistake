package de.richargh.billiondollar.people.exposed;

/*
 * Generated via IntelliJ Builder-Generator Plugin.
 */
public final class NotebookBuilder {

    private NotebookId id = aNotebookId();

    private String maker = "BELL";

    private NotebookBuilder() {
    }

    public static NotebookBuilder aNotebook() {
        return new NotebookBuilder();
    }

    public NotebookBuilder withId(NotebookId id) {
        this.id = id;
        return this;
    }

    public NotebookBuilder withMaker(String maker) {
        this.maker = maker;
        return this;
    }

    public Notebook build() {
        return new Notebook(id, maker);
    }

    public static NotebookId aNotebookId() {
        return new NotebookId("1");
    }
}
