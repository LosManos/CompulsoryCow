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

        #region Operator ==(DateTime d1, DateTime d2) tests.

        [Theory]
        [InlineData(12, System.DateTimeKind.Utc, 12, System.DateTimeKind.Utc, true, "Should be equal.")]
        [InlineData(13, System.DateTimeKind.Utc, 12, System.DateTimeKind.Utc, false, "Ticks differ.")]
        [InlineData(12, System.DateTimeKind.Utc, 12, System.DateTimeKind.Local, true, "Kind differ but is not considered.")]
        [InlineData(null, null, 12, System.DateTimeKind.Utc, false, "One is null")]
        [InlineData(null, null, null, null, true, "Both are null.")]
        public void EqualsOperator_MimicSystem(
            long? ticks1, System.DateTimeKind? kind1,
            long? ticks2, System.DateTimeKind? kind2,
            bool expectedResult, string because)
        {
            var a = ticks1.HasValue ? new Abstractions.DateTime(ticks1.Value, kind1.Value) : null;
            var b = ticks2.HasValue ? new Abstractions.DateTime(ticks2.Value, kind2.Value) : null;

            //  #   Act.
            var res = a == b;

            //  #   Assert.
            res.Should().Be(expectedResult, because);
        }

        [Fact]
        public void EqualsOperator_SetAndReset()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetEqualsOperator(null);

            var anyTicks1 = 334455;
            var anyTicks2 = 223344;
            var expected = new System.DateTime(anyTicks1) == new System.DateTime(anyTicks2);
            var actual = new Abstractions.DateTime(anyTicks1) == new Abstractions.DateTime(anyTicks2);
            expected.Should().Be(false, "Sanity test that we know what we are testing.");
            actual.Should().Be(expected, because: "Sanity test that we know what we are testing.");

            var anyFakeResult = true;
            anyFakeResult.Should().Be(!expected, "Sanity check we have different values; so a future refactoring of the test does not mistakenly set to the same values.");

            //  #   Act.
            Abstractions.DateTime.SetEqualsOperator(() => anyFakeResult);

            //  #   Assert.;
            actual = new Abstractions.DateTime(anyTicks1) == new Abstractions.DateTime(anyTicks2);
            actual.Should().Be(anyFakeResult);

            //  #   Act.
            Abstractions.DateTime.SetEqualsOperator(null);

            //  #   Assert.
            actual = new Abstractions.DateTime(anyTicks1) == new Abstractions.DateTime(anyTicks2);
            actual.Should().Be(expected);

        }

        #endregion  //  Operator ==(DateTime d1, DateTime d2) tests.

        #region Operator !=(DateTime d1, DateTime d2) tests.

        [Theory]
        [InlineData(12, System.DateTimeKind.Utc, 12, System.DateTimeKind.Utc, false, "Should be equal.")]
        [InlineData(13, System.DateTimeKind.Utc, 12, System.DateTimeKind.Utc, true, "Ticks differ.")]
        [InlineData(12, System.DateTimeKind.Utc, 12, System.DateTimeKind.Local, false, "Kind differ but is not considered.")]
        [InlineData(null, null, 12, System.DateTimeKind.Utc, true, "One is null")]
        [InlineData(null, null, null, null, false, "Both are null.")]
        public void NotEqualsOperator_MimicSystem(
            long? ticks1, System.DateTimeKind? kind1,
            long? ticks2, System.DateTimeKind? kind2,
            bool expectedResult, string because)
        {
            var a = ticks1.HasValue ? new Abstractions.DateTime(ticks1.Value, kind1.Value) : null;
            var b = ticks2.HasValue ? new Abstractions.DateTime(ticks2.Value, kind2.Value) : null;

            //  #   Act.
            var res = a != b;

            //  #   Assert.
            res.Should().Be(expectedResult, because);
        }

        [Fact]
        public void NotEqualsOperator_SetAndReset()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetNotEqualsOperator(null);

            var anyTicks1 = 334455;
            var anyTicks2 = 223344;
            var expected = new System.DateTime(anyTicks1) != new System.DateTime(anyTicks2);
            var actual = new Abstractions.DateTime(anyTicks1) != new Abstractions.DateTime(anyTicks2);
            expected.Should().Be(true, "Sanity test that we know what we are testing.");
            actual.Should().Be(expected, because: "Sanity test that we know what we are testing.");

            var anyFakeResult = false;
            anyFakeResult.Should().Be(!expected, "Sanity check we have different values; so a future refactoring of the test does not mistakenly set to the same values.");

            //  #   Act.
            Abstractions.DateTime.SetNotEqualsOperator(() => anyFakeResult);

            //  #   Assert.;
            actual = new Abstractions.DateTime(anyTicks1) != new Abstractions.DateTime(anyTicks2);
            actual.Should().Be(anyFakeResult);

            //  #   Act.
            Abstractions.DateTime.SetNotEqualsOperator(null);

            //  #   Assert.
            actual = new Abstractions.DateTime(anyTicks1) != new Abstractions.DateTime(anyTicks2);
            actual.Should().Be(expected);

        }

        #endregion  //  Operator ==(DateTime d1, DateTime d2) tests.

        #region operator <(DateTime t1, DateTime t2) tests.

        [Theory]
        [InlineData(12, System.DateTimeKind.Utc, 13, System.DateTimeKind.Utc, "Earlier than should be true.")]
        [InlineData(12, System.DateTimeKind.Utc, 12, System.DateTimeKind.Utc, "Equal should be false.")]
        [InlineData(13, System.DateTimeKind.Utc, 12, System.DateTimeKind.Utc, "Later than should be false.")]
        [InlineData(12, System.DateTimeKind.Utc, 13, System.DateTimeKind.Local, "Kind differs but is not considered.")]
        public void EarlierThanOperator_MimicSystem(
            long ticks1, System.DateTimeKind kind1,
            long ticks2, System.DateTimeKind kind2,
            string because)
        {
            var a = new Abstractions.DateTime(ticks1, kind1);
            var b = new Abstractions.DateTime(ticks2, kind2);
            var expected = new System.DateTime(ticks1, kind1) < new System.DateTime(ticks2, kind2);

            //  #   Act.
            var res = a < b;

            //  Assert.
            res.Should().Be(expected, because);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(1, null)]
        [InlineData(null, 1)]
        public void EarlierThanOperator_ThrowForNullValues(long? ticks1, long? ticks2)
        {
            var anyKind = System.DateTimeKind.Utc;
            var d1 = ticks1.HasValue ? new Abstractions.DateTime(ticks1.Value, anyKind) : null;
            var d2 = ticks2.HasValue ? new Abstractions.DateTime(ticks2.Value, anyKind) : null;

            //  #   Act..
            var res = Record.Exception(() =>
            {
                _ = d1 < d2;
            });

            //  #   Assert.
            res.Should().BeOfType<System.ArgumentNullException>();
        }

        [Fact]
        public void EarlierThanOperator_SetAndReset()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetEarlierThanOperator(null);

            var anyTicks1 = 223344;
            var anyTicks2 = 334455;
            var expected = new System.DateTime(anyTicks1) < new System.DateTime(anyTicks2);
            var actual = new Abstractions.DateTime(anyTicks1) < new Abstractions.DateTime(anyTicks2);
            expected.Should().Be(true, "Sanity test we know what we are testing.");
            actual.Should().Be(expected, because: "Sanity test we know what we are testing.");

            var anyFakeResult = false;
            anyFakeResult.Should().Be(!expected, "Sanity check we have different values; so a future refactoring of the test does not mistakenly set to the same values.");

            //  #   Act.
            Abstractions.DateTime.SetEarlierThanOperator(() => anyFakeResult);

            //  #   Assert.;
            actual = new Abstractions.DateTime(anyTicks1) < new Abstractions.DateTime(anyTicks2);
            actual.Should().Be(anyFakeResult);

            //  #   Act.
            Abstractions.DateTime.SetEarlierThanOperator(null);

            //  #   Assert.
            actual = new Abstractions.DateTime(anyTicks1) < new Abstractions.DateTime(anyTicks2);
            actual.Should().Be(expected);

        }

        #endregion  //  operator <(DateTime t1, DateTime t2) tests.

        #region operator >(DateTime t1, DateTime t2) tests.

        [Theory]
        [InlineData(12, System.DateTimeKind.Utc, 13, System.DateTimeKind.Utc, "Earlier than should be false.")]
        [InlineData(12, System.DateTimeKind.Utc, 12, System.DateTimeKind.Utc, "Equal should be false.")]
        [InlineData(13, System.DateTimeKind.Utc, 12, System.DateTimeKind.Utc, "Later than should be true.")]
        [InlineData(13, System.DateTimeKind.Utc, 12, System.DateTimeKind.Local, "Kind differs but is not considered.")]
        public void LaterThanOperator_MimicSystem(
            long ticks1, System.DateTimeKind kind1,
            long ticks2, System.DateTimeKind kind2,
            string because)
        {
            var a = new Abstractions.DateTime(ticks1, kind1);
            var b = new Abstractions.DateTime(ticks2, kind2);
            var expected = new System.DateTime(ticks1, kind1) > new System.DateTime(ticks2, kind2);

            //  #   Act.
            var res = a > b;

            //  Assert.
            res.Should().Be(expected, because);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData(1, null)]
        [InlineData(null, 1)]
        public void LaterThanOperator_ThrowForNullValues(long? ticks1, long? ticks2)
        {
            var anyKind = System.DateTimeKind.Utc;
            var d1 = ticks1.HasValue ? new Abstractions.DateTime(ticks1.Value, anyKind) : null;
            var d2 = ticks2.HasValue ? new Abstractions.DateTime(ticks2.Value, anyKind) : null;

            //  #   Act..
            var res = Record.Exception(() =>
            {
                _ = d1 < d2;
            });

            //  #   Assert.
            res.Should().BeOfType<System.ArgumentNullException>();
        }

        [Fact]
        public void LaterThanOperator_SetAndReset()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetLaterThanOperator(null);

            var anyTicks1 = 334455;
            var anyTicks2 = 223344;
            var expected = new System.DateTime(anyTicks1) > new System.DateTime(anyTicks2);
            var actual = new Abstractions.DateTime(anyTicks1) > new Abstractions.DateTime(anyTicks2);
            expected.Should().Be(true, "Sanity test we know what we are testing.");
            actual.Should().Be(expected, because: "Sanity test we know what we are testing.");

            var anyFakeResult = false;
            anyFakeResult.Should().Be(!expected, "Sanity check we have different values; so a future refactoring of the test does not mistakenly set to the same values.");

            //  #   Act.
            Abstractions.DateTime.SetLaterThanOperator(() => anyFakeResult);

            //  #   Assert.;
            actual = new Abstractions.DateTime(anyTicks1) > new Abstractions.DateTime(anyTicks2);
            actual.Should().Be(anyFakeResult);

            //  #   Act.
            Abstractions.DateTime.SetLaterThanOperator(null);

            //  #   Assert.
            actual = new Abstractions.DateTime(anyTicks1) > new Abstractions.DateTime(anyTicks2);
            actual.Should().Be(expected);

        }

        #endregion  //  operator >(DateTime t1, DateTime t2) tests.
    }
}
