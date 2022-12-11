using System.Globalization;

namespace CompulsoryCow.DateTime.Abstractions;

public partial class DateTime : IDateTime
{
    private static System.Func<DateTime> _systemNowFunc = () => System.DateTime.Now.ToAbstractionsDateTime();
    private static System.Func<DateTime> _now = _systemNowFunc;

    private static System.Func<DateTime> _systemTodayFunc = () => System.DateTime.Today.ToAbstractionsDateTime();
    private static System.Func<DateTime> _today = _systemTodayFunc;

    private static System.Func<DateTime> _systemUtcNow = () => System.DateTime.UtcNow.ToAbstractionsDateTime();
    private static System.Func<DateTime> _utcNow = _systemUtcNow;

    // There are lots of nullable references below. Can we get rid of them?
    private static System.Func<int>? _compare;
    private static System.Func<int>? _daysInMonth;
    private static System.Func<bool>? _equals;
    private static System.Func<DateTime>? _fromBinary;
    private static System.Func<DateTime>? _fromFileTime;
    private static System.Func<DateTime>? _fromFileTimeUtc;
    private static System.Func<DateTime>? _fromOADate;
    private static System.Func<bool>? _isLeapYear;
    private static System.Func<IDateTime>? _parseStringFormatProviderStyle;
    private static System.Func<IDateTime>? _parseStringFormatProvider;
    private static System.Func<IDateTime>? _parseString;
    private static System.Func<IDateTime>? _parseExactStringStringArrayFormatProviderStyle;
    private static System.Func<IDateTime>? _parseExactStringStringFormatProviderStyle;
    private static System.Func<IDateTime>? _parseExactStringStringFormatProvider;
    private static System.Func<DateTime>? _specifyKind;
    private static (System.Func<bool> Return, System.Func<IDateTime> Out) _setTryParseStringIFormatProviderDateTimeStylesDateTime;
    private static (System.Func<bool> Return, System.Func<IDateTime> Out) _setTryParseStringDateTime;
    private static (System.Func<bool> Return, System.Func<IDateTime> Out) _setTryParseExactStringStringIFormatProviderDateTimeStyles;
    private static (System.Func<bool> Return, System.Func<IDateTime> Out) _setTryParseExactStringStringArrayIFormatProviderDateTimeStyles;

    private static System.Func<DateTime>? _addOperator;
    private static System.Func<TimeSpan>? _subtractDateTimeDateTimeOperator;
    private static System.Func<DateTime>? _subtractDateTimeTimeSpanOperator;
    private static System.Func<bool>? _equalsOperator;
    private static System.Func<bool>? _notEqualsOperator;
    private static System.Func<bool>? _earlierThanOperator;
    private static System.Func<bool>? _laterThanOperator;
    private static System.Func<bool>? _earlierThanOrEqualOperator;
    private static System.Func<bool>? _laterThanOrEqualOperator;

    private readonly System.DateTime _value;

    #region Constructors.

    /// <summary>See <see cref="System.DateTime.DateTime(long)"/>.
    /// </summary>
    /// <param name="ticks"></param>
    public DateTime(long ticks)
    {
        _value = new System.DateTime(ticks);
    }

    /// <summary>See <see cref="System.DateTime.DateTime(long, System.DateTimeKind)"/>.
    /// </summary>
    /// <param name="ticks"></param>
    /// <param name="kind"></param>
    public DateTime(long ticks, System.DateTimeKind kind)
    {
        _value = new System.DateTime(ticks, kind);
    }

    /// <summary>See <see cref="System.DateTime.DateTime(int,int,int)"/>.
    /// </summary>
    /// <param name="year"></param>srs
    /// <param name="month"></param>
    /// <param name="day"></param>
    public DateTime(int year, int month, int day)
    {
        _value = new System.DateTime(year, month, day);
    }

