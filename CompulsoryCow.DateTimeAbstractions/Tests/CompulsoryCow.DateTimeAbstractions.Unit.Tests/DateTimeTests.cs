using FluentAssertions;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using Abstractions = CompulsoryCow.DateTime.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests
{
    public class DateTimeTests
    {
        private readonly VacheTacheLibrary.PseudoRandom _pr;

        public DateTimeTests(ITestOutputHelper output)
        {
            //  Get test info.
            var type = output.GetType();
            var testMember = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
            var test = (ITest)testMember.GetValue(output);

            //  Set the seed for randomising.
            _pr = new VacheTacheLibrary.PseudoRandom(test.DisplayName);
        }

        [Fact]
        public void AddShouldAdd()
        {
            var anyTicks = AnyTicks();
            var anyTimeSpan = new Abstractions.TimeSpan();
            var sut = new Abstractions.DateTime(anyTicks);

            var res = sut.Add(anyTimeSpan);

            var expected = new System.DateTime(anyTicks)
                .Add(anyTimeSpan.ToSystemTimeSpan());
            AssertEquals(expected, res);
        }

        private long AnyTicks()
        {
            return _pr.PositiveLong(1, global::System.DateTime.MaxValue.Ticks);
        }

        private static void AssertEquals(
            System.DateTime expectedDateTime,
            Abstractions.DateTime actualDateTime, 
            string because = "")
        {
            actualDateTime.Ticks.Should().Be(expectedDateTime.Ticks, because);
            actualDateTime.Kind.Should().Be(expectedDateTime.Kind, because);
        }
    }
}
