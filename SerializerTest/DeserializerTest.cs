using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SerializerTest
{
    [TestClass]
    public class DeserializerTest
    {
        [TestMethod]
        public void FromXml_Null()
        {
            var res = CompulsoryCow.Deserializer.FromXml<object>(null);
            Assert.IsNull(res);
        }

        [TestMethod]
        public void FromXml_Object()
        {
            var o = new SimpleClass {ID = 1, Name = "asdf"};
            var xml = CompulsoryCow.Serializer.ToXml(o);

            var res = CompulsoryCow.Deserializer.FromXml<SimpleClass>(xml);

            Assert.AreEqual(1, res.ID);
            Assert.AreEqual("asdf", res.Name);
        }

        [TestMethod]
        public void FromXml_List()
        {
        var lst = new List<SimpleClass>
            {
                    new SimpleClass {ID = 1, Name = "asdf"},
                    new SimpleClass {ID = 2, Name = null}
                };

            var xml = CompulsoryCow.Serializer.ToXml(lst);

            var res = CompulsoryCow.Deserializer.FromXml<List<SimpleClass>>(xml);

            Assert.AreEqual(2, res.Count);
            Assert.AreEqual(1, res[0].ID);
            Assert.AreEqual( null, res[1].Name);
        }
    }
}
