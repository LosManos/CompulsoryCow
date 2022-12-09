using System.Collections.Generic;
using FluentAssertions;
using SerialiserTest;
using Xunit;

namespace DeSerialiserTest;

public class DeSerialiserTest
{
    [Fact]
    public void FromXml_Null()
    {
        var res = CompulsoryCow.Deserialiser.FromXml<object>(null);
        res.Should().BeNull();
    }

    [Fact]
    public void FromXml_Object()
    {
        var o = new SimpleClass {ID = 1, Name = "asdf"};
        var xml = CompulsoryCow.Serialiser.ToXml(o);

        var res = CompulsoryCow.Deserialiser.FromXml<SimpleClass>(xml);

        res.ID.Should().Be(1);
        res.Name.Should().Be("asdf");
    }

    [Fact]
    public void FromXml_List()
    {
    var lst = new List<SimpleClass>
        {
                new SimpleClass {ID = 1, Name = "asdf"},
                new SimpleClass {ID = 2, Name = null}
            };

        var xml = CompulsoryCow.Serialiser.ToXml(lst);

        var res = CompulsoryCow.Deserialiser.FromXml<List<SimpleClass>>(xml);

        res.Count.Should().Be(2);
        res[0].ID.Should().Be(1);
        res[1].Name.Should().BeNull();
    }
}
