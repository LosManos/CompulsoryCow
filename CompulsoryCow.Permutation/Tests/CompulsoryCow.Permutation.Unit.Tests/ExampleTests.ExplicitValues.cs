using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CompulsoryCow.Permutation.Unit.Tests;

public class ExampleExplicitValuesTests
{
    [Theory]
    [MemberData(nameof(All_variations))]
    public void Example_usage_with_algorithm(AuthorisationService.WebPage page, bool isLoggedOn, bool isAdmin, string inData)
    {
        //  #   Arragen.
        var sut = new AuthorisationService();

        //  #   Act.
        var res = sut.Authorise(page, isLoggedOn, isAdmin);

        //  #   Assert.
        // The assertion is sieved through an algorithm working the same way as production code
        // preferably without being too much of a copy.

        // Everyone is authorised for the landing page.
        if (page == AuthorisationService.WebPage.LandingPage)
        {
            res.Should().BeTrue(inData);
        }

        // Only logged in admins are authorised for the admin page.
        // Every admin is naturally logged in, but that is also what we test, 
        // that no admin can be not-logged-in.
        else if (isLoggedOn && page == AuthorisationService.WebPage.AdminPage)
        {
            res.Should().Be(isAdmin, inData);
        }

        // The only requirement to reach the content page is to be logged in.
        else if (page == AuthorisationService.WebPage.ContentPage)
        {
            res.Should().Be(isLoggedOn, inData);
        }

        // Only the above variants should authorise access for a user.
        // All other variants should not authorise.
        else
        {
            res.Should().BeFalse(inData);
        }
    }

    [Theory]
    [MemberData(nameof(All_variations))]
    public void Example_usage_with_data(AuthorisationService.WebPage page, bool isLoggedOn, bool isAdmin, string inDataString)
    {
        //  #   Arrange.
        var sut = new AuthorisationService();

        //  #   Act.
        var res = sut.Authorise(page, isLoggedOn, isAdmin);

        //  #   Assert.

        var expectedAuthorisation =
            All_authorised_input()
                .Any(data => isMatch(data, page, isLoggedOn, isAdmin));

        res.Should().Be(expectedAuthorisation, inDataString);

        // Does a comparison of `data` (=possible authorised input combination)
        // with the real input 'p', 'isL' and 'isA'
        static bool isMatch(InputData data, AuthorisationService.WebPage p, bool isL, bool isA)
        {
            return
                (data.Page == null || data.Page == p) &&
                (data.IsLoggedOn == null || data.IsLoggedOn == isL) &&
                (data.IsAdmin == null || data.IsAdmin == isA);
        }
    }

    /// <summary>Returns a list of all input variants that yields to granted authorisation.
    /// Properties left out (==null) of each returned item is not of interest.
    /// </summary>
    /// <returns></returns>
    private static IEnumerable<InputData> All_authorised_input()
    {
        // Everyone can read the landing page.
        yield return new InputData
        {
            Page = AuthorisationService.WebPage.LandingPage,
        };

        // Only admins can read the admin page.
        yield return new InputData
        {
            Page = AuthorisationService.WebPage.AdminPage,
            IsLoggedOn = true,
            IsAdmin = true
        };

        // Only requirement to read the content page is to be logged in.
        yield return new InputData
        {
            Page = AuthorisationService.WebPage.ContentPage,
            IsLoggedOn = true,
        };
    }

    /// <summary>Returns all variations/permutations of all possible input to the testee.
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<object[]> All_variations()
    {
        // First permutate all possible input.
        return Permutation.Permutate(
                new object[] { AuthorisationService.WebPage.LandingPage, AuthorisationService.WebPage.AdminPage, AuthorisationService.WebPage.ContentPage },
                new object[] { false, true },
                new object[] { false, true }
        )
        // Then convert to a format usable by the test.
        .Select(data =>
        {
            var page = data.First();
            var isLoggedOn = data.Skip(1).First();
            var isAdmin = data.Skip(2).Single();
            return new[]
            {
                // Return the test input.
                page,
                isLoggedOn,
                isAdmin,
                // And a reason/because for the test to output if fail.
                $"Page={page}, IsLoggedOn={isLoggedOn}, IsAdmin={isAdmin}."
            };
        });
    }

    private class InputData
    {
        internal AuthorisationService.WebPage? Page { get; set; }
        internal bool? IsLoggedOn { get; set; }
        internal bool? IsAdmin { get; set; }
    }
}
