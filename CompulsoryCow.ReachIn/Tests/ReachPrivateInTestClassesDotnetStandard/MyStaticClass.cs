﻿namespace ReachPrivateInTestClassesDotnetStandard
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