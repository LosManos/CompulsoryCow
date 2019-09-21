using FluentAssertions;
using System.Globalization;
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
            res.Should().NotBeNull("Sanity test that we can create at all.");

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
            res.Should().NotBeNull("Sanity test that we can create at all.");

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
            res.Should().NotBeNull("Sanity test that we can create at all.");

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
            res.Should().NotBeNull("Sanity test that we can create at all.");

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

        [Fact]
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
            res.Should().NotBeNull("Sanity test that we can create at all.");

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
            res.Should().NotBeNull("Sanity test that we can create at all.");

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
            res.Should().NotBeNull("Sanity test that we can create at all.");

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
            res.Should().NotBeNull("Sanity test that we can create at all.");

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
            res.Should().NotBeNull("Sanity test that we can create at all.");

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
        [InlineData(10, 10, 0)]
        [InlineData(20, 10, 1)]
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
        [InlineData(1, null)]
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
            Abstractions.DateTime.SetCompare(new System.Func<System.DateTime, System.DateTime, int>((t1, t2) => expectedResult));

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

        #region DaysInMonth tests.

        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        public void EqualsShouldEqualSystemEquals(int ticks1, int ticks2)
        {
            //  #   Arrange.
            Abstractions.DateTime.SetEquals(null);
            var expected = System.DateTime.Equals(
                new System.DateTime(ticks1),
                new System.DateTime(ticks2));

            //  #   Act.
            var res = Abstractions.DateTime.Equals(
                new Abstractions.DateTime(ticks1),
                new Abstractions.DateTime(ticks2));

            //  #   Assert.
            res.Should().Be(expected);
        }

        [Theory]
        [InlineData(null, 1)]
        [InlineData(1, null)]
        [InlineData(null, null)]
        public void EqualsShouldThrowExceptionForNullArgument(int? ticks1, int? ticks2)
        {
            //  #   Arrange.
            Abstractions.DateTime.SetEquals(null);

            //  #   Act.
            var res = Record.Exception(() =>
            {
                Abstractions.DateTime.Equals(
                    ticks1.HasValue ? new Abstractions.DateTime(ticks1.Value) : null,
                    ticks2.HasValue ? new Abstractions.DateTime(ticks2.Value) : null);
            });

            res.Should().BeOfType<System.ArgumentNullException>();
        }

        [Fact]
        public void EqualsShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            var anyDateTime1 = new Abstractions.DateTime(1);
            var anyDateTime2 = new Abstractions.DateTime(2);
            anyDateTime1.Ticks.Should().NotBe(anyDateTime2.Ticks, "Sanity test that we have different datetimes.");
            var expectedResult = true;

            //  #   Act.
            Abstractions.DateTime.SetEquals(new System.Func<System.DateTime, System.DateTime, bool>((t1, t2) => expectedResult));

            //  #   Arrange.
            var res = Abstractions.DateTime.Equals(anyDateTime1, anyDateTime2);
            res.Should().Be(expectedResult);

            //  #   Act.
            Abstractions.DateTime.SetEquals(null);

            //  #   Assert.
            res = Abstractions.DateTime.Equals(anyDateTime1, anyDateTime2);
            res.Should().BeFalse();
        }

        #endregion

        #region FromBinary tests.

        [Fact]
        public void FromBinaryShouldEqualSystemFromBinary()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetFromBinary(null);
            var anyBinary = new System.DateTime(AnyTicks()).ToBinary();
            var expectedDateTime = System.DateTime.FromBinary(anyBinary);

            //  #   Act.
            var res = Abstractions.DateTime.FromBinary(anyBinary);

            //  #   Assert.
            AssertEquals(expectedDateTime, res);
        }

        [Fact]
        public void FromBinaryShouldThrowExceptionForTooBigOrLowInput()
        {
            //  #   Arrange.
            ////  ##  Create a mask for the 2 highest bits.
            var kindMask = ((long)System.Math.Pow(2, 63) + (long)System.Math.Pow(2, 62));
            ////  ##  Create a mask for the lowest 62 bits.
            var ticksMask = long.MaxValue & (long.MaxValue - kindMask);

            // ##   Create a too low value.
            var datedata = System.DateTime.MinValue.ToBinary();
            var kindPart = datedata & kindMask;
            var ticksPart = datedata & ticksMask;
            //(var kindPart, var ticksPart) = getParts(datedata);
            ticksPart.Should().Be(0);
            // If I understand the documentation correctly we should do 62 bits based arithmetic
            // when reducing ticksPart with 1. But 1) since I don't want to write 62 bits arithmetic 
            // and 2) I am sure the documentation has left something out as I doubt Ticks is in 
            // 62 bit base; I settle for this. It is not 100% correct but it it works.
            var tooLowTicksPart = (ticksPart - 1) & ticksMask;

            // ##   Create a too hight value.
            datedata = System.DateTime.MaxValue.ToBinary();
            kindPart = datedata & kindMask;
            ticksPart = datedata & ticksMask;
            // If I understand the documentation correctly we should do 62 bits based arithmetic
            // when reducing ticksPart with 1. But 1) since I don't want to write 62 bits arithmetic 
            // and 2) I am sure the documentation has left something out as I doubt Ticks is in 
            // 62 bit base; I settle for this. It is not 100% correct but it it works.
            var tooHighTicksPart = (ticksPart + 1) & ticksMask;

            //  #   Act.
            var tooLowException = Record.Exception(() =>
            {
                System.DateTime.FromBinary(kindPart | tooLowTicksPart);
            });
            var tooHighException = Record.Exception(() =>
            {
                System.DateTime.FromBinary(kindPart | tooHighTicksPart);
            });

            //  #   Assert.
            tooLowException.Should().BeOfType<System.ArgumentException>();
            tooHighException.Should().BeOfType<System.ArgumentException>();
        }

        [Fact]
        public void FromBinaryShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            var anyDateTime1 = new Abstractions.DateTime(AnyTicks());
            var anySystemDateTime1 = new System.DateTime(anyDateTime1.Ticks);
            var anyDateData1 = new System.DateTime(anyDateTime1.Ticks).ToBinary();

            var anyDateTime2 = new Abstractions.DateTime(AnyTicks());
            var anySystemDateTime2 = new System.DateTime(anyDateTime2.Ticks);

            anySystemDateTime1.Ticks.Should().NotBe(anySystemDateTime2.Ticks, "Sanity test we don't happen to randomise two identical datetimes.");

            //  #   Act.
            // Set `FromBinary` to always return datetime2.
            Abstractions.DateTime.SetFromBinary(new System.Func<long, System.DateTime>((dateData) => anySystemDateTime2));

            //  #   Assert..
            // Deserialise datetime1 but get datetime2 back due to `SetFromBinary` call.
            var res = Abstractions.DateTime.FromBinary(anyDateData1);
            AssertEquals(anySystemDateTime2, res, because: "FromBinary should return DateTime2 disregarding parameter value.");

            //  #   Act.
            // Reset and let `FromBinary` call default function.
            Abstractions.DateTime.SetFromBinary(null);

            //  #   Assert.
            res = Abstractions.DateTime.FromBinary(anyDateData1);
            AssertEquals(anySystemDateTime1, res);
        }

        #endregion

        #region FromFileTime tests.

        [Fact]
        public void FromFileTimeShouldEqualSystemFromFileTime()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetFromFileTime(null);
            var anyFileTime = 1;
            var expected = System.DateTime.FromFileTime(anyFileTime);

            //  #   Act.
            var res = Abstractions.DateTime.FromFileTime(anyFileTime);

            AssertEquals(expected, res);
        }

        [Fact]
        public void FromFileTimeShouldThrowForTooLargeOrSmallInput()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetFromFileTime(null);
            var tooSmallFileTime = -1;
            var tooLargeFileTime = System.DateTime.MaxValue.Ticks + 1;

            //  #   Act.
            var tooLowRes = Record.Exception(() =>
            {
                Abstractions.DateTime.FromFileTime(tooSmallFileTime);
            });
            var tooLargeRes = Record.Exception(() =>
            {
                Abstractions.DateTime.FromFileTime(tooLargeFileTime);
            });

            //  #   Assert.
            tooLowRes.Should().BeOfType<System.ArgumentOutOfRangeException>();
            tooLargeRes.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        [Fact]
        public void FromFileTimeShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            var anyFileTime = 42;
            var expected = System.DateTime.FromFileTime(anyFileTime);
            var actual = Abstractions.DateTime.FromFileTime(anyFileTime);
            AssertEquals(expected, actual, because: "Sanity test we get the standard System.DateTime.FromFileTime value.");

            var anyOtherFileTime = 43;

            //  #   Act.
            Abstractions.DateTime.SetFromFileTime((_) => System.DateTime.FromFileTime(anyOtherFileTime));

            //  #   Assert.
            var otherExpected = System.DateTime.FromFileTime(anyOtherFileTime);
            var otherActual = Abstractions.DateTime.FromFileTime(anyOtherFileTime);

            //  #   Act.
            Abstractions.DateTime.SetFromFileTime(null);

            //  #   Assert.
            actual = Abstractions.DateTime.FromFileTime(anyFileTime);
            AssertEquals(expected, actual);
        }

        #endregion

        #region FromFileTimeUtc tests.

        [Fact]
        public void FromFileTimeUtcShouldEqualSystemFromFileTimeUtc()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetFromFileTimeUtc(null);
            var anyFileTime = 1;
            var expected = System.DateTime.FromFileTimeUtc(anyFileTime);

            //  #   Act.
            var res = Abstractions.DateTime.FromFileTimeUtc(anyFileTime);

            AssertEquals(expected, res);
        }

        [Fact]
        public void FromFileTimeUtcShouldThrowForTooLargeOrSmallInput()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetFromFileTimeUtc(null);
            var tooSmallFileTime = -1;
            var tooLargeFileTime = System.DateTime.MaxValue.Ticks + 1;

            //  #   Act.
            var tooLowRes = Record.Exception(() =>
            {
                Abstractions.DateTime.FromFileTimeUtc(tooSmallFileTime);
            });
            var tooLargeRes = Record.Exception(() =>
            {
                Abstractions.DateTime.FromFileTimeUtc(tooLargeFileTime);
            });

            //  #   Assert.
            tooLowRes.Should().BeOfType<System.ArgumentOutOfRangeException>();
            tooLargeRes.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        [Fact]
        public void FromFileTimeUtcShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            var anyFileTime = 42;
            var expected = System.DateTime.FromFileTimeUtc(anyFileTime);
            var actual = Abstractions.DateTime.FromFileTimeUtc(anyFileTime);
            AssertEquals(expected, actual, because: "Sanity test we get the standard System.DateTime.FromFileTimeUtc value.");

            var anyOtherFileTime = 43;

            //  #   Act.
            Abstractions.DateTime.SetFromFileTimeUtc((_) => System.DateTime.FromFileTimeUtc(anyOtherFileTime));

            //  #   Assert.
            var otherExpected = System.DateTime.FromFileTimeUtc(anyOtherFileTime);
            var otherActual = Abstractions.DateTime.FromFileTimeUtc(anyOtherFileTime);

            //  #   Act.
            Abstractions.DateTime.SetFromFileTimeUtc(null);

            //  #   Assert.
            actual = Abstractions.DateTime.FromFileTimeUtc(anyFileTime);
            AssertEquals(expected, actual);
        }

        #endregion

        #region FromOADate tests.

        [Fact]
        public void FromOADateShouldEqualSystemFromOADate()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetFromOADate(null);
            var anyFileTime = 1d;
            var expected = System.DateTime.FromOADate(anyFileTime);

            //  #   Act.
            var res = Abstractions.DateTime.FromOADate(anyFileTime);

            AssertEquals(expected, res);
        }

        [Fact]
        public void FromOADateShouldThrowForInvalidInput()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetFromOADate(null);
            var invalidOADate = new System.DateTime(0100, 01, 01).Ticks - 1;

            //  #   Act.
            var res = Record.Exception(() =>
            {
                Abstractions.DateTime.FromOADate(invalidOADate);
            });

            //  #   Assert.
            res.Should().BeOfType<System.ArgumentException>();
        }

        [Fact]
        public void FromOADateShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            var anyFileTime = 42d;
            var expected = System.DateTime.FromOADate(anyFileTime);
            var actual = Abstractions.DateTime.FromOADate(anyFileTime);
            AssertEquals(expected, actual, because: "Sanity test we get the standard System.DateTime.FromOADate value.");

            var anyOtherFileTime = 43;

            //  #   Act.
            Abstractions.DateTime.SetFromOADate((_) => System.DateTime.FromOADate(anyOtherFileTime));

            //  #   Assert.
            var otherExpected = System.DateTime.FromOADate(anyOtherFileTime);
            var otherActual = Abstractions.DateTime.FromOADate(anyOtherFileTime);

            //  #   Act.
            Abstractions.DateTime.SetFromOADate(null);

            //  #   Assert.
            actual = Abstractions.DateTime.FromOADate(anyFileTime);
            AssertEquals(expected, actual);
        }

        #endregion

        #region IsLeapYear tests.

        [Fact]
        public void IsLeapYearShouldReturnSystemIsLeapYear()
        {
            //  #   Arrange.
            var anyLeapYear = 2004;
            var anyNonLeapYear = 2005;
            Abstractions.DateTime.SetIsLeapYear(null);

            //  #   Act.
            var resLeap = Abstractions.DateTime.IsLeapYear(anyLeapYear);
            var resNonLeap = Abstractions.DateTime.IsLeapYear(anyNonLeapYear);

            //  #   Assert.
            resLeap.Should().Be(System.DateTime.IsLeapYear(anyLeapYear));
            resNonLeap.Should().Be(System.DateTime.IsLeapYear(anyNonLeapYear));
        }

        [Fact]
        public void IsLeapYearShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetIsLeapYear(null);
            var anyLeapYear = 2004;
            Abstractions.DateTime.IsLeapYear(anyLeapYear).Should().Be(true, "Sanity test we know a positive");

            //  #   Act.
            Abstractions.DateTime.SetIsLeapYear((n) => false);

            //  #   Assert.
            Abstractions.DateTime.IsLeapYear(anyLeapYear).Should().BeFalse();

            //  #   Act.
            Abstractions.DateTime.SetIsLeapYear(null);
            Abstractions.DateTime.IsLeapYear(anyLeapYear).Should().BeTrue();
        }

        [Fact]
        public void IsLeapYearShouldThrowExceptionForInvalidArgument()
        {
            //  # Arrange.
            const int tooLowYear = 0;
            const int tooHighYear = 10000;
            Abstractions.DateTime.SetIsLeapYear(null);

            //  # Act.
            var tooLowRes = Record.Exception(() =>
            {
                Abstractions.DateTime.IsLeapYear(tooLowYear);
            });

            var tooHighRes = Record.Exception(() =>
            {
                Abstractions.DateTime.IsLeapYear(tooHighYear);
            });

            //  #   Assert.
            tooLowRes.Should().BeOfType<System.ArgumentOutOfRangeException>();
            tooHighRes.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        #endregion

        #region Parse(string s, IFormatProvider provider, DateTimeStyles styles) tests.

        [Fact]
        public void ParseStringFormatProviderStylesShouldMimicSystemParse()
        {
            //  #   Arrange.
            var anyDateTime = "2019-08-11 13:41";
            var anyFormatProvider = CultureInfo.InvariantCulture;
            var anyStyle = DateTimeStyles.AllowInnerWhite;
            var expected = System.DateTime.Parse(anyDateTime, anyFormatProvider, anyStyle);

            //  #   Act.
            var res = Abstractions.DateTime.Parse(anyDateTime, anyFormatProvider, anyStyle);

            //  #   Assert.
            AssertEquals(expected, res);
        }

        [Theory]
        [InlineData(null, null, typeof(System.ArgumentNullException))]
        [InlineData("no valid date", null, typeof(System.FormatException))]
        [InlineData("2019-08-11 19:31", DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal, typeof(System.ArgumentException))]
        public void ParseStringFormatProviderStylesShouldThrowExceptionForBadData(string s, DateTimeStyles? style, System.Type exceptionType)
        {
            //  #   Arrange.
            var anyFormatProvider = CultureInfo.InvariantCulture;
            style = style ?? DateTimeStyles.AllowInnerWhite;

            //  #   Act.
            var res = Record.Exception(() =>
            {
                Abstractions.DateTime.Parse(s, anyFormatProvider, style.Value);
            });

            //  #   Assert.
            res.Should().BeOfType(exceptionType);
        }

        [Fact]
        public void ParseStringFormatProviderStylesShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetParseStringFormatProviderStyle(null);
            var anyDateTime = "2019-08-11 19:37";
            var anyFormatProvider = CultureInfo.InvariantCulture;
            var anyStyle = DateTimeStyles.AssumeUniversal;
            var expected = System.DateTime.Parse(anyDateTime, CultureInfo.InvariantCulture, anyStyle);
            var abstractionResult = Abstractions.DateTime.Parse(anyDateTime, CultureInfo.InvariantCulture, anyStyle);
            AssertEquals(expected, abstractionResult, because: "Sanity test that we know what we are testing.");
            var anyFakeDateTime = new System.DateTime(2);

            //  #   Act.
            Abstractions.DateTime.SetParseStringFormatProviderStyle((s, fp, st) => anyFakeDateTime);

            //  #   Assert.
            var actual = Abstractions.DateTime.Parse(anyDateTime, CultureInfo.InvariantCulture, anyStyle);
            AssertEquals(anyFakeDateTime, actual);

            //  #   Act.
            Abstractions.DateTime.SetParseStringFormatProviderStyle(null);

            //  #   Assert.
            actual = Abstractions.DateTime.Parse(anyDateTime, CultureInfo.InvariantCulture, anyStyle);
            AssertEquals(expected, actual);
        }

        #endregion

        #region Parse(string s, IFormatProvider provider) tests.

        [Fact]
        public void ParseStringFormatProviderShouldMimicSystemParse()
        {
            //  #   Arrange.
            var anyDateTime = "2019-08-11 13:41";
            var anyFormatProvider = CultureInfo.InvariantCulture;
            var expected = System.DateTime.Parse(anyDateTime, anyFormatProvider);

            //  #   Act.
            var res = Abstractions.DateTime.Parse(anyDateTime, anyFormatProvider);

            //  #   Assert.
            AssertEquals(expected, res);
        }

        [Theory]
        [InlineData(null, typeof(System.ArgumentNullException))]
        [InlineData("no valid date", typeof(System.FormatException))]
        public void ParseStringFormatProviderShouldThrowExceptionForBadData(string s, System.Type exceptionType)
        {
            //  #   Arrange.
            var anyFormatProvider = CultureInfo.InvariantCulture;

            //  #   Act.
            var res = Record.Exception(() =>
            {
                Abstractions.DateTime.Parse(s, anyFormatProvider);
            });

            //  #   Assert.
            res.Should().BeOfType(exceptionType);
        }

        [Fact]
        public void ParseStringFormatProviderShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetParseStringFormatProvider(null);
            var anyDateTime = "2019-08-11 19:37";
            var anyFormatProvider = CultureInfo.InvariantCulture;
            var expected = System.DateTime.Parse(anyDateTime, CultureInfo.InvariantCulture);
            var abstractionResult = Abstractions.DateTime.Parse(anyDateTime, CultureInfo.InvariantCulture);
            AssertEquals(expected, abstractionResult, because: "Sanity test that we know what we are testing.");
            var anyFakeDateTime = new System.DateTime(2);

            //  #   Act.
            Abstractions.DateTime.SetParseStringFormatProvider((s, fp) => anyFakeDateTime);

            //  #   Assert.
            var actual = Abstractions.DateTime.Parse(anyDateTime, CultureInfo.InvariantCulture);
            AssertEquals(anyFakeDateTime, actual);

            //  #   Act.
            Abstractions.DateTime.SetParseStringFormatProvider(null);

            //  #   Assert.
            actual = Abstractions.DateTime.Parse(anyDateTime, CultureInfo.InvariantCulture);
            AssertEquals(expected, actual);
        }

        #endregion

        #region Parse(string s, IFormatProvider provider) tests.

        [Fact]
        public void ParseStringShouldMimicSystemParse()
        {
            //  #   Arrange.
            var anyDateTime = "2019-08-11 13:41";
            var expected = System.DateTime.Parse(anyDateTime);

            //  #   Act.
            var res = Abstractions.DateTime.Parse(anyDateTime);

            //  #   Assert.
            AssertEquals(expected, res);
        }

        [Theory]
        [InlineData(null, typeof(System.ArgumentNullException))]
        [InlineData("no valid date", typeof(System.FormatException))]
        public void ParseStringShouldThrowExceptionForBadData(string s, System.Type exceptionType)
        {
            //  #   Act.
            var res = Record.Exception(() =>
            {
                Abstractions.DateTime.Parse(s);
            });

            //  #   Assert.
            res.Should().BeOfType(exceptionType);
        }

        [Fact]
        public void ParseStringShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetParseString(null);
            var anyDateTime = "2019-08-11 19:37";
            var expected = System.DateTime.Parse(anyDateTime);
            var abstractionResult = Abstractions.DateTime.Parse(anyDateTime);
            AssertEquals(expected, abstractionResult, because: "Sanity test that we know what we are testing.");
            var anyFakeDateTime = new System.DateTime(2);

            //  #   Act.
            Abstractions.DateTime.SetParseString((s) => anyFakeDateTime);

            //  #   Assert.
            var actual = Abstractions.DateTime.Parse(anyDateTime);
            AssertEquals(anyFakeDateTime, actual);

            //  #   Act.
            Abstractions.DateTime.SetParseString(null);

            //  #   Assert.
            actual = Abstractions.DateTime.Parse(anyDateTime);
            AssertEquals(expected, actual);
        }

        #endregion

        #region ParseExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style) tests.

        [Fact]
        public void ParseExactStringStringArrayFormatProviderStylesShouldMimicSystemParse()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetParseExactStringStringArrayFormatProviderStyle(null);
            var anyDateTimeString = "2019-08-11 13:41";
            var anyFormat = "yyyy-MM-dd HH:mm";
            var anyFormatProvider = CultureInfo.InvariantCulture;
            var anyStyle = DateTimeStyles.AllowInnerWhite;
            var expected = System.DateTime.ParseExact(anyDateTimeString, new[] { anyFormat }, anyFormatProvider, anyStyle);

            //  #   Act.
            var res = Abstractions.DateTime.ParseExact(anyDateTimeString, new[] { anyFormat }, anyFormatProvider, anyStyle);

            //  #   Assert.
            AssertEquals(expected, res);
        }

        [Theory]
        [InlineData(null, "yyyy-MM-dd HH:mm", null, typeof(System.ArgumentNullException))]
        [InlineData("", "yyyy-MM-dd HH:mm", null, typeof(System.FormatException))]
        [InlineData("no valid date", "", null, typeof(System.FormatException))]
        [InlineData("no valid date", "yyyy-MM-dd HH:mm", null, typeof(System.FormatException))]
        [InlineData("2019-08-11 19:31", null, DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal, typeof(System.ArgumentException))]
        [InlineData("2019-08-11 19:31", "yyyy-MM-dd HH:mm", DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal, typeof(System.ArgumentException))]
        public void ParseExactStringStringArrayFormatProviderStylesShouldThrowExceptionForBadData(string s, string format, DateTimeStyles? style, System.Type exceptionType)
        {
            //  #   Arrange.
            Abstractions.DateTime.SetParseExactStringStringArrayFormatProviderStyle(null);
            var anyFormatProvider = CultureInfo.InvariantCulture;
            style = style ?? DateTimeStyles.AllowInnerWhite;

            //  #   Act.
            var res = Record.Exception(() =>
            {
                Abstractions.DateTime.ParseExact(s, new[] { format }, anyFormatProvider, style.Value);
            });

            //  #   Assert.
            res.Should().BeOfType(exceptionType);
        }

        [Fact]
        public void ParseExactStringStringArrayFormatProviderStylesShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetParseExactStringStringArrayFormatProviderStyle(null);
            var anyDateTime = "2019-08-11 19:37";
            var anyFormat = "yyyy-MM-dd HH:mm";
            var anyFormatProvider = CultureInfo.InvariantCulture;
            var anyStyle = DateTimeStyles.AssumeUniversal;
            var expected = System.DateTime.ParseExact(anyDateTime, new[] { anyFormat }, CultureInfo.InvariantCulture, anyStyle);
            var abstractionResult = Abstractions.DateTime.ParseExact(anyDateTime, new[] { anyFormat }, CultureInfo.InvariantCulture, anyStyle);
            AssertEquals(expected, abstractionResult, because: "Sanity test that we know what we are testing.");
            var anyFakeDateTime = new System.DateTime(2);

            //  #   Act.
            Abstractions.DateTime.SetParseExactStringStringArrayFormatProviderStyle((s, sa, fp, st) => anyFakeDateTime);

            //  #   Assert.
            var actual = Abstractions.DateTime.ParseExact(anyDateTime, new[] { anyFormat }, CultureInfo.InvariantCulture, anyStyle);
            AssertEquals(anyFakeDateTime, actual);

            //  #   Act.
            Abstractions.DateTime.SetParseExactStringStringArrayFormatProviderStyle(null);

            //  #   Assert.
            actual = Abstractions.DateTime.ParseExact(anyDateTime, new[] { anyFormat }, CultureInfo.InvariantCulture, anyStyle);
            AssertEquals(expected, actual);
        }

        #endregion

        #region ParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style) tests.

        [Fact]
        public void ParseExactStringStringFormatProviderStylesShouldMimicSystemParse()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetParseExactStringStringFormatProviderStyle(null);
            var anyDateTimeString = "2019-08-11 13:41";
            var anyFormat = "yyyy-MM-dd HH:mm";
            var anyFormatProvider = CultureInfo.InvariantCulture;
            var anyStyle = DateTimeStyles.AllowInnerWhite;
            var expected = System.DateTime.ParseExact(anyDateTimeString, anyFormat, anyFormatProvider, anyStyle);

            //  #   Act.
            var res = Abstractions.DateTime.ParseExact(anyDateTimeString, anyFormat, anyFormatProvider, anyStyle);

            //  #   Assert.
            AssertEquals(expected, res);
        }

        [Theory]
        [InlineData(null, "yyyy-MM-dd HH:mm", null, typeof(System.ArgumentNullException))]
        [InlineData("", "yyyy-MM-dd HH:mm", null, typeof(System.FormatException))]
        [InlineData("no valid date", "", null, typeof(System.FormatException))]
        [InlineData("no valid date", "yyyy-MM-dd HH:mm", null, typeof(System.FormatException))]
        [InlineData("2019-08-11 19:31", null, DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal, typeof(System.ArgumentException))]
        [InlineData("2019-08-11 19:31", "yyyy-MM-dd HH:mm", DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal, typeof(System.ArgumentException))]
        public void ParseExactStringStringFormatProviderStylesShouldThrowExceptionForBadData(string s, string format, DateTimeStyles? style, System.Type exceptionType)
        {
            //  #   Arrange.
            Abstractions.DateTime.SetParseExactStringStringFormatProviderStyle(null);
            var anyFormatProvider = CultureInfo.InvariantCulture;
            style = style ?? DateTimeStyles.AllowInnerWhite;

            //  #   Act.
            var res = Record.Exception(() =>
            {
                Abstractions.DateTime.ParseExact(s, format, anyFormatProvider, style.Value);
            });

            //  #   Assert.
            res.Should().BeOfType(exceptionType);
        }

        [Fact]
        public void ParseExactStringStringFormatProviderStylesShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetParseExactStringStringFormatProviderStyle(null);
            var anyDateTime = "2019-08-11 19:37";
            var anyFormat = "yyyy-MM-dd HH:mm";
            var anyFormatProvider = CultureInfo.InvariantCulture;
            var anyStyle = DateTimeStyles.AssumeUniversal;
            var expected = System.DateTime.ParseExact(anyDateTime, anyFormat, CultureInfo.InvariantCulture, anyStyle);
            var abstractionResult = Abstractions.DateTime.ParseExact(anyDateTime, anyFormat, CultureInfo.InvariantCulture, anyStyle);
            AssertEquals(expected, abstractionResult, because: "Sanity test that we know what we are testing.");
            var anyFakeDateTime = new System.DateTime(2);

            //  #   Act.
            Abstractions.DateTime.SetParseExactStringStringFormatProviderStyle((s, sa, fp, st) => anyFakeDateTime);

            //  #   Assert.
            var actual = Abstractions.DateTime.ParseExact(anyDateTime, anyFormat, CultureInfo.InvariantCulture, anyStyle);
            AssertEquals(anyFakeDateTime, actual);

            //  #   Act.
            Abstractions.DateTime.SetParseExactStringStringFormatProviderStyle(null);

            //  #   Assert.
            actual = Abstractions.DateTime.ParseExact(anyDateTime, anyFormat, CultureInfo.InvariantCulture, anyStyle);
            AssertEquals(expected, actual);
        }

        #endregion

        #region ParseExact(string s, string format, IFormatProvider provider) tests.

        [Fact]
        public void ParseExactStringStringFormatProviderShouldMimicSystemParse()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetParseExactStringStringFormatProvider(null);
            var anyDateTimeString = "2019-08-11 13:41";
            var anyFormat = "yyyy-MM-dd HH:mm";
            var anyFormatProvider = CultureInfo.InvariantCulture;
            var expected = System.DateTime.ParseExact(anyDateTimeString, anyFormat, anyFormatProvider);

            //  #   Act.
            var res = Abstractions.DateTime.ParseExact(anyDateTimeString, anyFormat, anyFormatProvider);

            //  #   Assert.
            AssertEquals(expected, res);
        }

        [Theory]
        [InlineData(null, "yyyy-MM-dd HH:mm", typeof(System.ArgumentNullException))]
        [InlineData("", "yyyy-MM-dd HH:mm", typeof(System.FormatException))]
        [InlineData("no valid date", "", typeof(System.FormatException))]
        [InlineData("no valid date", "yyyy-MM-dd HH:mm", typeof(System.FormatException))]
        [InlineData("2019-08-11 19:31", "", typeof(System.FormatException))]
        [InlineData("2019-08-11 19:31", "xxx", typeof(System.FormatException))]
        public void ParseExactStringStringFormatProviderShouldThrowExceptionForBadData(string s, string format, System.Type exceptionType)
        {
            //  #   Arrange.
            Abstractions.DateTime.SetParseExactStringStringFormatProvider(null);
            var anyFormatProvider = CultureInfo.InvariantCulture;

            //  #   Act.
            var res = Record.Exception(() =>
            {
                Abstractions.DateTime.ParseExact(s, format, anyFormatProvider);
            });

            //  #   Assert.
            res.Should().BeOfType(exceptionType);
        }

        [Fact]
        public void ParseExactStringStringFormatProviderShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetParseExactStringStringFormatProvider(null);
            var anyDateTime = "2019-08-11 19:37";
            var anyFormat = "yyyy-MM-dd HH:mm";
            var anyFormatProvider = CultureInfo.InvariantCulture;
            var expected = System.DateTime.ParseExact(anyDateTime, anyFormat, CultureInfo.InvariantCulture);
            var abstractionResult = Abstractions.DateTime.ParseExact(anyDateTime, anyFormat, CultureInfo.InvariantCulture);
            AssertEquals(expected, abstractionResult, because: "Sanity test that we know what we are testing.");
            var anyFakeDateTime = new System.DateTime(2);

            //  #   Act.
            Abstractions.DateTime.SetParseExactStringStringFormatProvider((s, sa, fp) => anyFakeDateTime);

            //  #   Assert.
            var actual = Abstractions.DateTime.ParseExact(anyDateTime, anyFormat, CultureInfo.InvariantCulture);
            AssertEquals(anyFakeDateTime, actual);

            //  #   Act.
            Abstractions.DateTime.SetParseExactStringStringFormatProvider(null);

            //  #   Assert.
            actual = Abstractions.DateTime.ParseExact(anyDateTime, anyFormat, CultureInfo.InvariantCulture);
            AssertEquals(expected, actual);
        }

        #endregion

        #region SpecifyKind(DateTime value, DateTimeKind kind) tests.

        [Fact]
        public void SpecifyKindShouldMimicSystemSpecifyKind()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetSpecifyKind(null);
            var anyTicks = 42;
            var anyDateTimeKind = System.DateTimeKind.Local;
            var expectedDateTimeKind = System.DateTimeKind.Utc;

            var anyDateTime = new Abstractions.DateTime(anyTicks, anyDateTimeKind);

            //  #   Act.
            var actual = Abstractions.DateTime.SpecifyKind(anyDateTime, expectedDateTimeKind);

            //  #   Assert.
            actual.Ticks.Should().Be(anyDateTime.Ticks);
            actual.Kind.Should().Be(expectedDateTimeKind);
        }

        [Fact]
        public void SpecifyKindShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetSpecifyKind(null);
            var anyDateTime = new Abstractions.DateTime(42, System.DateTimeKind.Local);
            anyDateTime.Kind.Should().Be(System.DateTimeKind.Local, "Sanity test we have a special DateTimeKind.");
            var anyOtherDateTimeKind = System.DateTimeKind.Utc;

            //  #   Act.
            Abstractions.DateTime.SetSpecifyKind(() => anyOtherDateTimeKind);

            //  #   Assert.
            var res = Abstractions.DateTime.SpecifyKind(anyDateTime, System.DateTimeKind.Local);
            res.Kind.Should().Be(System.DateTimeKind.Utc);

            //  #   Act.
            Abstractions.DateTime.SetSpecifyKind(null);

            //  #   Assert.
            res = Abstractions.DateTime.SpecifyKind(anyDateTime, System.DateTimeKind.Local);
            res.Kind.Should().Be(System.DateTimeKind.Local);
        }

        #endregion

        #region TryParse(string s, IFormatProvider provider, DateTimeStyles styles, out DateTime result) tests.

        [Fact]
        public void TryParseStringIForrmatProviderDateTimeStylesDateTimeShouldMimicSystemTryParse()
        {
            //  #   Arrange.
            var anyDateTime = "2019-08-11 13:41";
            var anyFormatProvider = CultureInfo.InvariantCulture;
            var anyStyle = DateTimeStyles.AllowInnerWhite;
            var expected = System.DateTime.Parse(anyDateTime, anyFormatProvider, anyStyle);

            //  #   Act.
            var res = Abstractions.DateTime.TryParse(anyDateTime, anyFormatProvider, anyStyle, out var result);

            //  #   Assert.
            res.Should().BeTrue();
            AssertEquals(expected, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("no valid date")]
        public void TryParseStringFormatProviderStylesShouldReturnFalseForBadInput(string s)
        {
            //  #   Arrange.
            var anyFormatProvider = CultureInfo.InvariantCulture;
            var anyStyle = DateTimeStyles.AllowInnerWhite;
            var expectedResult = System.DateTime.TryParse(s, anyFormatProvider, anyStyle, out var expected0ut);

            //  #   Act.
            var res = Abstractions.DateTime.TryParse(s, anyFormatProvider, anyStyle, out var resultOut);

            //  #   Assert.
            res.Should().BeFalse();
            res.Should().Be(expectedResult);
            AssertEquals(expected0ut, resultOut);
        }

        [Fact]
        public void TryParseStringIFormatProviderDateTimeStylesDateTimeShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetTryParseStringIFormatProviderDateTimeStylesDateTime(null, null);
            var anyDateTime = "2019-08-11 19:37";
            var anyFormatProvider = CultureInfo.InvariantCulture;
            var anyStyle = DateTimeStyles.AssumeUniversal;
            var expected = System.DateTime.TryParse(anyDateTime, CultureInfo.InvariantCulture, anyStyle, out var expectedOut);
            var abstractionResult = Abstractions.DateTime.TryParse(anyDateTime, CultureInfo.InvariantCulture, anyStyle, out var abstractionOut);
            expected.Should().BeTrue();
            expected.Should().Be(abstractionResult, because: "Sanity test that we know what we are testing.");
            AssertEquals(expectedOut, abstractionOut);
            var anyFakeDateTime = new System.DateTime(2);

            //  #   Act.
            Abstractions.DateTime.SetTryParseStringIFormatProviderDateTimeStylesDateTime(() => true, () => anyFakeDateTime);

            //  #   Assert.
            var actual = Abstractions.DateTime.TryParse("not even a date", CultureInfo.InvariantCulture, anyStyle, out var actualOut);
            actual.Should().BeTrue();
            AssertEquals(anyFakeDateTime, actualOut);

            //  #   Act.
            Abstractions.DateTime.SetTryParseStringIFormatProviderDateTimeStylesDateTime(null, null);

            //  #   Assert.
            actual = Abstractions.DateTime.TryParse(anyDateTime, CultureInfo.InvariantCulture, anyStyle, out actualOut);
            actual.Should().BeTrue();
            AssertEquals(expectedOut, actualOut);
        }

        #endregion

        #region TryParse(string s, out DateTime result) tests.

        [Fact]
        public void TryParseStringDateTimeShouldMimicSystemTryParse()
        {
            //  #   Arrange.
            var anyDateTime = "2019-08-11 13:41";
            var _ = System.DateTime.TryParse(anyDateTime, out var expected);

            //  #   Act.
            var res = Abstractions.DateTime.TryParse(anyDateTime, out var result);

            //  #   Assert.
            res.Should().BeTrue();
            AssertEquals(expected, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("no valid date")]
        public void TryParseStringShouldReturnFalseForBadInput(string s)
        {
            //  #   Arrange.
            var expectedResult = System.DateTime.TryParse(s, out var expected0ut);

            //  #   Act.
            var res = Abstractions.DateTime.TryParse(s, out var resultOut);

            //  #   Assert.
            res.Should().BeFalse();
            res.Should().Be(expectedResult);
            AssertEquals(expected0ut, resultOut);
        }

        [Fact]
        public void TryParseStringDateTimeShouldBeSettableAndResettable()
        {
            //  #   Arrange.
            Abstractions.DateTime.SetTryParseStringDateTime(null, null);
            var anyDateTime = "2019-08-11 19:37";
            var expected = System.DateTime.TryParse(anyDateTime, out var expectedOut);
            var abstractionResult = Abstractions.DateTime.TryParse(anyDateTime, out var abstractionOut);
            expected.Should().BeTrue();
            expected.Should().Be(abstractionResult, because: "Sanity test that we know what we are testing.");
            AssertEquals(expectedOut, abstractionOut);
            var anyFakeDateTime = new System.DateTime(2);

            //  #   Act.
            Abstractions.DateTime.SetTryParseStringDateTime(() => true, () => anyFakeDateTime);

            //  #   Assert.
            var actual = Abstractions.DateTime.TryParse("not even a date", out var actualOut);
            actual.Should().BeTrue();
            AssertEquals(anyFakeDateTime, actualOut);

            //  #   Act.
            Abstractions.DateTime.SetTryParseStringDateTime(null, null);

            //  #   Assert.
            actual = Abstractions.DateTime.TryParse(anyDateTime, out actualOut);
            actual.Should().BeTrue();
            AssertEquals(expectedOut, actualOut);
        }

        #endregion

        #region TryParseExact(string s, string format, IFormatProvider provider, DateTimeStyles style, out DateTime result) tests.

        [Fact]
        public void TryParseExact_StringStringIFormatProviderDateTimeStylesDateTime_ShouldMimicSystem()
        {
            Abstractions.DateTime.SetTryParseExactStringStringIFormatProviderDateTimeStyles(null, null);
            var anyDate = "2019-09-19 20:32";
            var anyFormat = "yyyy-MM-dd HH:mm";
            var anyProvider = CultureInfo.InvariantCulture;
            var anyDateTimeStyle = DateTimeStyles.None;
            var expectedReturn = System.DateTime.TryParseExact(anyDate, anyFormat, anyProvider, anyDateTimeStyle, out var expectedOut);

            //  Act.
            var actualReturn = Abstractions.DateTime.TryParseExact(anyDate, anyFormat, anyProvider, anyDateTimeStyle, out var actualOut);

            //  Assert.
            actualReturn.Should().BeTrue();
            actualReturn.Should().Be(expectedReturn);
            AssertEquals(expectedOut, actualOut);
        }

        [Fact]
        public void TryParseExact_StringStringIFormatProviderDateTimeStylesDateTime_ShouldThrowOnInvalidDateTimeStyles()
        {
            Abstractions.DateTime.SetTryParseExactStringStringIFormatProviderDateTimeStyles(null, null);
            var anyDate = "2019-09-19 20:32";
            var anyFormat = "yyyy-MMdd HH:mm";
            var anyProvider = CultureInfo.InvariantCulture;
            var anInvalidDateTimeStyle = DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal;

            //  Act.
            //  #   Act.
            var res = Record.Exception(() =>
            {
                Abstractions.DateTime.TryParseExact(anyDate, anyFormat, anyProvider, anInvalidDateTimeStyle, out var _);
            });

            res.Should().BeOfType<System.ArgumentException>();
        }

        [Fact]
        public void SetTryParseExactStringStringIFormatProviderDateTimeStylesDateTime_ShouldSetAndClear()
        {
            Abstractions.DateTime.SetTryParseExactStringStringIFormatProviderDateTimeStyles(null, null);
            var anyDate = "2019-09-19 20:32";
            var anyFormat = "yyyy-MM-dd HH:mm";
            var anyProvider = CultureInfo.InvariantCulture;
            var anyDateTimeStyle = DateTimeStyles.None;
            var expectedReturn = System.DateTime.TryParseExact(anyDate, anyFormat, anyProvider, anyDateTimeStyle, out var expectedOut);
            // Sanity test we are reset.
            var actualReturn = Abstractions.DateTime.TryParseExact(anyDate, anyFormat, anyProvider, anyDateTimeStyle, out var actualOut);
            actualReturn.Should().BeTrue();
            actualReturn.Should().Be(expectedReturn);
            AssertEquals(expectedOut, actualOut);

            var anyOtherExpectedReturn = false;
            var anyOtherExpectedOut = System.DateTime.MinValue.AddDays(1);

            //  Act.
            Abstractions.DateTime.SetTryParseExactStringStringIFormatProviderDateTimeStyles(
                () => anyOtherExpectedReturn,
                () => anyOtherExpectedOut);

            //  Assert.
            actualReturn = Abstractions.DateTime.TryParseExact(anyDate, anyFormat, anyProvider, anyDateTimeStyle, out actualOut);
            actualReturn.Should().Be(anyOtherExpectedReturn);
            AssertEquals(anyOtherExpectedOut, actualOut);

            //  Act.
            Abstractions.DateTime.SetTryParseExactStringStringIFormatProviderDateTimeStyles(
                null,
                null);

            //  Assert.
            actualReturn = Abstractions.DateTime.TryParseExact(anyDate, anyFormat, anyProvider, anyDateTimeStyle, out actualOut);
            actualReturn.Should().BeTrue();
            actualReturn.Should().Be(expectedReturn);
            AssertEquals(expectedOut, actualOut);
        }

        #endregion

        #region TryParseExact(string s, string[] format, IFormatProvider provider, DateTimeStyles style, out DateTime result) tests.

        [Fact]
        public void TryParseExact_StringStringArrayIFormatProviderDateTimeStylesDateTime_ShouldMimicSystem()
        {
            Abstractions.DateTime.SetTryParseExactStringStringArrayIFormatProviderDateTimeStyles(null, null);
            var anyDate = "2019-09-19 20:32";
            var anyFormats = new[] { "yyyy-MM-dd HH:mm" };
            var anyProvider = CultureInfo.InvariantCulture;
            var anyDateTimeStyle = DateTimeStyles.None;
            var expectedReturn = System.DateTime.TryParseExact(anyDate, anyFormats, anyProvider, anyDateTimeStyle, out var expectedOut);

            //  Act.
            var actualReturn = Abstractions.DateTime.TryParseExact(anyDate, anyFormats, anyProvider, anyDateTimeStyle, out var actualOut);

            //  Assert.
            actualReturn.Should().BeTrue();
            actualReturn.Should().Be(expectedReturn);
            AssertEquals(expectedOut, actualOut);
        }

        [Fact]
        public void TryParseExact_StringStringArrayIFormatProviderDateTimeStylesDateTime_ShouldThrowOnInvalidDateTimeStyles()
        {
            Abstractions.DateTime.SetTryParseExactStringStringArrayIFormatProviderDateTimeStyles(null, null);
            var anyDate = "2019-09-19 20:32";
            var anyFormats = new[] { "yyyy-MMdd HH:mm" };
            var anyProvider = CultureInfo.InvariantCulture;
            var anInvalidDateTimeStyle = DateTimeStyles.AssumeLocal | DateTimeStyles.AssumeUniversal;

            //  Act.
            //  #   Act.
            var res = Record.Exception(() =>
            {
                Abstractions.DateTime.TryParseExact(anyDate, anyFormats, anyProvider, anInvalidDateTimeStyle, out var _);
            });

            res.Should().BeOfType<System.ArgumentException>();
        }

        [Fact]
        public void SetTryParseExactStringStringArrayIFormatProviderDateTimeStylesDateTime_ShouldSetAndClear()
        {
            Abstractions.DateTime.SetTryParseExactStringStringArrayIFormatProviderDateTimeStyles(null, null);
            var anyDate = "2019-09-19 20:32";
            var anyFormats = new[] { "yyyy-MM-dd HH:mm" };
            var anyProvider = CultureInfo.InvariantCulture;
            var anyDateTimeStyle = DateTimeStyles.None;
            var expectedReturn = System.DateTime.TryParseExact(anyDate, anyFormats, anyProvider, anyDateTimeStyle, out var expectedOut);
            // Sanity test we are reset.
            var actualReturn = Abstractions.DateTime.TryParseExact(anyDate, anyFormats, anyProvider, anyDateTimeStyle, out var actualOut);
            actualReturn.Should().BeTrue();
            actualReturn.Should().Be(expectedReturn);
            AssertEquals(expectedOut, actualOut);

            var anyOtherExpectedReturn = false;
            var anyOtherExpectedOut = System.DateTime.MinValue.AddDays(1);

            //  Act.
            Abstractions.DateTime.SetTryParseExactStringStringArrayIFormatProviderDateTimeStyles(
                () => anyOtherExpectedReturn,
                () => anyOtherExpectedOut);

            //  Assert.
            actualReturn = Abstractions.DateTime.TryParseExact(anyDate, anyFormats, anyProvider, anyDateTimeStyle, out actualOut);
            actualReturn.Should().Be(anyOtherExpectedReturn);
            AssertEquals(anyOtherExpectedOut, actualOut);

            //  Act.
            Abstractions.DateTime.SetTryParseExactStringStringArrayIFormatProviderDateTimeStyles(
                null,
                null);

            //  Assert.
            actualReturn = Abstractions.DateTime.TryParseExact(anyDate, anyFormats, anyProvider, anyDateTimeStyle, out actualOut);
            actualReturn.Should().BeTrue();
            actualReturn.Should().Be(expectedReturn);
            AssertEquals(expectedOut, actualOut);
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

        #region Instance method tests.

        #region Add tests.

        [Fact]
        public void Add_ShouldMimicSystem()
        {
            var anyTimeSpanTicks = 100;
            var anyDateTimeTicks = 200;

            var anyTimeSpan = new Abstractions.TimeSpan(anyTimeSpanTicks);
            var sut = new Abstractions.DateTime(anyDateTimeTicks);

            var anySystemTimeSpan = new System.TimeSpan(anyTimeSpanTicks);
            var anySystemDateTime = new System.DateTime(anyDateTimeTicks);
            var expectedResult = anySystemDateTime.Add(anySystemTimeSpan); ;

            //  Act.
            var res = sut.Add(anyTimeSpan);

            //  Assert.
            AssertEquals(expectedResult, res);
        }

        [Fact]
        public void Add_ShouldThrownIfOutOfRange()
        {
            var subtract = new Abstractions.TimeSpan(-1);
            var add = new Abstractions.TimeSpan(1);

            //  Act.
            var tooLowException = Record.Exception(() =>
            {
                Abstractions.DateTime.MinValue.Add(subtract);
            });
            var tooHighException = Record.Exception(() =>
            {
                Abstractions.DateTime.MaxValue.Add(add);
            });

            //  Assert.
            tooLowException.Should().BeOfType<System.ArgumentOutOfRangeException>();
            tooHighException.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        [Fact]
        public void SetAdd_ShouldSetAndClear()
        {
            var anyTimeSpanTicks = 100;
            var anyDateTimeTicks = 200;
            var fakeTicks = 300;

            var fakeDateTime = new Abstractions.DateTime(fakeTicks);
            var anyTimeSpan = new Abstractions.TimeSpan(anyTimeSpanTicks);

            var sut = new Abstractions.DateTime(anyDateTimeTicks);
            sut.SetAdd(null);

            var anySystemTimeSpan = new System.TimeSpan(anyTimeSpanTicks);
            var anySystemDateTime = new System.DateTime(anyDateTimeTicks);
            var expectedResult = anySystemDateTime.Add(anySystemTimeSpan); ;
            var res = sut.Add(anyTimeSpan);
            // Sanity check we get system result to start with.
            AssertEquals(expectedResult, res);

            // Act.
            sut.SetAdd(() => fakeDateTime);

            //  Assert.
            sut.Add(anyTimeSpan).Should().Be(fakeDateTime);

            //  Act.
            sut.SetAdd(null);

            // Assert.
            AssertEquals(expectedResult, sut.Add(anyTimeSpan));
        }

        #endregion

        #region AddDays tests.

        #region Add tests.

        [Fact]
        public void AddDays_ShouldMimicSystem()
        {
            var anyDateTimeTicks = 200;
            var anyDays = 5.5d;

            var sut = new Abstractions.DateTime(anyDateTimeTicks);
            var systemDateTime = new System.DateTime(anyDateTimeTicks);

            //  Act.
            var res = sut.AddDays(anyDays);

            //  Assert.
            var expectedResult = systemDateTime.AddDays(anyDays);
            AssertEquals(expectedResult, res);
        }

        [Fact]
        public void AddDays_ShouldThrownIfOutOfRange()
        {
            var subtract = -1;
            var add = 1;

            //  Act.
            var tooLowException = Record.Exception(() =>
            {
                Abstractions.DateTime.MinValue.AddDays(subtract);
            });
            var tooHighException = Record.Exception(() =>
            {
                Abstractions.DateTime.MaxValue.AddDays(add);
            });

            //  Assert.
            tooLowException.Should().BeOfType<System.ArgumentOutOfRangeException>();
            tooHighException.Should().BeOfType<System.ArgumentOutOfRangeException>();
        }

        [Fact]
        public void SetAddDays_ShouldSetAndClear()
        {
            var anyDateTimeTicks = 200;
            var anyDays = 5.5;

            var fakeTicks = 300;
            var fakeDateTime = new Abstractions.DateTime(fakeTicks);

            var sut = new Abstractions.DateTime(anyDateTimeTicks);
            var systemDateTime = new System.DateTime(anyDateTimeTicks);

            sut.SetAdd(null);

            // Sanity check we get system result to start with.
            AssertEquals(
                systemDateTime.AddDays(anyDays),
                sut.AddDays(anyDays)
                );

            // Act.
            sut.SetAddDays(() => fakeDateTime);

            //  Assert.
            sut.AddDays(anyDays).Should().Be(fakeDateTime);

            //  Act.
            sut.SetAddDays(null);

            // Assert.
            AssertEquals(
                systemDateTime.AddDays(anyDays),
                sut.AddDays(anyDays)
            );
        }

        #endregion

        #endregion

        #endregion // Instance method tests.

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
