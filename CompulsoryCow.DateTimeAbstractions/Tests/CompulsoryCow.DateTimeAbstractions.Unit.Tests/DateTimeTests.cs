using FluentAssertions;
using System.Linq;
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

        #region MaxValue tests.

        [Fact]
        public void MaxValueShouldReturnMaxValue()
        {
            var res = Abstractions.DateTime.MaxValue;

            AssertEquals(System.DateTime.MaxValue, res);
        }

        #endregion

        #region MinValue tests.

        [Fact]
        public void MinValueShouldReturnMinValue()
        {
            var res = Abstractions.DateTime.MinValue;

            AssertEquals(System.DateTime.MinValue, res);
        }

        #endregion

        #region Constructor tests.

        #region public DateTime(long ticks) tests.

        [Fact]
        public void Constructor_Ticks_ShouldCreate()
        {
            //  #   Arrange.
            var anyTicks = AnyTicks();
            var systemDateTime = new System.DateTime(anyTicks);

            //  #   Act.
            var res = new Abstractions.DateTime(anyTicks);

            //  #   Assert.
            AssertEquals(systemDateTime, res);
        }

        [Fact]
        public void Constructor_Ticks_ShouldThrowForOutOfRange()
        {
            //  #   Arrange.
            var tooLow = Abstractions.DateTime.MinValue.Ticks - 1;
            var tooHigh = Abstractions.DateTime.MaxValue.Ticks + 1;

            //  #   Assert.
            Assert.Throws<System.ArgumentOutOfRangeException>(() =>
            {
                new Abstractions.DateTime(tooLow);
            });
            Assert.Throws<System.ArgumentOutOfRangeException>(() =>
            {
                new Abstractions.DateTime(tooHigh);
            });
        }

        #endregion

        #region public DateTime(long ticks, DateTimeKind kind) tests.

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

        #endregion

        #region public DateTime(int year, int month, int day)

        [Fact]
        public void Constructor_Year_Month_Day_ShouldCreate()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var systemDateTime = new System.DateTime(anyYear, anyMonth, anyDay);

            //  #   Act.
            var sut = new Abstractions.DateTime(anyYear, anyMonth, anyDay);

            //  #   Assert.
            AssertEquals(systemDateTime, sut);
        }

        [Theory]
        [InlineData(0, null, null, "Too low Year.")]
        [InlineData(10000, null, null, "Too high Year.")]
        [InlineData(null, 0, null, "Too low Month.")]
        [InlineData(null, 13, null, "Too high Month.")]
        [InlineData(null, null, 0, "Too low Day.")]
        [InlineData(null, null, 32, "Too high Day.")]
        public void Constructor_Year_Month_Day_ShouldThrowForOutOfRange(int? year, int? month, int? day, string reason)
        {
            //  #   Arrange.
            var anyValidYear = 2019;
            var anyValidMonth = 7;
            var anyValidDay = 26;
            var res = new Abstractions.DateTime(anyValidYear, anyValidMonth, anyValidDay);
            res.Should().NotBeNull("Smoke test that we can create at all.");

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(
                    year ?? anyValidDay,
                    month ?? anyValidMonth,
                    day ?? anyValidDay);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentOutOfRangeException>(reason);
        }

        #endregion

        #region DateTime(int year, int month, int day, Calendar calendar) test.

        [Fact]
        public void Constructor_Year_Mont_Day_Calendar_ShouldCreate()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var systemDateTime = new System.DateTime(anyYear, anyMonth, anyDay, anyCalendar);

            //  #   Act.
            var sut = new Abstractions.DateTime(anyYear, anyMonth, anyDay, anyCalendar);

            //  #   Assert.
            AssertEquals(systemDateTime, sut);
        }

        [Fact]
        public void Constructor_Year_Mont_Day_Calendar_ShouldThrowArgumentNullForNullCalendar()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var systemDateTime = new System.DateTime(anyYear, anyMonth, anyDay, anyCalendar);

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(anyYear, anyMonth, anyDay, null);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentNullException>();
        }

        [Theory]
        [InlineData(0, null, null, "Too low Year.")]
        [InlineData(10000, null, null, "Too high Year.")]
        [InlineData(null, 0, null, "Too low Month.")]
        [InlineData(null, 13, null, "Too high Month.")]
        [InlineData(null, null, 0, "Too low Day.")]
        [InlineData(null, null, 32, "Too high Day.")]
        public void Constructor_Year_Month_Day_Calendar_ShouldThrowForOutOfRange(int? year, int? month, int? day, string reason)
        {
            //  #   Arrange.
            var anyValidYear = 2019;
            var anyValidMonth = 7;
            var anyValidDay = 26;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var res = new Abstractions.DateTime(anyValidYear, anyValidMonth, anyValidDay, anyCalendar);
            res.Should().NotBeNull("Smoke test that we can create at all.");

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(
                    year ?? anyValidDay,
                    month ?? anyValidMonth,
                    day ?? anyValidDay,
                    anyCalendar);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentOutOfRangeException>(reason);
        }

        #endregion

        #region DateTime(int year, int month, int day, int hour, int minute, int second) tests.

        [Fact]
        public void Constructor_Year_Month_Day_Hour_Minute_Second_ShouldCreate()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyHour = 12;
            var anyMinute = 34;
            var anySecond = 56;
            var systemDateTime = new System.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond);

            //  #   Act.
            var sut = new Abstractions.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond);

            //  #   Assert.
            AssertEquals(systemDateTime, sut);
        }

        [Theory]
        [InlineData(0, null, null, null, null, null, "Too low Year.")]
        [InlineData(10000, null, null, null, null, null, "Too high Year.")]
        [InlineData(null, 0, null, null, null, null, "Too low Month.")]
        [InlineData(null, 13, null, null, null, null, "Too high Month.")]
        [InlineData(null, null, 0, null, null, null, "Too low Day.")]
        [InlineData(null, null, 32, null, null, null, "Too high Day.")]
        [InlineData(null, null, null, -1, null, null, "Too low Hour.")]
        [InlineData(null, null, null, 24, null, null, "Too high Hour.")]
        [InlineData(null, null, null, null, -1, null, "Too low Minute.")]
        [InlineData(null, null, null, null, 60, null, "Too high Minute.")]
        [InlineData(null, null, null, null, null, -1, "Too low Second.")]
        [InlineData(null, null, null, null, null, 60, "Too high Second.")]
        public void Constructor_Year_Month_Day_Hour_Minute_Second_ShouldThrowForOutOfRange(int? year, int? month, int? day, int? hour, int? minute, int? second, string reason)
        {
            //  #   Arrange.
            var anyValidYear = 2019;
            var anyValidMonth = 7;
            var anyValidDay = 26;
            var anyValidHour = 12;
            var anyValidMinute = 34;
            var anyValidSecond = 56;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var res = new Abstractions.DateTime(anyValidYear, anyValidMonth, anyValidDay, anyValidHour, anyValidMinute, anyValidSecond);
            res.Should().NotBeNull("Smoke test that we can create at all.");

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(
                    year ?? anyValidDay,
                    month ?? anyValidMonth,
                    day ?? anyValidDay,
                    hour ?? anyValidHour,
                    minute ?? anyValidMinute,
                    second ?? anyValidSecond);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentOutOfRangeException>(reason);
        }

        #endregion

        #region DateTime(int year, int month, int day, int, hour, int minute, int second, DateTimeKind kind) tests.

        [Fact]
        public void Constructor_Year_Month_Day_Hour_Minute_Second_Kind_ShouldCreate()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyHour = 12;
            var anyMinute = 34;
            var anySecond = 56;
            var anyKind = System.DateTimeKind.Utc;
            var systemDateTime = new System.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyKind);

            //  #   Act.
            var sut = new Abstractions.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyKind);

            //  #   Assert.
            AssertEquals(systemDateTime, sut);
        }

        [Theory]
        [InlineData(0, null, null, null, null, null, "Too low Year.")]
        [InlineData(10000, null, null, null, null, null, "Too high Year.")]
        [InlineData(null, 0, null, null, null, null, "Too low Month.")]
        [InlineData(null, 13, null, null, null, null, "Too high Month.")]
        [InlineData(null, null, 0, null, null, null, "Too low Day.")]
        [InlineData(null, null, 32, null, null, null, "Too high Day.")]
        [InlineData(null, null, null, -1, null, null, "Too low Hour.")]
        [InlineData(null, null, null, 24, null, null, "Too high Hour.")]
        [InlineData(null, null, null, null, -1, null, "Too low Minute.")]
        [InlineData(null, null, null, null, 60, null, "Too high Minute.")]
        [InlineData(null, null, null, null, null, -1, "Too low Second.")]
        [InlineData(null, null, null, null, null, 60, "Too high Second.")]
        public void Constructor_Year_Month_Day_Hour_Minute_Second_Kind_ShouldThrowForOutOfRange(int? year, int? month, int? day, int? hour, int? minute, int? second, string reason)
        {
            //  #   Arrange.
            var anyValidYear = 2019;
            var anyValidMonth = 7;
            var anyValidDay = 26;
            var anyValidHour = 12;
            var anyValidMinute = 34;
            var anyValidSecond = 56;
            var anyKind = System.DateTimeKind.Utc;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var res = new Abstractions.DateTime(anyValidYear, anyValidMonth, anyValidDay, anyValidHour, anyValidMinute, anyValidSecond, anyKind);
            res.Should().NotBeNull("Smoke test that we can create at all.");

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(
                    year ?? anyValidDay,
                    month ?? anyValidMonth,
                    day ?? anyValidDay,
                    hour ?? anyValidHour,
                    minute ?? anyValidMinute,
                    second ?? anyValidSecond,
                    anyKind);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentOutOfRangeException>(reason);
        }

        public void Constructor_Year_Month_Day_Hour_Minute_Second_Kind_ShouldThrowForInvalidDateTimeKind()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyHour = 12;
            var anyMinute = 34;
            var anySecond = 56;
            var unknownKind = (System.DateTimeKind)(((int)MaxDateTimeKind()) + 1);

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, unknownKind);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentException>();
        }

        #endregion

        #region DateTime(int year, int month, int day, int hour, int minute, int second, Calendar calendar) tests.

        [Fact]
        public void Constructor_Year_Mont_Day_Hour_Minute_Second_Calendar_ShouldCreate()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyHour = 12;
            var anyMinute = 34;
            var anySecond = 56;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var systemDateTime = new System.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyCalendar);

            //  #   Act.
            var sut = new Abstractions.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyCalendar);

            //  #   Assert.
            AssertEquals(systemDateTime, sut);
        }

        [Fact]
        public void Constructor_Year_Mont_Day_Hour_Minute_Second_Calendar_ShouldThrowArgumentNullForNullCalendar()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyHour = 12;
            var anyMinute = 34;
            var anySecond = 56;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var systemDateTime = new System.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyCalendar);

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, null);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentNullException>();
        }

        [Theory]
        [InlineData(0, null, null, null, null, null, "Too low Year.")]
        [InlineData(10000, null, null, null, null, null, "Too high Year.")]
        [InlineData(null, 0, null, null, null, null, "Too low Month.")]
        [InlineData(null, 13, null, null, null, null, "Too high Month.")]
        [InlineData(null, null, 0, null, null, null, "Too low Day.")]
        [InlineData(null, null, 32, null, null, null, "Too high Day.")]
        [InlineData(null, null, null, 24, null, null, "Too high Hour.")]
        [InlineData(null, null, null, null, -1, null, "Too low Minute.")]
        [InlineData(null, null, null, null, 60, null, "Too high Minute.")]
        [InlineData(null, null, null, null, null, -1, "Too low Second.")]
        [InlineData(null, null, null, null, null, 60, "Too high Second.")]
        public void Constructor_Year_Month_Day_Hour_Minute_Second_Calendar_ShouldThrowForOutOfRange(int? year, int? month, int? day, int? hour, int? minute, int? second, string reason)
        {
            //  #   Arrange.
            var anyValidYear = 2019;
            var anyValidMonth = 7;
            var anyValidDay = 26;
            var anyValidHour = 12;
            var anyValidMinute = 34;
            var anyValidSecond = 56;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var res = new Abstractions.DateTime(anyValidYear, anyValidMonth, anyValidDay, anyValidHour, anyValidMinute, anyValidSecond, anyCalendar);
            res.Should().NotBeNull("Smoke test that we can create at all.");

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(
                    year ?? anyValidDay,
                    month ?? anyValidMonth,
                    day ?? anyValidDay,
                    hour ?? anyValidHour,
                    minute ?? anyValidMinute,
                    second ?? anyValidSecond,
                    anyCalendar);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentOutOfRangeException>(reason);
        }

        #endregion

        #region DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond) tests.

        [Fact]
        public void Constructor_Year_Mont_Day_Hour_Minute_Second_Millisecond_ShouldCreate()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyHour = 12;
            var anyMinute = 34;
            var anySecond = 56;
            var anyMillisecond = 789;
            var systemDateTime = new System.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyMillisecond);

            //  #   Act.
            var sut = new Abstractions.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyMillisecond);

            //  #   Assert.
            AssertEquals(systemDateTime, sut);
        }

        [Theory]
        [InlineData(0, null, null, null, null, null, null, "Too low Year.")]
        [InlineData(10000, null, null, null, null, null, null, "Too high Year.")]
        [InlineData(null, 0, null, null, null, null, null, "Too low Month.")]
        [InlineData(null, 13, null, null, null, null, null, "Too high Month.")]
        [InlineData(null, null, 0, null, null, null, null, "Too low Day.")]
        [InlineData(null, null, 32, null, null, null, null, "Too high Day.")]
        [InlineData(null, null, null, 24, null, null, null, "Too high Hour.")]
        [InlineData(null, null, null, null, -1, null, null, "Too low Minute.")]
        [InlineData(null, null, null, null, 60, null, null, "Too high Minute.")]
        [InlineData(null, null, null, null, null, -1, null, "Too low Second.")]
        [InlineData(null, null, null, null, null, 60, null, "Too high Second.")]
        [InlineData(null, null, null, null, null, null, -1, "Too low Millisecond.")]
        [InlineData(null, null, null, null, null, null, 1000, "Too high Millisecond.")]
        public void Constructor_Year_Month_Day_Hour_Minute_Second_Millisecond_ShouldThrowForOutOfRange(int? year, int? month, int? day, int? hour, int? minute, int? second, int? millisecond, string reason)
        {
            //  #   Arrange.
            var anyValidYear = 2019;
            var anyValidMonth = 7;
            var anyValidDay = 26;
            var anyValidHour = 12;
            var anyValidMinute = 34;
            var anyValidSecond = 56;
            var anyValidMillisecond = 789;
            var res = new Abstractions.DateTime(anyValidYear, anyValidMonth, anyValidDay, anyValidHour, anyValidMinute, anyValidSecond, anyValidMillisecond);
            res.Should().NotBeNull("Smoke test that we can create at all.");

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(
                    year ?? anyValidDay,
                    month ?? anyValidMonth,
                    day ?? anyValidDay,
                    hour ?? anyValidHour,
                    minute ?? anyValidMinute,
                    second ?? anyValidSecond,
                    millisecond ?? anyValidMillisecond);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentOutOfRangeException>(reason);
        }

        #endregion

        #region DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind) tests.

        [Fact]
        public void Constructor_Year_Month_Day_Hour_Minute_Second_Millisecond_Kind_ShouldCreate()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyHour = 12;
            var anyMinute = 34;
            var anySecond = 56;
            var anyMillisecond = 789;
            var anyKind = System.DateTimeKind.Utc;
            var systemDateTime = new System.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyMillisecond, anyKind);

            //  #   Act.
            var sut = new Abstractions.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyMillisecond, anyKind);

            //  #   Assert.
            AssertEquals(systemDateTime, sut);
        }

        [Theory]
        [InlineData(0, null, null, null, null, null, null, "Too low Year.")]
        [InlineData(10000, null, null, null, null, null, null, "Too high Year.")]
        [InlineData(null, 0, null, null, null, null, null, "Too low Month.")]
        [InlineData(null, 13, null, null, null, null, null, "Too high Month.")]
        [InlineData(null, null, 0, null, null, null, null, "Too low Day.")]
        [InlineData(null, null, 32, null, null, null, null, "Too high Day.")]
        [InlineData(null, null, null, -1, null, null, null, "Too low Hour.")]
        [InlineData(null, null, null, 24, null, null, null, "Too high Hour.")]
        [InlineData(null, null, null, null, -1, null, null, "Too low Minute.")]
        [InlineData(null, null, null, null, 60, null, null, "Too high Minute.")]
        [InlineData(null, null, null, null, null, -1, null, "Too low Second.")]
        [InlineData(null, null, null, null, null, 60, null, "Too high Second.")]
        [InlineData(null, null, null, null, null, null, -1, "Too low Second.")]
        [InlineData(null, null, null, null, null, null, 1000, "Too high Second.")]
        public void Constructor_Year_Month_Day_Hour_Minute_Second_Millisecond_Kind_ShouldThrowForOutOfRange(int? year, int? month, int? day, int? hour, int? minute, int? second, int? millisecond, string reason)
        {
            //  #   Arrange.
            var anyValidYear = 2019;
            var anyValidMonth = 7;
            var anyValidDay = 26;
            var anyValidHour = 12;
            var anyValidMinute = 34;
            var anyValidSecond = 56;
            var anyValidMillisecond = 789;
            var anyKind = System.DateTimeKind.Utc;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var res = new Abstractions.DateTime(anyValidYear, anyValidMonth, anyValidDay, anyValidHour, anyValidMinute, anyValidSecond, anyValidMillisecond, anyKind);
            res.Should().NotBeNull("Smoke test that we can create at all.");

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(
                    year ?? anyValidDay,
                    month ?? anyValidMonth,
                    day ?? anyValidDay,
                    hour ?? anyValidHour,
                    minute ?? anyValidMinute,
                    second ?? anyValidSecond,
                    millisecond ?? anyValidMillisecond,
                    anyKind);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentOutOfRangeException>(reason);
        }

        [Fact]
        public void Constructor_Year_Month_Day_Hour_Minute_Second_Millisecond_Kind_ShouldThrowForInvalidDateTimeKind()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyHour = 12;
            var anyMinute = 34;
            var anySecond = 56;
            var anyMillisecond = 789;
            var unknownKind = (System.DateTimeKind)(((int)MaxDateTimeKind()) + 1);

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyMillisecond, unknownKind);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentException>();
        }

        #endregion

        #region DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar) tests.

        [Fact]
        public void Constructor_Year_Mont_Day_Hour_Minute_Second_Millisecond_Calendar_ShouldCreate()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyHour = 12;
            var anyMinute = 34;
            var anySecond = 56;
            var anyMillisecond = 789;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var systemDateTime = new System.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyMillisecond, anyCalendar);

            //  #   Act.
            var sut = new Abstractions.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyMillisecond, anyCalendar);

            //  #   Assert.
            AssertEquals(systemDateTime, sut);
        }

        [Fact]
        public void Constructor_Year_Mont_Day_Hour_Minute_Second_Millisecond_Calendar_ShouldThrowArgumentNullForNullCalendar()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyHour = 12;
            var anyMinute = 34;
            var anySecond = 56;
            var anyMillisecond = 789;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var systemDateTime = new System.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyMillisecond, anyCalendar);

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyMillisecond, null);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentNullException>();
        }

        [Theory]
        [InlineData(0, null, null, null, null, null, null, "Too low Year.")]
        [InlineData(10000, null, null, null, null, null, null, "Too high Year.")]
        [InlineData(null, 0, null, null, null, null, null, "Too low Month.")]
        [InlineData(null, 13, null, null, null, null, null, "Too high Month.")]
        [InlineData(null, null, 0, null, null, null, null, "Too low Day.")]
        [InlineData(null, null, 32, null, null, null, null, "Too high Day.")]
        [InlineData(null, null, null, 24, null, null, null, "Too high Hour.")]
        [InlineData(null, null, null, null, -1, null, null, "Too low Minute.")]
        [InlineData(null, null, null, null, 60, null, null, "Too high Minute.")]
        [InlineData(null, null, null, null, null, -1, null, "Too low Second.")]
        [InlineData(null, null, null, null, null, 60, null, "Too high Second.")]
        [InlineData(null, null, null, null, null, null, -1, "Too low Millisecond.")]
        [InlineData(null, null, null, null, null, null, 1000, "Too high Millisecond.")]
        public void Constructor_Year_Month_Day_Hour_Minute_Second_Millisecond_Calendar_ShouldThrowForOutOfRange(int? year, int? month, int? day, int? hour, int? minute, int? second, int? millisecond, string reason)
        {
            //  #   Arrange.
            var anyValidYear = 2019;
            var anyValidMonth = 7;
            var anyValidDay = 26;
            var anyValidHour = 12;
            var anyValidMinute = 34;
            var anyValidSecond = 56;
            var anyValidMillisecond = 789;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var res = new Abstractions.DateTime(anyValidYear, anyValidMonth, anyValidDay, anyValidHour, anyValidMinute, anyValidSecond, anyValidMillisecond, anyCalendar);
            res.Should().NotBeNull("Smoke test that we can create at all.");

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(
                    year ?? anyValidDay,
                    month ?? anyValidMonth,
                    day ?? anyValidDay,
                    hour ?? anyValidHour,
                    minute ?? anyValidMinute,
                    second ?? anyValidSecond,
                    millisecond ?? anyValidMillisecond,
                    anyCalendar);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentOutOfRangeException>(reason);
        }

        #endregion

        #region DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar DateTimeKind kind) tests.

        [Fact]
        public void Constructor_Year_Mont_Day_Hour_Minute_Second_Millisecond_Calendar_DateTimeKind_ShouldCreate()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyHour = 12;
            var anyMinute = 34;
            var anySecond = 56;
            var anyMillisecond = 789;
            var anyDateTimeKind = System.DateTimeKind.Utc;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var systemDateTime = new System.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyMillisecond, anyCalendar, anyDateTimeKind);

            //  #   Act.
            var sut = new Abstractions.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyMillisecond, anyCalendar, anyDateTimeKind);

            //  #   Assert.
            AssertEquals(systemDateTime, sut);
        }

        [Fact]
        public void Constructor_Year_Mont_Day_Hour_Minute_Second_Millisecond_Calendar_DateTimekind_ShouldThrowArgumentNullForNullCalendar()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyHour = 12;
            var anyMinute = 34;
            var anySecond = 56;
            var anyMillisecond = 789;
            var anyDateTimeKind = System.DateTimeKind.Utc;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var systemDateTime = new System.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyMillisecond, anyCalendar, anyDateTimeKind);

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyMillisecond, null, anyDateTimeKind);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentNullException>();
        }

        [Theory]
        [InlineData(0, null, null, null, null, null, null, "Too low Year.")]
        [InlineData(10000, null, null, null, null, null, null, "Too high Year.")]
        [InlineData(null, 0, null, null, null, null, null, "Too low Month.")]
        [InlineData(null, 13, null, null, null, null, null, "Too high Month.")]
        [InlineData(null, null, 0, null, null, null, null, "Too low Day.")]
        [InlineData(null, null, 32, null, null, null, null, "Too high Day.")]
        [InlineData(null, null, null, 24, null, null, null, "Too high Hour.")]
        [InlineData(null, null, null, null, -1, null, null, "Too low Minute.")]
        [InlineData(null, null, null, null, 60, null, null, "Too high Minute.")]
        [InlineData(null, null, null, null, null, -1, null, "Too low Second.")]
        [InlineData(null, null, null, null, null, 60, null, "Too high Second.")]
        [InlineData(null, null, null, null, null, null, -1, "Too low Millisecond.")]
        [InlineData(null, null, null, null, null, null, 1000, "Too high Millisecond.")]
        public void Constructor_Year_Month_Day_Hour_Minute_Second_Millisecond_Calendar_DateTimeKind_ShouldThrowForOutOfRange(int? year, int? month, int? day, int? hour, int? minute, int? second, int? millisecond, string reason)
        {
            //  #   Arrange.
            var anyValidYear = 2019;
            var anyValidMonth = 7;
            var anyValidDay = 26;
            var anyValidHour = 12;
            var anyValidMinute = 34;
            var anyValidSecond = 56;
            var anyValidMillisecond = 789;
            var anyDateTimeKind = System.DateTimeKind.Utc;
            var anyCalendar = new System.Globalization.TaiwanCalendar();
            var res = new Abstractions.DateTime(anyValidYear, anyValidMonth, anyValidDay, anyValidHour, anyValidMinute, anyValidSecond, anyValidMillisecond, anyCalendar, anyDateTimeKind); ;
            res.Should().NotBeNull("Smoke test that we can create at all.");

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(
                    year ?? anyValidDay,
                    month ?? anyValidMonth,
                    day ?? anyValidDay,
                    hour ?? anyValidHour,
                    minute ?? anyValidMinute,
                    second ?? anyValidSecond,
                    millisecond ?? anyValidMillisecond,
                    anyCalendar,
                    anyDateTimeKind);
            });

            //  #   Assert.
            exc.Should().BeOfType<System.ArgumentOutOfRangeException>(reason);
        }

        [Fact]
        public void Constructor_Year_Month_Day_Hour_Minute_Second_Millisecond_Calendar_DateTime_Kind_ShouldThrowForOutOfRange()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var anyDay = 26;
            var anyHour = 12;
            var anyMinute = 34;
            var anySecond = 56;
            var anyMillisecond = 789;
            var anyCalendar = new System.Globalization.ChineseLunisolarCalendar();
            var unknownKind = (System.DateTimeKind)(((int)MaxDateTimeKind()) + 1);

            //  #   Act.
            var exc = Record.Exception(() =>
            {
                new Abstractions.DateTime(anyYear, anyMonth, anyDay, anyHour, anyMinute, anySecond, anyMillisecond, unknownKind);
            });

            exc.Should().BeOfType<System.ArgumentException>();
        }

        #endregion

        #endregion  //  Constructor tests.

        #region Static methods tests.

        #region Compare tests.

        [Theory]
        [InlineData(10, 20, -1)]
        [InlineData(10,10,0)]
        [InlineData(20,10,1)]
        public void CompareShouldDoValidComparisons(long ticks1, long ticks2, int expectedResult)
        {
            //  #   Arrange.
            Abstractions.DateTime.SetCompare(null);

            //  #   Act.
            var res = Abstractions.DateTime.Compare(new Abstractions.DateTime(ticks1), new Abstractions.DateTime(ticks2));

            //  #   Assert.
            res.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(null, 1L)]
        [InlineData(1,null)]
        [InlineData(null, null)]
        public void CompareShouldThrowNullArgumentExceptionForNullParameters(long? ticks1, long? ticks2)
        {
            //  #   Act.
            var res = Record.Exception(() =>
            {
                Abstractions.DateTime.Compare(
                    ticks1.HasValue ? new Abstractions.DateTime(ticks1.Value) : null,
                    ticks2.HasValue ? new Abstractions.DateTime(ticks2.Value) : null);
            });

            //  #   Assert.
            res.Should().BeOfType<System.ArgumentNullException>();
        }

        [Fact]
        public void CompareShouldBeSettable()
        {
            //  #   Arrange.
            const long anyTicks1 = 1;
            const long anyTicks2 = 2;
            const int expectedResult = 42;
            Abstractions.DateTime.SetCompare(new System.Func<System.DateTime, System.DateTime, int> ((t1, t2) => expectedResult));

            //  #   Act.
            var res = Abstractions.DateTime.Compare(new Abstractions.DateTime(anyTicks1), new Abstractions.DateTime(anyTicks2));

            //  #   Assert.
            res.Should().Be(expectedResult);
        }

        #endregion

        #region DaysInMonth tests.

        [Fact]
        public void DaysInMonthShouldEqualSystemDaysInMonth()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var expected = System.DateTime.DaysInMonth(anyYear, anyMonth);

            //  #   Act.
            var res = Abstractions.DateTime.DaysInMonth(anyYear, anyMonth);

            //  #   Assert.
            res.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, null)]
        [InlineData(10000, null)]
        [InlineData(null, 0)]
        [InlineData(null, 13)]
        public void DaysInMonthShouldThrowExceptionForOutOfRange(int? year, int? month)
        {
            //  #   Arrange.
            var anyValidYear = 2019;
            var anyValidMonth = 7;

            //  #   Act.
            var res = Record.Exception(() =>
            {
                Abstractions.DateTime.DaysInMonth(year ?? anyValidYear, month ?? anyValidMonth);
            });

            //  #   Assert.
            res.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        [Fact]
        public void DaysInMonthShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            var anyYear = 2019;
            var anyMonth = 7;
            var expectedDaysInMonth = 42;

            //  #   Act.
            Abstractions.DateTime.SetDaysInMonth(new System.Func<int, int, int>((year, month) => expectedDaysInMonth));

            //  #   Arrange.
            var res = Abstractions.DateTime.DaysInMonth(anyYear, anyMonth);
            res.Should().Be(expectedDaysInMonth);

            //  #   Act.
            Abstractions.DateTime.SetDaysInMonth(null);

            //  #   Assert.
            res = Abstractions.DateTime.DaysInMonth(anyYear, anyMonth);
            res.Should().Be(System.DateTime.DaysInMonth(anyYear, anyMonth));
        }

        #endregion

        #endregion  //  Static methods tests.

        #region Properties tests.

        [Fact]
        public void GettersShouldReturnRespectiveValue()
        {
            //  #   Arrange.
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

        #region UtcNow tests.

        /// <summary>This test is not deterministic.
        /// </summary>
        [Fact]
        public void UtcNowShouldReturnSystemUtcNow()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetUtcNow(null);
            var before = System.DateTime.UtcNow;

            //  #   Act.
            var now = Abstractions.DateTime.UtcNow;

            //  #   Assert.
            var after = System.DateTime.UtcNow;

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

        #endregion

        #region Now tests.

        // TODO:OF:Write a test that checks System.Now, like UtcNowShouldReturnSystemUtcNow does.

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

        /// <summary>This test is not deterministic.
        /// </summary>
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

        #endregion

        #endregion

        #region Add tests.

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

        #endregion

        #region Private helper methods.

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

        #endregion
    }
}
