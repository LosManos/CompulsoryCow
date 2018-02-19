CompulsoryCow
=============

Version 2.3.1

Nuget: https://www.nuget.org/packages/CompulsoryCow/

**Useful functionality in C#.**  Will in the future take over from [CompulsoryCat](http://code.google.com/p/compulsorycat/) of [Selfelected](http://www.selfelected.com) fame.

## Contains

It presently contains:
* a [string.Format method](https://github.com/LosManos/CompulsoryCow/blob/master/README.md#stringformat-that-doesnt-crash) that can't throw exception. This method is going obsolete with the $"" syntax and will be removed.
* a [serialize to XML method](https://github.com/LosManos/CompulsoryCow/blob/master/README.md#seralizetoxml)
* a [deserialize from XML method](https://github.com/LosManos/CompulsoryCow/blob/master/README.md#deseralizefromxml)
* a string helper method [SplitAt](https://github.com/LosManos/CompulsoryCow/blob/master/README.md#splitat) that splits a string at a certain index or string.
* [Left, Right and Mid](https://github.com/LosManos/CompulsoryCow/blob/master/README.md#left-right-and-mid) methods behaving as we know from the BASIC heydays.
* a method for retrieving information about the calling method.
* methods for reaching private fields, properties and methods.
* a dynamic class for reading private fields, properties and methods. Typically used for unit unit testing.


I might contain in the future:
* [meta info help](https://github.com/LosManos/CompulsoryCow/edit/master/README.md#meta-info-help).  Use properties and methods names through lambda and not strings.
* SqlServer exceptions are notorious for having crucial data in the message and in an [integer](http://stackoverflow.com/questions/6221951/sqlexception-catch-and-handling) or in the [free text message](http://stackoverflow.com/questions/6982647/smart-way-to-get-unique-index-name-from-sqlexception-message). The plan is to create a library that can parse the message and return an exception that contains the information is a more technical fashion so it can be understood by a computer. The library might have to read meta data from the database server and then this functionality should be moved to a library of its own so as to not dirty CompulsoryCow with SqlServer dependencies. Another complications are different Sqlserver versions and different languages. A Spanish Sqlserver might return different error messages than an "English".
* A Linq method that returns true if [all items in a list are equal](http://stackoverflow.com/questions/1628658/linq-check-whether-two-list-are-the-same).

## License

License LGPLv3 + NoEvil.
Exception to LGPLv3 and the code: is not available for companies that create, buy or sell weapons. This includes companies and organisations that are owned by companies making weapons. The list includes, but is not limited to Bofors, Saab and Lockheed Martin.
Exception to LGPLv3 and the code: is not available for countries where torture is allowed or used. The list includes, but is not limited to, Egypt and USA.
An exeption to the above is where the company or organisation takes an active role in working against weapons, torture regardless of country. The list includes, but is not limited to Amnesty and Greenpeace.

## Methods

### string.Format that does not crash
##### The problem solved
string.Format _throws an exception_ when the {n} are more than the arguments.  Throwing an exception might be ok during the development phase but maybe not later on; especially during production when logging to a file.
Read this again:  If a system is running in production the log files are often the only way to search for problems.  _We want the logging to log, not throw exception._

```csharp
string.Format( "We are using {0} many {1}", "too" );
```
Will throw an exception.

Meanwhile
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
##### The problem solved
Every time one wants to serialise an object to XML one has to go google hunting.  With this method it is already solved and unit tested.

```csharp
class MyClass{
    string MyProp{ get; set; }
}
var myObject = new MyClass{ MyProp = "asdf"};
var xmlDocument = CompulsoryCow.Serialize( myObject );
```

### Deseralize.FromXml
##### The problem solved
Every time one wants to deserialise an object from XML one has to go google hunting.  With this method it is already solved and unit tested.

```csharp
class MyClass{
    string MyProp{ get; set; }
}
var myObject = CompulsoryCow.Deserialize<MyClass>( myXmlString );
```

### SplitAt
##### The problem solved
Splitting a string is often needed.  The built in Split method cannot split at a certain index or with a string as splitter.

Split a string at a certain index.
```csharp
"SplitAt".SplitAt(5) => [ "Split", "At" ]
```

Split a string at a certain string.
```csharp
"SplitAt".SplitAt("it") => [ "Spl", "At" ]
```

### Left, Right and Mid
##### The problem solved
Today's functionality for taking left, right and mid of a string is not as easy as Left$(mystring,length), Right$(mystring,length) and Mid$(mystring,startIndex,length) from the BASIC hey days.

Feel free to take Left, Right and Mid of a string without being afraid of stepping outside the string length as we are with Substr.
```csharp
"SplitAt".Left(5) => "Split"
"SplitAt".Right(2) => "At"
"SplitAt".Left(100) => "SplitAt"
"SplitAt".Mid(4,2) => "tA"
"SplitAt".Mid(5,100) => "At"
"SplitAt".Mid(6,3) => "itA"
```

### Meta info helper 
For instance get the name of a method of property without writing a string that later might be wrong when the method name is updated.
Not yet implemented at github.  Code resided at [code.google](http://code.google.com/p/compulsorycat/) for the time being.

#### The problem solved
Getting meta information in C# can be tricky. Some helper method can come in handy.

*GetCallingMethod*  
Get information about whatever called your code.

```
void MyFirstMethod(){
	MySecondMethod();
}
void MySecondMethod(){
	var callingMethod = CompulsoryCow.ReflectionUtilities.GetCallingMethod();
	//	callingMethod.Name is now "MyFirstMethod".
}
```

*GetProperty*
Get information about the property you are in.
```
class MyClass{
    public string Title{
	      get{
	          //  Just call with this.GetProperty.
            Log( "The user just called the property" + this.GetProperty().Name );
            return _title;
        }
    }
}
```

#### The problem solved
Getting information, and manipulating, private fields, properties and methods without having to googlewithbing.

*GetPrivateField, GetPrivateMethod, GetPrivateField*
```
var method = Meta.GetPrivateMethod(anObject, "GetCustomer");
method.Invoke(anObject, new[]{42});
```

### ReachPrivateIn
This *dynamic* class makes it possible to manipulate private fields, properties and methods by just writing normal code.
Typically used for unit testing.

```
[TestMethod]
public void Customer_given_KnownID_should_HaveIDFlagSet()
{
	// Arrange.
	var sut = new Customer{);
	dynamic sutPrivate = new ReachPrivateIn<Customer>(sut);

	sutPrivate.id = 12; // id is a private variable and not reachable by "normal" code.
	
	// Act.
	var res = sut.HasID();
	
	// Assert.
	Assert.IsTrue(res);
}
```
