package de.richargh.billiondollar;

public class RenterId {
    private final String rawValue;
    public RenterId(String rawValue){
        this.rawValue = rawValue;
    }

    @Override
    public boolean equals(Object o) {
        if (o == this)
            return true;
        if (!(o instanceof RenterId))
            return false;
        RenterId other = (RenterId)o;
        return rawValue.equals(other.rawValue);
    }

    @Override
    public int hashCode() {
        return rawValue.hashCode();
    }
}
