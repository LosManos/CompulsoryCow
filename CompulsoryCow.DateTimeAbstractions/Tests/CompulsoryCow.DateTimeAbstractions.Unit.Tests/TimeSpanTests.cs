using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using Abstractions = CompulsoryCow.DateTime.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests;

public class TimeSpanTests : TestsBase
{
    public TimeSpanTests(ITestOutputHelper output)
        : base(output)
    { }

    [Fact]
    public void Constructor_Ticks_Kind_ShouldCreate()
    {
        //  #   Arrange.
        var anyTicks = AnyTicks();
        var systemTimeSpan = new System.TimeSpan(anyTicks);

        //  #   Act.
        var sut = new Abstractions.TimeSpan(anyTicks);

        //  #   Assert.
        AssertEquals(systemTimeSpan, sut);
    }

    [Fact]
    public void Constructor_Days_Hours_Minutes_Seconds_Milliseconds_ShouldCreate()
    {
        //  #   Arrange.
        var anyDays = 11;
        var anyHours = 12;
        var anyMinutes = 34;
        var anySeconds = 45;
        var anyMilliseconds = 123;
        var systemTimeSpan = new System.TimeSpan(anyDays, anyHours, anyMinutes, anySeconds, anyMilliseconds);

        //  #   Act.
        var sut = new Abstractions.TimeSpan(anyDays, anyHours, anyMinutes, anySeconds, anyMilliseconds);

        //  #   Assert.
        AssertEquals(systemTimeSpan, sut);
    }

    /// <summary>This method only tests for the Ticks property.
    /// Rewrite it to test for all properties like DateTime.
    /// </summary>
    [Fact]
    [System.Obsolete("Should be replaced by GettersShouldReturnRespectiveValue")]
    public void GetTicks()
    {
        //  #   Arrange.
        var anyTicks = AnyTicks();

        //  #   Act.
        var sut = new Abstractions.TimeSpan(anyTicks);

        //  #   Assert.
        sut.Ticks.Should().Be(anyTicks);
    }

    [Fact]
    public void GettersShouldReturnRespectiveValue()
    {
        //  #   Arrange.
        var anyDays = 11;
        var anyHours = 12;
        var anyMinutes = 34;
        var anySeconds = 45;
        var anyMilliseconds = 123;
        var sut = new Abstractions.TimeSpan(anyDays, anyHours, anyMinutes, anySeconds, anyMilliseconds);
        var systemTimeSpan = new System.TimeSpan(anyDays, anyHours, anyMinutes, anySeconds, anyMilliseconds);

        //  #   Act and Assert.
        sut.TotalMilliseconds.Should().Be(systemTimeSpan.TotalMilliseconds);
        sut.TotalHours.Should().Be(systemTimeSpan.TotalHours);
        sut.TotalDays.Should().Be(systemTimeSpan.TotalDays);
        sut.Ticks.Should().Be(systemTimeSpan.Ticks);
        sut.Seconds.Should().Be(anySeconds);
        sut.Minutes.Should().Be(anyMinutes);
        sut.Milliseconds.Should().Be(anyMilliseconds);
        sut.TotalMinutes.Should().Be(systemTimeSpan.TotalMinutes);
        sut.TotalSeconds.Should().Be(systemTimeSpan.TotalSeconds);
    }

    private static void AssertEquals(
        System.TimeSpan expected,
        Abstractions.TimeSpan actual,
        string because = "")
    {
        actual.TotalMilliseconds.Should().Be(expected.TotalMilliseconds, because);
        actual.TotalHours.Should().Be(expected.TotalHours, because);
        actual.TotalDays.Should().Be(expected.TotalDays, because);
        actual.Ticks.Should().Be(expected.Ticks, because);
        actual.Seconds.Should().Be(expected.Seconds, because);
        actual.Minutes.Should().Be(expected.Minutes, because);
        actual.Milliseconds.Should().Be(expected.Milliseconds, because);
        actual.Hours.Should().Be(expected.Hours, because);
        actual.Days.Should().Be(expected.Days, because);
        actual.TotalMinutes.Should().Be(expected.TotalMinutes, because);
        actual.TotalSeconds.Should().Be(expected.TotalSeconds, because);
    }
}
