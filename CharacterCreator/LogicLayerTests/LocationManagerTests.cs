using DataAccessFakes;
using DataDomain.Locations;
using LogicLayer;
using System.Runtime.Intrinsics.X86;

namespace LogicLayerTests;

[TestClass]
public class LocationManagerTests
{
    private ILocationManager? _locationManager;

    [TestInitialize]
    public void TestSetup()
    {
        _locationManager = new LocationManager(new LocationAccessorFakes());
    }


    [TestMethod]
    public void TestGetAllCountries()
    {
        // arrange
        int expectedCount = 3;
        int actualCount = 0;

        // act
        actualCount = _locationManager.GetAllCountries().Count();

        // assert
        Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void TestGetAllSubdivisions()
    {
        // arrange
        int expectedCount = 2;
        int actualCount = 0;

        // act
        actualCount = _locationManager.GetAllSubdivisions().Count();

        // assert
        Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void TestGetAllCities()
    {
        // arrange
        int expectedCount = 3;
        int actualCount = 0;

        // act
        actualCount = _locationManager.GetAllCities().Count();

        // assert
        Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void TestGetAllLocationsByUserIsSuccessful()
    {
        // arrange
        int expectedCount = 2;
        int actualCount = 0;
        string user = "user";

        // act
        actualCount = _locationManager.GetAllLocationsByCreatorID(user).Count();

        // assert
        Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void TestGetAllLocationsByUserIsUnsuccessful()
    {
        // arrange
        int expectedCount = 0;
        int actualCount = 3;
        string user = "test";

        // act
        actualCount = _locationManager.GetAllLocationsByCreatorID(user).Count();

        // assert
        Assert.AreEqual(expectedCount, actualCount);
    }

    [TestMethod]
    public void TestGetLocationByLocationIDIsSuccessful()
    {
        // arrange
        int location = 1;
        string expectedName = "Park";
        string actualName = "";

        // act
        actualName = _locationManager.GetLocationByLocationID(location).LocationName;

        // assert
        Assert.AreEqual(expectedName, actualName);
    }

    [TestMethod][ExpectedException(typeof(NullReferenceException))]
    public void TestGetLocationByLocationIDIsUnsuccessful()
    {
        // arrange
        int location = 4;
        string expectedName = "Park";
        string actualName = "";

        // act
        actualName = _locationManager.GetLocationByLocationID(location).LocationName;

        // assert not needed
    }

    [TestMethod]
    public void TestCreateLocationReturnsTrueForSuccess()
    {
        // arrange
        bool expectedResult = true;
        bool actualResult = false;
        Location location = new Location()
        {
            LocationID = 4,
            LocationName = "Test"
        };

        // act
        actualResult = _locationManager.CreateLocation(location);

        // assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestCreateLocationReturnsFalseForFailure()
    {
        // arrange
        bool expectedResult = false;
        bool actualResult = true;
        Location location = new Location()
        {
            LocationID = 1,
            LocationName = "Test"
        };

        // act
        actualResult = _locationManager.CreateLocation(location);

        // assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestUpdateLocationReturnsTrueForSuccess()
    {
        // arrange
        bool expectedResult = true;
        bool actualResult = false;
        Location oldLocation = new Location()
        {
            LocationID = 1,
            LocationName = "Park"
        };
        Location newLocation = new Location()
        {
            LocationID = 1,
            LocationName = "Test"
        };

        // act
        actualResult = _locationManager.UpdateLocation(oldLocation, newLocation);

        // assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestUpdateLocationReturnsFalseForFailure()
    {
        // arrange
        bool expectedResult = false;
        bool actualResult = true;
        Location oldLocation = new Location()
        {
            LocationID = 4,
            LocationName = "Park"
        };
        Location newLocation = new Location()
        {
            LocationID = 4,
            LocationName = "Test"
        };

        // act
        actualResult = _locationManager.UpdateLocation(oldLocation, newLocation);

        // assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestDeleteLocationReturnsTrueForSuccess()
    {
        // arrange
        bool expectedResult = true;
        bool actualResult = false;
        Location location = new Location()
        {
            LocationID = 1,
            LocationName = "Park"
        };

        // act
        actualResult = _locationManager.DeleteLocation(location);

        // assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void TestDeleteLocationReturnsFalseForFailure()
    {
        // arrange
        bool expectedResult = false;
        bool actualResult = true;
        Location location = new Location()
        {
            LocationID = 4,
            LocationName = "Park"
        };

        // act
        actualResult = _locationManager.DeleteLocation(location);

        // assert
        Assert.AreEqual(expectedResult, actualResult);
    }
}
