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
    /// Interaction logic for ViewLocationList.xaml
    /// </summary>
    public partial class ViewLocationList : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        LocationManager _locationManager = new LocationManager();
        List<Location> locations = new List<Location>();
        public ViewLocationList()
        {
            InitializeComponent();
            populateInformation();
        }

        private void populateInformation()
        {
            try
            {
                locations = _locationManager.GetAllLocationsByCreatorID(main.Username);

                lblLocations.Content = "Locations (" + locations.Count + ")";
                gridLocations.ItemsSource = locations;

            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }
        }
        private void btnCreateLocation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new CreateLocation());
        }

        private void btnEditLocation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Location location = (Location)gridLocations.SelectedItem;

                if (location == null)
                {
                    throw new Exception("Please select a location.");
                }

                NavigationService.GetNavigationService(this).Navigate(new EditLocation(location));
            }
            catch (Exception ex)
            {
                main.ShowMessage("Invalid Location", ex.Message, "Error");
            }
        }

        private void btnViewLocation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Location location = (Location)gridLocations.SelectedItem;

                if(location == null)
                {
                    throw new Exception("Please select a location.");
                }

                NavigationService.GetNavigationService(this).Navigate(new ViewSingleLocation(location));
            }
            catch (Exception ex)
            {
                main.ShowMessage("Invalid Location", ex.Message, "Error");
            }
        }
    }
}
