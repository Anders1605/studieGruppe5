using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace Shared.Models

{
    public class Listing
    {
        [BsonId]
        public ObjectId Id { get; set; }  // MongoDB will handle the _id automatically

        public int ListingId { get; set; }

        /*Lånt fra Oles github*/
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 50 characters.")]
        public string Title { get; set; }

        /*Lånt fra Oles github*/
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "Price must be positive")]
        public double Price { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Status { get; set; }

        public List<Offer>? OfferEmbedded { get; set; }

        public Location? LocationEmbedded { get; set; }

        public User UserEmbedded { get; set; }

    }
}