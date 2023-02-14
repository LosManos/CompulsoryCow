# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

##[6.2.0]
Add method `public static ConstructorInfo? GetDefaultConstructor(Type type)`.

##[6.1.0]
Add `Meta.GetClassesWithAttribute<TAttribute>(AppDomain appDomain) where TAttribute : Attribute` method.
Add `Meta.GetDefaultConstructor<TClass>()` method.

## [6.0.0]
Deprecated GetCallingMethod.
Deprecated GetProperty.
Instead use CallerMemberNameAttribute.
Remove compile warnings.

## [5.0.0]
Rename test methods to snake case.
Add method `public static PropertyInfo[] GetPublicProperties(Type type, bool recurse = false)`
Remove old `public static PropertyInfo[] GetPublicProperties<T>(T theClass)`.

## [4.0.0]
GetPrivateField, GetPrivateProperty, GetPrivateMethod, GetPublicProperties returns ArgumentNullException if null arguments are provided.

## [3.0.0]
Moved to a project of its own.
Created nuspec file.
