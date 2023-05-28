namespace IsEqualsImplementedAssemblyOk;

public class AClassWithEqualsCorrectlyImplemented
{
    public int MyProperty { get; set; }

    public override bool Equals(object? obj)
    {
        var implemented = obj as AClassWithEqualsCorrectlyImplemented;
        return implemented is not null &&
               MyProperty == implemented.MyProperty;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(MyProperty);
    }

    public static bool operator ==(AClassWithEqualsCorrectlyImplemented implemented1, AClassWithEqualsCorrectlyImplemented implemented2)
    {
        return EqualityComparer<AClassWithEqualsCorrectlyImplemented>.Default.Equals(implemented1, implemented2);
    }

    public static bool operator !=(AClassWithEqualsCorrectlyImplemented implemented1, AClassWithEqualsCorrectlyImplemented implemented2)
    {
        return !(implemented1 == implemented2);
    }
}
