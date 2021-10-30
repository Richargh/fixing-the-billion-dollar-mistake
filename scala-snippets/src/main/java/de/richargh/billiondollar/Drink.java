package de.richargh.billiondollar;

public class Drink {
    private final DrinkId id;
    private final String name;

    public Drink(DrinkId id, String name) {
        this.id = id;
        this.name = name;
    }

    public DrinkId id(){
        return id;
    }

    public String name(){
        return name;
    }
}
