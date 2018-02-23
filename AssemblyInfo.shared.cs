using System.Reflection;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyCompany("LosManos")]
[assembly: AssemblyProduct("CompulsoryCow")]
[assembly: AssemblyCopyright("GPLv3+NoEvil")]
[assembly: AssemblyTrademark("Copyleft")]
[assembly: AssemblyCulture("")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
//  We are using semantic versioning as per http://semver.org
[assembly: AssemblyVersion(MyAssembly.Constants.Version)]
[assembly: AssemblyFileVersion(MyAssembly.Constants.Version)]

internal class MyAssembly
{
    internal class Constants
    {
        internal const string Version = "2.4.0";
    }
}