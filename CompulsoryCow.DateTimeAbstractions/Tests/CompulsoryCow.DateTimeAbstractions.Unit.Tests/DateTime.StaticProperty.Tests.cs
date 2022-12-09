using Xunit;
using Abstractions = CompulsoryCow.DateTime.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests;

public partial class DateTimeTests
{
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

}
