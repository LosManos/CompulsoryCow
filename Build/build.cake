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

if( FileExists( project )) {
	Information( "Project={0}", project );
}else{
	throw new Exception( $"File project {project} does not exist.");
}

Task("Clean")
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