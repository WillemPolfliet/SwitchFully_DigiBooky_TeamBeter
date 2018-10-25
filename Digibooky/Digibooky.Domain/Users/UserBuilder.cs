using Digibooky.Domain.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using static Digibooky.Domain.Users.User;

namespace Digibooky.Domain.Users
{
    public class UserBuilder 
    {
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

        private UserBuilder() { }

        public static UserBuilder CreateUser()
        {
            return new UserBuilder();
        }
        
        public UserBuilder WithINSS(long INSS)
        { 
            if(INSS.ToString().Length != 13)
            {
                throw new UserException("INSS must be 13 numbers");
            }

            this.INSS = INSS;
            return this;
        }

        public UserBuilder WithFirstName(string firstName)
        {
            this.FirstName = firstName;
            return this;
        }

        public UserBuilder WithLastName(string lastName)
        {
            if(string.IsNullOrEmpty(lastName))
            {
                throw new UserException("Last name is required");
            }

            this.LastName = lastName;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new UserException("Email is required");
            }

            if (!emailIsValid(email))
            {
                throw new UserException("Emailformat must be word@word.word");
            }

            this.Email = email;
            return this;
        }

        private bool emailIsValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch(FormatException)
            {
                return false;
            }
        }

        public UserBuilder WithPassword(string password)
        {
            this.Password= password;
            return this;
        }

        public UserBuilder WithRole(Roles role)
        {
            this.UserRole = role;
            return this;
        }

        public UserBuilder WithStreet(string street)
        {
            this.Street= street;
            return this;
        }

        public UserBuilder WithStreetNumber(string streetNumber)
        {
            this.StreetNumber= streetNumber;
            return this;
        }

        public UserBuilder WithPostalCode(int postalCode)
        {
            this.PostalCode = postalCode;
            return this;
        }

        public UserBuilder WithCity(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                throw new UserException("City is required");
            }

            this.City = city;
            return this;
        }

        public User Build()
        {
            return new User(this);
        }


    }
}
