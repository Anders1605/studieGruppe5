using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Offer
    {
        public int OfferId { get; set; }

        public User Buyer { get; set; }

        public bool OfferAccepted { get; set; } = false;
    }
}
