using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    public class Location
    {
        public int LocationId { get; set; }

        public string Name { get; set; }

        public int StorageQuantity { get; set; }

        public string BuildingLocation { get; set; }

        public string RoomNumber { get; set; }

        public string OpeningHours { get; set; }
    }


}
