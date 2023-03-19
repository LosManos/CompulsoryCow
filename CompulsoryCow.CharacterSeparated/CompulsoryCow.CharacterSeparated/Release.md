CompulsoryCow.CharacterSeparated- Release notes
====================

### Verson 0.4.0
Breaking change.
" false" with implicitString==true is now parsed as (bool)false. Earlier result was " false".
" 1.0" with implicitString==true is now parsed as (double)1.0. Earlier result was " 1.0".
Enable nullable references to get rid of build warnings.


### Version 0.3.0
Moved to a project of its own.
