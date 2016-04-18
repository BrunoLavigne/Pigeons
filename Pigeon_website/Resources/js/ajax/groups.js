/**
 * 
 * Groups-page specific js
 * 
 */

function pageLoad() {


    ///////////////// MODIFIER /////////////////
    // faudrait que ce soit pluggé sur le bouton create new group
    $.ajax({
        type: "POST",
        url: "Groups.aspx/createNewGroup",
        contentType: "application/json; charset=utf-8",
        async: false,
        // data: une arraylist d'users qu'on envoie à la méthode createNewGroup
        success: function (data) {
            alert("successfully posted data");
        },
        error: function (data) {
            alert("failed posted data");
            alert(postData);
        }

    });
    /////////////////////////////////////////////



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

    // When user modifies value in search box
    $searchValue.on('change input', function () {

        // Clear previous results
        $("body").find(".users-container").remove();

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


            var $usersContainer = $("<ul class='users-container'></ul>");
            var elements = [];

            $.each(filteredUsers, function (k, v) {
                $.each($.parseJSON(v), function (k, user) {

                    console.log(user.Id, user.Name);

                    var $personElement = $("<li></li>");
                    $personElement.addClass("user-container");

                    var $profilePicture = $("<div></div>");
                    $profilePicture.addClass('profile-picture-container');
                    $profilePicture.css({
                        "background-image": 'url("' + user.Profile_picture_link + '")',
                    });

                    var $textContainer = $("<div></div>");
                    $textContainer.addClass('text-container');

                    var $addUserContainer = $("<i class='material-icons add-user-btn'>person_add</i>");
                    $addUserContainer.data('user-id', user.Id);
                    $addUserContainer.data('user-name', user.Name);

                    var $nameLabel = $("<div></div>");
                    var $emailLabel = $("<div></div>");
                    var $organizationLabel = $("<div></div>");

                    $nameLabel.addClass('name-label');
                    $emailLabel.addClass('email-label');
                    $organizationLabel.addClass('organization-label');

                    $nameLabel.text(user.Name);
                    $emailLabel.text(user.Email);
                    $organizationLabel.text(user.Organization);

                    $textContainer.append($nameLabel);
                    $textContainer.append($organizationLabel);
                    $textContainer.append($emailLabel);

                    $personElement.append($profilePicture);
                    $personElement.append($addUserContainer);
                    $personElement.append($textContainer);
                    $personElement.append($addUserContainer);

                    elements.push($personElement);

                }); // end each on person values
            }); // end each on matching users

            $usersContainer.append(elements);


            $("body").prepend($usersContainer);
            $(".user-container").each(function (index, el) {
                $(this).fadeIn();
            }, 1000);




            // When click on button to add user
            $(".add-user-btn").click(function () {
                console.log("Add user of id: " + $(this).data("user-id"));
                $(".new-group-followers-container").append("<div>" + $(this).data("user-name") + "</div>");
            });

        } // end onsuccess function
    }); // end searchvalue/on input and change function

}
