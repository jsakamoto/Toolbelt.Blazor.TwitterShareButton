namespace Toolbelt.Blazor.TwitterShareButton
{
    /// <summary>
    /// Global options for "Twitter Share Button".
    /// </summary>
    public interface ITwitterShareButtonGlobalOptions
    {
        /// <summary>
        /// Gets a value that determines whether or not to inject client script for "Twitter Share Button" component automatically.
        /// </summary>
        bool DisableClientScriptAutoInjection { get; }
    }
}
