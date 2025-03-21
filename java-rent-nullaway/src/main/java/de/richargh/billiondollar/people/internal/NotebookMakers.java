package de.richargh.billiondollar.people.internal;

import de.richargh.billiondollar.people.exposed.NotebookMaker;
import de.richargh.billiondollar.people.exposed.NotebookMakerId;

import java.util.Optional;

public interface NotebookMakers {
    Optional<NotebookMaker> getById(NotebookMakerId id);
}
