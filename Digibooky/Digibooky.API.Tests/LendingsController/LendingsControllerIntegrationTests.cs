using Digibooky.Databases;
using Digibooky.Domain.Books;
using Digibooky.Domain.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Digibooky.API.Tests.LendingsController
{
	public class LendingsControllerIntegrationTests
	{
		private readonly TestServer _server;
		private readonly HttpClient _client;

		public LendingsControllerIntegrationTests()
		{
			_server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
			_client = _server.CreateClient();
			_client.DefaultRequestHeaders.Accept.Clear();
			_client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));


			UsersDatabase.users.Clear();
			var temp = new List<@string>()
			{
				UserBuilder.CreateUser()
				.WithINSS(1234567891235)
				.WithFirstName("Firstname")
				.WithLastName("Lastname")
				.WithEmail("user01@user.com")
				.WithPassword("Password123")
				.WithRole(@string.Roles.admin)
				.WithStreet("Street")
				.WithStreetNumber("5A")
				.WithPostalCode(2800)
				.WithCity("Mechelen")
				.Build(),

				UserBuilder.CreateUser()
				.WithINSS(1234567891238)
				.WithFirstName("Firstname")
				.WithLastName("Lastname")
				.WithEmail("user011@user.com")
				.WithPassword("Password123")
				.WithRole()
				.WithStreet("Street")
				.WithStreetNumber("5A")
				.WithPostalCode(2800)
				.WithCity("Mechelen")
				.Build(),

				UserBuilder.CreateUser()
				.WithINSS(1234567891239)
				.WithFirstName("Firstname")
				.WithLastName("Lastname")
				.WithEmail("user012@user.com")
				.WithPassword("Password123")
				.WithRole()
				.WithStreet("Street")
				.WithStreetNumber("5A")
				.WithPostalCode(2800)
				.WithCity("Mechelen")
				.Build()
			};
			UsersDatabase.users.AddRange(temp);

		}

		private AuthenticationHeaderValue CreateBasicHeader(string username, string password)
		{
			byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
			return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
		}


	}
}
