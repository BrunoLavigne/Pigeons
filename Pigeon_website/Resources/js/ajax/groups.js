/**
 * 
 * Groups-page specific js
 * 
 */

function pageLoad() {

    var $groupItem = $(".Group-item");

    setElementsToEqualHeight($(".Group-item"));

    // TODO: add on debounce method
    $(window).resize(function () {
        setElementsToEqualHeight($groupItem);
        console.log("Setting elems to equal height");
    });

    function setElementsToEqualHeight($element) {

        var heights = $element.map(function () {
            return $(this).height();
        }).get(),

        maxHeight = Math.max.apply(null, heights);

        $element.height(maxHeight);
    }


    // Toggle the new group creation form on the groups page
    $("#toggleNewGroupForm").click(function (event) {

        event.preventDefault();

        $(".New-group-form").slideToggle();
    });







    var $searchValue = $(".searchBarValue");


    // Optimize this in future
    // link if input empty or if we didn't find any results and search value keeps getting longer

    // Use JSON.NET in backend before using this, otherwise we get a "circular reference exception"
    // http://stackoverflow.com/questions/16949520/circular-reference-detected-exception-while-serializing-object-to-json

    // When user modifies value in search box
    $searchValue.on('change input', function () {

        // Start searching after 5 chars in search box
        if ($(this).val().length > 5) {
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
        }


        function OnSuccess(response) {

            var filteredUsers = response;

            $.each(filteredUsers, function (k, v) {
                $.each($.parseJSON(v), function (k, v) {
                    console.log(v.Id);
                });
            });


            // var elements = [];

            // Append new results
             //if (filteredUsers.length > 0) {

                //for (i = 0; i < filteredUsers.d.length; i++) {

                //    var $personElement = $("<li></li>");
                //    $personElement.addClass("user-container");

                //    var $profilePicture = $("<div></div>");
                //    $profilePicture.addClass('profile-picture-container');
                //    $profilePicture.css({
                //        "background-image": 'url("' + filteredUsers.d[i].Profile_picture_link + '")',
                //    });

                //    var $textContainer = $("<div></div>");
                //    $textContainer.addClass('text-container');

                //    var $addUserContainer = $("<i class='material-icons add-user-btn'>person_add</i>");
                //    $addUserContainer.data('user-id', filteredUsers.d[i].id);

                //    var $nameLabel = $("<div></div>");
                //    var $emailLabel = $("<div></div>");
                //    var $organizationLabel = $("<div></div>");

                //    $nameLabel.addClass('name-label');
                //    $emailLabel.addClass('email-label');
                //    $organizationLabel.addClass('organization-label');

                //    $nameLabel.text(filteredUsers.d[i].name);
                //    $emailLabel.text(filteredUsers.d[i].email);
                //    $organizationLabel.text(filteredUsers.d[i].organization);

                //    $textContainer.append($nameLabel);
                //    $textContainer.append($organizationLabel);
                //    $textContainer.append($emailLabel);

                //    $personElement.append($profilePicture);
                //    $personElement.append($addUserContainer);
                //    $personElement.append($textContainer);
                //    $personElement.append($addUserContainer);

                //    elements.push($personElement);

                //}

                //$usersContainer.append(elements);

            //} else {

             //   $usersContainer.text("No results found");

             //}


            //$("body").prepend($usersContainer);
            //$(".user-container").each(function (index, el) {
            //    $(this).fadeIn();
            //}, 1000);
            //$(".add-user-btn").click(function () {
            //    console.log("Add user of id: " + $(this).data("user-id"));
            //});


        } // end onsuccess function
    }); // end searchvalue/on input and change function
}
