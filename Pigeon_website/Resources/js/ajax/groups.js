﻿/**
 * 
 * Groups-page specific js
 * 
 */


$(document).ready(function () {

    var $searchValue = $("#searchBarValue");


    // Optimize this in future
    // link if input empty or if we didn't find any results and search value keeps getting longer

    // Use JSON.NET in backend before using this, otherwise we get a "circular reference exception"
    // http://stackoverflow.com/questions/16949520/circular-reference-detected-exception-while-serializing-object-to-json

    // When user modifies value in search box
    $searchValue.on('change input', function () {

        console.log("i just want to log" + $(this).val());

        var params = JSON.stringify({ searchValue: $(this).val() });

        $.ajax({

            type: "POST",
            url: "Groups.aspx/GetMatchingUsers",
            data: params,
            contentType: "application/json; charset=UTF-8",
            dataType: "json",
            success: OnSuccess,
            error: function (response) {
                alert(response.e);
            }
        });

        function OnSuccess(response) {
            console.log("success i guess" + response.d);
        }
    });

});