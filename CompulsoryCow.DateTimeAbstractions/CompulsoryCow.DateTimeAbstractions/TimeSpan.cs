[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("CompulsoryCow.DateTimeAbstractions.Unit.Tests")]

namespace CompulsoryCow.DateTime.Abstractions;

/// TODO:OF:Implement interfaces at https:///docs.microsoft.com/en-us/dotnet/api/system.timespan?view=netcore-2.2
public struct TimeSpan : ITimeSpan
{
    private readonly System.TimeSpan _value;

    public TimeSpan(long ticks)
    {
        _value = new System.TimeSpan(ticks);
    }

    public TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds)
    {
        _value = new System.TimeSpan(days, hours, minutes, seconds, milliseconds);
    }

    public long Ticks { get { return _value.Ticks; } }

    public double TotalMilliseconds => _value.TotalMilliseconds;

    public double TotalHours => _value.TotalHours;

    public double TotalDays => _value.TotalDays;

    public int Seconds => _value.Seconds;

    public int Minutes => _value.Minutes;

    public int Milliseconds => _value.Milliseconds;

    public int Hours => _value.Hours;

    public int Days => _value.Days;

    public double TotalMinutes => _value.TotalMinutes;

    public double TotalSeconds => _value.TotalSeconds;

    ///  <summary>This method converts the <see cref="TimeSpan"/> to <see cref="System.TimeSpan"/>.
    /// It should only be used for tests and is not part of the TimeSpan interface.
    /// </summary>
    /// <returns></returns>
    internal System.TimeSpan ToSystemTimeSpan()
    {
        return _value;
    }
}
