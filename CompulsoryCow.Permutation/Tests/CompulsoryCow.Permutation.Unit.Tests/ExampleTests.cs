using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CompulsoryCow.Permutation.Unit.Tests;

public class ExampleTests
{
    [Theory]
    [MemberData(nameof(All_variations))]
    public void Example_usage_with_algorithm(MyDomain.PageEnum page, bool isLoggedOn, bool isAdmin, string inData)
    {
        //  #   Arragen.
        var sut = new MyDomain();

        //  #   Act.
        var res = sut.Authorise(page, isLoggedOn, isAdmin);

        //  #   Assert.
        // The assertion is sieved through an algorithm working the same way as production code
        // preferably without being too much of a copy.
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
    [MemberData(nameof(All_variations))]
    public void Example_usage_with_data(MyDomain.PageEnum page, bool isLoggedOn, bool isAdmin, string inDataString)
    {
        //  #   Arrange.
        var sut = new MyDomain();

        //  #   Act.
        var res = sut.Authorise(page, isLoggedOn, isAdmin);

        //  #   Assert.

        var expectedAuthorisation =
            All_authorised_input()
                .Any(data => data.IsMatch(page, isLoggedOn, isAdmin));

        if (expectedAuthorisation)
        {
            res.Should().BeTrue(inDataString);
        }
        else
        {
            res.Should().BeFalse(inDataString);
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
            Page = MyDomain.PageEnum.LandingPage,
        };

        // Only admins can read the admin page.
        yield return new InputData
        {
            Page = MyDomain.PageEnum.AdminPage,
            IsLoggedOn = true,
            IsAdmin = true
        };

        // Only requirement to read the content page is to be logged in.
        yield return new InputData
        {
            Page = MyDomain.PageEnum.ContentPage,
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
            new object[][]{
                new object[] { MyDomain.PageEnum.LandingPage, MyDomain.PageEnum.AdminPage, MyDomain.PageEnum.ContentPage },
                new object[] { false, true },
                new object[] { false, true }
        })
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

    /// <summary>All the input data to the testee are properties of this class.
    /// </summary>
    private class InputData
    {
        internal MyDomain.PageEnum? Page { get; set; }
        internal bool? IsLoggedOn { get; set; }
        internal bool? IsAdmin { get; set; }

        /// <summary>This method compares its parameters to its properties.
        /// Only non-null properties are interesting for comparison.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="isLoggedOn"></param>
        /// <param name="isAdmin"></param>
        /// <returns></returns>
        internal bool IsMatch(MyDomain.PageEnum page, bool isLoggedOn, bool isAdmin)
        {
            return
                (this.Page == null || this.Page == page) &&
                (this.IsLoggedOn == null || this.IsLoggedOn == isLoggedOn) &&
                (this.IsAdmin == null || this.IsAdmin == isAdmin);
        }
    }
}
