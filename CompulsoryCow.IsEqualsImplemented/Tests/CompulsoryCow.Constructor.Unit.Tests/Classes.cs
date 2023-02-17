namespace CompulsoryCow.Constructor.Unit.Tests;

public class ImplicitDefaultConstructorAttribute : Attribute{}

[ImplicitDefaultConstructor]
public class MyImplicitClass{}

public class NoDefaultConstructorAttribute : Attribute{}

[ExplicitDefaultConstructor]
public class MyExplicitClass
{
    public MyExplicitClass() { }
}

public class ExplicitDefaultConstructorAttribute : Attribute{}

[NoDefaultConstructor]
public class MyNoDefaultClass
{
    public MyNoDefaultClass(int _)
    { }
}

public class AttributeNoOneHasImplemented : Attribute { }