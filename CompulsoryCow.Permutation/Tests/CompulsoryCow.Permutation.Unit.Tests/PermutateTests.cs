using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CompulsoryCow.Permutation.Unit.Tests;

public class PermutateTests
{
    [Fact]
    public void Can_Permutate()
    {
        //  #   Arrange
        var parametersCollection = new object[][]
            {
                new object[]{1,2},
                new string[]{"a", "b", "c"},
            };

        //  #   Act.
        var res = Permutation.Permutate(parametersCollection);

        //  #   Assert.
        res.Should().BeEquivalentTo(
            new[]{
                new object[]{1,"a"},
                new object[]{1,"b"},
                new object[]{1,"c"},
                new object[]{2,"a"},
                new object[]{2,"b"},
                new object[]{2,"c"},
        });
    }

    [Fact]
    public void Can_Pemutate_only_one_parameter()
    {
        //  #   Arrange.
        var parametersCollection = new object[][]
            {
                new object[]{3,4}
            };

        //  #   Act.
        var res = Permutation.Permutate(
            parametersCollection
        );

        //  #   Assert.
        res.Should().BeEquivalentTo(
            new[]
            {
                new []{3},
                new []{4},
            }
        );
    }
}
