/**
 *
 * Website-wide js for UI/anims
 *
 */

// Pigeon animation on homepage
window.onload = function () {

    var t1 = new TimelineLite();

    var pigeonSwell = TweenMax.to('.Home-logo-container', 5, {
        scale: 0.85,
        //skewY: 4,
        //skewX: 4,
        repeat: -1,
        yoyo: true,
        ease: Power1.easeInOut,
        onComplete: function () {
            console.log('done');
        }
    });


    t1.add(pigeonSwell, 1);
};



// init modal
$('#myModal').modal();


// bind escape key to close modal
var ESCAPE_KEY = 27;

$(document).keyup(function (e) {

    if (e.keyCode === ESCAPE_KEY) {
        $(".modal").modal('hide');
    }

});
