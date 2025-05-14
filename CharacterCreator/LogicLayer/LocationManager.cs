using DataAccessInterfaces;
using DataAccessLayer;
using DataDomain.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class LocationManager : ILocationManager
    {
        private ILocationAccessor _locationAccessor;

        public LocationManager()
        {
            _locationAccessor = new LocationAccessor();

        }
        public LocationManager(ILocationAccessor locationAccessor)
        {
            _locationAccessor = locationAccessor;
        }


        public bool CreateLocation(Location location)
        {
            bool result = false;
            try
            {
                result = _locationAccessor.CreateLocation(location);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool DeleteLocation(Location location)
        {
            bool result = false;
            try
            {
                result = _locationAccessor.DeleteLocation(location);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public List<City> GetAllCities()
        {
            List<City> cities = null;
            try
            {
                cities = _locationAccessor.SelectAllCities();
            }
            catch (Exception)
            {
                throw;
            }
            return cities;
        }

        public List<Country> GetAllCountries()
        {
            List<Country> countries = null;
            try
            {
                countries = _locationAccessor.SelectAllCountries();
            }
            catch (Exception)
            {
                throw;
            }
            return countries;
        }

        public List<Location> GetAllLocationsByCreatorID(string creatorID)
        {
            List<Location> locations = null;
            try
            {
                locations = _locationAccessor.SelectAllLocationsByCreatorID(creatorID);
            }
            catch (Exception)
            {
                throw;
            }
            return locations;
        }

        public List<Subdivision> GetAllSubdivisions()
        {
            List<Subdivision> subdivisions = null;
            try
            {
                subdivisions = _locationAccessor.SelectAllSubdivisions();
            }
            catch (Exception)
            {
                throw;
            }
            return subdivisions;
        }

        public Location GetLocationByLocationID(int locationID)
        {
            Location location = null;
            try
            {
                location = _locationAccessor.SelectLocationByLocationID(locationID);
            }
            catch (Exception)
            {
                throw;
            }
            return location;
        }

        public bool UpdateLocation(Location oldLocation, Location newLocation)
        {
            bool result = false;
            try
            {
                result = _locationAccessor.UpdateLocation(oldLocation, newLocation);
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
