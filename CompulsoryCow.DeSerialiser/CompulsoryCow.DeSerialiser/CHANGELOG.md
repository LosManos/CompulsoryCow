# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.3.2]
Update build nuget publish module.

## [0.3.0]
Update to dotnetstandard2.1 to allow for DisallowNull attribute.
FromXml<T> now throws an exception if argument is null.
ToXml now throws an exception if argument is null.
This is a breaking change.

## [0.2.0]
Moved to a project of its own.
Renamed DeSerializer to DeSerialiser.
Created nuspec file.
