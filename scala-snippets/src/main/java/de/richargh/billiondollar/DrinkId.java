package de.richargh.billiondollar;

public class DrinkId {
    private final String rawValue;
    public DrinkId(String rawValue){
        this.rawValue = rawValue;
    }

    @Override
    public boolean equals(Object o) {
        if (o == this)
            return true;
        if (!(o instanceof DrinkId))
            return false;
        DrinkId other = (DrinkId)o;
        return rawValue.equals(other.rawValue);
    }

    @Override
    public int hashCode() {
        return rawValue.hashCode();
    }
}
