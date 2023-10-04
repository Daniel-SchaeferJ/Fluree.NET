using System;
using System.Net.Http;
using Flurl.Http;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Retry;

namespace FlureeDotnetLibrary.Utilities;

public static class PollyPolicy
{
    public static AsyncRetryPolicy GetPollyPolicy()
    {
        return Policy
            .Handle<HttpRequestException>()
            .Or<FlurlHttpException>()
            .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 3),
                (exception, span) => { });
    }
}