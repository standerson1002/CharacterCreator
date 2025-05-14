using DataDomain.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public interface ILocationManager
    {
        bool CreateLocation(Location location);
        bool UpdateLocation(Location oldLocation, Location newLocation);
        bool DeleteLocation(Location location);
        List<Location> GetAllLocationsByCreatorID(string creatorID);
        Location GetLocationByLocationID(int locationID);
        List<Country> GetAllCountries();
        List<Subdivision> GetAllSubdivisions();
        List<City> GetAllCities();
    }
}
