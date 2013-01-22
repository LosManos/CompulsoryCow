using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SerializerTest
{
    [TestClass]
    public class SerializerTest
    {
        [TestMethod]
        public void ToXml_Null()
        {
            var res = CompulsoryCow.Serializer.ToXml(null);
            Assert.IsNull(res);
        }

        [TestMethod]
        public void ToXml_Object()
        {
            var o = new SimpleClass {ID = 1, Name = "asdf"};
            var res = CompulsoryCow.Serializer.ToXml(o);
            Assert.IsNotNull(res.DocumentElement);
            Assert.AreEqual( "SimpleClass", res.DocumentElement.Name);
            Assert.AreEqual(2, res.ChildNodes.Count);
            Assert.AreEqual( 
                "<?xml version=\"1.0\"?><SimpleClass xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><ID>1</ID><Name>asdf</Name></SimpleClass>", 
                res.InnerXml);
        }

        [TestMethod]
        public void ToXml_List()
        {
            var lst = new List<SimpleClass>
                {
                    new SimpleClass {ID = 1, Name = "asdf"},
                    new SimpleClass {ID = 2, Name = null}
                };

            var res = CompulsoryCow.Serializer.ToXml(lst);

            Assert.IsNotNull(res);
            Assert.AreEqual(
                "<?xml version=\"1.0\"?><ArrayOfSimpleClass xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><SimpleClass><ID>1</ID><Name>asdf</Name></SimpleClass><SimpleClass><ID>2</ID></SimpleClass></ArrayOfSimpleClass>", 
                res.InnerXml);
        }
    }
}
