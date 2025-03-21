package de.richargh.billiondollar.people.internal;

import de.richargh.billiondollar.commons.annotations.Nullable;
import de.richargh.billiondollar.people.exposed.Notebook;
import de.richargh.billiondollar.people.exposed.NotebookType;

public interface Notebooks {

    @Nullable
    Notebook firstAvailable(NotebookType type);

}
