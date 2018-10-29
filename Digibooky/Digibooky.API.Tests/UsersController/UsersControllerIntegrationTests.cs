using Digibooky.API.Controllers.Users;
using Digibooky.Databases;
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

namespace Digibooky.API.Tests.UsersController
{
    public class UsersControllerIntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public UsersControllerIntegrationTests()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            UsersDatabase.users.Clear();
            var temp = new List<User>()
            {
                UserBuilder.CreateUser()
                .WithINSS(1234567891235)
                .WithFirstName("Firstname")
                .WithLastName("Lastname")
                .WithEmail("user01@user.com")
                .WithPassword("Password123")
                .WithRole(User.Roles.admin)
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

        [Fact]
        public async Task GetAllUsers_WhenGivenAListOfUsers_ThenAllUsersAreReturned()
        {
			var username = UsersDatabase.users[0].Email;
			var password = UsersDatabase.users[0].Password;

			_client.DefaultRequestHeaders.Authorization = CreateBasicHeader(username, password);

			var response = await _client.GetAsync("/api/users");
            var responseString = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<UserDTO>>(responseString);

            Assert.True(response.IsSuccessStatusCode);

            Assert.Equal(3, users.Count);
			
        }

        [Fact]
        public async Task RegisterUser_Specific_Valid()
        {
            var userToRegister = UserBuilder.CreateUser()
                .WithINSS(1234567891335)
                .WithFirstName("Firstname")
                .WithLastName("Lastname")
                .WithEmail("email@user.com")
                .WithPassword("Password123")
                .WithRole()
                .WithStreet("Street")
                .WithStreetNumber("5A")
                .WithPostalCode(2800)
                .WithCity("Mechelen")
                .Build();

            var content = JsonConvert.SerializeObject(userToRegister);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/users", stringContent);

            Assert.True(response.IsSuccessStatusCode);

            Assert.Equal(4, UsersDatabase.users.Count);
        }

        [Fact]
        public async Task RegisterUser_Specific_Invalid()
        {
            var userToRegister = UserBuilder.CreateUser()
                .WithINSS(1234567891335)
                .WithFirstName("Firstname")
                .WithLastName("Lastname")
                .WithPassword("Password123")
                .WithRole()
                .WithStreet("Street")
                .WithStreetNumber("5A")
                .WithPostalCode(2800)
                .WithCity("Mechelen")
                .Build();

            var content = JsonConvert.SerializeObject(userToRegister);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/users", stringContent);

            Assert.False(response.IsSuccessStatusCode);

            Assert.Equal(3, UsersDatabase.users.Count);
        }

        [Fact]
        public async Task GivenUserINSS_WhenAdminRegistersUserAsLibrarian_GivenUSerHAsNEwRole()
        {
            var username = UsersDatabase.users[0].Email;
            var password = UsersDatabase.users[0].Password;

            var inss = UsersDatabase.users[1].INSS;

            _client.DefaultRequestHeaders.Authorization = CreateBasicHeader(username, password);

            var content = JsonConvert.SerializeObject(User.Roles.librarian);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"/api/users/{inss}", stringContent);

            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(2, UsersDatabase.users[1].UserRoles.Count);
        }

        private AuthenticationHeaderValue CreateBasicHeader(string username, string password)
        {
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }
    }


}
