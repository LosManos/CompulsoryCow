namespace ReachPrivateInTestClassesDotnetFramework
{
    public class MyClass
    {
        private string myName;

        private int MyProperty { get; set; }

        private static int MyStaticProperty { get; set; }

        private int _myField;

        private static int _myStaticField;

        private string GetMethod()
        {
            return myName;
        }

        private (string First, int Second) GetMethodTuple(string a, int n)
        {
            return (First: a, Second: n);
        }
        
        private void SetMethod(string value)
        {
            myName = value;
        }

        private int StaticGetMethod()
        {
            return _myStaticField;
        }

        private void StaticSetMethod(int value)
        {
            _myStaticField = value;
        }
    }
}