CompulsoryCow.IsEqualsImplemented - Release notes
====================

### [6.1.0]
Add Meta.`GetClassesWithAttribute<TAttribute>(AppDomain appDomain) where TAttribute : Attribute` method.

### [6.0.0]
Deprecated GetCallintMethod.
Deprecated GetProperty.
Instead use CallerMemberNameAttribute.
Remove compile warnings.

### Version 5.0.0
`public static PropertyInfo[] GetPublicProperties<T>(T theClass)` is exchanged for
`public static PropertyInfo[] GetPublicProperties(Type type, bool recurse = false)`.

### Version 4.0.0
GetPrivateField, GetPrivateProperty, GetPrivateMethod, GetPublicProperties returns ArgumentNullException if null arguments are provided.

### Version 3.0.0
Moved to a project of its own.
