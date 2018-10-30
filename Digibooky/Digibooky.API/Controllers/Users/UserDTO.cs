namespace Digibooky.API.Controllers.Users
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
    }
}