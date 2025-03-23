package de.richargh.billiondollar.people.internal;

import de.richargh.billiondollar.people.exposed.Notebook;
import de.richargh.billiondollar.people.exposed.NotebookType;
import org.jspecify.annotations.Nullable;

public interface Notebooks {

    @Nullable
    Notebook firstAvailable(NotebookType type);

}
