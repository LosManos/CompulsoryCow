using CompulsoryCow;
using MetaTestClassesDotnetFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace MetaTest
{
    [TestClass]
    public class GetClassTests
    {
        #region GetClass( className:string ) extension

        [TestMethod]
        [DataRow("MyInnerPublicClass")]
        [DataRow("MyInnerInternalClass")]
        [DataRow("MyInnerPrivateClass")]
        [DataRow("MyInnerStaticPublicClass")]
        [DataRow("MyInnerStaticInternalClass")]
        [DataRow("MyInnerStaticPrivateClass")]
        public void GetClass_KnownClass_ReturnClassesType(string className)
        {
                var res = new MyPublicClass().GetClass(className);
                Assert.IsNotNull(res);
                Assert.AreEqual(className, res.Name);
        }

        [TestMethod]
        public void GetClass_UnknowClass_ThowException()
        {
            //  #   Act.
            Assert.ThrowsException<ArgumentException>(() =>
            {
                new MyPublicClass().GetClass("doesnotexist");
            });
        }

        #endregion  //  GetClass( className:string ) extension

        #region GetClassOrNull( className:string ) extension

        [TestMethod]
        [DataRow("MyInnerPublicClass")]
        [DataRow("MyInnerInternalClass")]
        [DataRow("MyInnerPrivateClass")]
        [DataRow("MyInnerStaticPublicClass")]
        [DataRow("MyInnerStaticInternalClass")]
        [DataRow("MyInnerStaticPrivateClass")]
        public void GetClassOrNull_KnownClass_ReturnClassesType(string className)
        {
            var res = Meta.GetClassOrNull(typeof(MyPublicClass), className);
            Assert.IsNotNull(res);
            Assert.AreEqual(className, res.Name);
        }

        [TestMethod]
        public void GetClassOrNull_UnknowClass_ThowException()
        {
            //  #   Act.
            var res = Meta.GetClassOrNull(typeof(MyPublicClass), "doesnotexist");

            //  #   Assert.
            Assert.IsNull(res);
        }

        #endregion  //  GetClassOrNull( className:string ) extension

        #region GetStaticClass( className:string )

        [TestMethod]
        [DataRow("MyInnerStaticPublicClass")]
        [DataRow("MyInnerStaticInternalClass")]
        [DataRow("MyInnerStaticPrivateClass")]
        public void GetStaticClass_KnownClass_ReturnClassesType(string className)
        {
            //  #   Act.
            var res = Meta.GetClass<MyPublicStaticClass>(className);

            //  #   Assert.
            Assert.IsNotNull(res);
            Assert.AreEqual(className, res.Name);
        }

        [TestMethod]
        public void GetStaticClass_UnknowClass_ReturnNull()
        {
            //  #   Act.
            Assert.ThrowsException<ArgumentException>(() =>
                Meta.GetClass<MyPublicStaticClass>("doesnotexst")
            );
        }

        #endregion  // GetStaticClass( className:string )

        #region GetClass( assemblyName:string, namespace:string, className:string)

        [TestMethod]
        [DataRow("MetaTestClassesDotnetFramework", "MyPublicStaticClass")]
        [DataRow("MetaTestClassesDotnetFramework", "MyInternalStaticClass")]
        [DataRow("MetaTestClassesDotnetFramework", "MyPublicStaticClass+MyInnerStaticPublicClass")]
        [DataRow("MetaTestClassesDotnetFramework", "MyPublicStaticClass+MyInnerStaticInternalClass")]
        [DataRow("MetaTestClassesDotnetFramework", "MyPublicStaticClass+MyInnerStaticPrivateClass")]
        [DataRow("MetaTestClassesDotnetFramework", "MyInternalStaticClass+MyInnerStaticPublicClass")]
        [DataRow("MetaTestClassesDotnetFramework", "MyInternalStaticClass+MyInnerStaticInternalClass")]
        [DataRow("MetaTestClassesDotnetFramework", "MyInternalStaticClass+MyInnerStaticPrivateClass")]
        public void GetInternalClass_KnownNamespaceAndKnownClass_Type(string @namespace, string className)
        {
            //  #   Arrange.
            Console.WriteLine($"Indata:{{Namespace={@namespace},ClassName{className}}}");
            const string AssemblyName = "MetaTestClassesDotnetFramework";
            // Just reference the assembly by loading the assembly so we don't have to loade it explicitly through AssemblyLoadFrom.
            // This testing code might not work in Release compile.
            new MetaTestClassesDotnetFramework.MyPublicClass();
            var assembly =
                AppDomain.CurrentDomain.GetAssemblies()
                .Single(a => a.FullName.StartsWith(AssemblyName));
            var @class = assembly.GetType($"{AssemblyName}.{className}");
            Assert.IsNotNull(@class);

            //  #   Act.
            var res = Meta.GetClass(AssemblyName, @namespace, className);

            //  #   Assert.
            Assert.IsNotNull(res);
            Assert.AreEqual($"{@namespace}.{className}", res.FullName);
        }

        [TestMethod]
        public void GetInternalClass_KnownAssemblyAndNamespaceAndUnknownClass_ThrowArgumentException()
        {
            //  #   Arrange.
            const string AssemblyName = "MetaTestClassesDotnetFramework";
            const string Namespace = "MetaTestClassesDotnetFramework";
            // Just reference the assembly by loading the assembly so we don't have to loade it explicitly through AssemblyLoadFrom.
            // This testing code might not work in Release compile.
            new MetaTestClassesDotnetFramework.MyPublicClass();

            //  #   Act.
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Meta.GetClass(AssemblyName, Namespace, "ThisClassDoesNotExist");
            });
        }

        [TestMethod]
        public void GetInternalClass_KnownAssemblyAndUnknownNamespace_ThrowArgumentException()
        {
            //  #   Arrange.
            const string AssemblyName = "MetaTestClassesDotnetFramework";
            // Just reference the assembly by loading the assembly so we don't have to loade it explicitly through AssemblyLoadFrom.
            // This testing code might not work in Release compile.
            new MetaTestClassesDotnetFramework.MyPublicClass();

            //  #   Act.
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Meta.GetClass(AssemblyName, "ThisNamespaceDoesnotExist", "ThisClassDoesNotExist");
            });
        }

        [TestMethod]
        public void GetInternalClass_UnknownAssembly_ThrowArgumentException()
        {
            //  #   Arrange.
            const string AssemblyName = "MetaTestClassesDotnetFramework";
            // Just reference the assembly by loading the assembly so we don't have to loade it explicitly through AssemblyLoadFrom.
            // This testing code might not work in Release compile.
            new MetaTestClassesDotnetFramework.MyPublicClass();

            //  #   Act.
            Assert.ThrowsException<ArgumentException>(() =>
            {
                Meta.GetClass(AssemblyName, "ThisNamespaceDoesnotExist", "ThisClassDoesNotExist");
            });
        }
        #endregion  //  GetClass( assemblyName:string, namespace:string, className:string)
    }
}
