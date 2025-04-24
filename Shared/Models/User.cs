namespace Shared.Models
{
    public class User
    {
        public string Name { get; set; }

        public string TelephoneNumber { get; set; }

        public string Address { get; set; }

        public string ProfilePictureUrl { get; set; } = string.Empty;

        public string EmailAddress { get; set; }

        public string Password { get; set; }
    }
}
