package de.richargh.billiondollar.people.internal;

import de.richargh.billiondollar.people.exposed.NotebookMaker;
import de.richargh.billiondollar.people.exposed.NotebookMakerId;

import java.util.Arrays;
import java.util.Map;
import java.util.Optional;
import java.util.concurrent.ConcurrentHashMap;

public class InMemoryNotebookMakers implements NotebookMakers {

    private final Map<NotebookMakerId, NotebookMaker> allMakers = new ConcurrentHashMap<>();

    public InMemoryNotebookMakers(NotebookMaker... makers) {
        Arrays.stream(makers)
                .forEach(it -> allMakers.put(it.id(), it));
    }

    @Override
    public Optional<NotebookMaker> getById(NotebookMakerId id) {
        return Optional.ofNullable(allMakers.get(id));
    }
}
