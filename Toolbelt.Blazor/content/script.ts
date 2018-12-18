declare var twttr: any;

//var twttr = {
//    widgets: {
//        createShareButton: function (shareUrl: string, targetElement: HTMLElement, ...args: any[]) {
//            console.log('CALLED CREATESHAREBUTTON', shareUrl, targetElement);
//            targetElement.innerText = `[shareUrl: "${shareUrl}"]`;
//        }
//    }
//};

namespace Toolbelt.Blazor.TwitterShareButton {

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

    export function create(placeHolder: HTMLElement, options: any, interval?: number): void {
        if (typeof (twttr) !== 'undefined') {
            const needToSweep = placeHolder.innerHTML !== "";
            createCore(placeHolder, options, needToSweep);
        }
        else {
            if (typeof (interval) === 'undefined') interval = 50;
            setTimeout(() => create(placeHolder, options, interval * 2), interval * 2);
        }
    }

    function createCore(placeHolder: HTMLElement, options: any, needToSweep: boolean): void {
        twttr.widgets.createShareButton(options.url, placeHolder, options)
            .then((el: HTMLIFrameElement) => {
                function f(interval: number) {
                    if (el.clientWidth !== 0) {
                        placeHolder.style.width = el.style.width;
                        placeHolder.style.height = el.style.height;

                        if (needToSweep) {
                            const firstChildElement = placeHolder.firstElementChild as HTMLElement;
                            if (firstChildElement != null) {
                                firstChildElement.remove();
                            }
                        }
                    }
                    else setTimeout(() => f(interval * 2), interval * 2);
                }
                setTimeout(() => f(100), 100);
            });
    }
}