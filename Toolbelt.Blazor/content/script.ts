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

    export function create(targetElement: HTMLElement, options: any): void {
        targetElement.innerHTML = "";
        if (typeof (twttr) !== 'undefined') {
            createCore(targetElement, options);
        }
        else {
            setTimeout(() => create(targetElement, options), 1000);
        }
    }

    function createCore(targetElement: HTMLElement, options: any): void {
        twttr.widgets.createShareButton(options.url, targetElement, options);
    }
}