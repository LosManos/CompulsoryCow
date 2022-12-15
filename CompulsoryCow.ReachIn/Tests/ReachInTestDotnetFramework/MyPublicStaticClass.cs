#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable CS0169 // Field is never used
#pragma warning disable CS0414 // Field is assigned but never used
#pragma warning disable CS0649 // Field is never assigned to and will always have its default value

namespace ReachInTestDotnetFramework
{
    public static class MyPublicStaticClass
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
