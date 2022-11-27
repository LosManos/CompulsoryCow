using CompulsoryCow;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MetaTest;

public class GetPublicPropertiesFromTypeTests
{
    [Fact]
    public void GetPublicProperties_Should_throw_When_null_argument()
    {
        var res = Record.Exception(() =>
        {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var _ = Meta.GetPublicProperties(null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
        });

        res.Should().BeOfType<ArgumentNullException>();
    }

    [Fact]
    public void GetPublicProperties_Should_only_return_public_propertes()
    {
        var res = Meta.GetPublicProperties(typeof(VariousVisibility));

        res.Select(p => p.Name)
            .Should().BeEquivalentTo(new[] { "MyPublicProperty" });
    }

#pragma warning disable IDE0051 // Remove unused private members
    public class VariousVisibility
    {
        private int MyPrivateProperty { get; set; }
        internal int MyInternalProperty { get; set; }
        public int MyPublicProperty { get; set; }
        private static int MyStaticPrivateProperty { get; set; }
        internal static int MyStaticInternalProperty { get; set; }
        public static int MyStaticPublicProperty { get; set; }
    }
#pragma warning restore IDE0051 // Remove unused private members

    [Fact]
    public void GetPublicProperties_Should_be_able_to_recurse()
    {
        //  Act.
        var res = Meta.GetPublicProperties(typeof(Owner), recurse: true);

        //  Assert.
        res.Length.Should().Be(12);
        res.Select(p => p.Name)
            .Should().BeEquivalentTo(
            new[] { "MyPropertyOwner", "MyNullablePropertyOwner", "MyContent", "MyContentArray", "MyContentEnumerable", "MyContentIList", "MyContentList", "MyPropertyContent", "MyPropertyContent", "MyPropertyContent", "MyPropertyContent", "MyPropertyContent" }
            );
    }

    [Fact]
    public void GetPublicProperties_Should_be_able_to_not_recurse_When_set_to_not_recurse()
    {
        //  Act.
        var res = Meta.GetPublicProperties(typeof(Owner), recurse: false);

        //  Assert.
        res.Length.Should().Be(7);
        res.Select(p => p.Name).Should().BeEquivalentTo(
            new[] { "MyPropertyOwner", "MyNullablePropertyOwner", "MyContent", "MyContentArray", "MyContentEnumerable", "MyContentIList", "MyContentList" }
            );
    }

    [Fact]
    public void GetPublicProperties_Should_be_able_to_return_distinct_When_set_to_distinct()
    {
        //  Act.
        var res = Meta.GetPublicProperties(typeof(Owner), recurse: true, distinct: true);

        //  Assert.
        res.Length.Should().Be(8);
        res.Select(p => p.Name).Should().BeEquivalentTo(
            new[] { "MyPropertyOwner", "MyNullablePropertyOwner", "MyContent", "MyContentArray", "MyContentEnumerable", "MyContentIList", "MyContentList", "MyPropertyContent" }
            );
    }

    public class Owner
    {
        public int MyPropertyOwner { get; set; }
        public int? MyNullablePropertyOwner { get; set; }
        public Content MyContent { get; set; } = new();
        public Content[] MyContentArray { get; set; } = Array.Empty<Content>();
        public IEnumerable<Content> MyContentEnumerable { get; set; } = Array.Empty<Content>();
        public IList<Content> MyContentIList { get; set; } = new List<Content>();
        public List<Content> MyContentList { get; set; } = new List<Content>();
    }

    public class Content
    {
        public int MyPropertyContent { get; set; }
    }
}
