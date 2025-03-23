package de.richargh.billiondollar.people.internal;

import de.richargh.billiondollar.people.exposed.Notebook;
import de.richargh.billiondollar.people.exposed.NotebookId;
import de.richargh.billiondollar.people.exposed.NotebookType;
import org.jspecify.annotations.Nullable;

import java.util.Arrays;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;

public class InMemoryNotebooks implements Notebooks {

    private final Map<NotebookId, Notebook> allNotebooks = new ConcurrentHashMap<>();

    public InMemoryNotebooks(Notebook... notebooks) {
        Arrays.stream(notebooks)
                .forEach(it -> allNotebooks.put(it.id(), it));
    }

    @Override
    public @Nullable Notebook firstAvailable(NotebookType type) {
        return allNotebooks.values().stream()
                .filter(it -> it.type() == type)
                .findFirst().orElse(null);
    }
}
