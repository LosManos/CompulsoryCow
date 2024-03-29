﻿using FluentAssertions;
using System;
using Xunit;

namespace CompulsoryCow.Permutation.Unit.Tests;

public class AllIEnumItemsTests
{
    public enum MyEnum
    {
        One,
        Two,
    }

    [Fact]
    public void AllEnumItems_Should_throw_exception_if_not_an_enum()
    {
        //  Act.
        var res = Record.Exception(() =>
        {
            var res = Permutation.AllIEnumItems<EnumLookAlikeClass>();
        });

        res.Should().BeOfType(typeof(ArgumentException));
    }

    [Fact]
    public void AllIEnumtems_Should_return_all_items_Given_an_enum()
    {
        var expectednumName = typeof(MyEnum).Name;
        var expectedEnumLength = Enum.GetValues(typeof(MyEnum)).Length;

        //  Act.
        var res = Permutation.AllIEnumItems<MyEnum>();

        //  Assert.
        res.Length.Should().Be(expectedEnumLength);
        res[0].Should().Be(MyEnum.One);
        res[0].GetType().Name.Should().Be(expectednumName);
        res[1].Should().Be(MyEnum.Two);
        res[1].GetType().Name.Should().Be(expectednumName);
    }
}
