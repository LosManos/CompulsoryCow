using CompulsoryCow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReflectionUtilitiesTests
{
	[TestClass]
	public class GetPropertiesTests
	{
		[TestMethod]
		public void GetPublicProperties_OnlyPublicProperteis()
		{
			//	#	Arrange;
			var o = new ClassWithAllScopes();

			//	#	Act.
			var res = Meta.GetPublicProperties(o);

			//	#	Assert.
			Assert.AreEqual(1, res.Length);
			Assert.AreEqual("myPublicProperty", res[0].Name);
		}

		internal class ClassWithAllScopes
		{
#pragma warning disable IDE0044 // Add readonly modifier
            private int myPrivateField;
            internal int myInternalField;
			protected int myProtectedField;
#pragma warning restore IDE0044 // Add readonly modifier
            public int myPublicField;

            private int myPrivateProperty { get; set; }
			internal int myInternalProperty { get; set; }
			protected int myProtectedProperty { get; set; }
			public int myPublicProperty { get; set; }

			private void myPrivateMethod(){}
			internal void myInternalMethod(){}
			protected void myProtectedMethod(){}
			public void myPublicMethod(){}
		}
	}
}
