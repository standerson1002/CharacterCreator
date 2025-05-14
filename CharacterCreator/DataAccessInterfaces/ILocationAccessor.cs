using DataDomain.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface ILocationAccessor
    {
        bool CreateLocation(Location location);
        bool UpdateLocation(Location oldLocation, Location newLocation);
        bool DeleteLocation(Location location);
        List<Location> SelectAllLocationsByCreatorID(string creatorID);
        Location SelectLocationByLocationID(int locationID);
        List<Country> SelectAllCountries();
        List<Subdivision> SelectAllSubdivisions();
        List<City> SelectAllCities();
    }
}
