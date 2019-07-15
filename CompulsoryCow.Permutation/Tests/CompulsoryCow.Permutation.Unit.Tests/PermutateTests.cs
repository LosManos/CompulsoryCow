using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CompulsoryCow.Permutation.Unit.Tests
{
    public class PermutateTests
    {
        [Fact]
        public void CanPermutate()
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
        public void CanPemutateOnlyOneParameter()
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

        [Theory]
        [MemberData(nameof(AllVariations))]
        public void ExampleUsageWithAlgorithm(MyDomain.PageEnum page, bool isLoggedOn, bool isAdmin, string inData)
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
            } else if (isLoggedOn && page == MyDomain.PageEnum.AdminPage)
            {
                res.Should().Be(isAdmin, inData);
            } else if (page == MyDomain.PageEnum.ContentPage)
            {
                res.Should().Be(isLoggedOn, inData);
            } else
            {
                res.Should().BeFalse(inData);
            }
        }
        
        [Theory]
        [MemberData(nameof(AllVariations))]
        public void ExampleUsageWithData(MyDomain.PageEnum page, bool isLoggedOn, bool isAdmin, string inDataString)
        {
            //  #   Arrange.
            var sut = new MyDomain();

            //  #   Act.
            var res = sut.Authorise(page, isLoggedOn, isAdmin);

            //  #   Assert.

            var isMatch =
                AllValidData()
                    .Any(data => data.IsMatch(page, isLoggedOn, isAdmin));
            if( isMatch)
            {
                res.Should().BeTrue(inDataString);
            }
            else
            {
                res.Should().BeFalse(inDataString);
            }
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
    }
}
