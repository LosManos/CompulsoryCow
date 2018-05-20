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
