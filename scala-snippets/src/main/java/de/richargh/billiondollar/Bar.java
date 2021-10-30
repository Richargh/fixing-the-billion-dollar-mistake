package de.richargh.billiondollar;

import java.util.Map;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class Bar {

    private final Map<DrinkId, Drink> allDrinks;

    public Bar(Drink... drinks){
        this.allDrinks = Stream.of(drinks).collect(Collectors.toMap(Drink::id, item -> item));
    }

    public Drink findById(DrinkId id){
        return allDrinks.get(id);
    }

    public void place(Drink drink){
        allDrinks.put(drink.id(), drink);
    }

}
