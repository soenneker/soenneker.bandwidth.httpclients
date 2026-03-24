using Soenneker.Bandwidth.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Bandwidth.HttpClients.Tests;

[Collection("Collection")]
public sealed class BandwidthOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IBandwidthOpenApiHttpClient _httpclient;

    public BandwidthOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IBandwidthOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
