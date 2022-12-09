using FluentAssertions;
using System.Linq;
using Xunit.Abstractions;
using Abstractions = CompulsoryCow.DateTime.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests;

public abstract class DateTimeTestsBase : TestsBase 
{
    public DateTimeTestsBase(ITestOutputHelper output)
        :base(output)
    {
    }

    protected internal System.DateTimeKind AnyKind()
    {
        return _pr.Enum<System.DateTimeKind>();
    }

    protected internal System.DateTimeKind AnyKindExcept(System.DateTimeKind exceptKind)
    {
        return _pr.EnumExcept(exceptKind);
    }

    protected internal static void AssertEquals(
        System.TimeSpan expected,
        Abstractions.TimeSpan actual,
        string because = "")
    {
        expected.Ticks.Should().Be(actual.Ticks, because);
    }

    protected internal static void AssertEquals(
        System.DateTime expectedDateTime,
        Abstractions.IDateTime actualDateTime,
        System.DateTimeKind? withKind = null,
        string because = "")
    {
        // TODO:OF:Check for all properties.
        actualDateTime.Ticks.Should().Be(expectedDateTime.Ticks, because);
        actualDateTime.Kind.Should().Be(
            withKind ?? expectedDateTime.Kind,
            because);
    }

    protected internal static System.DateTimeKind MaxDateTimeKind()
    {
        return (System.DateTimeKind)System.Enum.GetValues(typeof(System.DateTimeKind)).Cast<int>().Max();
    }
}
