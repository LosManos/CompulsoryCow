CompulsoryCow
=============

CompulsoryCow Version 2.5.0 <- deprecated in favour of the ones below  
CompulsoryCow.AreEqual Version 0.2.0  
Compulsorycow.CharacterSeparated Version 0.3.0  
CompulsoryCow.DeSerialiser Version 0.2.0  
CompulsoryCow.IsEqualsImplemented Version 0.2.0  
CompulsoryCow.Meta Version 3.0.0  
CompulsoryCow.Permutation Version 0.1.0  
CompulsoryCow.ReachIn Version 3.0.0  
CompulsoryCow.StringExtensions  Version 3.0.0

Nuget: https://www.nuget.org/packages/CompulsoryCow/

**Useful functionality in C#.**  Will in the future take over from [CompulsoryCat](http://code.google.com/p/compulsorycat/) of [Selfelected](http://www.selfelected.com) fame.

## Contains

### *CompulsoryCow.AreEqual* contains:
* [AreEqual.Public]($areequal) methods for comparing two objects.

### *CompulsoryCow.CharacterSeparated* contains:
* Parse.StringLine method for splitting a string per character (comma). It is like `string.Split` but with with the possibility to have a comma in the very string.
* Parse.String method for splitting a string per character (comma) and returns every item as a specific type.

### *CompulsoryCow.DateTimeAbstractions* contains:
* Help for abstracting System.DateTime to make it deterministic and/or testable.
  * All of System.DateTime's instance methods and properties implemented as interface for making mocking easier.
  * All of System.DateTime's static methods, properties and all constructors and operators, but setable for making testing possible in a deterministic way.

### *CompulsoryCow.DeSerialiser* contains:  
* A [serialize to XML method](#serialize.toxml) with `CompulsoryCow.Serialize(myObject)`
* A [deserialize from XML method](#deseralize.fromxml) with `CompulsoryCow.Deserialize<MyType>(myString)`

### *CompulsoryCow.Meta* contains:  
* [Meta info help](#meta-info-help).  Use properties and methods names through lambda and not strings.  
  * [GetProperty method](#getproperty) for getting information about the property the code is presently in.  
  * [GetPrivate methods](#getprivate...) for reaching private fields, properties and methods. Warning: These methods might be deprecated in the future in favour of `ReachIn`.  
  * [Method GetPublicProperties](#GetPublicProperties) for getting an array of all public properties on an object.  
* A method GetCallingMethod retrieving information about the calling method. Warning: This method might be deprecated as it only works properly in debug compile and doesn't behave as expected as it contains the historical where-you've-been but rather [where it will go when it returns](https://stackoverflow.com/a/15368508/521554).

### *CompulsoryCow.IsEqualsImplemented* contains:
* [HasEqualsBeenDeclared]($hasequalsbeenimplemented) method for telling if a class has explicitly declared the Equals method
* [IsEqualsImplementedCorrectly]($isequalsimplementedcorrectly) method for telling if a class has implemented the Equals method correctly.

### *CompulsoryCow.Permutation* contains:
* Permutate method for permutation all possible values/objects sent to it.  
It takes a list of list where a latter list is the possible values/objects.  Use it for permutating all possible values to send to a method.  
See the test methods for example of its usage. When you get your head around it, it is quite nifty.

### *CompulsoryCow.ReachIn* contains:  
* A dynamic class [ReachIn](#reachin) for reading (disregarding visibility(private,protected etc.)) fields, properties and methods. Typically used for unit testing.

### *CompulsoryCow.StringExtensions* contains:
* A [string.SFormat method](#string.sformat-that-does-not-crash) that can't throw exception. This method is going obsolete with the $"" syntax and will be removed.
* A string helper method [SplitAt](#splitat) that splits a string at a certain index or string.
* [Left, Right and Mid](#left-right-and-mid) methods behaving as we know from the BASIC heydays.

### The projects might contain in the future:
* SqlServer exceptions are notorious for having crucial data in the message and in an [integer](http://stackoverflow.com/questions/6221951/sqlexception-catch-and-handling) or in the [free text message](http://stackoverflow.com/questions/6982647/smart-way-to-get-unique-index-name-from-sqlexception-message). The plan is to create a library that can parse the message and return an exception that contains the information is a more technical fashion so it can be understood by a computer. The library might have to read meta data from the database server and then this functionality should be moved to a library of its own so as to not dirty CompulsoryCow with SqlServer dependencies. Another complications are different Sqlserver versions and different languages. A Spanish Sqlserver might return different error messages than an "English".
* A Linq method that returns true if [all items in a list are equal](http://stackoverflow.com/questions/1628658/linq-check-whether-two-list-are-the-same).

## License

License LGPLv3 + NoEvil.  
https://raw.githubusercontent.com/LosManos/CompulsoryCow/master/License.txt

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

*EOF*
