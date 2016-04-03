TweenMax.set($(".Group-message"), { scale: 0, opacity: 0, display: 'none', x: -100, y: -200, skewX: 180 });

var revealMessageCards = TweenMax.staggerTo(".Group-message", 0.6, { display: 'block', opacity: 1, scale: 1, y: 0, x: 0, skewX: 0, ease: 'Elastic.easeInOut' }, 0.2);
var t1 = new TimelineMax({ paused: true });

t1.add(revealMessageCards);

var messageCardsRevealed = false;
var messagesToggler = document.getElementById("Group-messages-toggler");

messagesToggler.onclick = function (e) {
    e.preventDefault();
    console.log("Click on messages toggler");

    // (t1.reversed() || t1.paused()) ? t1.play() : t1.reverse(); not really working

    if (messageCardsRevealed) {
        t1.reverse();
        messageCardsRevealed = false;
    } else {
        t1.play();
        messageCardsRevealed = true;
    }

};
