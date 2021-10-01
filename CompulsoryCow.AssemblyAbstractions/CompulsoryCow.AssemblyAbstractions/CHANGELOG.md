# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.6]
Breaking change.
Change from netstandard2.0 to net5.0 as it was needed to get a method to work. (can't remember which')

Add AssemblyLoadContext.
Add AssemblyLoadContextFactory.

## [0.5]
Add LoadFrom constructor.
Fix bug where LoadFile called LoadFrom internally.

## [0.3]
Add Location property.

## [0.2.1]
Bug: Fix a failing test.

## [0.2.0]
Split code into Assembly and AssemblyFactory. The static constructors go into the latter.

## [0.1 0]
Set up first try.
