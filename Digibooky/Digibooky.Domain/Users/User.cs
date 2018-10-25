using System;
using System.Collections.Generic;
using System.Text;

namespace Digibooky.Domain.Users
{
    public class User
    {
        public enum Roles { member }

        public Guid ID { get; }
        public int INSS { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Roles UserRole { get; private set; }
        public string Street { get; private set; }
        public string StreetNumber { get; private set; }
        public int PostalCode { get; private set; }
        public string City { get; private set; }
    }
}
