using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CompulsoryCow.Permutation.Unit.Tests;

public class ExampleTests
{
    [Theory]
    [MemberData(nameof(AllVariations))]
    public void Example_usage_with_algorithm(MyDomain.PageEnum page, bool isLoggedOn, bool isAdmin, string inData)
    {
        //  #   Arragen.
        var sut = new MyDomain();

        //  #   Act.
        var res = sut.Authorise(page, isLoggedOn, isAdmin);

        //  #   Assert.
        // The assertion is sieved through an algorithm working the same way as production code
        // preferably without being a copy.
        if (page == MyDomain.PageEnum.LandingPage)
        {
            res.Should().BeTrue(inData);
        }
        else if (isLoggedOn && page == MyDomain.PageEnum.AdminPage)
        {
            res.Should().Be(isAdmin, inData);
        }
        else if (page == MyDomain.PageEnum.ContentPage)
        {
            res.Should().Be(isLoggedOn, inData);
        }
        else
        {
            res.Should().BeFalse(inData);
        }
    }

    [Theory]
    [MemberData(nameof(AllVariations))]
    public void Example_usage_with_data(MyDomain.PageEnum page, bool isLoggedOn, bool isAdmin, string inDataString)
    {
        //  #   Arrange.
        var sut = new MyDomain();

        //  #   Act.
        var res = sut.Authorise(page, isLoggedOn, isAdmin);

        //  #   Assert.

        var isMatch =
            AllValidData()
                .Any(data => data.IsMatch(page, isLoggedOn, isAdmin));
        if (isMatch)
        {
            res.Should().BeTrue(inDataString);
        }
        else
        {
            res.Should().BeFalse(inDataString);
        }
    }

    private static IEnumerable<ValidData> AllValidData()
    {
        yield return new ValidData
        {
            Page = MyDomain.PageEnum.LandingPage,
        };
        yield return new ValidData
        {
            Page = MyDomain.PageEnum.AdminPage,
            IsLoggedOn = true,
            IsAdmin = true
        };
        yield return new ValidData
        {
            Page = MyDomain.PageEnum.ContentPage,
            IsLoggedOn = true,
        };
    }

    public static IEnumerable<object[]> AllVariations()
    {
        return Permutation.Permutate(
            new object[][]{
                new object[] { MyDomain.PageEnum.LandingPage, MyDomain.PageEnum.AdminPage, MyDomain.PageEnum.ContentPage },
                new object[] { false, true },
                new object[] { false, true }
        })
        .Select(data =>
        {
            var page = data.First();
            var isLoggedOn = data.Skip(1).First();
            var isAdmin = data.Skip(2).Single();
            return new[]
            {
                page,
                isLoggedOn,
                isAdmin,
                $"Page={page}, IsLoggedOn={isLoggedOn}, IsAdmin={isAdmin}."
            };
        });
    }

    private class ValidData
    {
        internal MyDomain.PageEnum? Page { get; set; }
        internal bool? IsLoggedOn { get; set; }
        internal bool? IsAdmin { get; set; }
        internal bool IsMatch(MyDomain.PageEnum page, bool isLoggedOn, bool isAdmin)
        {
            return
                (this.Page == null || this.Page == page) &&
                (this.IsLoggedOn == null || this.IsLoggedOn == isLoggedOn) &&
                (this.IsAdmin == null || this.IsAdmin == isAdmin);
        }
    }
}
