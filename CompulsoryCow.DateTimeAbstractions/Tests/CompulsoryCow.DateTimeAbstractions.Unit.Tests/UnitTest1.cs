using FluentAssertions;
using Xunit;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void AddShouldAdd()
        {
            var anyTicks = 1000;
            var anyTimeSpan = new CompulsoryCow.DateTimeAbstractions.TimeSpan();
            var sut = new CompulsoryCow.DateTimeAbstractions.DateTime(anyTicks);

            var res = sut.Add(anyTimeSpan);

            var expected = new global::System.DateTime(anyTicks)
                .Add(anyTimeSpan.ToSystemTimeSpan());
            Equals(expected, res);
        }

        private static void AssertEquals(
            global::System.DateTime expectedDateTime,
            DateTimeAbstractions.DateTime actualDateTime, 
            string because)
        {
            actualDateTime.Ticks.Should().Be(expectedDateTime.Ticks, because);
            actualDateTime.Kind.Should().Be(expectedDateTime.Kind, because);
        }
    }
}
