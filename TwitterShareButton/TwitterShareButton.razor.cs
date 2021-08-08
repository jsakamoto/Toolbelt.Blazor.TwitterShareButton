using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;

namespace Toolbelt.Blazor.TwitterShareButton
{
    public partial class TwitterShareButton
#if ENABLE_JSMODULE
        : IAsyncDisposable
#endif
    {
        private delegate ValueTask ScriptVoidAsyncInvoker(string identifier, params object[] args);

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

        private bool _ScriptLoaded = false;

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

            var scriptVoidAsyncInvoker = await EnsureScriptAsync();
            await scriptVoidAsyncInvoker.Invoke("Toolbelt.Blazor.TwitterShareButton.create", this.PlaceHolder, options);
        }

        private string GetVersionText()
        {
            var assembly = this.GetType().Assembly;
            var version = assembly
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                .InformationalVersion ?? assembly.GetName().Version.ToString();
            return version;
        }

#if ENABLE_JSMODULE
        
        private IJSObjectReference _JSModule = null;

        private ScriptVoidAsyncInvoker _ScriptVoidAsyncInvoker;

        private async ValueTask<ScriptVoidAsyncInvoker> EnsureScriptAsync()
        {
            if (!this.DisableClientScriptAutoInjection && !this._GlobalOptions.DisableClientScriptAutoInjection)
            {
                if (!this._ScriptLoaded)
                {
                    var version = GetVersionText();
                    var scriptPath = $"./_content/Toolbelt.Blazor.TwitterShareButton/script.module.min.js?v={version}";
                    this._JSModule = await this.JSRuntime.InvokeAsync<IJSObjectReference>("import", scriptPath);
                    _ScriptVoidAsyncInvoker = _JSModule.InvokeVoidAsync;
                    this._ScriptLoaded = true;
                }
            }
            else
            {
                if (!this._ScriptLoaded)
                {
                    try { await this.JSRuntime.InvokeVoidAsync("eval", "Toolbelt.Blazor.TwitterShareButton.ready"); } catch { }
                    _ScriptVoidAsyncInvoker = JSRuntime.InvokeVoidAsync;
                    this._ScriptLoaded = true;
                }
            }
            return _ScriptVoidAsyncInvoker;
        }

        public async ValueTask DisposeAsync()
        {
            if (this._JSModule != null) await this._JSModule.DisposeAsync();
        }
#else
        private async ValueTask<ScriptVoidAsyncInvoker> EnsureScriptAsync()
        {
            if (!this.DisableClientScriptAutoInjection && !this._GlobalOptions.DisableClientScriptAutoInjection)
            {
                if (!this._ScriptLoaded)
                {
                    var version = GetVersionText();
                    await this.JSRuntime.InvokeVoidAsync("eval", "new Promise(r=>((d,t,s,v)=>(h=>h.querySelector(t+`[src^=\"${s}\"]`)?r():(e=>(e.src=(s+v),e.onload=r,h.appendChild(e)))(d.createElement(t)))(d.head))(document,'script','_content/Toolbelt.Blazor.TwitterShareButton/script.js','?v=" + version + "'))");
                    try { await this.JSRuntime.InvokeVoidAsync("eval", "Toolbelt.Blazor.TwitterShareButton.ready"); } catch { }
                    _ScriptLoaded = true;
                }
            }
            return JSRuntime.InvokeVoidAsync;
        }
#endif
    }
}
