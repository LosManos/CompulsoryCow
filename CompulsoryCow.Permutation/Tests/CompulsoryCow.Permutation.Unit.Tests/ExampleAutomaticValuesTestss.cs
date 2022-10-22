using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static CompulsoryCow.Permutation.Unit.Tests.AuthorisationService;

namespace CompulsoryCow.Permutation.Unit.Tests;

public class ExampleAutomaticValuesTests
{
    public static IEnumerable<object[]> Variants()
    {
        return Permutation.Permutate(
            new object[][] {
                Permutation.AllItems<WebPage>(),
                Permutation.AllBools(),
                Permutation.AllBools(),
            })
            .Select(data =>
            {
                return new[] {
                    data.First(),
                    data.Skip(1).First(),
                    data.Skip(2).First()
                };
            });
    }

    [Theory]
    [MemberData(nameof(Variants))]
    public void Example_usage(WebPage page, bool isLoggedOn, bool isAdmin)
    {
        var sut = new AuthorisationService();

        //  # Act.
        var res = sut.Authorise(page, isLoggedOn, isAdmin);

        //  # Assert.
        res.Should().Be(expectedResult(page, isLoggedOn, isAdmin));

        static bool expectedResult(WebPage p, bool isL, bool isA)
        {
            if( p == WebPage.LandingPage)
            {
                return true;
            }
            if( p == WebPage.AdminPage && isL && isA)
            {
                return true;
            }
            if( p==WebPage.ContentPage && isL)
            {
                return true;
            }
            return false;
        }
    }
}
