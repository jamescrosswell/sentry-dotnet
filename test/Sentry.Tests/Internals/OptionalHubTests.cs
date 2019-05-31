using System;
using System.Threading.Tasks;
using Sentry.Internal;
using Xunit;

namespace Sentry.Tests.Internals
{
    public class OptionalHubTests
    {
        // Issue: https://github.com/getsentry/sentry-dotnet/issues/123
        [Fact]
        public void Ctor_NoDsn_DisposeDoesNotThrow()
        {
            var sut = new OptionalHub(new SentryOptions());
            sut.Dispose();
        }

        [Fact]
        public Task Ctor_NoDsn_FlushAsyncDoesNotThrow()
        {
            var sut = new OptionalHub(new SentryOptions());
            return sut.FlushAsync(TimeSpan.FromDays(1));
        }
    }
}
