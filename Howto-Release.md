# How to release

## Versioning
We are using semver.

## Version
There are several places to update
The csproj file has 3.
The nuget nuspec file has 1.
The project's release.md should have a new entry.
The project's changelog should have a new entry.
The solution's release.md should have a neew entry.

## Nuget package
The nuget nuspec file has en entry <releaseNotes> that should be updated.
The build in github manages publishing to nuget.
It might take a while for nuget to index the new package.
