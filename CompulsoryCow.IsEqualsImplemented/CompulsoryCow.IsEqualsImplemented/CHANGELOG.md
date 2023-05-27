# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.6.0]
Deprecate this package with warning. Move to IsImplemented.  
Refactoring to get rid of compiler warnings.

## [0.5.0]
`Constructor.IsDefaultImplemented` returns whether a class contains a default constructor.

## [0.4.1]
`AreAllEqualsImplementedCorrectly` returns empty string, instead of null, when ResultMessage is empty.
`IsEqualsImplementedCorrectly` returns empty string, instead of null, when ResultMessage is empty.
DotnetStandard raised to 2.1 to allow for DisallowNull attribute.
This is a breaking change.

## [0.4.0]
Added method AddIgnoredClass{T} to be able to exclude classes from being tested.

## [0.3.0]
Added method ` AddInstantiator`  to be able to test classes
that do not have a default constructor.

## [0.2.0]
Moved to a project of its own.
Created nuspec file.

## [0.1.0]
Created Verify.AreAllEqualsImplementedCorrectly, Verify.HasEqualsBeenDeclared and IsEqualsImplementedCorrectly.
