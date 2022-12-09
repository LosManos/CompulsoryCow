using System;
using System.Collections.Generic;
using CompulsoryCow.IsEqualsImplemented;

namespace VerifyTest;

public partial class VerifyTests
{
    /// <summary>This class contains a type that <see cref="Verify.IsEqualsImplementedCorrectly{T}"/> does not handle natively.
    /// </summary>
    internal class ClassWithCustomType
    {
        internal class InnerClass
        {
            public char MyChar { get; set; }

            public override bool Equals(object obj)
            {
                var @class = obj as InnerClass;
                return @class != null &&
                       MyChar == @class.MyChar;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(MyChar);
            }

            public static bool operator ==(InnerClass class1, InnerClass class2)
            {
                return EqualityComparer<InnerClass>.Default.Equals(class1, class2);
            }

            public static bool operator !=(InnerClass class1, InnerClass class2)
            {
                return !(class1 == class2);
            }
        }

        public string MyString { get; set; }

        public InnerClass MyInnerClass { get; set; }

        public override bool Equals(object obj)
        {
            var type = obj as ClassWithCustomType;
            return type != null &&
                   MyString == type.MyString &&
                   EqualityComparer<InnerClass>.Default.Equals(MyInnerClass, type.MyInnerClass);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MyString, MyInnerClass);
        }

        public static bool operator ==(ClassWithCustomType type1, ClassWithCustomType type2)
        {
            return EqualityComparer<ClassWithCustomType>.Default.Equals(type1, type2);
        }

        public static bool operator !=(ClassWithCustomType type1, ClassWithCustomType type2)
        {
            return !(type1 == type2);
        }
    }

    /// <summary>This class contains an Equals implementation.
    /// (albeit a halting one)
    /// </summary>
    internal class ClassWithEqualsDeclaration
    {
        public override bool Equals(object obj)
        {
            throw new NotImplementedException("There is no need for implementing anything in this method, it is only for checking if the Equals method exists.");
        }
    }

    internal class ClassWithEqualsDeclarationWithWrongParameters
    {
        public bool Equals(object obj, string s)
        {
            throw new NotImplementedException("This is a variant of an correctly almost-Equals method");
        }
    }

    internal class ClassWithInternalEqualsDefinition
    {
        internal bool Equals(object obj)
        {
            throw new NotImplementedException("This is a variant of an correctly almost-Equals method");
        }
    }

    /// <summary>This class should not contain any explicit Equal implementation.
    /// </summary>
    internal class ClassWithoutEqualsDeclaration
    {
    }

    internal class ClassWithStaticEqualsDeclaration
    {
        public static bool Equals(object obj)
        {
            throw new NotImplementedException("This is a variant of an correctly almost-Equals method");
        }
    }

    /// <summary>This class does not have a properly implemented Equals
    /// as one of the public properties is missing.
    /// </summary>
    internal class LackingAFieldInEqualsComparisonClass
    {
        public int MyInt { get; set; }
        public string MyString { get; set; }

        public override bool Equals(object obj)
        {
            var @class = obj as LackingAFieldInEqualsComparisonClass;
            return @class != null &&
                   MyInt == @class.MyInt;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MyInt);
        }

        public static bool operator ==(LackingAFieldInEqualsComparisonClass class1, LackingAFieldInEqualsComparisonClass class2)
        {
            return EqualityComparer<LackingAFieldInEqualsComparisonClass>.Default.Equals(class1, class2);
        }

        public static bool operator !=(LackingAFieldInEqualsComparisonClass class1, LackingAFieldInEqualsComparisonClass class2)
        {
            return !(class1 == class2);
        }
    }

    /// <summary>This class has a properly implemented Equals 
    /// where all public properties are compared.
    /// </summary>
    internal class ProperlyImplementedClass
    {
        public int MyInt { get; set; }
        public string MyString { get; set; }

        public override bool Equals(object obj)
        {
            var @class = obj as ProperlyImplementedClass;
            return @class != null &&
                   MyInt == @class.MyInt &&
                   MyString == @class.MyString;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(MyInt, MyString);
        }

        public static bool operator ==(ProperlyImplementedClass class1, ProperlyImplementedClass class2)
        {
            return EqualityComparer<ProperlyImplementedClass>.Default.Equals(class1, class2);
        }

        public static bool operator !=(ProperlyImplementedClass class1, ProperlyImplementedClass class2)
        {
            return !(class1 == class2);
        }
    }

    /// <summary>This class has a properly implemented Equals but
    /// does not have a default constructor.
    /// </summary>
    internal class LackingDefaultConstructor: ProperlyImplementedClass
    {
        internal LackingDefaultConstructor(int myInt, string myString)
        {
            MyInt = myInt;
            MyString = MyString;
        }
    }

    internal static IEnumerable<object> IsEqualsTestData
    {
        get
        {
            yield return new object[]
            {
                typeof(ProperlyImplementedClass),
                true,
                "Should be properly implemented."
            };
        }
    }
}
