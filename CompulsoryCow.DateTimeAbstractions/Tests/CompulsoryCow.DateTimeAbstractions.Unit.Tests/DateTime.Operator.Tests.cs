using FluentAssertions;
using Xunit;
using Abstractions = CompulsoryCow.DateTime.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests
{
    public partial class DateTimeTests : DateTimeTestsBase
    {
        #region DateTime operator +(DateTime d, TimeSpan t) tests.

        [Fact]
        public void AddOperator_MimicSystem()
        {
            var anyDateTimeTicks = 334455;
            var anyTimeSpanTicks = 223344;
            var expected = new System.DateTime(anyDateTimeTicks) + new System.TimeSpan(anyTimeSpanTicks);

            //  #   Act.
            var res = new Abstractions.DateTime(anyDateTimeTicks) + new Abstractions.TimeSpan(anyTimeSpanTicks);

            //  #   Assert.
            AssertEquals(expected, res);
        }

        [Fact]
        public void AddOperator_ThrowIfOutOfBounds()
        {
            //  #   Act.
            var res = Record.Exception(() =>
            {
                _ = Abstractions.DateTime.MaxValue + new Abstractions.TimeSpan(1);
            });

            //  #   Assert.
            res.Should().BeOfType<System.ArgumentOutOfRangeException>();

            //  #   Act.
            res = Record.Exception(() =>
            {
                _ = Abstractions.DateTime.MinValue + new Abstractions.TimeSpan(-1);
            });

            //  #   Assert.
            res.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        [Fact]
        public void AddOperator_SetAndReset()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetAddOperator(null);

            var anyDateTimeTicks = 334455;
            var anyTimeSpanTicks = 223344;
            var expected = new System.DateTime(anyDateTimeTicks) + new System.TimeSpan(anyTimeSpanTicks);
            var actual = new Abstractions.DateTime(anyDateTimeTicks) + new Abstractions.TimeSpan(anyTimeSpanTicks);
            AssertEquals(expected, actual, because: "Sanity test that we know what we are testing.");

            var anyFakeDateTime = new Abstractions.DateTime(2);

            //  #   Act.
            Abstractions.DateTime.SetAddOperator(() => anyFakeDateTime);

            //  #   Assert.
            actual = new Abstractions.DateTime(anyDateTimeTicks) + new Abstractions.TimeSpan(anyTimeSpanTicks);
            actual.Should().Be(anyFakeDateTime);

            //  #   Act.
            Abstractions.DateTime.SetAddOperator(null);

            //  #   Assert.
            actual = new Abstractions.DateTime(anyDateTimeTicks) + new Abstractions.TimeSpan(anyTimeSpanTicks);
            AssertEquals(expected, actual);
        }

        #endregion  //  DateTime operator +(DateTime d, TimeSpan t) tests.

        #region TimeSpan operator -(DateTime d1, DateTime d2) tests.

        [Fact]
        public void SubtractDateTimeDateTimeOperator_MimicSystem()
        {
            var anyDateTimeFirstTicks = 334455;
            var anyDateTimeSecondTicks = 223344;
            var expected = new System.DateTime(anyDateTimeFirstTicks) - new System.DateTime(anyDateTimeSecondTicks);

            //  #   Act.
            var res = new Abstractions.DateTime(anyDateTimeFirstTicks) - new Abstractions.DateTime(anyDateTimeSecondTicks);

            //  #   Assert.
            AssertEquals(expected, res);
        }

        [Fact]
        public void SubtractDateTimeDateTime_SetAndReset()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetSubtractDateTimeDateTimeOperator(null);

            var anyDateTimeFirstTicks = 334455;
            var anyDateTimeSecondTicks = 223344;
            var expected = new System.DateTime(anyDateTimeFirstTicks) - new System.DateTime(anyDateTimeSecondTicks);
            var actual = new Abstractions.DateTime(anyDateTimeFirstTicks) - new Abstractions.DateTime(anyDateTimeSecondTicks);
            AssertEquals(expected, actual, because: "Sanity test that we know what we are testing.");

            var anyFakeDateTime = new Abstractions.TimeSpan(2);

            //  #   Act.
            Abstractions.DateTime.SetSubtractDateTimeDateTimeOperator(() => anyFakeDateTime);

            //  #   Assert.
            actual = new Abstractions.DateTime(anyDateTimeFirstTicks) - new Abstractions.DateTime(anyDateTimeSecondTicks);
            actual.Should().Be(anyFakeDateTime);

            //  #   Act.
            Abstractions.DateTime.SetSubtractDateTimeDateTimeOperator(null);

            //  #   Assert.
            actual = new Abstractions.DateTime(anyDateTimeFirstTicks) - new Abstractions.DateTime(anyDateTimeSecondTicks);
            AssertEquals(expected, actual);
        }

        #endregion  //  TimeSpan operator -(DateTime d1, DateTime d2) tests.

        #region DateTime operator -(DateTime d, TimeSpan t) tests.

        [Fact]
        public void SubtractDateTimeTimeSpanOperator_MimicSystem()
        {
            var anyDateTimeTicks = 334455;
            var anyTimeSpanTicks = 223344;
            var expected = new System.DateTime(anyDateTimeTicks) - new System.TimeSpan(anyTimeSpanTicks);

            //  #   Act.
            var res = new Abstractions.DateTime(anyDateTimeTicks) - new Abstractions.TimeSpan(anyTimeSpanTicks);

            //  #   Assert.
            AssertEquals(expected, res);
        }

        [Fact]
        public void SubtractDateTimeTimeSpanOperator_ThrowIfOutOfBounds()
        {
            //  #   Act.
            var res = Record.Exception(() =>
            {
                _ = Abstractions.DateTime.MinValue - new Abstractions.TimeSpan(1);
            });

            //  #   Assert.
            res.Should().BeOfType<System.ArgumentOutOfRangeException>();

            //  #   Act.
            res = Record.Exception(() =>
            {
                _ = Abstractions.DateTime.MaxValue - new Abstractions.TimeSpan(-1);
            });

            //  #   Assert.
            res.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        [Fact]
        public void SubtractDateTimeTimeSpanOperator_SetAndReset()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetSubtractDateTimeTimeSpanOperator(null);

            var anyDateTimeTicks = 334455;
            var anyTimeSpanTicks = 223344;
            var expected = new System.DateTime(anyDateTimeTicks) - new System.TimeSpan(anyTimeSpanTicks);
            var actual = new Abstractions.DateTime(anyDateTimeTicks) - new Abstractions.TimeSpan(anyTimeSpanTicks);
            AssertEquals(expected, actual, because: "Sanity test that we know what we are testing.");

            var anyFakeDateTime = new Abstractions.DateTime(2);

            //  #   Act.
            Abstractions.DateTime.SetSubtractDateTimeTimeSpanOperator(() => anyFakeDateTime);

            //  #   Assert.
            actual = new Abstractions.DateTime(anyDateTimeTicks) - new Abstractions.TimeSpan(anyTimeSpanTicks);
            actual.Should().Be(anyFakeDateTime);

            //  #   Act.
            Abstractions.DateTime.SetSubtractDateTimeTimeSpanOperator(null);

            //  #   Assert.
            actual = new Abstractions.DateTime(anyDateTimeTicks) - new Abstractions.TimeSpan(anyTimeSpanTicks);
            AssertEquals(expected, actual);
        }

        #endregion  //  DateTime operator -(DateTime d, TimeSpan t)
    }
}
