using System.Globalization;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("CompulsoryCow.DateTimeAbstractions.Unit.Tests")]

namespace CompulsoryCow.DateTime.Abstractions
{
    public class DateTime : IDateTime
    {
        private static System.DateTime? _now;
        private static System.DateTime? _utcNow;
        private static System.Func<int> _compare;
        private static System.Func<int> _daysInMonth;
        private static System.Func<bool> _equals;
        private static System.Func<DateTime> _fromBinary;
        private static System.Func<DateTime> _fromFileTime;
        private static System.Func<DateTime> _fromFileTimeUtc;
        private static System.Func<DateTime> _fromOADate;
        private static System.Func<bool> _isLeapYear;
        private static System.Func<IDateTime> _parseStringFormatProviderStyle;
        private static System.Func<IDateTime> _parseStringFormatProvider;
        private static System.Func<IDateTime> _parseString;
        private static System.Func<IDateTime> _parseExactStringStringArrayFormatProviderStyle;
        private static System.Func<IDateTime> _parseExactStringStringFormatProviderStyle;
        private static System.Func<IDateTime> _parseExactStringStringFormatProvider;
        private static System.Func<DateTime> _specifyKind;
        private static (System.Func<bool> Return, System.Func<IDateTime> Out) _setTryParseStringIFormatProviderDateTimeStylesDateTime;
        private static (System.Func<bool> Return, System.Func<IDateTime> Out) _setTryParseStringDateTime;
        private static (System.Func<bool> Return, System.Func<IDateTime> Out) _setTryParseExactStringStringIFormatProviderDateTimeStyles;
        private static (System.Func<bool> Return, System.Func<IDateTime> Out) _setTryParseExactStringStringArrayIFormatProviderDateTimeStyles;

        private static System.Func<DateTime> _addOperator;
        private static System.Func<TimeSpan> _subtractDateTimeDateTimeOperator;
        private static System.Func<DateTime> _subtractDateTimeTimeSpanOperator;
        private static System.Func<bool> _equalsOperator;
        private static System.Func<bool> _notEqualsOperator;
        private static System.Func<bool> _earlierThanOperator;
        private static System.Func<bool> _laterThanOperator;
        private static System.Func<bool> _earlierThanOrEqualOperator;
        private static System.Func<bool> _laterThanOrEqualOperator;

        private readonly System.DateTime _value;

