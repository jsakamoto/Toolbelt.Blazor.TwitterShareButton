namespace Toolbelt.Blazor.TwitterShareButton {
    const searchParam = document.currentScript?.getAttribute('src')?.split('?')[1] || '';
    export var ready = import('./script.module.js?' + searchParam).then(m => {
        Object.assign(TwitterShareButton, m.Toolbelt.Blazor.TwitterShareButton);
    });
}
