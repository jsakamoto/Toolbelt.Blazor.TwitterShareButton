var Toolbelt;
(function (Toolbelt) {
    var Blazor;
    (function (Blazor) {
        var TwitterShareButton;
        (function (TwitterShareButton) {
            (function () {
                var d = document;
                var s = 'script';
                var id = 'twitter-wjs';
                var fjs = d.getElementsByTagName(s)[0];
                if (!d.getElementById(id)) {
                    var js = d.createElement(s);
                    js.id = id;
                    js.src = '//platform.twitter.com/widgets.js';
                    fjs.parentNode.insertBefore(js, fjs);
                }
            })();
            function create(placeHolder, options, interval) {
                if (typeof (twttr) !== 'undefined') {
                    var needToSweep = placeHolder.innerHTML !== "";
                    createCore(placeHolder, options, needToSweep);
                }
                else {
                    if (typeof (interval) === 'undefined')
                        interval = 50;
                    setTimeout(function () { return create(placeHolder, options, interval * 2); }, interval * 2);
                }
            }
            TwitterShareButton.create = create;
            function createCore(placeHolder, options, needToSweep) {
                twttr.widgets.createShareButton(options.url, placeHolder, options)
                    .then(function (el) {
                    function f(interval) {
                        if (el.clientWidth !== 0) {
                            placeHolder.style.width = el.style.width;
                            placeHolder.style.height = el.style.height;
                            if (needToSweep) {
                                var firstChildElement = placeHolder.firstElementChild;
                                if (firstChildElement != null) {
                                    firstChildElement.remove();
                                }
                            }
                        }
                        else
                            setTimeout(function () { return f(interval * 2); }, interval * 2);
                    }
                    setTimeout(function () { return f(100); }, 100);
                });
            }
        })(TwitterShareButton = Blazor.TwitterShareButton || (Blazor.TwitterShareButton = {}));
    })(Blazor = Toolbelt.Blazor || (Toolbelt.Blazor = {}));
})(Toolbelt || (Toolbelt = {}));
//# sourceMappingURL=script.js.map