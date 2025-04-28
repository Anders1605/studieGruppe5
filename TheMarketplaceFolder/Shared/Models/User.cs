using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Shared.Models
{
    public class User
    {
        //Linje 9+10 er ChatGPT løsning på _id fra mongoDB
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB will handle the _id automatically

        public string Name { get; set; }

        public string TelephoneNumber { get; set; }

        public string Address { get; set; }

        public string ProfilePictureUrl { get; set; } = string.Empty;

        public string EmailAddress { get; set; }

        public string Password { get; set; }
    }
}
