using FluentAssertions;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests
{
    public class DateTimeTests
    {
        private readonly VacheTacheLibrary.PseudoRandom _pr;

        public DateTimeTests(ITestOutputHelper output)
        {
            var type = output.GetType();
            var testMember = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
            var test = (ITest)testMember.GetValue(output);
            _pr = new VacheTacheLibrary.PseudoRandom(test.DisplayName);

        }

        [Fact]
        public void AddShouldAdd()
        {
            var anyTicks = AnyTicks();
            var anyTimeSpan = new CompulsoryCow.DateTimeAbstractions.TimeSpan();
            var sut = new CompulsoryCow.DateTimeAbstractions.DateTime(anyTicks);

            var res = sut.Add(anyTimeSpan);

            var expected = new global::System.DateTime(anyTicks)
                .Add(anyTimeSpan.ToSystemTimeSpan());
            AssertEquals(expected, res);
        }

        private long AnyTicks()
        {
            return _pr.PositiveLong(1, global::System.DateTime.MaxValue.Ticks);
        }

        private static void AssertEquals(
            global::System.DateTime expectedDateTime,
            DateTimeAbstractions.DateTime actualDateTime, 
            string because = "")
        {
            actualDateTime.Ticks.Should().Be(expectedDateTime.Ticks, because);
            actualDateTime.Kind.Should().Be(expectedDateTime.Kind, because);
        }
    }
}
