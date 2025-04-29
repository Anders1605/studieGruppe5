using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace Shared.Models
{
    public class Offer
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB will handle the _id automatically

        public int OfferId { get; set; }

        public User Buyer { get; set; }
        
        //public int Amount { get; set; }

        public bool OfferAccepted { get; set; } = false;
    }
}
