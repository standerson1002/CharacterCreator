using DataDomain.Locations;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    /// Interaction logic for CreateLocation.xaml
    /// </summary>
    public partial class CreateLocation : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        LocationManager _locationManager = new LocationManager();

        List<Country> countries = new List<Country>();
        List<Subdivision> subdivisions = new List<Subdivision>();
        List<City> cities = new List<City>();
        public CreateLocation()
        {
            InitializeComponent();
            populateInformation();
        }

        private void populateInformation()
        {
            try
            {
                countries = _locationManager.GetAllCountries();
                subdivisions = _locationManager.GetAllSubdivisions();
                cities = _locationManager.GetAllCities();

                comboCountries.ItemsSource = countries;
                comboSubdivisions.ItemsSource = subdivisions;
                comboCities.ItemsSource = cities;

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
                foreach(Subdivision subdivision in subdivisions)
                {
                    if(subdivision.SubdivisionCountry == country.CountryID)
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

                if(subdivision != null)
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

        private void btnCreateLocation_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                string name = textName.Text;
                string address = textAddress.Text;
                string description = textDescription.Text;

                Country country = (Country)comboCountries.SelectedItem;
                Subdivision? subdivision = (Subdivision)comboSubdivisions.SelectedItem;
                City city = (City)comboCities.SelectedItem;

                if(name == "" || name == null)
                {
                    throw new Exception("Name cannot be empty.");
                }
                else if(country == null)
                {
                    throw new Exception("Country cannot be empty.");
                }
                else if(subdivision != null && subdivision.SubdivisionCountry != country.CountryID)
                {
                    throw new Exception("Subdivision does not match country.");
                }
                else if(city == null)
                {
                    throw new Exception("City cannot be empty.");
                }
                else if(city.CityCountry != country.CountryID)
                {
                    throw new Exception("City does not match country.");
                }
                else if(subdivision != null && city.CitySubdivisionID  != subdivision.SubdivisionID)
                {
                    throw new Exception("City does not match subdivision.");
                }
                else
                {
                    Location location = new Location();
                    location.LocationName = name;
                    location.LocationAddress = address;
                    location.LocationDescription = description;
                    location.LocationCountry = country.CountryID;
                    location.LocationSubdivisionID = subdivision == null ? 0 : subdivision.SubdivisionID;
                    location.LocationCityID = city.CityID;
                    location.CreatorID = main.Username;

                    if(_locationManager.CreateLocation(location))
                    {
                        main.ShowMessage("Location Added", "The location was added.", "Success");
                        NavigationService.GetNavigationService(this).Navigate(new ViewLocationList());
                    }
                    else
                    {
                        throw new Exception("Location not added.");
                    }
                }
            }
            catch (Exception ex)
            {
                main.ShowMessage("Error Adding Location", ex.Message, "Error");
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new ViewLocationList());
        }
    }
}
