namespace IsEqualsImplementedAssemblyNotOk;

public class AClassWithEqualsNotCorrectlyImplemented
{
    public int MyProperty { get; set; }
    public int AnotherProperty { get; set; }

    public override bool Equals(object? obj)
    {
        var implemented = obj as AClassWithEqualsNotCorrectlyImplemented;
        return implemented is not null &&
               MyProperty == implemented.MyProperty;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(MyProperty);
    }

    public static bool operator ==(AClassWithEqualsNotCorrectlyImplemented implemented1, AClassWithEqualsNotCorrectlyImplemented implemented2)
    {
        return EqualityComparer<AClassWithEqualsNotCorrectlyImplemented>.Default.Equals(implemented1, implemented2);
    }

    public static bool operator !=(AClassWithEqualsNotCorrectlyImplemented implemented1, AClassWithEqualsNotCorrectlyImplemented implemented2)
    {
        return !(implemented1 == implemented2);
    }
}
