using System;
using System.Collections.Generic;
using System.Text;

namespace Part3_BuilderPattern
{
    public class Address
    {
        public string Street { get; }
        public string City { get; }
        public string? State { get; }
        public string? ZipCode { get; }
        public string? Country { get; }

        public Address(string street,string city,string? state,string? zipCode,string? country)
        {
            Street = street;
            City = city;
            State = state;
            ZipCode = zipCode;
            Country = country;
        }
    }
    public class AddressBuilder
    {
        private string _street;
        private string _city;
        private string? _state;
        private string? _zipCode;
        private string? _country;
        public AddressBuilder(string street, string city)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Street is required.", nameof(street));

            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("City is required.", nameof(city));

            _street = street;
            _city = city;
        }
       
        public AddressBuilder SetState(string state)
        {
            _state = state;
            return this;
        }
        public AddressBuilder SetZipCode(string zipCode)
        {
            _zipCode = zipCode;
            return this;
        }
        public AddressBuilder SetCountry(string country)
        {
            _country = country;
            return this;
        }
        public Address Build()
        {
            return new Address(_street, _city, _state, _zipCode, _country);
        }
    }
}
