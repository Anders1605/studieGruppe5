using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class User
    {
        //Linje 9+10 er ChatGPT løsning på _id fra mongoDB
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB will handle the _id automatically

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 20 characters.")]
        public string Name { get; set; }

        public string TelephoneNumber { get; set; } = "";

        public string Address { get; set; } = "";

        public string ProfilePictureUrl { get; set; } = string.Empty;

        [Required]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "Name must be between 10 and 60 characters.")]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 20 characters.")]
        public string Password { get; set; }
    }
}
