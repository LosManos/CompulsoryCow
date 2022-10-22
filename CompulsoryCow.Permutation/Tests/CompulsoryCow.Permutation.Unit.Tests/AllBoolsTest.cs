using FluentAssertions;
using Xunit;

namespace CompulsoryCow.Permutation.Unit.Tests;

public class AllBoolsTest
{
    [Fact]
    public void AllBools_Should_return_both_true_and_false()
    {
        var res = Permutation.AllBools();

        // The result should be both true and fals in any order.
        var all = new[] { false, true };
        res.Should().BeEquivalentTo(all);
    }
}
