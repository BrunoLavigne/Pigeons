// bind escape key to close modal
var ESCAPE_KEY = 27;

$(document).keyup(function (e) {

    if (e.keyCode === ESCAPE_KEY) {
        $(".modal").modal('hide');
    }

});
