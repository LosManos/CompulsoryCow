using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CompulsoryCow.Permutation.Unit.Tests;

public class IEnumerableIEnumerableObjectExtensionTests : IClassFixture<Context>
{
    private readonly Context context;

    public IEnumerableIEnumerableObjectExtensionTests(Context contextData)
    {
        this.context = contextData;
    }

    public static IEnumerable<object[]> TestData()
    {
        IEnumerable<IEnumerable<object>> res = Permutation.Permutate(
            new object[] { 1, 2 },
            new object[] { "a", "b" }
        );

        //  This line is the test, `ToTestData`.
        return res.ToTestData();
    }

    /// <summary>This test makes sure we run through all permuataions
    /// of the test data. It is done by recording all test data and then verify
    /// it against a known list. The verification/assert is done in the context's
    /// Dispose method.
    /// </summary>
    /// <param name="n"></param>
    /// <param name="s"></param>
    [Theory]
    [MemberData(nameof(TestData))]
    public void Should_return_all_permutations(int n, string s)
    {
        context.Use((n, s));

        //  Assert is done in the Context Dispose.
    }
}

public class Context : IDisposable
{
    // Since we cannot know in which order the testdata is received
    // we have a list of all possible testdata and tick them off
    // for every test. That way we can verify all testdata are passed uniquely.
    // Finally we use the Dispose method, that runs after all tests in the class,
    // to verify all testdata are used up.
    private readonly List<(int, string)> expectedTestdata = new List<(int, string)>
    {
        (1,"a"),
        (1,"b"),
        (2,"a"),
        (2,"b"),
    };

    private readonly List<(int, string)> actualTestdata = new List<(int, string)>();

    public void Dispose()
    {
        actualTestdata.Should().BeEquivalentTo(expectedTestdata, 
            "All testdata should be accounted for, no more, no less.");
    }

    public void Use((int,string) testdata)
    {
        actualTestdata.Add(testdata);
    }
}
