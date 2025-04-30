using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain.Locations
{
    public class City
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string CityCountry { get; set; }

        public int CitySubdivisionID { get; set; }
        public string? CitySubdivision { get; set; }
        public string CityDescription { get; set; }
    }
}
