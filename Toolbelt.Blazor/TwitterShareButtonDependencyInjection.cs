using System;
using Microsoft.Extensions.DependencyInjection;
using Toolbelt.Blazor.TwitterShareButton;

namespace Toolbelt.Blazor.Extensions.DependencyInjection
{
    /// <summary>
    /// Extension methods for adding global options for "Twitter Share Button".
    /// </summary>
    public static class TwitterShareButtonDependencyInjection
    {
        /// <summary>
        ///  Adds a global options for "Twitter Share Button" to the specified Microsoft.Extensions.DependencyInjection.IServiceCollection.
        /// </summary>
        /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection to add the service to.</param>
        /// <param name="configure">An System.Action`1 to configure the provided TwitterShareButtonGlobalOptions.</param>
        public static IServiceCollection AddTwitterShareButtonGlobalOptions(this IServiceCollection services, Action<TwitterShareButtonGlobalOptions> configure)
        {
            var options = new TwitterShareButtonGlobalOptions();
            configure(options);
            services.AddSingleton<ITwitterShareButtonGlobalOptions>(options);
            return services;
        }
    }
}