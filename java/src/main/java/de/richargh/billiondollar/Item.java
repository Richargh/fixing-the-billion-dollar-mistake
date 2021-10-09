package de.richargh.billiondollar;

public class Item {
    private final ItemId id;
    private final String name;

    public Item(ItemId id, String name) {
        this.id = id;
        this.name = name;
    }

    public ItemId id(){
        return id;
    }

    public String name(){
        return name;
    }

}
