using FluentAssertions;
using Xunit;
using Abstractions = CompulsoryCow.DateTime.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests;

public partial class DateTimeTests
{
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

    #region Now tests.

    // TODO:OF:Write a test that checks System.Now, like UtcNowShouldReturnSystemUtcNow does.

    /// <summary>This test is not deterministic.
    /// </summary>
    [Fact]
    public void NowShouldMimicSystem()
    {
        Abstractions.DateTime.SetNow(null);
        var systemBefore = System.DateTime.Now;
        var before = Abstractions.DateTime.Now;

        //  #   Act.
        var now = Abstractions.DateTime.Now;

        //  #   Assert.
        var after = Abstractions.DateTime.Now;
        var systemAfter = System.DateTime.Now;

        systemBefore.Ticks.Should().BeLessOrEqualTo(before.Ticks);
        before.Ticks.Should().BeLessOrEqualTo(now.Ticks);
        now.Ticks.Should().BeLessOrEqualTo(after.Ticks);
        after.Ticks.Should().BeLessOrEqualTo(systemAfter.Ticks);

        now.Kind.Should().Be(systemBefore.Kind);
    }

    /// <summary>This test is not deterministic.
    /// </summary>
    [Fact]
    public void ResetNowShouldReturnSystemNow()
    {
        //  #   Arrange.
        var anyTicks = AnyTicks();
        Abstractions.DateTime.SetNow(() => new Abstractions.DateTime(anyTicks));
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

    #region UtcNow tests.

    #region Today tests.

    /// <summary>This test is not deterministic.
    /// </summary>
    [Fact]
    public void TodayShouldReturnSystemToday()
    {
        //  #   Arrange.
        Abstractions.DateTime.SetToday(null);
        var before = System.DateTime.Today;

        //  #   Act.
        var now = Abstractions.DateTime.Today;

        //  #   Assert.
        var after = System.DateTime.Today;

        before.Ticks.Should().BeLessOrEqualTo(now.Ticks);
        now.Ticks.Should().BeLessOrEqualTo(after.Ticks);
    }

    [Fact]
    public void TodayShouldBeSettableAndResettable()
    {
        Abstractions.DateTime.SetToday(null);

        //  #   Assert.
        AssertEquals(System.DateTime.Today, Abstractions.DateTime.Today);

        //  #   Arrange.
        var anyTicks = AnyTicks();
        Abstractions.DateTime.SetToday(() => new Abstractions.DateTime(anyTicks));
        Abstractions.DateTime.Today.Ticks.Should().Be(anyTicks, "Sanity check we are setting the Today property.");

        //  #   Act.
        Abstractions.DateTime.SetToday(null);

        //  #   Assert.
        var before = System.DateTime.Today;
        var now = Abstractions.DateTime.Today;
        var after = System.DateTime.Today;
        before.Ticks.Should().BeLessOrEqualTo(now.Ticks);
        now.Ticks.Should().BeLessOrEqualTo(after.Ticks);
    }

    #endregion

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
        Abstractions.DateTime.SetUtcNow(() => new Abstractions.DateTime(anyTicks));

        //  #   Assert.
        Abstractions.DateTime.UtcNow.Ticks.Should().Be(anyTicks);
    }

    [Fact]
    public void ResetUtcNowShouldReturnSystemNow()
    {
        //  #   Arrange.
        var anyTicks = AnyTicks();
        Abstractions.DateTime.SetUtcNow(() => new Abstractions.DateTime(anyTicks));
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

}
