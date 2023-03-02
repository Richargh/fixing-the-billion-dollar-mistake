package de.richargh.billiondollar.people.exposed;

/*
 * Generated via IntelliJ Builder-Generator Plugin.
 */
public final class AddressBuilder {

    private String street = "Cool Street 5";

    private String town = "Cool Town";

    private CountryCode country = CountryCode.Germany;

    private AddressBuilder() {
    }

    public static AddressBuilder anAddress() {
        return new AddressBuilder();
    }

    public AddressBuilder withStreet(String street) {
        this.street = street;
        return this;
    }

    public AddressBuilder withTown(String town) {
        this.town = town;
        return this;
    }

    public AddressBuilder withCountry(CountryCode country) {
        this.country = country;
        return this;
    }

    public Address build() {
        return new Address(street, town, country);
    }
}