    /// <summary>See <see cref="System.DateTime.DateTime(int, int, int, Calendar)"/>.
    /// </summary>
    /// <param name="anyValidYear"></param>
    /// <param name="anyValidMonth"></param>
    /// <param name="anyValidDay"></param>
    /// <param name="anyCalendar"></param>
    public DateTime(int anyValidYear, int anyValidMonth, int anyValidDay, TaiwanCalendar anyCalendar)
    {
        _value = new System.DateTime(anyValidYear, anyValidMonth, anyValidDay, anyCalendar);
    }

    /// <summary>See <see cref="System.DateTime.DateTime(int, int, int, int, int, int)"/>
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    public DateTime(int year, int month, int day, int hour, int minute, int second)
    {
        _value = new System.DateTime(year, month, day, hour, minute, second);
    }

    /// <summary>See <see cref="System.DateTime.DateTime(int, int, int, int, int, int, int, Calendar, System.DateTimeKind)"/>
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <param name="kind"></param>
    public DateTime(int year, int month, int day, int hour, int minute, int second, System.DateTimeKind kind)
    {
        _value = new System.DateTime(year, month, day, hour, minute, second, kind);
    }

    /// <summary>See <see cref="System.DateTime.DateTime(int, int, int, int, int, int, Calendar)"/>
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <param name="calendar"></param>
    public DateTime(int year, int month, int day, int hour, int minute, int second, Calendar calendar)
    {
        _value = new System.DateTime(year, month, day, hour, minute, second, calendar);
    }

