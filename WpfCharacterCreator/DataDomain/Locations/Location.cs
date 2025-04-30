using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain.Locations
{
    public class Location
    {
		public int LocationID { get; set; }

		[DisplayName("Location Name")]
		public string LocationName { get; set; }

		[DisplayName("Country")]
		public string LocationCountry { get; set; }

        [DisplayName("Subdivision")]
        public int? LocationSubdivisionID { get; set; }

        [DisplayName("Subdivision")]
        public string? LocationSubdivision { get; set; }

        [DisplayName("City")]
        public int LocationCityID { get; set; }

        [DisplayName("City")]
        public string? LocationCity { get; set; }

        [DisplayName("Address")]
        public string? LocationAddress { get; set; }

        [DisplayName("Description")]
        public string? LocationDescription { get; set; }

        [DisplayName("Creator")]
        public string CreatorID { get; set; }
    }
}
