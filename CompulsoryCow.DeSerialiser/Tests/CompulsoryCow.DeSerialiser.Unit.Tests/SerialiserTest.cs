﻿using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace SerialiserTest;

public class SerialiserTest
{
    [Fact]
    public void ToXml_Null()
    {
        var res = Record.Exception(() =>
        {
            CompulsoryCow.Serialiser.ToXml(null);
        });
        res.Should().BeOfType<ArgumentNullException>();
    }

    [Fact]
    public void ToXml_Object()
    {
        var o = new SimpleClass {ID = 1, Name = "asdf"};
        var res = CompulsoryCow.Serialiser.ToXml(o);
        res.DocumentElement.Should().NotBeNull();
        res.DocumentElement.Name.Should().Be("SimpleClass");
        res.ChildNodes.Count.Should().Be(2);
        res.InnerXml.Should().Be(
            "<?xml version=\"1.0\" encoding=\"utf-8\"?><SimpleClass xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><ID>1</ID><Name>asdf</Name></SimpleClass>" 
        );
    }

    [Fact]
    public void ToXml_List()
    {
        var lst = new List<SimpleClass>
            {
                new SimpleClass {ID = 1, Name = "asdf"},
                new SimpleClass {ID = 2, Name = null}
            };

        var res = CompulsoryCow.Serialiser.ToXml(lst);

        res.Should().NotBeNull();
        res.InnerXml.Should().Be(
            "<?xml version=\"1.0\" encoding=\"utf-8\"?><ArrayOfSimpleClass xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><SimpleClass><ID>1</ID><Name>asdf</Name></SimpleClass><SimpleClass><ID>2</ID></SimpleClass></ArrayOfSimpleClass>"
        );
    }
}
