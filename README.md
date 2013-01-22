CompulsoryCow
=============

License LGPLv3

Useful functionality in C#.  Will in the future take over from CompulsoryCat (http://code.google.com/p/compulsorycat/) of [Selfelected](http://www.selfelected.com) fame.

It contains now:
* a [string.Format method](https://github.com/LosManos/CompulsoryCow/blob/master/README.md#stringformat-that-doesnt-crash) that can't throw exception.
* a [serialize to XML method](https://github.com/LosManos/CompulsoryCow/blob/master/README.md#Seralize.ToXml)
* a [deserialize from XML method](https://github.com/LosManos/CompulsoryCow/blob/master/README.md#Deseralize.FromXml)
It will contain in the future:
* a string helper method [SplitAt](https://github.com/LosManos/CompulsoryCow/blob/master/README.md#splitat) that splits a string at a certain index or string.
* [Left and Right](https://github.com/LosManos/CompulsoryCow/blob/master/README.md#left-and-right) methods behaving as we know from the BASIC heydays.
* [meta info help](https://github.com/LosManos/CompulsoryCow/edit/master/README.md#meta-info-help).  Use properties and methods names through lambda and not strings.

### string.Format that doesn't crash
##### The problem solved
string.Format _throws an exception_ when the {n} are more than the arguments.  Throwing an exception might be ok during the development phase but maybe not later on; especially during production when logging to a file.
Read this again:  If a system is running in production the log files are often the only way to search for problems.  _We want the logging to log, not throw exception._

```csharp
string.Format( "We are using {0} many {1}", "too" );
```
Will throw an exception.

Mean while
```csharp
"We are using {0} many {1}".SFormat( "too" );
```
will render to a `We are using {0} many {1}[Failed formatting. Parameter(s) missing. Parameter(s) is/are:{System.String:'too'}.]`

We could also solve the above problem with inline string concatenation like so:
```csharp
"We are using " + "too" + " many " + whatchagot.ToString();
```
but if one prefers the string.Format way then there is now a safe way to do it.
Besides; what happens if whatchagot is null?  Exception...

##### Remaining bugs and caveats
* SFormat [does not handle escaped {](https://github.com/LosManos/CompulsoryCow/issues/1).  
* As long as there is no [null dot operator](http://visualstudio.uservoice.com/forums/121579-visual-studio/suggestions/2216723-automaticaly-check-object-nullity-before-access-so)
```csharp
class MyClass{
    string MyProp{ get; set; }
}
MyClass myObject = null;
"This {0} fail".SFormat( myObject.MyProp );
```
will fail no matter which method one uses.

##### Info
log.Error( string.Format( "Method {0} threw an exception with message {1}", methodName ) );
throws an exception.  Resharper warns you but without such a tool you will get a string formatting? exception at runtime and the real exception wasn't logged.
That is why you have unit tests you might say but 1) do you really have 100% test coveraget and 2) if you know the method succeeds no test is needed.

### Seralize.ToXml

```csharp
class MyClass{
    string MyProp{ get; set; }
}
var myObject = new MyClass{ MyProp = "asdf"};
var xmlDocument = CompulsoryCow.Serialize( myObject );
```

### Deseralize.FromXml

```csharp
class MyClass{
    string MyProp{ get; set; }
}
var myObject = CompulsoryCow.Deserialize<MyClass>( myXmlString );
```

### SplitAt

Split a string at a certain index.
```csharp
"SplitAt".SplitAt(5) => [ "Split", "At" ]
```

Split a string at a certain string.
```csharp
"SplitAt".SplitAt("it") => [ "Spl", "At" ]
```

### Left and Right

Feel free to take Left and Right of a string without being afraid of stepping outside the string length as we are with Substr.
```csharp
"SplitAt".Left(5) => "Split"
"SplitAt".Right(2) => "At"
"SplitAt".Left(100) => "SplitAt"
```

### Meta info helper 
For instance get the name of a method of property without writing a string that later might be wrong when the method name is updated.
Not yet implemented at github.  Code resided at [code.google](http://code.google.com/p/compulsorycat/) for the time being.
