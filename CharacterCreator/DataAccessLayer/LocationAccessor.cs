using DataAccessInterfaces;
using DataDomain;
using DataDomain.Locations;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LocationAccessor : ILocationAccessor
    {
        public bool CreateLocation(Location location)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_create_location", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LocationName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@LocationCountry", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@LocationSubdivision", SqlDbType.Int);
            cmd.Parameters.Add("@LocationCity", SqlDbType.Int);
            cmd.Parameters.Add("@LocationAddress", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@LocationDescription", SqlDbType.NVarChar, 100);
            cmd.Parameters.Add("@CreatorID", SqlDbType.NVarChar, 20);
            
            cmd.Parameters["@LocationName"].Value = location.LocationName;
            cmd.Parameters["@LocationCountry"].Value = location.LocationCountry;
            cmd.Parameters["@LocationSubdivision"].Value = location.LocationSubdivisionID != 0 ? location.LocationSubdivisionID : DBNull.Value;
            cmd.Parameters["@LocationCity"].Value = location.LocationCityID != 0 ? location.LocationCityID : DBNull.Value;
            cmd.Parameters["@LocationAddress"].Value = location.LocationAddress != null ? location.LocationAddress : DBNull.Value;
            cmd.Parameters["@LocationDescription"].Value = location.LocationDescription != null ? location.LocationDescription : DBNull.Value;
            cmd.Parameters["@CreatorID"].Value = location.CreatorID;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public bool DeleteLocation(Location location)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_delete_location", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LocationID", SqlDbType.Int);
            cmd.Parameters.Add("@CreatorID", SqlDbType.NVarChar, 20);

            cmd.Parameters["@LocationID"].Value = location.LocationID;
            cmd.Parameters["@CreatorID"].Value = location.CreatorID;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public List<City> SelectAllCities()
        {
            List<City> cities = new List<City>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_all_cities", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    City city = new City();

                    city.CityID = reader.GetInt32(0);
                    city.CityName = reader.GetString(1);
                    city.CityCountry = reader.GetString(2);
                    city.CitySubdivisionID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                    city.CitySubdivision = reader.IsDBNull(4) ? null : reader.GetString(4);
                    city.CityDescription = reader.GetString(5);

                    cities.Add(city);

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return cities;
        }

        public List<Country> SelectAllCountries()
        {
            List<Country> countries = new List<Country>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_all_countries", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Country country = new Country();

                    country.CountryID = reader.GetString(0);
                    country.CountryDescription = reader.GetString(1);

                    countries.Add(country);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return countries;
        }

        public List<Location> SelectAllLocationsByCreatorID(string creatorID)
        {
            List<Location> locations = new List<Location>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_all_locations", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CreatorID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@CreatorID"].Value = creatorID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Location location = new Location();

                    location.LocationID = reader.GetInt32(0);
                    location.LocationName = reader.GetString(1);
                    location.LocationCountry = reader.GetString(2);
                    location.LocationSubdivisionID = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                    location.LocationSubdivision = reader.IsDBNull(4) ? null : reader.GetString(4);
                    location.LocationCityID = reader.GetInt32(5);
                    location.LocationCity = reader.GetString(6);
                    location.LocationAddress = reader.IsDBNull(7) ? null : reader.GetString(7);
                    location.LocationDescription = reader.IsDBNull(8) ? null : reader.GetString(8);
                    location.CreatorID = creatorID;

                    locations.Add(location);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return locations;
        }

        public List<Subdivision> SelectAllSubdivisions()
        {
            List<Subdivision> subdivisions = new List<Subdivision>();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_all_subdivisions", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Subdivision subdivision = new Subdivision();

                    subdivision.SubdivisionID = reader.GetInt32(0);
                    subdivision.SubdivisionName = reader.GetString(1);
                    subdivision.SubdivisionCountry = reader.GetString(2);
                    subdivision.SubdivisionType = reader.GetString(3);
                    subdivision.SubdivisionDescription = reader.GetString(4);

                    subdivisions.Add(subdivision);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return subdivisions;
        }

        public Location SelectLocationByLocationID(int locationID)
        {
            Location location = new Location();

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_view_location_by_locationid", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LocationID", SqlDbType.Int);
            cmd.Parameters["@LocationID"].Value = locationID;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    location.LocationID = locationID;
                    location.LocationName = reader.GetString(0);
                    location.LocationCountry = reader.GetString(1);
                    location.LocationSubdivisionID = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                    location.LocationSubdivision = reader.IsDBNull(3) ? null : reader.GetString(3);
                    location.LocationCityID = reader.GetInt32(4);
                    location.LocationCity = reader.GetString(5);
                    location.LocationAddress = reader.IsDBNull(6) ? null : reader.GetString(6);
                    location.LocationDescription = reader.IsDBNull(7) ? null : reader.GetString(7);
                    location.CreatorID = reader.GetString(8);
                }
                else
                {
                    throw new Exception("Location Not Found.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return location;
        }

        public bool UpdateLocation(Location oldLocation, Location newLocation)
        {
            bool result = false;

            var conn = DatabaseConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_location", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LocationID", SqlDbType.Int);
            cmd.Parameters["@LocationID"].Value = oldLocation.LocationID;

            cmd.Parameters.Add("@OldLocationName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@OldLocationCountry", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@OldLocationSubdivision", SqlDbType.Int);
            cmd.Parameters.Add("@OldLocationCity", SqlDbType.Int);
            cmd.Parameters.Add("@OldLocationAddress", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@OldLocationDescription", SqlDbType.NVarChar, 100);

            cmd.Parameters.Add("@NewLocationName", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NewLocationCountry", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NewLocationSubdivision", SqlDbType.Int);
            cmd.Parameters.Add("@NewLocationCity", SqlDbType.Int);
            cmd.Parameters.Add("@NewLocationAddress", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NewLocationDescription", SqlDbType.NVarChar, 100);

            cmd.Parameters["@OldLocationName"].Value = oldLocation.LocationName;
            cmd.Parameters["@OldLocationCountry"].Value = oldLocation.LocationCountry;
            cmd.Parameters["@OldLocationSubdivision"].Value = oldLocation.LocationSubdivisionID != 0 ? oldLocation.LocationSubdivisionID : DBNull.Value;
            cmd.Parameters["@OldLocationCity"].Value = oldLocation.LocationCityID != 0 ? oldLocation.LocationCityID : DBNull.Value;
            cmd.Parameters["@OldLocationAddress"].Value = oldLocation.LocationAddress != null ? oldLocation.LocationAddress : DBNull.Value;
            cmd.Parameters["@OldLocationDescription"].Value = oldLocation.LocationDescription != null ? oldLocation.LocationDescription : DBNull.Value;

            cmd.Parameters["@NewLocationName"].Value = newLocation.LocationName;
            cmd.Parameters["@NewLocationCountry"].Value = newLocation.LocationCountry;
            cmd.Parameters["@NewLocationSubdivision"].Value = newLocation.LocationSubdivisionID != 0 ? newLocation.LocationSubdivisionID : DBNull.Value;
            cmd.Parameters["@NewLocationCity"].Value = newLocation.LocationCityID != 0 ? newLocation.LocationCityID : DBNull.Value;
            cmd.Parameters["@NewLocationAddress"].Value = newLocation.LocationAddress != null ? newLocation.LocationAddress : DBNull.Value;
            cmd.Parameters["@NewLocationDescription"].Value = newLocation.LocationDescription != null ? newLocation.LocationDescription : DBNull.Value;

            try
            {
                conn.Open();
                result = cmd.ExecuteNonQuery() == 1;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }
    }
}
