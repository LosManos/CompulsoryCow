using System;

namespace CompulsoryCow.Permutation.Unit.Tests;

public abstract class EnumLookAlikeClass : IComparable, IConvertible, IFormattable
{
    public abstract int CompareTo(object obj);
    public abstract TypeCode GetTypeCode();
    public abstract bool ToBoolean(IFormatProvider provider);
    public abstract byte ToByte(IFormatProvider provider);
    public abstract char ToChar(IFormatProvider provider);
    public abstract DateTime ToDateTime(IFormatProvider provider);
    public abstract decimal ToDecimal(IFormatProvider provider);
    public abstract double ToDouble(IFormatProvider provider);
    public abstract short ToInt16(IFormatProvider provider);
    public abstract int ToInt32(IFormatProvider provider);
    public abstract long ToInt64(IFormatProvider provider);
    public abstract sbyte ToSByte(IFormatProvider provider);
    public abstract float ToSingle(IFormatProvider provider);
    public abstract string ToString(IFormatProvider provider);
    public abstract string ToString(string format, IFormatProvider formatProvider);
    public abstract object ToType(Type conversionType, IFormatProvider provider);
    public abstract ushort ToUInt16(IFormatProvider provider);
    public abstract uint ToUInt32(IFormatProvider provider);
    public abstract ulong ToUInt64(IFormatProvider provider);
}
