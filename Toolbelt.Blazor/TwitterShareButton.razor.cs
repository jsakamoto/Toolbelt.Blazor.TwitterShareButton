using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace Toolbelt.Blazor.TwitterShareButton
{
    public partial class TwitterShareButton
    {
        [Inject] private IJSRuntime JSRuntime { get; set; }

        [Inject] private IServiceProvider Services { get; set; }

        private ElementReference PlaceHolder;

        /// <summary>
        /// An element id of the place holder DOM element.
        /// </summary>
        [Parameter] public string Id { get; set; } = null;

        /// <summary>
        /// A space-separated list of CSS class names of the place holder DOM element.
        /// </summary>
        [Parameter] public string CssClass { get; set; } = null;

        // Tweet content parameters

        /// <summary>
        /// Pre-populated text highlighted in the Tweet composer.
        /// </summary>
        [Parameter] public string Text { get; set; } = "";

        /// <summary>
        /// URL included with the Tweet.
        /// </summary>
        [Parameter] public string Url { get; set; } = "";

        /// <summary>
        /// A comma-separated list of hashtags to be appended to default Tweet text.
        /// </summary>
        [Parameter] public string HashTags { get; set; } = "";

        /// <summary>
        /// Attribute the source of a Tweet to a Twitter username.
        /// </summary>
        [Parameter] public string Via { get; set; } = "";

        /// <summary>
        /// A comma-separated list of accounts related to the content of the shared URI.
        /// </summary>
        [Parameter] public string Related { get; set; } = "";

        // Button display parameters

        /// <summary>
        /// When set to large, display a larger version of the button. Set to l for iframe.
        /// </summary>
        [Parameter] public string Size { get; set; } = "";

        /// <summary>
        /// A supported Twitter language code. (https://developer.twitter.com/en/docs/twitter-for-websites/twitter-for-websites-supported-languages)
        /// </summary>
        [Parameter] public string Lang { get; set; } = "";

        /// <summary>
        /// When set to true, the button and its embedded page on your site are not used for purposes that include personalized suggestions and personalized ads.
        /// </summary>
        [Parameter] public bool DNT { get; set; } = false;

        /// <summary>
        /// get the flag of disable client script auto injection, or not.
        /// </summary>
        [Parameter] public bool DisableClientScriptAutoInjection { get; set; }

        private ITwitterShareButtonGlobalOptions _GlobalOptions;

        protected override void OnInitialized()
        {
            this._GlobalOptions = this.Services.GetService<ITwitterShareButtonGlobalOptions>() ?? new TwitterShareButtonGlobalOptions();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            var options = new
            {
                // Tweet content parameters
                this.Text,
                this.Url,
                Hashtags = this.HashTags,
                this.Via,
                this.Related,
                // Button display parameters
                Size = this.Size.ToLower(),
                this.Lang,
                this.DNT
            };

            if (!this.DisableClientScriptAutoInjection && !this._GlobalOptions.DisableClientScriptAutoInjection)
            {
                await this.JSRuntime.InvokeVoidAsync("eval", $"new Promise(r=>((d,t,s)=>(h=>h.querySelector(t+`[src=\"${{s}}\"]`)?r():(e=>(e.src=s,e.onload=r,h.appendChild(e)))(d.createElement(t)))(d.head))(document,'script','_content/Toolbelt.Blazor.TwitterShareButton/script.js'))");
            }
            await this.JSRuntime.InvokeVoidAsync("Toolbelt.Blazor.TwitterShareButton.create", this.PlaceHolder, options);
        }
    }
}
