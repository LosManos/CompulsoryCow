# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [0.4.0]
Breaking change.
" false" with implicitString==true is now parsed as (bool)false. Earlier result was " false".
" 1.0" with implicitString==true is now parsed as (double)1.0. Earlier result was " 1.0".
Enable nullable references to get rid of build warnings.
Testing framework changed to xunit (from mstest).

## [0.3.0]
Moved to a project of its own.
Created nuspec file.
