using FluentAssertions;
using System.Linq;
using Xunit;

namespace CompulsoryCow.Permutation.Unit.Tests;

public class ScrollTests
{
    [Fact]
    public void Can_Scroll()
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
