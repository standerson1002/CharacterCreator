// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
'use strict';

window.addEventListener("load", initialize);

function initialize() {
    console.log(`in initialize()`);
    updateLikeDislikeLabels()
    document.getElementById("likeDislikeType").addEventListener("change", updateLikeDislikeLabels, false);

} // end initialize

function updateLikeDislikeLabels() {
    // console.log("Like or Dislike changed");
    let likeOrDislike = document.getElementById("likeDislikeType");
    if (likeOrDislike.value == "like") {
        $('#like-dislike-heading').text("Add Like");
        $('#like-dislike-label').text("Like:");
        $('#like-dislike-button').attr("value", "Add Like");
    }
    else if (likeOrDislike.value == "dislike") {
        $('#like-dislike-heading').text("Add Dislike");
        $('#like-dislike-label').text("Dislike:");
        $('#like-dislike-button').attr("value", "Add Dislike");
    }
}
function resetLikeDislikeLabels() {
    // console.log("Reset Like or Dislike");
    $('#like-dislike-heading').text("Add Like or Dislike");
    $('#like-dislike-label').text("Like or Dislike:");
    $('#like-dislike-button').attr("value", "Add Like or Dislike");
}
