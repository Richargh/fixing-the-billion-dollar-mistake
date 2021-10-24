package de.richargh.billiondollar;

public class ItemId {
    private final String rawValue;
    public ItemId(String rawValue){
        this.rawValue = rawValue;
    }

    @Override
    public boolean equals(Object o) {
        if (o == this)
            return true;
        if (!(o instanceof ItemId))
            return false;
        ItemId other = (ItemId)o;
        return rawValue.equals(other.rawValue);
    }

    @Override
    public int hashCode() {
        return rawValue.hashCode();
    }
}
