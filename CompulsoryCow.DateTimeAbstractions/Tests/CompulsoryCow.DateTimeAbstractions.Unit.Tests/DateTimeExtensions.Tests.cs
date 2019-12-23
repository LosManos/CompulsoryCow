using CompulsoryCow.DateTime.Abstractions;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Abstractions = CompulsoryCow.DateTime.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests
{
    public class DateTimeExtensionsTests : DateTimeTestsBase
    {
        public DateTimeExtensionsTests(ITestOutputHelper output)
            : base(output)
        { }

        [Fact]
        public void ToSystemDateTimeShouldConvert()
        {
            var anyTicks = 637126222737764398;
            var anyKind = System.DateTimeKind.Utc;
            var expected = new System.DateTime(anyTicks, anyKind);

            //  Act.
            var actual = new Abstractions.DateTime(anyTicks, anyKind).ToSystemDateTime();

            //  Assert.
            actual.Should().Be(expected);
        }

        [Fact]
        public void ToSystemDateTimeShouldThrowForNullParameter()
        {
            //  Act.
            var result = Record.Exception(() =>
            {
                (null as Abstractions.DateTime).ToSystemDateTime();
            });

            //  Assert.
            result.Should().BeOfType<System.ArgumentNullException>();
        }

        [Fact]
        public void ToAbstractionsDateTimeShouldConvert()
        {
            var anyTicks = 637126222737764398;
            var anyKind = System.DateTimeKind.Local;
            var expected = new Abstractions.DateTime(anyTicks, anyKind);

            //  Act.
            var actual = new System.DateTime(anyTicks, anyKind).ToAbstractionsDateTime();

            //  Assert.
            actual.Should().Be(expected);
        }
    }
}
