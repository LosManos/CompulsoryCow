#pragma warning disable IDE0044 // Add readonly modifier
#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable CS0169 // Field is never used

namespace ReachPrivateInTestClassesDotnetFramework
{
    public static class MyStaticClass
    {
        private static string _myName;

        private static int MyProperty { get; set; }

        private static int _myField;

        private static string GetMethod()
        {
            return _myName;
        }

        private static void SetMethod(string value)
        {
            _myName = value;
        }
    }
}
