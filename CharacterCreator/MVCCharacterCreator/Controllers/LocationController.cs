using LogicLayer;
using DataDomain;
using DataDomain.Locations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace MVCCharacterCreator.Controllers
{
    public class LocationController : Controller
    {

        LocationManager _locationManager = new LocationManager();

        // GET: LocationController

        [Authorize]
        public ActionResult Index()
        {
            string user = User.Identity.Name;
            List<Location> locations = _locationManager.GetAllLocationsByCreatorID(user);
            return View(locations);
        }

        // GET: LocationController/Details/5

        [Authorize]
        public ActionResult Details(int id)
        {
            Location location = _locationManager.GetLocationByLocationID(id);

            if (location.CreatorID != User.Identity.Name)
            {
                TempData["MessageDanger"] = "Error viewing profile!";
                return RedirectToAction("Index", "Location");

            }

            return View(location);
        }

        // GET: LocationController/Create

        [Authorize]
        public ActionResult Create()
        {
            populateLocations();

            return View();
        }

        // POST: LocationController/Create

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Location location)
        {
            try
            {
                populateLocations();

                string user = User.Identity.Name;
                location.CreatorID = user;

                if (ModelState.IsValid || true)
                {

                    bool result = _locationManager.CreateLocation(location);
                    if(result)
                    {
                        TempData["MessageSuccess"] = "The location was added.";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["MessageDanger"] = "The location was not added.";
                        return RedirectToAction(nameof(Index));
                    }

                }
                else
                {
                    TempData["MessageWarning"] = "Invalid location.";
                    return View(location);
                }
            }
            catch(Exception e)
            {
                TempData["MessageDanger"] = "There was an unexpected error adding the location.\n" + e.Message;
                return View();
            }
        }

        // GET: LocationController/Edit/5

        [Authorize]
        public ActionResult Edit(int id)
        {
            Location location = _locationManager.GetLocationByLocationID(id);
            if (location.CreatorID != User.Identity.Name)
            {
                TempData["MessageDanger"] = "Error viewing profile!";
                return RedirectToAction("Index", "Location");

            }

            populateLocations();
            return View(location);
        }

        // POST: LocationController/Edit/5

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Location newLocation)
        {

            try
            {

                if(ModelState.IsValid)
                {

                    Location oldLocation = _locationManager.GetLocationByLocationID(id);
                    if (oldLocation.CreatorID != User.Identity.Name)
                    {
                        TempData["MessageDanger"] = "Error viewing profile!";
                        return RedirectToAction("Index", "Location");

                    }

                    bool result = _locationManager.UpdateLocation(oldLocation, newLocation);
                    if (result)
                    {
                        TempData["MessageSuccess"] = "Location updated!";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        TempData["MessageWarning"] = "Error updating location.";
                    }
                }
                else
                {
                    TempData["MessageWarning"] = "Invalid location.";
                }

                populateLocations();
                return View(newLocation);

            }
            catch (Exception e)
            {
                TempData["MessageDanger"] = "There was an unexpected error updating the location.\n" + e.Message;

                populateLocations();
                return View();
            }
        }

        // GET: LocationController/Delete/5

        [Authorize]
        public ActionResult Delete(int id)
        {
            Location location = _locationManager.GetLocationByLocationID(id);
            if (location.CreatorID != User.Identity.Name)
            {
                TempData["MessageDanger"] = "Error viewing profile!";
                return RedirectToAction("Index", "Location");

            }
            return View(location);
        }

        // POST: LocationController/Delete/5

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Location collection)
        {
            try
            {
                collection = _locationManager.GetLocationByLocationID(id);
                if (collection.CreatorID != User.Identity.Name)
                {
                    TempData["MessageDanger"] = "Error viewing profile!";
                    return RedirectToAction("Index", "Location");

                }

                if (true)
                {
                    bool result = _locationManager.DeleteLocation(collection);
                    if (result)
                    {
                        TempData["MessageSuccess"] = "Location was deleted!";
                    }
                    else
                    {
                        TempData["MessageWarning"] = "Location was not deleted!";
                    }
                }
                else
                {
                    TempData["MessageWarning"] = "Invalid location!";

                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                TempData["MessageDanger"] = "There was an unexpected error deleting the location.\n" + e.Message;
                return View();
            }
        }



        private void populateLocations()
        {
            List<Country> countries = _locationManager.GetAllCountries();
            List<Subdivision> subdivisions = _locationManager.GetAllSubdivisions();
            List<City> cities = _locationManager.GetAllCities();

            ViewBag.Countries = countries;
            ViewBag.Subdivisions = subdivisions;
            ViewBag.Cities = cities;
        }
    }

}
