// #tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0
#tool nuget:?package=vswhere

FilePath vsTestPath =
    VSWhereLatest()
    .CombineWithFilePath(
        "./Common7/IDE/CommonExtensions/Microsoft/TestWindow/vstest.console.exe");
VSTestSettings testSettings = new VSTestSettings { 
    ToolPath = vsTestPath};

// See https://www.phillipsj.net/posts/cake-automating-an-existing-project.

//////////////////////////////////////////////////////////////////////
// ARGUMENTS
//////////////////////////////////////////////////////////////////////

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

Information( "Target={0}.", target );
Information( "Configuration={0}.", configuration );

var dir = Argument<string>("dir");
var proj = Argument<string>("proj");

Information( "Parameter dir={0}", dir );
Information( "Parameter proj={0}", proj );

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.

// Bail if the dir parameter does not match reality.
if( DirectoryExists( dir ) == false ){
	throw new Exception( $"Directory {dir} does not exist.");
}

// Make sure we have the dirs we need underneath.
var outputDir = Directory(dir) + Directory("bin") + Directory(configuration);
CreateDirectory( outputDir );

Information( "Output dir={0}", outputDir );

var project = dir + "/" + proj + ".csproj";
var nuspec = dir + "/" + proj + ".nuspec";

if( FileExists( project )) {
	Information( "Project={0}", project );
}else{
	throw new Exception( $"File project {project} does not exist.");
}

if( FileExists( nuspec)) {
	Information( "Nuspec={0}", nuspec );
}else{
	throw new Exception( $"File nuspec {nuspec} does not exist.");
}

// Verify all version numberings are the same.
var csprojAssemblyVersion = XmlPeek( project, @"/Project/PropertyGroup/AssemblyVersion/text()" );
var csprojFileVersion = XmlPeek( project, "/Project/PropertyGroup/FileVersion/text()" );
var csprojVersion = XmlPeek( project, "/Project/PropertyGroup/Version/text()" );
var settings = new XmlPeekSettings{
	Namespaces = new Dictionary<string, string> {{ "ns", "http://schemas.microsoft.com/packaging/2010/07/nuspec.xsd" }}
};
var nuspecVersion = XmlPeek( nuspec, "/ns:package/ns:metadata/ns:version/text()", settings);

Task("Verify-Setup")
	.Does(() =>{
		if( csprojAssemblyVersion != csprojFileVersion ||
			csprojFileVersion != csprojVersion ||
			csprojVersion != nuspecVersion ){
				throw new Exception( $"Versions are not the same.");
		}	
		Information( "Version = {0}", nuspecVersion);
});

Task("Clean")
	.IsDependentOn("Verify-Setup")
    .Does(() =>{
        CleanDirectory(outputDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() => {
		NuGetRestore(project);
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>{
      // MSBuild(solution, settings =>
	  MSBuild(project, settings =>
        settings.SetConfiguration(configuration));  
});

Task("Run-Unit-Tests")
    .Does(() =>{
        VSTest(
            "../**/bin/" + configuration + "/*Test.dll", 
            testSettings
        ); 
});

Task("Execute-Unit-Tests")
    .IsDependentOn("Build")
    .IsDependentOn("Run-Unit-Tests");

Task("Default")
    .IsDependentOn("Execute-Unit-Tests");

Task("Run-Package")
    .Does(() =>{
		Information( "Packing {0}.", project );
        NuGetPack(
			project,
             new NuGetPackSettings{
                Verbosity = NuGetVerbosity.Detailed,
				Properties = new Dictionary<string, string>
				{
					{ "Configuration", configuration }
				}
            }
        );
});

Task("Package")
    .IsDependentOn("Execute-Unit-Tests")
    .IsDependentOn("Run-Package");

RunTarget(target);