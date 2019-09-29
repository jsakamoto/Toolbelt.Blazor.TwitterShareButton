namespace Toolbelt.Blazor.TwitterShareButton
{
    /// <summary>
    /// Implementation of global options for "Twitter Share Button".
    /// </summary>
    public class TwitterShareButtonGlobalOptions : ITwitterShareButtonGlobalOptions
    {
        /// <summary>
        /// Gets or sets a value that determines whether or not to inject client script for "Twitter Share Button" component automatically.
        /// </summary>
        public bool DisableClientScriptAutoInjection { get; set; }
    }
}