        private System.Func<DateTime> _addDays;
        private System.Func<DateTime> _addHours;
        private System.Func<DateTime> _addMilliseconds;
        private System.Func<DateTime> _addMinutes;
        private System.Func<DateTime> _addMonths;
        private System.Func<DateTime> _addSeconds;
        private System.Func<DateTime> _addTicks;
        private System.Func<DateTime> _addYears;
        private System.Func<int> _compareToDateTime;
        private System.Func<int> _compareToObject;
        private System.Func<bool> _equalsObject;
        private System.Func<bool> _equalsDateTime;
        private System.Func<string[]> _getDateTimeFormatsCharIFormatProvider;
        private System.Func<string[]> _getDateTimeFormatsChar;
        private System.Func<string[]> _getDateTimeFormats;
        private System.Func<string[]> _getDateTimeFormatsIFormatProvider;
        private System.Func<int> _getHashCode;
        private System.Func<System.TypeCode> _getTypeCode;
        private System.Func<bool> _isDaylightSavingTime;
        private System.Func<TimeSpan> _subtractDateTime;
        private System.Func<DateTime> _subtractTimeSpan;
        private System.Func<long> _toBinary;
        private System.Func<long> _toFileTime;
        private System.Func<long> _toFileTimeUtc;
        private System.Func<DateTime> _toLocalTime;
        private System.Func<string> _toLongDateString;
        private System.Func<string> _toLongTimeString;
        private System.Func<double> _toOADate;
        private System.Func<string> _toShortDateString;
        private System.Func<string> _toShortTimeString;
        private System.Func<string> _toStringString;
        private System.Func<string> _toStringIFormatProvider;
        private System.Func<string> _toString;
        private System.Func<string> _toStringStringIFormatProvider;
        private System.Func<DateTime> _toUniversalTime;

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
                return new DateTime(_now?.Ticks ?? System.DateTime.Now.Ticks);
            }
        }

        /// <summary>See <see cref="System.DateTime.UtcNow"/>.
        /// </summary>
        public static DateTime UtcNow
        {
            get
            {
                return new DateTime(_utcNow?.Ticks ?? System.DateTime.UtcNow.Ticks);
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
            if (t1 == null)
            {
                throw new System.ArgumentNullException(nameof(t1));
            }
            if (t2 == null)
            {
                throw new System.ArgumentNullException(nameof(t2));
            }

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
            if (t1 == null)
            {
                throw new System.ArgumentNullException(nameof(t1));
            }
            if (t2 == null)
            {
                throw new System.ArgumentNullException(nameof(t2));
            }

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
                FromSystemDateTime( System.DateTime.FromBinary(dateData));
        }

        /// <summary>See <see cref="System.DateTime.FromFileTime(long)"/>.
        /// </summary>
        /// <param name="fileTime"></param>
        /// <returns></returns>
        public static DateTime FromFileTime(long fileTime)
        {
            return _fromFileTime != null ?
                _fromFileTime() :
                FromSystemDateTime(System.DateTime.FromFileTime(fileTime));
        }

        /// <summary>See <see cref="System.DateTime.FromFileTimeUtc(long)"/>.
        /// </summary>
        /// <param name="fileTime"></param>
        /// <returns></returns>
        public static DateTime FromFileTimeUtc(long fileTime)
        {
            return _fromFileTimeUtc != null ?
                _fromFileTimeUtc() :
                FromSystemDateTime(System.DateTime.FromFileTimeUtc(fileTime));
        }
        /// <summary>See <see cref="System.DateTime.FromOADate(double)"/>.
        /// </summary>
        /// <param name="fileTime"></param>
        /// <returns></returns>
        public static DateTime FromOADate(double d)
        {
            return _fromOADate != null ?
                _fromOADate() :
                FromSystemDateTime(System.DateTime.FromOADate(d));
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
                FromSystemDateTime(System.DateTime.Parse(s, provider, styles));
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
                FromSystemDateTime(System.DateTime.Parse(s, provider));
        }

        /// <summary>See <see cref="System.DateTime.Parse(string)"/>.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static IDateTime Parse(string s)
        {
            return _parseString != null ?
                _parseString():
                FromSystemDateTime(System.DateTime.Parse(s));
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
                FromSystemDateTime(System.DateTime.ParseExact(s, formats, provider, style));
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
                FromSystemDateTime(System.DateTime.ParseExact(s, format, provider, style));
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
                FromSystemDateTime(System.DateTime.ParseExact(s, format, provider));
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
                FromSystemDateTime(System.DateTime.SpecifyKind(ToSystem(value), kind));
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
            return FromSystemDateTime(_value.Add(value.ToSystemTimeSpan()));
        }

        /// <inheritdoc/>
        public DateTime AddDays(double value)
        {
            return _addDays == null ?
                FromSystemDateTime(_value.AddDays(value)) :
                _addDays();
        }

        /// <inheritdoc/>
        public DateTime AddHours(double value)
        {
            return _addHours == null ?
                FromSystemDateTime(_value.AddHours(value)) :
                _addHours();
        }

        /// <inheritdoc/>
        public DateTime AddMilliseconds(double value)
        {
            return _addMilliseconds == null ?
                FromSystemDateTime(_value.AddMilliseconds(value)) :
                _addMilliseconds();
        }

        /// <inheritdoc/>
        public DateTime AddMinutes(double value)
        {
            return _addMinutes == null ?
                FromSystemDateTime(_value.AddMinutes(value)) :
                _addMinutes();
        }

        /// <inheritdoc/>
        public DateTime AddMonths(int months)
        {
            return _addMonths == null ?
                FromSystemDateTime(_value.AddMonths(months)) :
                _addMonths();
        }

        /// <inheritdoc/>
        public DateTime AddSeconds(double value)
        {
            return _addSeconds == null ?
                FromSystemDateTime(_value.AddSeconds(value)) :
                _addSeconds();
        }

        /// <inheritdoc/>
        public DateTime AddTicks(long value)
        {
            return _addTicks == null ?
                FromSystemDateTime(_value.AddTicks(value)) :
                _addTicks();
        }

        /// <inheritdoc/>
        public DateTime AddYears(int value)
        {
            return _addYears == null ?
                FromSystemDateTime(_value.AddYears(value)) :
                _addYears();
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
            if (_compareToDateTime != null)
            {
                return _compareToDateTime();
            }
            return _value.CompareTo(ToSystem(value));
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
            if (_compareToObject != null)
            {
                return _compareToObject();
            }
            return _value.CompareTo(ToSystem((DateTime)value));
        }

        /// <inheritdoc/>
        public override bool Equals(object value)
        {
            if (_equalsObject != null)
            {
                return _equalsObject();
            }
            if (value == null)
            {
                return _value.Equals(value);
            }
            if (value is DateTime)
            {
                return _value.Equals(ToSystem((DateTime)value));
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

            if (_equalsDateTime != null)
            {
                return _equalsDateTime();
            }
            if (value is DateTime)
            {
                return _value.Equals(ToSystem((DateTime)value));
            }
            return _value.Equals(value);
        }

        /// <inheritdoc/>
        public string[] GetDateTimeFormats(char format, System.IFormatProvider provider)
        {
            return
                _getDateTimeFormatsCharIFormatProvider != null ?
                _getDateTimeFormatsCharIFormatProvider() :
                _value.GetDateTimeFormats(format, provider);
        }

        /// <inheritdoc/>
        public string[] GetDateTimeFormats(char format)
        {
            return
                _getDateTimeFormatsChar != null ?
                _getDateTimeFormatsChar() :
                _value.GetDateTimeFormats(format);
        }

        /// <inheritdoc/>
        public string[] GetDateTimeFormats()
        {
            return
                _getDateTimeFormats != null ?
                _getDateTimeFormats() :
                _value.GetDateTimeFormats();
        }

        /// <inheritdoc/>
        public string[] GetDateTimeFormats(System.IFormatProvider provider)
        {
            return
                _getDateTimeFormatsIFormatProvider != null ?
                _getDateTimeFormatsIFormatProvider() :
                _value.GetDateTimeFormats(provider);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return _getHashCode != null ?
                _getHashCode() :
                _value.GetHashCode();
        }

        /// <inheritdoc/>
        public System.TypeCode GetTypeCode()
        {
            return _getTypeCode != null ?
                _getTypeCode() :
                _value.GetTypeCode();
        }

        /// <inheritdoc/>
        public bool IsDaylightSavingTime()
        {
            return _isDaylightSavingTime != null ?
                _isDaylightSavingTime() :
                _value.IsDaylightSavingTime();
        }

        /// <inheritdoc/>
        public TimeSpan Subtract(DateTime value)
        {
            return _subtractDateTime != null ?
                _subtractDateTime() :
                new TimeSpan(_value.Subtract(ToSystem(value)).Ticks);
        }

        /// <inheritdoc/>
        public DateTime Subtract(TimeSpan value)
        {
            return _subtractTimeSpan != null ?
                _subtractTimeSpan() :
                FromSystemDateTime(_value.Subtract(value.ToSystemTimeSpan()));
        }

        /// <inheritdoc/>
        public long ToBinary()
        {
            return _toBinary != null ?
                _toBinary() :
                _value.ToBinary();
        }

        /// <inheritdoc/>
        public long ToFileTime()
        {
            return _toFileTime != null ?
                _toFileTime() :
                _value.ToFileTime();
        }

        /// <inheritdoc/>
        public long ToFileTimeUtc()
        {
            return _toFileTimeUtc != null ?
                _toFileTimeUtc() :
                _value.ToFileTime();
        }

        /// <inheritdoc/>
        public DateTime ToLocalTime()
        {
            return _toLocalTime != null ?
                _toLocalTime() :
                FromSystemDateTime(_value.ToLocalTime());
        }

        /// <inheritdoc/>
        public string ToLongDateString()
        {
            return _toLongDateString != null ?
                _toLongDateString() :
                _value.ToLongDateString();
        }

        /// <inheritdoc/>
        public string ToLongTimeString()
        {
            return _toLongTimeString != null ?
                _toLongTimeString() :
                _value.ToLongTimeString();
        }

        /// <inheritdoc/>
        public double ToOADate()
        {
            return _toOADate != null ?
                _toOADate() :
                _value.ToOADate();
        }

        /// <inheritdoc/>
        public string ToShortDateString()
        {
            return _toShortDateString != null ?
                _toShortDateString() :
                _value.ToShortDateString();
        }

        /// <inheritdoc/>
        public string ToShortTimeString()
        {
            return _toShortTimeString != null ?
                _toShortTimeString() :
                _value.ToShortTimeString();
        }

        /// <inheritdoc/>
        public string ToString(string format)
        {
            return _toStringString != null ?
                _toStringString() :
                _value.ToString(format);
        }

        /// <inheritdoc/>
        public string ToString(System.IFormatProvider provider)
        {
            return _toStringIFormatProvider != null ?
                _toStringIFormatProvider() :
                _value.ToString(provider);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _toString != null ?
                _toString() :
                _value.ToString();
        }

        /// <inheritdoc/>
        public string ToString(string format, System.IFormatProvider provider)
        {
            return _toStringStringIFormatProvider != null ?
                _toStringStringIFormatProvider() :
                _value.ToString(format, provider);
        }

        /// <inheritdoc/>
        public DateTime ToUniversalTime()
        {
            return _toUniversalTime != null ?
                _toUniversalTime() :
                FromSystemDateTime(_value.ToUniversalTime());
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

            return FromSystemDateTime(ToSystem(d) + t.ToSystemTimeSpan());
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

            return new TimeSpan((ToSystem(d1) - ToSystem(d2)).Ticks);
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

            return FromSystemDateTime(ToSystem(d) - t.ToSystemTimeSpan());
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

            return ToSystem(d1) == ToSystem(d2);
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

            return ToSystem(d1) != ToSystem(d2);
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

            return ToSystem(d1) < ToSystem(d2);
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

            return ToSystem(d1) > ToSystem(d2);
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

            return ToSystem(d1) <= ToSystem(d2);
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

            return ToSystem(d1) >= ToSystem(d2);
        }

        #endregion  //  Operators.

        #region Methods used for testing and not production.

        #region Static methods used for testing and not production.

        /// <summary>This method sets the function used for <see cref="Compare(DateTime, DateTime)"/>.
        /// By default it is set to <see cref="System.DateTime.Compare(System.DateTime, System.DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="Compare(DateTime, DateTime)"/> return <see cref="System.DateTime.Compare(System.DateTime, System.DateTime)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetCompare(System.Func<int> func)
        {
            _compare = func;
        }

        /// <summary>This method sets the function used for <see cref="DaysInMonth(int, int)"/>.
        /// By default it is set to <see cref="System.DateTime.DaysInMonth(int, int)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="DaysInMonth(int, int)"/> use its default function.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetDaysInMonth(System.Func<int> func)
        {
            _daysInMonth = func;
        }

        /// <summary>This method sets the function used for <see cref="Equals(DateTime, DateTime)"/>.
        /// By default it is set to <see cref="System.DateTime.Equals(System.DateTime, System.DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="Equals(DateTime, DateTime)"/> use its default function.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetEquals(System.Func<bool> func)
        {
            _equals = func;
        }

        /// <summary>This method sets the function used for <see cref="FromBinary(long)"/>.
        /// By default it is set to <see cref="System.DateTime.FromBinary(long)"/>.
        /// 
        /// This method should onl be used for testing and really not bi in this class at all.
        /// Set to null to have <see cref="FromBinary(long)"/> use its default function.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetFromBinary(System.Func<DateTime> func)
        {
            _fromBinary = func;
        }

        /// <summary>This method sets the <see cref="FromFileTime(long)"/> property.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="FromFileTime(long)"/> return <see cref="System.DateTime.FromFileTime(long)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetFromFileTime(System.Func<DateTime> func) => _fromFileTime = func;

        /// <summary>This method sets the <see cref="FromFileTimeUtc(long)"/> method.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="FromFileTimeUtc(long)"/> return <see cref="System.DateTime.FromFileTimeUtc(long)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetFromFileTimeUtc(System.Func<DateTime> func) => _fromFileTimeUtc = func;

        /// <summary>This method sets the <see cref="FromOADate(double)"/> method.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="FromOADate(double)"/> return <see cref="System.DateTime.FromOADate(double)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetFromOADate(System.Func<DateTime> func) => _fromOADate = func;

        /// <summary>This method sets the <see cref="IsLeapYear(int)"/> method.
        /// Set to null to have <see cref="IsLeapYear(int)"/> return <see cref="System.DateTime.IsLeapYear(int)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all
        /// </summary>
        /// <param name="func"></param>
        internal static void SetIsLeapYear(System.Func<bool> func) => _isLeapYear = func;

        /// <summary>This method sets the <see cref="Parse(string, System.IFormatProvider, DateTimeStyles)"/> method.
        /// Set to null to have <see cref="Parse(string, System.IFormatProvider, DateTimeStyles)"/> return <see cref="System.DateTime.Parse(string, System.IFormatProvider, DateTimeStyles)"/>.
        /// 
        /// This method should only be used for testing and should really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetParseStringFormatProviderStyle(System.Func<IDateTime> func) => _parseStringFormatProviderStyle = func;

        /// <summary>This method set the <see cref="Parse(string, System.IFormatProvider)"/> method.
        /// Set to null to have <see cref="Parse(string, System.IFormatProvider)"/> return <see cref="System.DateTime.Parse(string, System.IFormatProvider)"/>.
        /// 
        /// This method should only be used for testing and should really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetParseStringFormatProvider(System.Func<IDateTime> func) => _parseStringFormatProvider = func;

        /// <summary>This method set the <see cref="Parse(string)"/> method.
        /// Set to null to have <see cref="Parse(string)"/> return <see cref="System.DateTime.Parse(string)"/>.
        /// 
        /// This method should only be used for testing and should really not in this class att all.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetParseString(System.Func<IDateTime> func) => _parseString = func;

        /// <summary>This method set the <see cref="ParseExact(string, string[], System.IFormatProvider, DateTimeStyles)"/> method.
        /// Set to null to have <see cref="ParseExact(string, string[], System.IFormatProvider, DateTimeStyles)"/> return <see cref="System.DateTime.ParseExact(string, string[], System.IFormatProvider, DateTimeStyles)"/>.
        /// 
        /// This method should only be used for testing and should really not in this class att all.
        /// </summary>
        /// <param name="parse"></param>
        internal static void SetParseExactStringStringArrayFormatProviderStyle(System.Func<IDateTime> parse) =>
            _parseExactStringStringArrayFormatProviderStyle = parse;

        /// <summary>This method set the <see cref="ParseExact(string, string, System.IFormatProvider, DateTimeStyles)"/> method.
        /// Set to null to have <see cref="ParseExact(string, string, System.IFormatProvider, DateTimeStyles)"/> return <see cref="System.DateTime.ParseExact(string, string, System.IFormatProvider, DateTimeStyles)"/>.
        /// 
        /// This method should only be used for testing and should really not in this class att all.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetParseExactStringStringFormatProviderStyle(System.Func<IDateTime> func) =>
            _parseExactStringStringFormatProviderStyle = func;

        /// <summary>This method sets the <see cref="ParseExact(string, string, System.IFormatProvider)"/> method.
        /// Set to null to have <see cref="ParseExact(string, string, System.IFormatProvider)"/> return <see cref="System.DateTime.ParseExact(string, string, System.IFormatProvider)"/>.
        /// 
        /// This method should only be used for testing and should really not in this class att all.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetParseExactStringStringFormatProvider(System.Func<IDateTime> func) =>
            _parseExactStringStringFormatProvider = func;

        /// <summary>This method sets the <see cref="SpecifyKind(DateTime, System.DateTimeKind)"/> method.
        /// Set to null to have <see cref="SpecifyKind(DateTime, System.DateTimeKind)"/> return <see cref="System.DateTime.SpecifyKind(System.DateTime, System.DateTimeKind)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetSpecifyKind(System.Func<DateTime> func) => _specifyKind = func;

        /// <summary>This method sets the <see cref="TryParse(string, System.IFormatProvider, DateTimeStyles, out DateTime)"/> method.
        /// Set to null to have <see cref="TryParse(string, System.IFormatProvider, DateTimeStyles, out DateTime)"/> return <see cref="System.DateTime.TryParse(string, System.IFormatProvider, DateTimeStyles, out System.DateTime)"/>.
        /// </summary>
        /// <param name="returnFunc"></param>
        /// <param name="outFunc"></param>
        internal static void SetTryParseStringIFormatProviderDateTimeStylesDateTime(
            System.Func<bool> returnFunc,
            System.Func<DateTime> outFunc)
        {
            _setTryParseStringIFormatProviderDateTimeStylesDateTime.Return = returnFunc;
            _setTryParseStringIFormatProviderDateTimeStylesDateTime.Out = outFunc;
        }

        /// <summary>This method sets the <see cref="TryParse(string, out DateTime)"/> method.
        /// Set to null to have <see cref="TryParse(string, out DateTime)"/> return <see cref="System.DateTime.TryParse(string, out System.DateTime)"/>.
        /// </summary>
        /// <param name="returnFunc"></param>
        /// <param name="outFunc"></param>
        internal static void SetTryParseStringDateTime(
            System.Func<bool> returnFunc,
            System.Func<DateTime> outFunc)
        {
            _setTryParseStringDateTime.Return = returnFunc;
            _setTryParseStringDateTime.Out = outFunc;
        }

        /// <summary>This method sets the <see cref="TryParseExact(string, string, System.IFormatProvider, DateTimeStyles, out System.DateTime)"/> method.
        /// Set to null to have <see cref="TryParseExact(string, string, System.IFormatProvider, DateTimeStyles, out System.DateTime)"/> return <see cref="System.DateTime.TryParseExact(string, string, System.IFormatProvider, DateTimeStyles, out System.DateTime)"/>.
        /// </summary>
        /// <param name="returnFunc"></param>
        /// <param name="outFunc"></param>
        internal static void SetTryParseExactStringStringIFormatProviderDateTimeStyles(
            System.Func<bool> returnFunc,
            System.Func<IDateTime> outFunc)
        {
            _setTryParseExactStringStringIFormatProviderDateTimeStyles.Return = returnFunc;
            _setTryParseExactStringStringIFormatProviderDateTimeStyles.Out = outFunc;
        }

        /// <summary>This method sets the <see cref="TryParseExact(string, string[], System.IFormatProvider, DateTimeStyles, out System.DateTime)"/> method.
        /// Set to null to have <see cref="TryParseExact(string, string[], System.IFormatProvider, DateTimeStyles, out System.DateTime)"/> return <see cref="System.DateTime.TryParseExact(string, string[], System.IFormatProvider, DateTimeStyles, out System.DateTime)"/>.
        /// </summary>
        /// <param name="returnFunc"></param>
        /// <param name="outFunc"></param>
        internal static void SetTryParseExactStringStringArrayIFormatProviderDateTimeStyles(
            System.Func<bool> returnFunc,
            System.Func<IDateTime> outFunc)
        {
            _setTryParseExactStringStringArrayIFormatProviderDateTimeStyles.Return = returnFunc;
            _setTryParseExactStringStringArrayIFormatProviderDateTimeStyles.Out = outFunc;
        }

        /// <summary>This method sets the <see cref="Now"/> property.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="DateTime.Now"/> return <see cref="System.DateTime.Now"/>.
        /// </summary>
        /// <param name="now"></param>
        internal static void SetNow(System.DateTime? now) => _now = now;

        /// <summary>This method sets the <see cref="DateTime.UtcNow"/> property.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="UtcNow"/> return <see cref="System.DateTime.UtcNow"/>.
        /// </summary>
        /// <param name="utcNow"></param>
        internal static void SetUtcNow(System.DateTime? utcNow) => _utcNow = utcNow;

        /// <summary>This method sets the <see cref="operator +(DateTime, TimeSpan)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetAddOperator(System.Func<Abstractions.DateTime> func)
        {
            _addOperator = func;
        }

        /// <summary>This method sets the <see cref="operator -(DateTime, DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetSubtractDateTimeDateTimeOperator(System.Func<TimeSpan> func)
        {
            _subtractDateTimeDateTimeOperator = func;
        }

        /// <summary>This method sets the <see cref="operator -(DateTime, TimeSpan)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetSubtractDateTimeTimeSpanOperator(System.Func<DateTime> func)
        {
            _subtractDateTimeTimeSpanOperator = func;
        }

        /// <summary>This method sets the <see cref="operator ==(DateTime, DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetEqualsOperator(System.Func<bool> func)
        {
            _equalsOperator = func;
        }

        /// <summary>This method sets the <see cref="operator !=(DateTime, DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetNotEqualsOperator(System.Func<bool> func)
        {
            _notEqualsOperator = func;
        }

        /// <summary>This method sets the <see cref="operator <(DateTime, DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetEarlierThanOperator(System.Func<bool> func)
        {
            _earlierThanOperator = func;
        }

        /// <summary>This method sets the <see cref="operator >(DateTime, DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetLaterThanOperator(System.Func<bool> func)
        {
            _laterThanOperator = func;
        }

        /// <summary>This method sets the <see cref="operator <=(DateTime, DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetEarlierThanOrEqualOperator(System.Func<bool> func)
        {
            _earlierThanOrEqualOperator = func;
        }

        /// <summary>This method sets the <see cref="operator >=(DateTime, DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have normal behaviour.
        /// </summary>
        /// <param name="func"></param>
        internal static void SetLaterThanOrEqualOperator(System.Func<bool> func)
        {
            _laterThanOrEqualOperator = func;
        }

        #endregion  //  Static methods used for testing and not production.

        #region Instance methods used for testing and not production.

        /// <summary>This method sets the <see cref="AddDays(double)"/> return value.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have the method return <see cref="System.DateTime.AddDays(double)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal void SetAddDays(System.Func<DateTime> func)
        {
            _addDays = func;
        }

        /// <summary>This method sets the <see cref="AddHours(double)"/> return value.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have the method return <see cref="System.DateTime.AddHours(double)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal void SetAddHours(System.Func<DateTime> func)
        {
            _addHours = func;
        }

        /// <summary>This method sets the <see cref="AddMilliseconds(double)"/> return value.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have the method return <see cref="System.DateTime.AddMilliseconds(double)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal void SetAddMilliseconds(System.Func<DateTime> func)
        {
            _addMilliseconds = func;
        }

        /// <summary>This method sets the <see cref="AddMinutes(double)"/> return value.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have the method return <see cref="System.DateTime.AddMinutes(double)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal void SetAddMinutes(System.Func<DateTime> func)
        {
            _addMinutes = func;
        }

        /// <summary>This method sets the <see cref="AddMonths(int)"/> return value.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have the method return <see cref="System.DateTime.AddMonths(int)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal void SetAddMonths(System.Func<DateTime> func)
        {
            _addMonths = func;
        }

        /// <summary>This method sets the <see cref="AddSeconds(double)"/> return value.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have the method return <see cref="System.DateTime.AddSeconds(double)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal void SetAddSeconds(System.Func<DateTime> func)
        {
            _addSeconds = func;
        }

        /// <summary>This method sets the <see cref="AddTicks(long)"/> return value.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have the method return <see cref="System.DateTime.AddTicks(long)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal void SetAddTicks(System.Func<DateTime> func)
        {
            _addTicks = func;
        }

        /// <summary>This method sets the <see cref="AddYears(int)"/> return value.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have the method return <see cref="System.DateTime.AddYears(int)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal void SetAddYears(System.Func<DateTime> func)
        {
            _addYears = func;
        }

        /// <summary>This method set the <see cref="CompareTo(DateTime)"/> return value.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have the method return <see cref="System.DateTime.CompareTo(System.DateTime)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal void SetCompareToDateTime(System.Func<int> func)
        {
            _compareToDateTime = func;
        }

        /// <summary>This method sets the <see cref="CompareTo(object)"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.CompareTo(object)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetCompareToObject(System.Func<int> func)
        {
            _compareToObject = func;
        }

        /// <summary>This method sets the <see cref="Equals(object)"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.Equals(object)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetEqualsObject(System.Func<bool> func)
        {
            _equalsObject = func;
        }

        /// <summary>This method sets the <see cref="Equals(System.DateTime)"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.Equals(System.DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetEqualsDateTime(System.Func<bool> func)
        {
            _equalsDateTime = func;
        }

        /// <summary>This methods sets the <see cref="GetDateTimeFormats(char, System.IFormatProvider)"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.GetDateTimeFormats(char, System.IFormatProvider)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetGetDateTimeFormatsCharIFormatProvider(System.Func<string[]> func)
        {
            _getDateTimeFormatsCharIFormatProvider = func;
        }

        /// <summary>This methods sets the <see cref="GetDateTimeFormats(char)"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.GetDateTimeFormats(char)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetGetDateTimeFormatsChar(System.Func<string[]> func)
        {
            _getDateTimeFormatsChar = func;
        }

        /// <summary>This methods sets the <see cref="GetDateTimeFormats()"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.GetDateTimeFormats()"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetGetDateTimeFormats(System.Func<string[]> func)
        {
            _getDateTimeFormats = func;
        }

        /// <summary>This methods sets the <see cref="GetDateTimeFormats(System.IFormatProvider)"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.GetDateTimeFormats(System.IFormatProvider)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetGetDateTimeFormatsIFormatProvider(System.Func<string[]> func)
        {
            _getDateTimeFormatsIFormatProvider = func;
        }

        /// <summary>This method sets the <see cref="GetHashCode"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.GetHashCode"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetGetHashCode(System.Func<int> func)
        {
            _getHashCode = func;
        }

        /// <summary>This method sets the <see cref="GetTypeCode"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.GetTypeCode"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetGetTypeCode(System.Func<System.TypeCode> func)
        {
            _getTypeCode = func;
        }

        /// <summary>This method sets the <see cref="IsDaylightSavingTime"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.IsDaylightSavingTime"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetIsDaylightSavingTime(System.Func<bool> func)
        {
            _isDaylightSavingTime = func;
        }

        /// <summary>This method sets the <see cref="Subtract(DateTime)"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.Subtract(System.DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetSubtractDateTime(System.Func<TimeSpan> func)
        {
            _subtractDateTime = func;
        }

        /// <summary>This method sets the <see cref="Subtract(TimeSpan)"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.Subtract(System.TimeSpan)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetSubtractTimeSpan(System.Func<DateTime> func)
        {
            _subtractTimeSpan = func;
        }

        /// <summary>This method sets the <see cref="ToBinary"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.ToBinary"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetToBinary(System.Func<long> func)
        {
            _toBinary = func;
        }

        /// <summary>This method sets the <see cref="ToFileTime"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.ToFileTime"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetToFileTime(System.Func<long> func)
        {
            _toFileTime = func;
        }

        /// <summary>This method sets the <see cref="ToFileTimeUtc"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.ToFileTimeUtc"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetToFileTimeUtc(System.Func<long> func)
        {
            _toFileTimeUtc = func;
        }

        /// <summary>This method sets the <see cref="ToLocalTime"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.ToLocalTime"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetToLocalTime(System.Func<DateTime> func)
        {
            _toLocalTime = func;
        }

        /// <summary>This method sets the <see cref="ToLongDateString"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.ToLongDateString"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetToLongDateString(System.Func<string> func)
        {
            _toLongDateString = func;
        }

        /// <summary>This method sets the <see cref="ToLongTimeString"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.ToLongTimeString"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetToLongTimeString(System.Func<string> func)
        {
            _toLongTimeString = func;
        }

        /// <summary>This method sets the <see cref="ToOADate"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.ToOADate"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetToOADate(System.Func<double> func)
        {
            _toOADate = func;
        }

        /// <summary>This method sets the <see cref="ToShortDateString"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.ToShortDateString"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetToShortDateString(System.Func<string> func)
        {
            _toShortDateString = func;
        }

        /// <summary>This method sets the <see cref="ToShortTimeString"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.ToShortTimeString"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetToShortTimeString(System.Func<string> func)
        {
            _toShortTimeString = func;
        }

        /// <summary>This method sets the <see cref="ToString(string)"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.ToString(string)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetToStringString(System.Func<string> func)
        {
            _toStringString = func;
        }

        /// <summary>This method sets the <see cref="ToString(System.IFormatProvider)"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.ToString(System.IFormatProvider)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetToStringIFormatProvider(System.Func<string> func)
        {
            _toStringIFormatProvider = func;
        }

        /// <summary>This method sets the <see cref="ToString"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.ToString()"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetToString(System.Func<string> func)
        {
            _toString = func;
        }

        /// <summary>This method sets the <see cref="ToString(string, System.IFormatProvider)"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.ToString(string, System.IFormatProvider)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetToStringStringIFormatProvider(System.Func<string> func)
        {
            _toStringStringIFormatProvider = func;
        }

        /// <summary>This method sets the <see cref="ToUniversalTime"/> return value.
        /// Set to null to have the method return <see cref="System.DateTime.ToUniversalTime"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// </summary>
        /// <param name="func"></param>
        internal void SetToUniversalTime(System.Func<DateTime> func)
        {
            _toUniversalTime = func;
        }

        #endregion

        #endregion

        #region Private helper methods.

        private static bool BothAreNull(DateTime d1, DateTime d2)
        {
            return IsNull(d1) && IsNull(d2);
        }

        private static DateTime FromSystemDateTime(System.DateTime datetime)
        {
            return new DateTime(datetime.Ticks, datetime.Kind);
        }

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

        private static System.DateTime ToSystem(DateTime datetime)
        {
            return new System.DateTime(datetime.Ticks, datetime.Kind);
        }

        #endregion
    }
}
