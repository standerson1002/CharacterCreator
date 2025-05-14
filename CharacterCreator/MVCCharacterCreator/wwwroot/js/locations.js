"use strict";

// GLOBAL VARIABLES
let country;
let subdivision;
let city;

window.addEventListener("load", initialize);

/**
 * Initial global variables and other tasks needed for the application
 */
function initialize() {
    console.log(`in initialize()`);

    country = document.getElementById("LocationCountry");
    subdivision = document.getElementById("LocationSubdivisionID");
    city = document.getElementById("LocationCityID")

    document.getElementById("LocationCountry").addEventListener("change", changedCountry, false);
    document.getElementById("LocationSubdivisionID").addEventListener("change", changedSubdivision, false);

    //alert('before');
    editForm();

}

function hideChildren() {
    $('#LocationSubdivisionID').children().hide();
    $('#LocationCityID').children().hide();
}

function changedCountry() {
    console.log("Country was changed.");

    country = document.getElementById("LocationCountry");
    if (country.value !== "Unspecified") {
        hideChildren();

        subdivision.selectedIndex = 0;
        city.selectedIndex = 0;
        $("." + (country.value).replaceAll(" ", "-")).show();

    } else {
        console.log("It's unspecified.");
        subdivision.selectedIndex = 0;
        $('#LocationSubdivisionID').children().hide();
        $('#LocationCityID').children().show();
    }
}

function changedSubdivision() {
    console.log("Subdivision was changed.");

    subdivision = document.getElementById("LocationSubdivisionID");
    $('#LocationCityID').children().hide();

    if (subdivision.value !== 0) {

        city.selectedIndex = 0;
        $("." + subdivision.value).show();

    } else {
        console.log("It's unspecified.");

        let x = city.selectedIndex;
        changedCountry();
        city.selectedIndex = x;
    }
}

function editForm() {

    if (country.value !== "Unspecified") {
        console.log("Edit location.");

        let countryIndex = country.selectedIndex;
        let subdivisionIndex = subdivision.selectedIndex;
        let cityIndex = city.selectedIndex;

        changedCountry();

        subdivision.selectedIndex = subdivisionIndex;

        if (subdivision.value != 0) {
            changedSubdivision();
        }

        country.selectedIndex = countryIndex;
        subdivision.selectedIndex = subdivisionIndex;
        city.selectedIndex = cityIndex;
    }
    
}