    /// <summary>See <see cref="System.DateTime.DateTime(int, int, int, int, int, int, int)"/>
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <param name="millisecond"></param>
    public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond)
    {
        _value = new System.DateTime(year, month, day, hour, minute, second, millisecond);
    }

    /// <summary>See <see cref="System.DateTime.DateTime(int, int, int, int, int, int, int, System.DateTimeKind)"/>
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <param name="millisecond"></param>
    /// <param name="kind"></param>
    public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, System.DateTimeKind kind)
    {
        _value = new System.DateTime(year, month, day, hour, minute, second, millisecond, kind);
    }

    /// <summary>See <see cref="System.DateTime.DateTime(int, int, int, int, int, int, int, Calendar)"/>
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <param name="millisecond"></param>
    /// <param name="calendar"></param>
    public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar)
    {
        _value = new System.DateTime(year, month, day, hour, minute, second, millisecond, calendar);
    }

    /// <summary>See <see cref="System.DateTime.DateTime(int, int, int, int, int, int, int, Calendar, System.DateTimeKind)"/>.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <param name="millisecond"></param>
    /// <param name="calendar"></param>
    /// <param name="kind"></param>
    public DateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, System.DateTimeKind kind)
    {
        _value = new System.DateTime(year, month, day, hour, minute, second, millisecond, calendar, kind);
    }

    #endregion

    #region Static properties.

    /// <summary>See <see cref="System.DateTime.Now"/>.
    /// </summary>
    public static DateTime Now
    {
        get
        {
            return _now();
        }
    }

    /// <summary>See <see cref="System.DateTime.Today"/>.
    /// </summary>
    /// <returns></returns>
    public static DateTime Today
    {
        get
        {
            return _today();
        }
    }

    /// <summary>See <see cref="System.DateTime.UtcNow"/>.
    /// </summary>
    public static DateTime UtcNow
    {
        get
        {
            return _utcNow();
        }
    }

    #endregion

    #region Properties.

    /// <inheritdoc />
    public long Ticks { get { return _value.Ticks; } }

    /// <inheritdoc />
    public int Second { get { return _value.Second; } }

    /// <inheritdoc />
    public DateTime Date { get { return new DateTime(_value.Date.Ticks); } }

    /// <inheritdoc />
    public int Month { get { return _value.Month; } }

    /// <inheritdoc />
    public int Minute { get { return _value.Minute; } }

    /// <inheritdoc />
    public int Millisecond { get { return _value.Millisecond; } }

    /// <inheritdoc />
    public System.DateTimeKind Kind { get { return _value.Kind; } }

    /// <inheritdoc />
    public int Hour { get { return _value.Hour; } }

    /// <inheritdoc />
    public int DayOfYear { get { return _value.DayOfYear; } }

    /// <inheritdoc />
    public System.DayOfWeek DayOfWeek { get { return _value.DayOfWeek; } }

    /// <inheritdoc />
    public int Day { get { return _value.Day; } }

    /// <inheritdoc />
    public TimeSpan TimeOfDay { get { return new TimeSpan(_value.TimeOfDay.Ticks); } }

    /// <inheritdoc />
    public int Year { get { return _value.Year; } }

    #endregion

    #region Static methods, disguised as properties.

    /// <summary>See <see cref="System.DateTime.MaxValue"/>.
    /// </summary>
    public static DateTime MaxValue { get { return new DateTime(System.DateTime.MaxValue.Ticks); } }

    /// <summary>See <see cref="System.DateTime.MinValue"/>.
    /// </summary>
    public static DateTime MinValue { get { return new DateTime(System.DateTime.MinValue.Ticks); } }

    #endregion

    #region Static methods.

    /// <summary>See <see cref="System.DateTime.Compare(System.DateTime, System.DateTime)"/>.
    /// </summary>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <returns></returns>
    public static int Compare(DateTime t1, DateTime t2)
    {
        return _compare != null ?
            _compare() :
            System.DateTime.Compare(new System.DateTime(t1.Ticks), new System.DateTime(t2.Ticks));
    }

    /// <summary>See <see cref="System.DateTime.DaysInMonth(int, int)"/>.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <returns></returns>
    public static int DaysInMonth(int year, int month)
    {
        return _daysInMonth != null ?
            _daysInMonth() :
            System.DateTime.DaysInMonth(year, month);
    }

    /// <summary>See <see cref="System.DateTime.Equals(System.DateTime, System.DateTime)"/>.
    /// </summary>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <returns></returns>
    public static bool Equals(DateTime t1, DateTime t2)
    {
        return _equals != null ?
            _equals() :
            System.DateTime.Equals(new System.DateTime(t1.Ticks), new System.DateTime(t2.Ticks));
    }

    /// <summary>See <see cref="System.DateTime.FromBinary(long)"/>.
    /// </summary>
    /// <param name="dateData"></param>
    /// <returns></returns>
    public static DateTime FromBinary(long dateData)
    {
        return _fromBinary != null ?
            _fromBinary() :
            System.DateTime.FromBinary(dateData).ToAbstractionsDateTime();
    }

    /// <summary>See <see cref="System.DateTime.FromFileTime(long)"/>.
    /// </summary>
    /// <param name="fileTime"></param>
    /// <returns></returns>
    public static DateTime FromFileTime(long fileTime)
    {
        return _fromFileTime != null ?
            _fromFileTime() :
            System.DateTime.FromFileTime(fileTime).ToAbstractionsDateTime();
    }

    /// <summary>See <see cref="System.DateTime.FromFileTimeUtc(long)"/>.
    /// </summary>
    /// <param name="fileTime"></param>
    /// <returns></returns>
    public static DateTime FromFileTimeUtc(long fileTime)
    {
        return _fromFileTimeUtc != null ?
            _fromFileTimeUtc() :
            System.DateTime.FromFileTimeUtc(fileTime).ToAbstractionsDateTime();
    }

    /// <summary>See <see cref="System.DateTime.FromOADate(double)"/>.
    /// </summary>
    /// <param name="fileTime"></param>
    /// <returns></returns>
    public static DateTime FromOADate(double d)
    {
        return _fromOADate != null ?
            _fromOADate() :
            System.DateTime.FromOADate(d).ToAbstractionsDateTime();
    }

    /// <summary>See <see cref="System.DateTime.IsLeapYear(int)"/>.
    /// </summary>
    /// <param name="year"></param>
    /// <returns></returns>
    public static bool IsLeapYear(int year)
    {
        return _isLeapYear != null ?
            _isLeapYear() :
            System.DateTime.IsLeapYear(year);
    }

    /// <summary>See <see cref="System.DateTime.Parse(string, System.IFormatProvider, DateTimeStyles)"/>.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <param name="styles"></param>
    /// <returns></returns>
    public static IDateTime Parse(string s, System.IFormatProvider provider, DateTimeStyles styles)
    {
        return _parseStringFormatProviderStyle != null ?
            _parseStringFormatProviderStyle() :
            System.DateTime.Parse(s, provider, styles).ToAbstractionsDateTime();
    }

    /// <summary>See <see cref="System.DateTime.Parse(string, System.IFormatProvider)"/>.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static IDateTime Parse(string s, System.IFormatProvider provider)
    {
        return _parseStringFormatProvider != null ?
            _parseStringFormatProvider() :
            System.DateTime.Parse(s, provider).ToAbstractionsDateTime();
    }

    /// <summary>See <see cref="System.DateTime.Parse(string)"/>.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static IDateTime Parse(string s)
    {
        return _parseString != null ?
            _parseString():
            System.DateTime.Parse(s).ToAbstractionsDateTime();
    }

    /// <summary>See <see cref="System.DateTime.ParseExact(string, string[], System.IFormatProvider, DateTimeStyles)"/>.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="formats"></param>
    /// <param name="provider"></param>
    /// <param name="style"></param>
    /// <returns></returns>
    public static IDateTime ParseExact(string s, string[] formats, System.IFormatProvider provider, DateTimeStyles style)
    {
        return _parseExactStringStringArrayFormatProviderStyle != null ?
            _parseExactStringStringArrayFormatProviderStyle() :
            System.DateTime.ParseExact(s, formats, provider, style).ToAbstractionsDateTime();
    }

    /// <summary>See <see cref="System.DateTime.ParseExact(string, string, System.IFormatProvider, DateTimeStyles)"/>.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="format"></param>
    /// <param name="provider"></param>
    /// <param name="style"></param>
    /// <returns></returns>
    public static IDateTime ParseExact(string s, string format, System.IFormatProvider provider, DateTimeStyles style)
    {
        return _parseExactStringStringFormatProviderStyle != null ?
            _parseExactStringStringFormatProviderStyle():
            System.DateTime.ParseExact(s, format, provider, style).ToAbstractionsDateTime();
    }

    /// <summary>See <see cref="System.DateTime.ParseExact(string, string, System.IFormatProvider)"/>.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="format"></param>
    /// <param name="provider"></param>
    /// <returns></returns>
    public static IDateTime ParseExact(string s, string format, System.IFormatProvider provider)
    {
        return _parseExactStringStringFormatProvider != null ?
            _parseExactStringStringFormatProvider() :
            System.DateTime.ParseExact(s, format, provider).ToAbstractionsDateTime();
    }

    /// <summary>See <see cref="System.DateTime.SpecifyKind(System.DateTime, System.DateTimeKind)"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="kind"></param>
    /// <returns></returns>
    public static DateTime SpecifyKind(DateTime value, System.DateTimeKind kind)
    {
        return _specifyKind != null ?
            _specifyKind() :
            System.DateTime.SpecifyKind(value.ToSystemDateTime(), kind).ToAbstractionsDateTime();
    }

    /// <summary>See <see cref="System.DateTime.TryParse(string, System.IFormatProvider, DateTimeStyles, out System.DateTime)"/>.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <param name="styles"></param>
    /// <param name="resultOut"></param>
    /// <returns></returns>
    public static bool TryParse(string s, System.IFormatProvider provider, DateTimeStyles styles, out DateTime resultOut)
    {
        var ret = System.DateTime.TryParse(s, provider, styles, out var @out);

        ret = _setTryParseStringIFormatProviderDateTimeStylesDateTime.Return == null ?
            ret : _setTryParseStringIFormatProviderDateTimeStylesDateTime.Return();

        resultOut = _setTryParseStringIFormatProviderDateTimeStylesDateTime.Out == null ?
            new DateTime(
                @out.Ticks,
                @out.Kind) :
            new DateTime(
                _setTryParseStringIFormatProviderDateTimeStylesDateTime.Out().Ticks,
                _setTryParseStringIFormatProviderDateTimeStylesDateTime.Out().Kind);

        return ret;
    }

    /// <summary>See <see cref="System.DateTime.TryParse(string, out System.DateTime)"/>.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse(string s, out DateTime result)
    {
        var ret = System.DateTime.TryParse(s, out var @out);

        ret = _setTryParseStringDateTime.Return == null ?
            ret : _setTryParseStringDateTime.Return();

        result = _setTryParseStringDateTime.Out == null ?
            new DateTime(
                @out.Ticks,
                @out.Kind) :
            new DateTime(
                _setTryParseStringDateTime.Out().Ticks,
                _setTryParseStringDateTime.Out().Kind);

        return ret;
    }

    /// <summary>See <see cref="System.DateTime.TryParseExact(string, string, System.IFormatProvider, DateTimeStyles, out System.DateTime)"/>.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="format"></param>
    /// <param name="provider"></param>
    /// <param name="style"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParseExact(string s, string format, System.IFormatProvider provider, DateTimeStyles style, out DateTime result)
    {
        var ret = System.DateTime.TryParseExact(s, format, provider, style, out var @out);

        ret = _setTryParseExactStringStringIFormatProviderDateTimeStyles.Return == null ?
            ret : _setTryParseExactStringStringIFormatProviderDateTimeStyles.Return();

        result = _setTryParseExactStringStringIFormatProviderDateTimeStyles.Out == null ?
            new DateTime(
                @out.Ticks,
                @out.Kind) :
                new DateTime(
                    _setTryParseExactStringStringIFormatProviderDateTimeStyles.Out().Ticks,
                    _setTryParseExactStringStringIFormatProviderDateTimeStyles.Out().Kind);

        return ret;
    }

    /// <summary>See <see cref="System.DateTime.TryParseExact(string, string[], System.IFormatProvider, DateTimeStyles, out System.DateTime)"/>.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="formats"></param>
    /// <param name="provider"></param>
    /// <param name="style"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParseExact(string s, string[] formats, System.IFormatProvider provider, DateTimeStyles style, out DateTime result)
    {
        var ret = System.DateTime.TryParseExact(s, formats, provider, style, out var @out);

        ret = _setTryParseExactStringStringArrayIFormatProviderDateTimeStyles.Return == null ?
            ret : _setTryParseExactStringStringArrayIFormatProviderDateTimeStyles.Return();

        result = _setTryParseExactStringStringArrayIFormatProviderDateTimeStyles.Out == null ?
            new DateTime(
                @out.Ticks,
                @out.Kind) :
                new DateTime(
                    _setTryParseExactStringStringArrayIFormatProviderDateTimeStyles.Out().Ticks,
                    _setTryParseExactStringStringArrayIFormatProviderDateTimeStyles.Out().Kind);

        return ret;
    }

    #endregion

    #region Instance methods.

    /// <inheritdoc/>
    public DateTime Add(TimeSpan value)
    {
        return _value.Add(value.ToSystemTimeSpan()).ToAbstractionsDateTime();
    }

    /// <inheritdoc/>
    public DateTime AddDays(double value)
    {
        return _value.AddDays(value).ToAbstractionsDateTime();
    }

    /// <inheritdoc/>
    public DateTime AddHours(double value)
    {
        return _value.AddHours(value).ToAbstractionsDateTime();
    }

    /// <inheritdoc/>
    public DateTime AddMilliseconds(double value)
    {
        return _value.AddMilliseconds(value).ToAbstractionsDateTime();
    }

    /// <inheritdoc/>
    public DateTime AddMinutes(double value)
    {
        return _value.AddMinutes(value).ToAbstractionsDateTime();
    }

    /// <inheritdoc/>
    public DateTime AddMonths(int months)
    {
        return _value.AddMonths(months).ToAbstractionsDateTime();
    }

    /// <inheritdoc/>
    public DateTime AddSeconds(double value)
    {
        return _value.AddSeconds(value).ToAbstractionsDateTime();
    }

    /// <inheritdoc/>
    public DateTime AddTicks(long value)
    {
        return _value.AddTicks(value).ToAbstractionsDateTime();
    }

    /// <inheritdoc/>
    public DateTime AddYears(int value)
    {
        return _value.AddYears(value).ToAbstractionsDateTime();
    }

    /// <inheritdoc/>
    public int CompareTo(DateTime value)
    {
        // Value is never null for System.DateTime.CompareTo as
        // System.DateTime is not nullable.
        // With Dotnet3 we can probably replicate that with setting the parameter
        // to be not nullable but for now we return the same result as 
        // System.DateTime.CompareTo(object).
        if (value == null)
        {
            return _value.CompareTo(value);
        }
        return _value.CompareTo(value.ToSystemDateTime());
    }

    /// <inheritdoc/>
    public int CompareTo(object value)
    {
        if (value == null)
        {
            return _value.CompareTo(value);
        }
        if ((value is DateTime) == false)
        {
            _value.CompareTo(value); // Will throw an exception, the same as System will.
        }
        return _value.CompareTo(((DateTime)value).ToSystemDateTime());
    }

    /// <inheritdoc/>
    public override bool Equals(object value)
    {
        if (value == null)
        {
            return _value.Equals(value);
        }
        if (value is DateTime)
        {
            return _value.Equals(((DateTime)value).ToSystemDateTime());
        }
        return _value.Equals(value);
    }

    /// <inheritdoc/>
    public bool Equals(DateTime value)
    {
        // Value is never null for System.DateTime.CompareTo as
        // System.DateTime is not nullable.
        // With Dotnet3 we can probably replicate that with setting the parameter
        // to be not nullable but for now we return the same result as 
        // System.DateTime.CompareTo(object).
        if (value == null)
        {
            return _value.Equals(value);
        }

        if (value is DateTime)
        {
            return _value.Equals(value.ToSystemDateTime());
        }
        return _value.Equals(value);
    }

    /// <inheritdoc/>
    public string[] GetDateTimeFormats(char format, System.IFormatProvider provider)
    {
        return _value.GetDateTimeFormats(format, provider);
    }

    /// <inheritdoc/>
    public string[] GetDateTimeFormats(char format)
    {
        return _value.GetDateTimeFormats(format);
    }

    /// <inheritdoc/>
    public string[] GetDateTimeFormats()
    {
        return _value.GetDateTimeFormats();
    }

    /// <inheritdoc/>
    public string[] GetDateTimeFormats(System.IFormatProvider provider)
    {
        return _value.GetDateTimeFormats(provider);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    /// <inheritdoc/>
    public System.TypeCode GetTypeCode()
    {
        return _value.GetTypeCode();
    }

    /// <inheritdoc/>
    public bool IsDaylightSavingTime()
    {
        return _value.IsDaylightSavingTime();
    }

    /// <inheritdoc/>
    public TimeSpan Subtract(DateTime value)
    {
        return new TimeSpan(_value.Subtract(value.ToSystemDateTime()).Ticks);
    }

    /// <inheritdoc/>
    public DateTime Subtract(TimeSpan value)
    {
        return _value.Subtract(value.ToSystemTimeSpan()).ToAbstractionsDateTime();
    }

    /// <inheritdoc/>
    public long ToBinary()
    {
        return _value.ToBinary();
    }

    /// <inheritdoc/>
    public long ToFileTime()
    {
        return _value.ToFileTime();
    }

    /// <inheritdoc/>
    public long ToFileTimeUtc()
    {
        return _value.ToFileTimeUtc();
    }

    /// <inheritdoc/>
    public DateTime ToLocalTime()
    {
        return _value.ToLocalTime().ToAbstractionsDateTime();
    }

    /// <inheritdoc/>
    public string ToLongDateString()
    {
        return _value.ToLongDateString();
    }

    /// <inheritdoc/>
    public string ToLongTimeString()
    {
        return _value.ToLongTimeString();
    }

    /// <inheritdoc/>
    public double ToOADate()
    {
        return _value.ToOADate();
    }

    /// <inheritdoc/>
    public string ToShortDateString()
    {
        return _value.ToShortDateString();
    }

    /// <inheritdoc/>
    public string ToShortTimeString()
    {
        return _value.ToShortTimeString();
    }

    /// <inheritdoc/>
    public string ToString(string format)
    {
        return _value.ToString(format);
    }

    /// <inheritdoc/>
    public string ToString(System.IFormatProvider provider)
    {
        return _value.ToString(provider);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return _value.ToString();
    }

    /// <inheritdoc/>
    public string ToString(string format, System.IFormatProvider provider)
    {
        return _value.ToString(format, provider);
    }

    /// <inheritdoc/>
    public DateTime ToUniversalTime()
    {
        return _value.ToUniversalTime().ToAbstractionsDateTime();
    }

    #endregion  //  Instance methods.

    #region Operators.

    /// <summary>See + operator in <see cref="System.DateTime"/>.
    /// https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_addition
    /// </summary>
    /// <param name="d"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static DateTime operator +(DateTime d, TimeSpan t)
    {
        if (_addOperator != null)
        {
            return _addOperator();
        }

        return (d.ToSystemDateTime() + t.ToSystemTimeSpan()).ToAbstractionsDateTime();
    }

    /// <summary>See - operator in <see cref="System.DateTime"/>.
    /// https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_subtraction#System_DateTime_op_Subtraction_System_DateTime_System_DateTime_
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static TimeSpan operator -(DateTime d1, DateTime d2)
    {
        if (_subtractDateTimeDateTimeOperator != null)
        {
            return _subtractDateTimeDateTimeOperator();
        }

        return new TimeSpan((d1.ToSystemDateTime() - d2.ToSystemDateTime()).Ticks);
    }

    /// <summary>See - operator in <see cref="System.DateTime"/>.
    /// https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_subtraction#System_DateTime_op_Subtraction_System_DateTime_System_TimeSpan_
    /// </summary>
    /// <param name="d"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static DateTime operator -(DateTime d, TimeSpan t)
    {
        if (_subtractDateTimeTimeSpanOperator != null)
        {
            return _subtractDateTimeTimeSpanOperator();
        }

        return (d.ToSystemDateTime() - t.ToSystemTimeSpan()).ToAbstractionsDateTime();
    }

    /// <summary>See == operator in <see cref="System.DateTime"/>
    /// https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_equality
    /// 
    /// Note: There is a difference between System.DateTime and Abstractions.DateTime here
    /// as System.DateTime is a struct and hence cannot be null while Abstractions.DateTime is a class
    /// and can be null.
    /// In the future this should change when we can use non nullable references.
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static bool operator ==(DateTime d1, DateTime d2)
    {
        if( _equalsOperator != null)
        {
            return _equalsOperator();
        }

        if ( OnlyOneIsNull(d1, d2))
        {
            return false;
        }

        if( BothAreNull(d1, d2))
        {
            return true;
        }

        return d1.ToSystemDateTime() == d2.ToSystemDateTime();
    }

    /// <summary>See != operator in <see cref="System.DateTime"/>
    /// https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_inequality
    /// 
    /// Note: There is a difference between System.DateTime and Abstractions.DateTime here
    /// as System.DateTime is a struct and hence cannot be null while Abstractions.DateTime is a class
    /// and can be null.
    /// In the future this should change when we can use non nullable references.
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static bool operator !=(DateTime d1, DateTime d2)
    {
        if(_notEqualsOperator != null)
        {
            return _notEqualsOperator();
        }

        if (OnlyOneIsNull(d1, d2))
        {
            return true;
        }

        if (BothAreNull(d1, d2))
        {
            return false;
        }

        return d1.ToSystemDateTime() != d2.ToSystemDateTime();
    }

    /// <summary>See < operator in <see cref="System.DateTime"/>
    /// https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_lessthan
    /// 
    /// Note: There is a difference between System.DateTime and Abstractions.DateTime here
    /// as System.DateTime is a struct and hence cannot be null while Abstractions.DateTime is a class
    /// and can be null.
    /// In the future this should change when we can use non nullable references.
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static bool operator <(DateTime d1, DateTime d2)
    {
        if (_earlierThanOperator != null)
        {
            return _earlierThanOperator();
        }

        ThrowIfNull(nameof(d1), d1);
        ThrowIfNull(nameof(d2), d2);

        return d1.ToSystemDateTime() < d2.ToSystemDateTime();
    }

    /// <summary>See > operator in <see cref="System.DateTime"/>
    /// https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_lessthan
    /// 
    /// Note: There is a difference between System.DateTime and Abstractions.DateTime here
    /// as System.DateTime is a struct and hence cannot be null while Abstractions.DateTime is a class
    /// and can be null.
    /// In the future this should change when we can use non nullable references.
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static bool operator >(DateTime d1, DateTime d2)
    {
        if (_laterThanOperator != null)
        {
            return _laterThanOperator();
        }

        ThrowIfNull(nameof(d1), d1);
        ThrowIfNull(nameof(d2), d2);

        return d1.ToSystemDateTime() > d2.ToSystemDateTime();
    }

    /// <summary>See <= operator in <see cref="System.DateTime"/>
    /// https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_lessthan
    /// 
    /// Note: There is a difference between System.DateTime and Abstractions.DateTime here
    /// as System.DateTime is a struct and hence cannot be null while Abstractions.DateTime is a class
    /// and can be null.
    /// In the future this should change when we can use non nullable references.
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static bool operator <=(DateTime d1, DateTime d2)
    {
        if (_earlierThanOrEqualOperator != null)
        {
            return _earlierThanOrEqualOperator();
        }

        ThrowIfNull(nameof(d1), d1);
        ThrowIfNull(nameof(d2), d2);

        return d1.ToSystemDateTime() <= d2.ToSystemDateTime();
    }

    /// <summary>See >= operator in <see cref="System.DateTime"/>
    /// https://docs.microsoft.com/en-us/dotnet/api/system.datetime.op_lessthan
    /// 
    /// Note: There is a difference between System.DateTime and Abstractions.DateTime here
    /// as System.DateTime is a struct and hence cannot be null while Abstractions.DateTime is a class
    /// and can be null.
    /// In the future this should change when we can use non nullable references.
    /// </summary>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <returns></returns>
    public static bool operator >=(DateTime d1, DateTime d2)
    {
        if (_laterThanOrEqualOperator != null)
        {
            return _laterThanOrEqualOperator();
        }

        ThrowIfNull(nameof(d1), d1);
        ThrowIfNull(nameof(d2), d2);

        return d1.ToSystemDateTime() >= d2.ToSystemDateTime();
    }

    #endregion  //  Operators.

    #region Private helper methods.

    private static bool BothAreNull(DateTime d1, DateTime d2)
    {
        return IsNull(d1) && IsNull(d2);
    }

    //private static DateTime FromSystemDateTime(System.DateTime datetime)
    //{
    //    return new DateTime(datetime.Ticks, datetime.Kind);
    //}

    /// <summary>This helper method returns if the datetime is null 
    /// without touching the == operator we are overloading.
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    private static bool IsNull(DateTime d)
    {
        return object.Equals(d, null);
    }

    private static bool OnlyOneIsNull(DateTime d1, DateTime d2)
    {
        return (IsNull(d1) && !IsNull(d2)) ||
            (!IsNull(d1) && IsNull(d2));
    }

    private static void ThrowIfNull(string parameterName, DateTime d)
    {
        if (object.Equals(d, null))
        {
            throw new System.ArgumentNullException(parameterName, "Argument should be considered as not nullable.");
        }
    }

    #endregion
}
