// Start js plugins on every page load
function pageLoad() {

    // Init the datepicker
    $(".datepicker-holder").datepicker({
        dateFormat: "dd/mm/yy"
    });


    // Init the text editor
    $(".summernote").summernote();


    $('.eventCalendar td').mouseenter(function () {

        if ($(this).data("id") != undefined) {
            var idString = $(this).data('id');

            var formatedString = idString.substring(0, idString.length - 1);
            var id = formatedString.split(',');

            jQuery.each(id, function (i) {

                $(".eventRow").filter(function () {
                    return $(this).data('id') == id[i];
                }).css('background-color', '#FFFFFF');
            });

        } else {
            return false;
        }

    });

    $(".eventCalendar td").mouseleave(function () {
        $(".eventRow").each(function () {
            $(this).css({ "background": "none" });
        });

    });

    var calendarEventDays;
    var style;

    $('.eventRow').hover(function () {
        var eventID = $(this).data('id');

        calendarEventDays = $('.eventCalendar').find("[data-id*='" + eventID + "']");
        style = calendarEventDays.attr('style');
        calendarEventDays.css('background-color', '#737373');

    }, function () {
        calendarEventDays.css('background-color', '');
        calendarEventDays.attr('style', style);
    });


    /*
     Smooth scroll on sidebar links
     */
    var $sideBarLinks = $(".Sidebar a");
    var $htmlBody = $("html, body");

    $sideBarLinks.click(function () {
        $htmlBody   .animate({
            scrollTop: $($.attr(this, 'href')).offset().top
        }, 500);
        return false;
    });

}
