namespace ReachInTestDotnetFramework
{
    public class MyBaseClass
    {
        //  #   Fields.
        private int _myPrivateField;
        internal int _myInternalField;
        protected int _myProtectedField;
        public int _myPublicField;

        //  #   Static fields.
        private static int _myStaticPrivateField;
        internal static int _myStaticInternalField;
        protected static int _myStaticProtectedField;
        public static int _myStaticPublicField;

        //  #   Properties.
        private int MyPrivateProperty { get; set; }
        internal int MyInternalProperty { get; set; }
        protected int MyProtectedProperty { get; set; }
        public int MyPublicProperty { get; set; }

        //  #   Static properties.
        private static int MyStaticPrivateProperty { get; set; }
        internal static int MyStaticInternalProperty { get; set; }
        protected static int MyStaticProtectedProperty { get; set; }
        public static int MyStaticPublicProperty { get; set; }

        //  #   Methods.
        private int MyPrivateMethod(int n) { return n + 1; }
        internal int MyInternalMethod(int n) { return n + 1; }
        protected int MyProtectedMethod(int n) { return n + 1; }
        public int MyPublicMethod(int n) { return n + 1; }

        //  #   Static methods.
        private static int MyStaticPrivateMethod(int n) { return n + 1; }
        internal static int MyStaticInternalMethod(int n) { return n + 1; }
        protected static int MyStaticProtectedMethod(int n) { return n + 1; }
        public static int MyStaticPublicMethod(int n) { return n + 1; }
    }
}
