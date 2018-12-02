CompulsoryCow
=============

CompulsoryCow Version 2.5.0  
CompulsoryCow.AreEqual Version 0.1.0
CompulsoruCow.0.1 IsEqualsImplemented Version 0.1.0

Nuget: https://www.nuget.org/packages/CompulsoryCow/

**Useful functionality in C#.**  Will in the future take over from [CompulsoryCat](http://code.google.com/p/compulsorycat/) of [Selfelected](http://www.selfelected.com) fame.

## Contains

### *CompulsoryCow* contains:
* A [string.SFormat method](#string.sformat-that-does-not-crash) that can't throw exception. This method is going obsolete with the $"" syntax and will be removed.
* A [serialize to XML method](#serialize.toxml) with `CompulsoryCow.Serialize(myObject)`
* A [deserialize from XML method](#deseralize.fromxml) with `CompulsoryCow.Deserialize<MyType>(myString)`
* A string helper method [SplitAt](#splitat) that splits a string at a certain index or string.
* [Left, Right and Mid](#left-right-and-mid) methods behaving as we know from the BASIC heydays.
* A method GetCallingMethod retrieving information about the calling method. Warning: This method might be deprecated as it only works properly in debug compile and doesn't behave as expected as it contains the historical where-you've-been but rather [where it will go when it returns](https://stackoverflow.com/a/15368508/521554).
* A dynamic class [ReachIn](#reachin) for reading (disregarding visibility(private,protected etc.)) fields, properties and methods. Typically used for unit testing.
* [Meta info help](#meta-info-help).  Use properties and methods names through lambda and not strings.  
  * [GetProperty method](#getproperty) for getting information about the property the code is presently in.  
  * [GetPrivate methods](#getprivate...) for reaching private fields, properties and methods. Warning: These methods might be deprecated in the future in favour of `ReachIn`.  
  * [Method GetPublicProperties](#GetPublicProperties) for getting an array of all public properties on an object.  

### *CompulsoryCow.AreEqual* contains:
* [AreEqual.Public]($areequal) methods for comparing two objects.

### *CompulsoryCow.IsEqualsImplemented* contains:
* [HasEqualsBeenDeclared]($hasequalsbeenimplemented) method for telling if a class has explicitly declared the Equals method
* [IsEqualsImplementedCorrectly]($isequalsimplementedcorrectly) method for telling if a class has implemented the Equals method correctly.

### The projects might contain in the future:
* SqlServer exceptions are notorious for having crucial data in the message and in an [integer](http://stackoverflow.com/questions/6221951/sqlexception-catch-and-handling) or in the [free text message](http://stackoverflow.com/questions/6982647/smart-way-to-get-unique-index-name-from-sqlexception-message). The plan is to create a library that can parse the message and return an exception that contains the information is a more technical fashion so it can be understood by a computer. The library might have to read meta data from the database server and then this functionality should be moved to a library of its own so as to not dirty CompulsoryCow with SqlServer dependencies. Another complications are different Sqlserver versions and different languages. A Spanish Sqlserver might return different error messages than an "English".
* A Linq method that returns true if [all items in a list are equal](http://stackoverflow.com/questions/1628658/linq-check-whether-two-list-are-the-same).

## License

License LGPLv3 + NoEvil.

### LGPLv3

https://www.gnu.org/licenses/lgpl-3.0.txt

### NoEvil

The code is not available for companies that create, buy or sell weapons.
This includes companies and organisations that are owned by companies making weapons. 
The list includes, but is not limited to Bofors, Saab and Lockheed Martin.

The code is not available for countries where capital punishment or torture is allowed or used. 
The list includes, but is not limited to, Egypt, China and USA. 

An exception to the above is where the company or organisation takes an active role in working against weapons, capital punishment or torture regardless of country. 
The list includes, but is not limited to Amnesty and Greenpeace.

The code is also not available for companies and persons dealing with unlawful things or aiding the same.

## Methods

### string.SFormat that does not crash
This method is losing its value with the adoptiojn of [string interpolation](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated).

##### The problem solved
The normal Microsoft string.Format _throws an exception_ when the {n} are more than the arguments.  Throwing an exception might be ok during the development phase but maybe not later on; especially during production when logging to a file.
Read this again:  If a system is running in production the log files are often the only way to search for problems.  _We want the logging to log, not throw exception._

```csharp
string.Format( "We are using {0} many {1}", "too" );
```
Will throw an exception.

Contrary SFormat
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

----
### Serialize.ToXml
##### The problem solved
Every time one wants to serialise an object to XML one has to go google hunting.  With this method it is already solved and unit tested.

```csharp
class MyClass{
    string MyProp{ get; set; }
}
var myObject = new MyClass{ MyProp = "asdf"};
var xmlDocument = CompulsoryCow.Serialize( myObject );
```

----
### Deseralize.FromXml
##### The problem solved
Every time one wants to deserialise an object from XML one has to go google hunting.  With this method it is already solved and unit tested.

```csharp
class MyClass{
    string MyProp{ get; set; }
}
var myObject = CompulsoryCow.Deserialize<MyClass>( myXmlString );
```

----
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

----
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

----
### Meta info helper 
#### The problem solved
Getting meta information in C# can be tricky. Some helper method can come in handy.

For instance get the name of a method of property without writing a string that later might be wrong when the method name is updated.
Not yet implemented at github.  Code resides at [code.google](http://code.google.com/p/compulsorycat/) for the time being.

##### GetCallingMethod

This method gets information about whatever called your code.

```
void MyFirstMethod(){
	MySecondMethod();
}
void MySecondMethod(){
	var callingMethod = CompulsoryCow.ReflectionUtilities.GetCallingMethod();
	//	callingMethod.Name is now "MyFirstMethod".
}
```

##### GetProperty
This method gets information about the property you are in.
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

##### GetPrivate...
 *GetPrivateField, GetPrivateStaticField, GetPrivateProperty GetPrivateStaticProperty, GetPrivateMethod, GetPrivateStaticMethod*
```
var method = Meta.GetPrivateMethod(anObject, "GetCustomer");
method.Invoke(anObject, new[]{42});
```

##### GetPublicProperties
*GetPublicProperties*
```
var properties = Meta.GetPublicProperties(anObject);
```

----
### ReachIn
#### The problem solved
There are certain times the scope (private, public etc.) for a member (field, property, method) or class is a hindrance.

This *dynamic* class makes it possible to manipulate private fields, properties and methods by just writing normal code.
Typically used for unit testing.

```
[TestMethod]
public void Customer_given_KnownID_should_HaveIDFlagSet()
{
	// Arrange.
	var sut = new Customer{);
	dynamic sutPrivate = new ReachIn(typeof(Customer));

	sutPrivate.id = 12; // id is a private variable and not reachable by "normal" code.
	
	// Act.
	var res = sut.HasID();
	
	// Assert.
	Assert.IsTrue(res);
}
```

### AreEqual.Public
#### The problem solved
Comparing two objects in C# requires comparing every property or field one by one. To add insult to injury, reference objects are compared by their references. This can be solved by overriding Equals and operators, a task that is easy to do wrong.

In most cases only public properties are compared so for simplicity's sake the method only looks at public properties.  
It can also handle nested objects.

```
var isObjectCopyCorrect = AreEqual.Public(source, destination);
```
or more complex, for nexted classes:
```
var isObjectDeepCopyCorrect = AreEqual.Public(Depth.Infinite, source, destination);
```

### HasEqualsBeenDeclared
#### The problem solved
Is an explicit Equals declared for a class or not? This method will answer True or False for that. Quite limited usefulness.

### IsEqualsImplementedCorrectly
#### The problem solved
It is easy to implement Equals. With today's tools it is just a ctrl-period or alt-enter away; just press and all public properties are compared. But what happens when a property is added, is it certain that the developer remembers to update Equals and GetHashCode? Probably not.  
So IsEqualsImplemententedCorrectly to the rescue. Call it with two objects with your class of choice and let it change one property at a time. The resutl is a boolean but the last comparisons value is in ResultMember and ResultMessage properties.

### AreAllEqualsImplementedCorrectly
#### The problem solved
Like IsEqualsImplementedCorrectly but on an assembly scale. Hand it an assembly and you get all failing Equals implementations back.

*EOF*
