using Soenneker.Bandwidth.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Bandwidth.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class BandwidthOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IBandwidthOpenApiHttpClient _httpclient;

    public BandwidthOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IBandwidthOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
