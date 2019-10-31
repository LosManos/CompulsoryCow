using FluentAssertions;
using Xunit;
using Abstractions = CompulsoryCow.DateTime.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests
{
    public partial class DateTimeTests
    {
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
   }
}
