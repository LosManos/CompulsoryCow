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

//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.
var buildDir = Directory("../CompulsoryCow/bin") + Directory(configuration);
var solution = "../CompulsoryCow.sln";

Task("Clean")
    .Does(() =>{
        CleanDirectory(buildDir);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() => {
        NuGetRestore(solution);
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>{
      MSBuild(solution, settings =>
        settings.SetConfiguration(configuration));  
});

Task("Run-Unit-Tests-Only")
    .Does(() =>{
        VSTest(
            "../**/bin/" + configuration + "/*Test.dll", 
            testSettings
        ); 
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .IsDependentOn("Run-Unit-Tests-Only");

Task("Default")
    .IsDependentOn("Run-Unit-Tests");

Task("Package-Only")
    .Does(() =>{
        NuGetPack(
            "../CompulsoryCow/CompulsoryCow.csproj",
             new NuGetPackSettings{
                Verbosity = NuGetVerbosity.Detailed,
            }
        );
        NuGetPack(
            "../CompulsoryCow.AreEqual/CompulsoryCow.AreEqual.csproj",
             new NuGetPackSettings{
                Verbosity = NuGetVerbosity.Detailed,
            }
        );
});

// TODO: Bägge nuget-paketen.

Task("Package")
    .IsDependentOn("Run-Unit-Tests")
    .IsDependentOn("Package-Only");

RunTarget(target);