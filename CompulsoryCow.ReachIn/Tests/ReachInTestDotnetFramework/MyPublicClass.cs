#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable CS0169 // Field is never used
#pragma warning disable CS0649 // Field is never assigned to and will always have its default value

namespace ReachInTestDotnetFramework
{
    public class MyPublicClass : MyBaseClass
    {
        public MyPublicClass()
        {
            _myInnerPrivateClass = new MyInnerPrivateClass();
            _myInnerInternalClass = new MyInnerInternalClass();
            _myInnerProtectedClass = new MyInnerProtectedClass();
            _myInnerPublicClass = new MyInnerPublicClass();
        }

        private class MyInnerPrivateClass : MyBaseClass
        {
            //  We don't support finding privates in inherited classes.
            private int _myPrivateField;
        }
        internal class MyInnerInternalClass : MyBaseClass { }
        protected class MyInnerProtectedClass : MyBaseClass { }
        public class MyInnerPublicClass : MyBaseClass { }

        private MyInnerPrivateClass _myInnerPrivateClass;
        private MyInnerInternalClass _myInnerInternalClass;
        private MyInnerProtectedClass _myInnerProtectedClass;
        private MyInnerPublicClass _myInnerPublicClass;

        private static class MyStaticInnerPrivateClass
        {
            private static int _myStaticPrivateField;
            internal static int _myStaticInternalField;
            public static int _myStaticPublicField;

            private static int MyStaticPrivateProperty { get; set; }
            internal static int MyStaticInternalProperty { get; set; }
            public static int MyStaticPublicProperty { get; set; }

            private static int MyStaticPrivateMethod(int n) { return n + 1; }
            internal static int MyStaticInternalMethod(int n) { return n + 1; }
            public static int MyStaticPublicMethod(int n) { return n + 1; }
        }
        internal static class MyStaticInnerInternalClass
        {
            private static int _myStaticPrivateField;
            internal static int _myStaticInternalField;
            public static int _myStaticPublicField;

            private static int MyStaticPrivateProperty { get; set; }
            internal static int MyStaticInternalProperty { get; set; }
            public static int MyStaticPublicProperty { get; set; }

            private static int MyStaticPrivateMethod(int n) { return n + 1; }
            internal static int MyStaticInternalMethod(int n) { return n + 1; }
            public static int MyStaticPublicMethod(int n) { return n + 1; }
        }
        protected static class MyStaticInnerProtectedClass
        {
            private static int _myStaticPrivateField;
            internal static int _myStaticInternalField;
            public static int _myStaticPublicField;

            private static int MyStaticPrivateProperty { get; set; }
            internal static int MyStaticInternalProperty { get; set; }
            public static int MyStaticPublicProperty { get; set; }

            private static int MyStaticPrivateMethod(int n) { return n + 1; }
            internal static int MyStaticInternalMethod(int n) { return n + 1; }
            public static int MyStaticPublicMethod(int n) { return n + 1; }
        }
        public static class MyStaticInnerClass
        {
            private static int _myStaticPrivateField;
            internal static int _myStaticInternalField;
            public static int _myStaticPublicField;

            private static int MyStaticPrivateProperty { get; set; }
            internal static int MyStaticInternalProperty { get; set; }
            public static int MyStaticPublicProperty { get; set; }

            private static int MyStaticPrivateMethod(int n) { return n + 1; }
            internal static int MyStaticInternalMethod(int n) { return n + 1; }
            public static int MyStaticPublicMethod(int n) { return n + 1; }
        }
    }
}
