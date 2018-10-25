using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Users
{
    public class User
    {
        public enum Roles { member }

        public Guid ID { get; }
        public long INSS { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Roles UserRole { get; private set; }
        public string Street { get; private set; }
        public string StreetNumber { get; private set; }
        public int PostalCode { get; private set; }
        public string City { get; private set; }

        public User(long iNSS, string firstName, string lastName, string email, string password, Roles userRole, string street, string streetNumber, int postalCode, string city)
        {
            ID = Guid.NewGuid();
            INSS = iNSS;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserRole = userRole;
            Street = street;
            StreetNumber = streetNumber;
            PostalCode = postalCode;
            City = city;
        }
    }
}
