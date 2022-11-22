using CompulsoryCow;
using FluentAssertions;
using Xunit;

namespace MetaTest;

public class GetPublicTest
{
    [Fact]
    public void GetPublicProperties_ReturnOnlyPublicProperties()
    {
        var res = Meta.GetPublicProperties(new MyClass());

        //  #   Assert.
        res.Length.Should().Be(2);
        res[0].Name.Should().Be("MyPublicIntProperty");
        res[1].Name.Should().Be("MyPublicStringProperty");
    }

    private class MyClass
    {
        private int _myMethodField;
        private int _myField;
        private int MyProperty { get; set; }
        public int MyPublicIntProperty { get; set; }
        public string MyPublicStringProperty { get; set; }
        private int MyGetMethod()
        {
            return _myMethodField;
        }
        private void MySetMethod(int value)
        {
            _myMethodField = value;
        }
    }
}
