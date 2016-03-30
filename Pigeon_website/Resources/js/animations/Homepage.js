/**
 *
 * Website-wide js for UI/anims
 *
 */

// Pigeon animation on homepage
window.onload = function () {

    var t1 = new TimelineLite();

    // Make pigeon bigger and smaller
    var pigeonSwell = TweenMax.to('.Home-logo-container', 5, {
        scale: 0.85,
        repeat: -1,
        yoyo: true,
        ease: Power1.easeInOut,
        onComplete: function () {
            console.log("... anim: done with PIGEON-SWELL");
        }
    });

    // Rotate the pigeon on Y axis
    var pigeonRotate = TweenMax.to('.Home-logo-container', 1.5, {
        skewY: 180,
        repeat: -1,
        repeatDelay: 10,
        yoyo: true,
        ease: Back.easeInOut.config(1.4),
        onComplete: function () {
            console.log("... anim: done with PIGEON-ROTATE");
        }
    });

    // Add anims to timeline
    t1.add(pigeonSwell, 1);
    t1.add(pigeonRotate, 5);

};

