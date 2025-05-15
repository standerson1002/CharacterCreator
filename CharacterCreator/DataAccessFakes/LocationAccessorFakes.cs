using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataDomain.Locations;

namespace DataAccessFakes
{
    public class LocationAccessorFakes : ILocationAccessor
    {
        private List<Country> _countries;
        private List<Subdivision> _subdivisions;
        private List<City> _cities;
        private List<Location> _locations;

        public LocationAccessorFakes()
        {
            _countries = new List<Country>();
            _countries.Add(new Country()
            {
                CountryID = "United States of America",
                CountryNationality = "American",
                CountryDescription = "Country in North America."
            });
            _countries.Add(new Country()
            {
                CountryID = "Canada",
                CountryNationality = "Canadian",
                CountryDescription = "Country in North America."
            });
            _countries.Add(new Country()
            {
                CountryID = "Mexico",
                CountryNationality = "Mexican",
                CountryDescription = "Country in North America."
            });

            _subdivisions = new List<Subdivision>();
            _subdivisions.Add(new Subdivision()
            {
                SubdivisionID = 1,
                SubdivisionCountry = "United States of America",
                SubdivisionType = "State",
                SubdivisionName = "Iowa",
                SubdivisionDescription = "One of the 50 US states."
            });
            _subdivisions.Add(new Subdivision()
            {
                SubdivisionID = 2,
                SubdivisionCountry = "United States of America",
                SubdivisionType = "State",
                SubdivisionName = "Florida",
                SubdivisionDescription = "One of the 50 US states."
            });

            _cities = new List<City>();
            _cities.Add(new City()
            {
                CityID = 1,
                CityCountry = "United States of America",
                CitySubdivision = "Iowa",
                CitySubdivisionID = 1,
                CityName = "Iowa City",
                CityDescription = "A city in the United States of America."
            });
            _cities.Add(new City()
            {
                CityID = 2,
                CityCountry = "United States of America",
                CitySubdivision = "Iowa",
                CitySubdivisionID = 1,
                CityName = "Cedar Rapids",
                CityDescription = "A city in the United States of America."
            });
            _cities.Add(new City()
            {
                CityID = 3,
                CityCountry = "United States of America",
                CitySubdivision = "Florida",
                CitySubdivisionID = 2,
                CityName = "Miami",
                CityDescription = "A city in the United States of America."
            });

            _locations = new List<Location>();
            _locations.Add(new Location()
            {
                LocationID = 1,
                LocationName = "Park",
                LocationCountry = "United States of America",
                LocationSubdivision = "Iowa",
                LocationSubdivisionID = 1,
                LocationCity = "Iowa City",
                LocationCityID = 1,
                CreatorID = "user"
            });
            _locations.Add(new Location()
            {
                LocationID = 2,
                LocationName = "School",
                LocationCountry = "United States of America",
                LocationSubdivision = "Iowa",
                LocationSubdivisionID = 1,
                LocationCity = "Cedar Rapids",
                LocationCityID = 2,
                CreatorID = "user"
            });
            _locations.Add(new Location()
            {
                LocationID = 3,
                LocationName = "Beach",
                LocationCountry = "United States of America",
                LocationSubdivision = "Florida",
                LocationSubdivisionID = 2,
                LocationCity = "Miami",
                LocationCityID = 3,
                CreatorID = "friend"
            });
        }

        public bool CreateLocation(Location location)
        {

            foreach (Location l in _locations)
            {
                if (l.LocationID == location.LocationID)
                {
                    return false;
                }
            }
                
            int count1 = _locations.Count;
            _locations.Add(location);
            int count2 = _locations.Count;
            return count1 + 1 == count2;
        }

        public bool DeleteLocation(Location location)
        {
            bool result = false;

            foreach (Location l in _locations)
            {
                if (l.LocationID == location.LocationID)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public bool UpdateLocation(Location oldLocation, Location newLocation)
        {
            bool result = false;

            foreach (Location l in _locations)
            {
                if (l.LocationID == oldLocation.LocationID)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public List<City> SelectAllCities()
        {
            return _cities;
        }

        public List<Subdivision> SelectAllSubdivisions()
        {
            return _subdivisions;
        }

        public List<Country> SelectAllCountries()
        {
            return _countries;
        }

        public List<Location> SelectAllLocationsByCreatorID(string creatorID)
        {
            List<Location> locations = new List<Location>();

            foreach (Location location in _locations)
            {
                if(location.CreatorID == creatorID)
                {
                    locations.Add(location);
                }
            }

            return locations;
        }
        
        public Location SelectLocationByLocationID(int locationID)
        {
            Location result = null;

            foreach (Location location in _locations)
            {
                if (location.LocationID == locationID)
                {
                    result = location;
                    break;
                }
            }

            return result;
        }

        
    }
}
