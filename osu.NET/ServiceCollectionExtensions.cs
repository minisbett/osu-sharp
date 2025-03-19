using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using osu.NET.Authorization;

namespace osu.NET;

/// <summary>
/// Provides extension methods for <see cref="IServiceCollection"/> to register <see cref="OsuApiClient"/> objects.
/// </summary>
public static class ServiceCollectionExtensions
{
  /// <summary>
  /// Registers a scoped <see cref="OsuApiClient"/> with the specified access token provider in the service collection.
  /// Optionally, a configuration delegate for the options of the API client can be specified.
  /// </summary>
  /// <param name="services">The service collection.</param>
  /// <param name="accessTokenProvider">An access token provider for the API client.</param>
  /// <param name="configurator">A configuration delegate for setting the options for the API client.</param>
  public static IServiceCollection AddOsuApiClient(this IServiceCollection services, IOsuAccessTokenProvider accessTokenProvider, Action<OsuApiClientOptions, IServiceProvider>? configurator = null)
    => services.AddOsuApiClient(_ => accessTokenProvider, configurator);

  /// <summary>
  /// Registers a scoped <see cref="OsuApiClient"/> in the service collection.
  /// <br/><br/>
  /// Notes:
  /// <list type="bullet">
  /// <item>The <paramref name="accessTokenProviderFactory"/> is ran on service registration as the access token provider must be a singleton instance in order to persist authorization data.</item>
  /// <item>The <paramref name="configurator"/> is ran when the scoped <see cref="OsuApiClient"/> is created.</item>
  /// </list>
  /// </summary>
  /// <param name="services">The service collection.</param>
  /// <param name="accessTokenProviderFactory">A factory for creating an access token provider for the API client.</param>
  /// <param name="configurator">A configuration delegate for setting the options for the API client.</param>
  public static IServiceCollection AddOsuApiClient(this IServiceCollection services, Func<IServiceProvider, IOsuAccessTokenProvider> accessTokenProviderFactory, Action<OsuApiClientOptions, IServiceProvider>? configurator = null)
  {
    IOsuAccessTokenProvider accessTokenProvider = accessTokenProviderFactory(services.BuildServiceProvider());
    return services.AddScoped(services =>
    {
      OsuApiClientOptions options = new();
      configurator?.Invoke(options, services);
      return new OsuApiClient(accessTokenProvider, options, services.GetRequiredService<ILogger<OsuApiClient>>());
    });
  }
}
