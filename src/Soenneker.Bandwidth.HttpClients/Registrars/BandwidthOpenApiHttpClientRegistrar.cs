using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Bandwidth.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Bandwidth.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class BandwidthOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IBandwidthOpenApiHttpClient"/> as a singleton service backed by the singleton HTTP-client cache.
    /// </summary>
    public static IServiceCollection AddBandwidthOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IBandwidthOpenApiHttpClient, BandwidthOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IBandwidthOpenApiHttpClient"/> as a scoped service backed by the singleton HTTP-client cache.
    /// </summary>
    public static IServiceCollection AddBandwidthOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IBandwidthOpenApiHttpClient, BandwidthOpenApiHttpClient>();

        return services;
    }
}
