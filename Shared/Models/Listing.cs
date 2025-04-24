using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Listing
    {
        public int ListingId { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Status { get; set; }

        public Offer? OfferEmbedded { get; set; }

        public Location? LocationEmbedded { get; set; }

        public User UserEmbedded { get; set; }

    }
}
