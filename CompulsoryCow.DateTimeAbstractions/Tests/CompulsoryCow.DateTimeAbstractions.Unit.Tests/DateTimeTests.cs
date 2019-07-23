using CompulsoryCow.DateTime.Abstractions;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Abstractions;
using Abstractions = CompulsoryCow.DateTime.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests
{
    public class DateTimeTests : TestsBase
    {
        public DateTimeTests(ITestOutputHelper output)
            : base(output)
        { }

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

        [Fact]
        public void GettersShouldReturnRespeciveValue()
        {
            //  #   Arrange.
            //var anyTicks = AnyTicks();
            var expectedYear = 1910;
            var expectedMonth = 11;
            var expectedDay = 12;
            var expectedHour = 13;
            var expectedMinute = 14;
            var expectedSecond = 15;
            var expectedMillisecond = 162;
            var expectedKind = AnyKindExcept(default);
            var expected = new System.DateTime(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinute, expectedSecond, expectedMillisecond, expectedKind);

            var sut = new Abstractions.DateTime(expectedYear, expectedMonth, expectedDay, expectedHour, expectedMinute, expectedSecond, expectedMillisecond, expectedKind);

            //  #   Act and Assert.
            sut.Second.Should().Be(expected.Second);
            sut.Ticks.Should().Be(expected.Ticks);
            AssertEquals(expected.Date, sut.Date, withKind: System.DateTimeKind.Unspecified, "It seems Date part of a DateTime has a hard coded/unset Kind.");
            //sut.Date.Should().Be(expected.Date);
            sut.Month.Should().Be(expected.Month);
            sut.Minute.Should().Be(expected.Minute);
            sut.Millisecond.Should().Be(expected.Millisecond);
            sut.Kind.Should().Be(expected.Kind);
            sut.Hour.Should().Be(expected.Hour);
            sut.DayOfYear.Should().Be(expected.DayOfYear);
            sut.DayOfWeek.Should().Be(expected.DayOfWeek);
            sut.Day.Should().Be(expected.Day);
            AssertEquals(expected.TimeOfDay, sut.TimeOfDay);
            sut.Year.Should().Be(expected.Year);
        }

        /// <summary>This test is not deterministic.
        /// </summary>
        [Fact]
        public void UtcNowShouldReturnUtcNow()
        {
            //  #   Arrange and Act.
            var before = System.DateTime.UtcNow;
            var now = Abstractions.DateTime.UtcNow;
            var after = System.DateTime.UtcNow;

            //  #   Assert.
            before.Ticks.Should().BeLessOrEqualTo(now.Ticks);
            now.Ticks.Should().BeLessOrEqualTo(after.Ticks);
        }

        [Fact]
        public void NowShouldReturnPresetValue()
        {
            //  #   Arrange.
            var anyTicks = AnyTicks();

            //  #   Act.
            Abstractions.DateTime.SetNow(new System.DateTime(anyTicks));

            //  #   Assert.
            Abstractions.DateTime.Now.Ticks.Should().Be(anyTicks);
        }

        [Fact]
        public void ResetNowShouldReturnSystemNow()
        {
            //  #   Arrange.
            var anyTicks = AnyTicks();
            Abstractions.DateTime.SetNow(new System.DateTime(anyTicks));
            Abstractions.DateTime.Now.Ticks.Should().Be(anyTicks, "Intermediary test we are setting the Now property.");

            //  #   Act.
            Abstractions.DateTime.SetNow(null);

            //  #   Assert.
            var before = System.DateTime.Now;
            var now = Abstractions.DateTime.Now;
            var after = System.DateTime.Now;
            before.Ticks.Should().BeLessOrEqualTo(now.Ticks);
            now.Ticks.Should().BeLessOrEqualTo(after.Ticks);
        }

        [Fact]
        public void UtcNowShouldReturnPresetValue()
        {
            //  #   Arrange.
            var anyTicks = AnyTicks();

            //  #   Act.
            Abstractions.DateTime.SetUtcNow(new System.DateTime(anyTicks));

            //  #   Assert.
            Abstractions.DateTime.UtcNow.Ticks.Should().Be(anyTicks);
        }

        [Fact]
        public void ResetUtcNowShouldReturnSystemNow()
        {
            //  #   Arrange.
            var anyTicks = AnyTicks();
            Abstractions.DateTime.SetUtcNow(new System.DateTime(anyTicks));
            Abstractions.DateTime.UtcNow.Ticks.Should().Be(anyTicks, "Intermediary test we are setting the UtcNow property.");

            //  #   Act.
            Abstractions.DateTime.SetUtcNow(null);

            //  #   Assert.
            var before = System.DateTime.UtcNow;
            var now = Abstractions.DateTime.UtcNow;
            var after = System.DateTime.UtcNow;
            before.Ticks.Should().BeLessOrEqualTo(now.Ticks);
            now.Ticks.Should().BeLessOrEqualTo(after.Ticks);
        }

        [Fact]
        public void Constructor_Ticks_Kind_ShouldCreate()
        {
            //  #   Arrange.
            var anyTicks = AnyTicks();
            var anyKind = AnyKindExcept(default);

            //  #   Act.
            var res = new Abstractions.DateTime(anyTicks, anyKind);

            //  #   Assert.
            res.Ticks.Should().Be(anyTicks);
            res.Kind.Should().Be(anyKind);
        }

        [Fact]
        public void Constructor_Year_Month_Day_Hour_Minute_Second_Millisecond_Kind_ShouldCreate()
        {
            //  #   Arrange.
            var anyDateTime = new System.DateTime(AnyTicks(), AnyKindExcept(default));
            var expected = new System.DateTime(anyDateTime.Year, anyDateTime.Month, anyDateTime.Day, anyDateTime.Hour, anyDateTime.Minute, anyDateTime.Second, anyDateTime.Millisecond, anyDateTime.Kind);

            //  #   Act.
            var sut = new Abstractions.DateTime(expected.Year, expected.Month, expected.Day, expected.Hour, expected.Minute, expected.Second, expected.Millisecond, AnyKindExcept(default));

            //  #   Assert.
            AssertEquals(expected, sut);
        }

        [Fact]
        public void Constructor_Ticks_Kind_ShouldThrowExceptionForTicksOutOfRange()
        {
            //  #   Arrange.
            var tooLowTicks = System.DateTime.MinValue.Ticks - 1;
            var tooHighTicks = System.DateTime.MaxValue.Ticks + 1;
            var anyKind = AnyKind();

            //  #   Act and Assert.
            Assert.Throws<System.ArgumentOutOfRangeException>(() =>
            {
                new Abstractions.DateTime(tooLowTicks, anyKind);
            });
            Assert.Throws<System.ArgumentOutOfRangeException>(() =>
            {
                new Abstractions.DateTime(tooHighTicks, anyKind);
            });
        }

        [Fact]
        public void Constructor_Ticks_Kind_ShouldThrowExceptionForUnknowKind()
        {
            //  #   Arrange.
            var anyTicks = AnyTicks();
            var unknownKind = (System.DateTimeKind)(((int)MaxDateTimeKind()) + 1);

            //  #   Act and Assert.
            Assert.Throws<System.ArgumentException>(() =>
            {
                new Abstractions.DateTime(anyTicks, unknownKind);
            });
        }

        private System.DateTimeKind AnyKind()
        {
            return _pr.Enum<System.DateTimeKind>();
        }

        private System.DateTimeKind AnyKindExcept(System.DateTimeKind exceptKind)
        {
            return _pr.EnumExcept(exceptKind);
        }

        private static void AssertEquals(
            System.TimeSpan expected, 
            Abstractions.TimeSpan actual,
            string because = "")
        {
            expected.Ticks.Should().Be(actual.Ticks, because);
        }

        private static void AssertEquals(
            System.DateTime expectedDateTime,
            Abstractions.DateTime actualDateTime,
            System.DateTimeKind? withKind = null,
            string because = "")
        {
            // TODO:OF:Check for all properties.
            actualDateTime.Ticks.Should().Be(expectedDateTime.Ticks, because);
            actualDateTime.Kind.Should().Be(
                withKind ?? expectedDateTime.Kind,
                because);
        }

        private static System.DateTimeKind MaxDateTimeKind()
        {
            return (System.DateTimeKind)System.Enum.GetValues(typeof(System.DateTimeKind)).Cast<int>().Max();
        }
    }
}
