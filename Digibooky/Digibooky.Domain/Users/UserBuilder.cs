using Digibooky.Domain.Users.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using static Digibooky.Domain.Users.User;

namespace Digibooky.Domain.Users
{
    public class UserBuilder 
    {
        private const int REQUIRED_PASSWORD_LENGTH = 8;
        public long INSS { get; private set; } //long or string?
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public Roles UserRoles { get; private set; }
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
            if(string.IsNullOrWhiteSpace(lastName))
            {
                throw new UserException("Last name is required");
            }

            this.LastName = lastName;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new UserException("Email is required");
            }

            if (!IsEmailValid(email))
            {
                throw new UserException("Emailformat must be word@word.word");
            }

            this.Email = email;
            return this;
        }

        private bool IsEmailValid(string email)
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
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new UserException("Password is required");
            }
            if(password.Length < REQUIRED_PASSWORD_LENGTH)
            {
                throw new UserException($"Password must contain at least {REQUIRED_PASSWORD_LENGTH} characters");
            }
            if(!Regex.Match(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]").Success)
            {
                throw new UserException("The password is not valid. It should contain at least one uppercase character, one lowercase character and one digit");
            }


            this.Password= password;
            return this;
        }

        public UserBuilder WithRole(Roles role = Roles.member)
        {
			this.UserRoles = role;
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
            if (string.IsNullOrWhiteSpace(city))
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
