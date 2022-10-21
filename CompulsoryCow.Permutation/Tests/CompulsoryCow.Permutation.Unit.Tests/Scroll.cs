using FluentAssertions;
using System.Linq;
using Xunit;

namespace CompulsoryCow.Permutation.Unit.Tests;

public class Scroll
{
    [Fact]
    public void CanScroll()
    {
        string value = "<script>";
        string defaultValue = "x";
        const int size = 5;

        //  Act.
        var res = Permutation.Scroll(value, defaultValue, size);

        //  Assert.
        var result = res.ToList();
        result.Count().Should().Be(size);
        result[0].Should().BeEquivalentTo(new[] { value, defaultValue, defaultValue, defaultValue, defaultValue });
        result[0].Should().BeEquivalentTo(new[] { defaultValue, value, defaultValue, defaultValue, defaultValue });
        result[0].Should().BeEquivalentTo(new[] { defaultValue, defaultValue, value, defaultValue, defaultValue });
        result[0].Should().BeEquivalentTo(new[] { defaultValue, defaultValue, defaultValue, value, defaultValue });
        result[0].Should().BeEquivalentTo(new[] { defaultValue, defaultValue, defaultValue, defaultValue, value });
    }
}
