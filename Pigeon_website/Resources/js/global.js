window.onload = function () {
    var t1 = new TimelineLite();
    var pigeonSwell = TweenMax.to('.Home-logo-container', 5, {
        scale: 0.85,
        repeat: -1,
        yoyo: true,
        ease: Power1.easeInOut,
        onComplete: function () {
            console.log('done');
        }
    });

    //var theRedEye = TweenMax.to('#eye', 2, {
    //    color: 'red',
    //    ease: Power1.easeInOut,
    //    repeat: -1,
    //    yoyo: true,
    //}, 0.25);

    var flopWings = TweenMax.to("#wing", 2, {
        skewX: 20,
        skewY: 100,
        ease: Power3.easeInOut,
        yoyo: true,
        repeat: -1
    }, 0.75);

    var bubbleFade = TweenMax.staggerTo('.bubble', 1.25, {
        opacity: 1,
        x: "+= 50px",
        y: "+= 20px",
        ease: Power3.easeInOut
    }, 0.75);
    

    t1.add(pigeonSwell, 1);
    t1.add(flopWings, 2);
    t1.add(bubbleFade, 6);

};

 $('#myModal').modal();
