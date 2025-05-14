using DataDomain.Locations;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCharacterCreator.Pages.Locations
{
    /// <summary>
    /// Interaction logic for EditLocation.xaml
    /// </summary>
    public partial class EditLocation : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        LocationManager _locationManager = new LocationManager();

        List<Country> countries = new List<Country>();
        List<Subdivision> subdivisions = new List<Subdivision>();
        List<City> cities = new List<City>();

        Location location;


        public EditLocation(Location location)
        {
            InitializeComponent();
            this.location = location;
            populateInformation();
        }


        private void populateInformation()
        {
            try
            {
                main.ClearMessage();

                textName.Text = location.LocationName;
                textAddress.Text = location.LocationAddress;
                textDescription.Text = location.LocationDescription;
             

                countries = _locationManager.GetAllCountries();
                Country selectedCountry = null;
                foreach (Country country in countries)
                {
                    if(country.CountryID == location.LocationCountry)
                    {
                        selectedCountry = country;
                        break;
                    }
                }
                comboCountries.ItemsSource = countries;
                comboCountries.SelectedItem = selectedCountry;


                subdivisions = _locationManager.GetAllSubdivisions();
                List<Subdivision> availableSubdivisions= new List<Subdivision>();
                Subdivision selectedSubdivision = null;
                foreach (Subdivision subdivision in subdivisions)
                {
                    if(subdivision.SubdivisionCountry == location.LocationCountry)
                    {
                        availableSubdivisions.Add(subdivision);
                        if(location.LocationSubdivision != null && subdivision.SubdivisionID == location.LocationSubdivisionID)
                        {
                            selectedSubdivision = subdivision;
                        }
                    }
                }
                comboSubdivisions.ItemsSource = availableSubdivisions;
                comboSubdivisions.SelectedItem = selectedSubdivision;


                cities = _locationManager.GetAllCities();
                List<City> availableCities = new List<City>();
                City selectedCity = null;
                if(location.LocationSubdivision != null)
                {
                    foreach(City city in cities)
                    {
                        if(city.CitySubdivision != null && city.CitySubdivision == location.LocationSubdivision)
                        {
                            availableCities.Add(city);
                            if(city.CityID == location.LocationCityID)
                            {
                                selectedCity = city;
                            }
                        }
                    }
                }
                else
                {
                    foreach (City city in cities)
                    {
                        if (city.CityCountry == location.LocationCountry)
                        {
                            availableCities.Add(city);
                            if (city.CityID == location.LocationCityID)
                            {
                                selectedCity = city;
                            }
                        }
                    }
                }
                comboCities.ItemsSource = availableCities;
                comboCities.SelectedItem = selectedCity;


            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }
        }

        private void comboCountries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Country country = (Country)comboCountries.SelectedItem;

                List<Subdivision> countrySubdivisions = new List<Subdivision>();
                foreach (Subdivision subdivision in subdivisions)
                {
                    if (subdivision.SubdivisionCountry == country.CountryID)
                    {
                        countrySubdivisions.Add(subdivision);
                    }
                }
                comboSubdivisions.ItemsSource = countrySubdivisions;

                List<City> countryCities = new List<City>();
                foreach (City city in cities)
                {
                    if (city.CityCountry == country.CountryID)
                    {
                        countryCities.Add(city);
                    }
                }
                comboCities.ItemsSource = countryCities;

            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }
        }

        private void comboSubdivisions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Subdivision subdivision = (Subdivision)comboSubdivisions.SelectedItem;

                if (subdivision != null)
                {
                    List<City> subdivisionCities = new List<City>();
                    foreach (City city in cities)
                    {
                        if (city.CitySubdivisionID == subdivision.SubdivisionID)
                        {
                            subdivisionCities.Add(city);
                        }
                    }
                    comboCities.ItemsSource = subdivisionCities;
                }


            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }
        }


        private void btnDeleteLocation_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this location?", "Delete Location", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                try
                {
                    if (_locationManager.DeleteLocation(location))
                    {
                        main.ShowMessage("Location Deleted", "The location was updated.", "Success");
                        NavigationService.GetNavigationService(this).Navigate(new ViewLocationList());
                    }
                    else
                    {
                        throw new Exception("Location was not deleted.");
                    }
                }
                catch (Exception ex)
                {
                    main.ShowMessage("Error Deleting Location", ex.Message, "Error");
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new ViewSingleLocation(location));
        }

        private void btnUpdateLocation_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                string name = textName.Text;
                string address = textAddress.Text;
                string description = textDescription.Text;

                Country country = (Country)comboCountries.SelectedItem;
                Subdivision? subdivision = (Subdivision)comboSubdivisions.SelectedItem;
                City city = (City)comboCities.SelectedItem;

                if (name == "" || name == null)
                {
                    throw new Exception("Name cannot be empty.");
                }
                else if (country == null)
                {
                    throw new Exception("Country cannot be empty.");
                }
                else if (subdivision != null && subdivision.SubdivisionCountry != country.CountryID)
                {
                    throw new Exception("Subdivision does not match country.");
                }
                else if (city == null)
                {
                    throw new Exception("City cannot be empty.");
                }
                else if (city.CityCountry != country.CountryID)
                {
                    throw new Exception("City does not match country.");
                }
                else if (subdivision != null && city.CitySubdivisionID != subdivision.SubdivisionID)
                {
                    throw new Exception("City does not match subdivision.");
                }
                else
                {
                    Location newLocation = new Location();
                    newLocation.LocationName = name;
                    newLocation.LocationAddress = address;
                    newLocation.LocationDescription = description;
                    newLocation.LocationCountry = country.CountryID;
                    newLocation.LocationSubdivisionID = subdivision == null ? 0 : subdivision.SubdivisionID;
                    newLocation.LocationCityID = city.CityID;
                    newLocation.CreatorID = main.Username;

                    if (_locationManager.UpdateLocation(location, newLocation))
                    {
                        main.ShowMessage("Location Updated", "The location was updated.", "Success");
                        NavigationService.GetNavigationService(this).Navigate(new ViewLocationList());
                    }
                    else
                    {
                        throw new Exception("Location not updated.");
                    }
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Updating Location", ex.Message, "Error");
            }

        }

    }
}
