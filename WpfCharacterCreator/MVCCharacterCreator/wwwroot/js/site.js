// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
'use strict';

$().ready(function () {

    $("#tabbed").tabs();

    $("#polka").accordion({
        collapsable: true,
        icons: {
            header: 'ui-icon-circle-plus',
            activeHeader: 'ui-icon-circle-minus'
        }
    });


}); // end ready
