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
    /// Interaction logic for ViewSingleLocation.xaml
    /// </summary>
    public partial class ViewSingleLocation : Page
    {
        CharacterCreator main = CharacterCreator.GetMainWindow();
        LocationManager _locationManager = new LocationManager();

        Location location;

        public ViewSingleLocation(Location location)
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

                if(location == null)
                {
                    throw new Exception("Invalid location.");
                }

                lblLocationName.Content = location.LocationName;
                
                string address = location.LocationAddress + "\n" + 
                    location.LocationCity + ", ";
                if(location.LocationSubdivision != null)
                {
                    address += location.LocationSubdivision + ", ";
                }
                address += location.LocationCountry;

                lblAddress.Content = address;
                txtDescription.Text = location.LocationDescription;

            }
            catch (Exception ex)
            {
                main.ShowMessage("Error", ex.Message, "Error");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new EditLocation(location));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GetNavigationService(this).Navigate(new ViewLocationList());
        }
    }
}
