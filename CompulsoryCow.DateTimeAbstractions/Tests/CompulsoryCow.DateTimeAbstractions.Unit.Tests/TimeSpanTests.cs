using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests
{
    public class TimeSpanTests : TestsBase
    {
        public TimeSpanTests(ITestOutputHelper output)
            : base(output)
        { }

        [Fact]
        public void Constructor_Ticks_Kind_ShouldCreate()
        {
            false.Should().BeTrue("TBA");
        }

        [Fact]
        public void GetTicks()
        {
            false.Should().BeTrue("Maybe we should test all properties at once, like with DateTime.");
        }
    }
}
