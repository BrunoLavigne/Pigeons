// bind escape key to close modal
var ESCAPE_KEY = 27;

$(document).keyup(function (e) {

    if (e.keyCode === ESCAPE_KEY) {
        $(".modal").modal('hide');
    }

});



var $equalHeightElements = $(".equal");

setElementsToEqualHeight($equalHeightElements);

// TODO: add on debounce method
$(window).resize(function () {
    setElementsToEqualHeight($equalHeightElements);
});

function setElementsToEqualHeight($element) {

    var heights = $element.map(function () {
        return $(this).height();
    }).get(),

    maxHeight = Math.max.apply(null, heights);

    $element.height(maxHeight);
}
