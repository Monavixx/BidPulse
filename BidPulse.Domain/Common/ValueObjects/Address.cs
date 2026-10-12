using FluentResults;

namespace BidPulse.Domain.Common.ValueObjects;

public sealed record Address
{
    private Address() { }

    public string Street { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string State { get; private set; } = null!;
    public string PostalCode { get; private set; } = null!;
    public string Country { get; private set; } = null!;

    public static Result<Address> Create(string street, string city, string state, string postalCode, string country)
    {
        if (string.IsNullOrWhiteSpace(street)) return Errors.Validation("Address.Street.Empty", "Street cannot be empty.");
        if (string.IsNullOrWhiteSpace(city)) return Errors.Validation("Address.City.Empty", "City cannot be empty.");
        if (string.IsNullOrWhiteSpace(state)) return Errors.Validation("Address.State.Empty", "State cannot be empty.");
        if (string.IsNullOrWhiteSpace(postalCode)) return Errors.Validation("Address.PostalCode.Empty", "Postal code cannot be empty.");
        if (string.IsNullOrWhiteSpace(country)) return Errors.Validation("Address.Country.Empty", "Country cannot be empty.");

        return new Address
        {
            Street = street,
            City = city,
            State = state,
            PostalCode = postalCode,
            Country = country
        };
    }
}
