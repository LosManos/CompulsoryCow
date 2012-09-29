CompulsoryCow
=============

Useful functionality in C#.  Will in the future take over from CompulsoryCat of Selfelected (http://code.google.com/p/compulsorycat/) fame.

It will contain
* meta info help.  Use properties and methods names through lambda and not strings.
* a string.Format method that can't throw exception.


### Meta info help 
For instance get the name of a method of property without writing a string that later might be wrong when the method name is updated.

### string.Format that doesn't crash
log.Error( string.Format( "Method {0} threw an exception with message {1}", methodName ) );
throws an exception.  Resharper warns you but without such a tool you will get a string formatting? exception at runtime and the real exception wasn't logged.
That is why you have unit tests you might say but 1) do you really have 100% test coveraget and 2) if you know the method succeeds no test is needed.
