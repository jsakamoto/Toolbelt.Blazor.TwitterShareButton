export var Toolbelt;
(function (Toolbelt) {
    var Blazor;
    (function (Blazor) {
        var TwitterShareButton;
        (function (TwitterShareButton) {
            (function () {
                const d = document;
                const s = 'script';
                const id = 'twitter-wjs';
                const fjs = d.getElementsByTagName(s)[0];
                if (!d.getElementById(id)) {
                    const js = d.createElement(s);
                    js.id = id;
                    js.src = '//platform.twitter.com/widgets.js';
                    fjs.parentNode.insertBefore(js, fjs);
                }
            })();
            function create(placeHolder, options, interval) {
                if (typeof (twttr) !== 'undefined') {
                    const needToSweep = placeHolder.innerHTML !== "";
                    createCore(placeHolder, options, needToSweep);
                }
                else {
                    if (typeof (interval) === 'undefined')
                        interval = 50;
                    setTimeout(() => create(placeHolder, options, interval * 2), interval * 2);
                }
            }
            TwitterShareButton.create = create;
            function createCore(placeHolder, options, needToSweep) {
                twttr.widgets.createShareButton(options.url, placeHolder, options)
                    .then((el) => {
                    function f(interval) {
                        if (el.clientWidth !== 0) {
                            placeHolder.style.width = el.style.width;
                            placeHolder.style.height = el.style.height;
                            if (needToSweep) {
                                const firstChildElement = placeHolder.firstElementChild;
                                if (firstChildElement != null) {
                                    firstChildElement.remove();
                                }
                            }
                        }
                        else
                            setTimeout(() => f(interval * 2), interval * 2);
                    }
                    setTimeout(() => f(100), 100);
                });
            }
        })(TwitterShareButton = Blazor.TwitterShareButton || (Blazor.TwitterShareButton = {}));
    })(Blazor = Toolbelt.Blazor || (Toolbelt.Blazor = {}));
})(Toolbelt || (Toolbelt = {}));
