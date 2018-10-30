using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Users
{
    public class User
    {
        public enum Roles
        {
            member,
            admin,
            librarian
        }

        public Guid ID { get; }
        public long INSS { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Roles UserRoles { get; private set; }
        public string Street { get; private set; }
        public string StreetNumber { get; private set; }
        public int PostalCode { get; private set; }
        public string City { get; private set; }

        public User(UserBuilder userBuilder)
        {
            ID = Guid.NewGuid();
            INSS = userBuilder.INSS;
            FirstName = userBuilder.FirstName;
            LastName = userBuilder.LastName;
            Email = userBuilder.Email;
            Password = userBuilder.Password;
            UserRoles = userBuilder.UserRoles;
            Street = userBuilder.Street;
            StreetNumber = userBuilder.StreetNumber;
            PostalCode = userBuilder.PostalCode;
            City = userBuilder.City;
        }

		public void SetRole(Roles roles)
		{
			UserRoles = roles;
		}

    }
}
