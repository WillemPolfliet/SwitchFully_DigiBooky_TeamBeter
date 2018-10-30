using Digibooky.Domain.Users;
using System.Collections.Generic;

namespace Digibooky.Databases
{
	public static class UsersDatabase
	{
		public static List<@string> users = new List<@string>() { UserBuilder.CreateUser()
				.WithINSS(1234567891234)
				.WithFirstName("Firstname")
				.WithLastName("Lastname")
				.WithEmail("user@user.com")
				.WithPassword("Password123")
				.WithRole(@string.Roles.admin)
				.WithStreet("Street")
				.WithStreetNumber("5A")
				.WithPostalCode(2800)
				.WithCity("Mechelen")
				.Build(),

			UserBuilder.CreateUser()
				.WithINSS(1234567891234)
				.WithFirstName("Firstname")
				.WithLastName("Lastname")
				.WithEmail("user1@user.com")
				.WithPassword("Password123")
			.WithRole(@string.Roles.member)
				.WithStreet("Street")
				.WithStreetNumber("5A")
				.WithPostalCode(2800)
				.WithCity("Mechelen")
				.Build(),
	};
	}
}

