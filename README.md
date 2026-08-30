[![](https://img.shields.io/nuget/v/soenneker.bandwidth.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.bandwidth.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.bandwidth.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.bandwidth.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.bandwidth.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.bandwidth.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.bandwidth.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.bandwidth.httpclients/actions/workflows/codeql.yml)

# Soenneker.Bandwidth.HttpClients

Provides a cached, authenticated `HttpClient` for the Bandwidth OpenAPI client.

## Installation

```bash
dotnet add package Soenneker.Bandwidth.HttpClients
```

## Configuration

```json
{
  "Bandwidth": {
    "ApiKey": "your-token",
    "ClientBaseUrl": "https://api.bandwidth.com/api/v2/",
    "AuthHeaderName": "Authorization",
    "AuthHeaderValueTemplate": "Bearer {token}"
  }
}
```

`Bandwidth:ApiKey` is required. The other values shown are the defaults.

Bandwidth's combined API surface uses more than one authentication scheme. Set the header template for the particular service you call. For a Basic credential that has already been Base64-encoded, use `Basic {token}`. Endpoints requiring multiple credential headers need a separately configured Kiota authentication provider rather than this single-header transport wrapper.

## Registration

```csharp
using Soenneker.Bandwidth.HttpClients.Registrars;

services.AddBandwidthOpenApiHttpClientAsSingleton();
```

`AddBandwidthOpenApiHttpClientAsScoped()` is also available. Both registrations use the singleton HTTP-client cache.

## Usage

```csharp
using Soenneker.Bandwidth.HttpClients.Abstract;

public sealed class BandwidthTransport
{
    private readonly IBandwidthOpenApiHttpClient _clientProvider;

    public BandwidthTransport(IBandwidthOpenApiHttpClient clientProvider)
    {
        _clientProvider = clientProvider;
    }

    public async Task<HttpResponseMessage> Send(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        HttpClient client = await _clientProvider.Get(cancellationToken);
        return await client.SendAsync(request, cancellationToken);
    }
}
```

`Get()` creates the named client on first use and returns it afterward. Configuration changes do not rebuild an existing client. Do not dispose the returned `HttpClient` per request. Disposing the provider removes and disposes its named client from the cache.
