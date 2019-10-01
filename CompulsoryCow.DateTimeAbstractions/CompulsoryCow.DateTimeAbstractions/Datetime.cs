using System.Globalization;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("CompulsoryCow.DateTimeAbstractions.Unit.Tests")]

namespace CompulsoryCow.DateTime.Abstractions
{
    public interface IDateTime
    {
        /// <summary>See <see cref="System.DateTime.Ticks"/>.
        /// </summary>
        long Ticks { get; }

        /// <summary>See <see cref="System.DateTime.Second"/>.
        /// </summary>
        int Second { get; }

        /// <summary>See <see cref="System.DateTime.Date"/>.
        /// </summary>
        DateTime Date { get; }

        /// <summary>See <see cref="System.DateTime.Month"/>.
        /// </summary>
        int Month { get; }
        
        /// <summary>See <see cref="Minute"/>.
        /// </summary>
         int Minute { get; }
        
        /// <summary>See <see cref="Millisecond"/>.
        /// </summary>
         int Millisecond { get; }

        /// <summary>See <see cref="System.DateTime.Kind"/>.
        /// </summary>
        System.DateTimeKind Kind { get; }

        /// <summary>See <see cref="System.DateTime.Hour"/>.
        /// </summary>
        int Hour { get; }

        /// <summary>See <see cref="System.DateTime.DayOfYear"/>.
        /// </summary>
        int DayOfYear { get; }

        /// <summary>See <see cref="System.DateTime.DayOfWeek"/>.
        /// </summary>
        System.DayOfWeek DayOfWeek { get; }

        /// <summary>See <see cref="System.DateTime.Day"/>.
        /// </summary>
        int Day { get; }

        /// <summary>See <see cref="System.DateTime.TimeOfDay"/>.
        /// </summary>
        TimeSpan TimeOfDay { get; }

        /// <summary>See <see cref="System.DateTime.Year"/>.
        /// </summary>
        int Year { get; }

        /// <summary>See <see cref="System.DateTime.Add(System.TimeSpan)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        DateTime Add(TimeSpan value);
    }

    // TODO:OF:Implement interfaces found at https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netcore-2.2
    public class DateTime : IDateTime
    {
        private static System.DateTime? _now;
        private static System.DateTime? _utcNow;
        private static System.Func<System.DateTime, System.DateTime, int> _compare;
        private static System.Func<int, int, int> _daysInMonth;
        private static System.Func<System.DateTime, System.DateTime, bool> _equals;
        private static System.Func<long, System.DateTime> _fromBinary;
        private static System.Func<long, System.DateTime> _fromFileTime;
        private static System.Func<long, System.DateTime> _fromFileTimeUtc;
        private static System.Func<double, System.DateTime> _fromOADate;
        private static System.Func<int, bool> _isLeapYear;
        private static System.Func<string, System.IFormatProvider, DateTimeStyles, System.DateTime> _parseStringFormatProviderStyle;
        private static System.Func<string, System.IFormatProvider, System.DateTime> _parseStringFormatProvider;
        private static System.Func<string, System.DateTime> _parseString;
        private static System.Func<string, string[], System.IFormatProvider, DateTimeStyles, System.DateTime> _parseExactStringStringArrayFormatProviderStyle;
        private static System.Func<string, string, System.IFormatProvider, DateTimeStyles, System.DateTime> _parseExactStringStringFormatProviderStyle;
        private static System.Func<string, string, System.IFormatProvider, System.DateTime> _parseExactStringStringFormatProvider;
        private static System.Func<System.DateTimeKind> _specifyKind;
        private static System.Func<bool> _setTryParseStringIFormatProviderDateTimeStylesDateTimeReturn;
        private static System.Func<System.DateTime> _setTryParseStringIFormatProviderDateTimeStylesDateTimeOut;
        private static System.Func<bool> _setTryParseStringDateTimeReturn;
        private static System.Func<System.DateTime> _setTryParseStringDateTimeOut;
        private static System.Func<bool> _setTryParseExactStringStringIFormatProviderDateTimeStylesReturn;
        private static System.Func<System.DateTime> _setTryParseExactStringStringIFormatProviderDateTimeStylesOut;
        private static System.Func<bool> _setTryParseExactStringStringArrayIFormatProviderDateTimeStylesReturn;
        private static System.Func<System.DateTime> _setTryParseExactStringStringArrayIFormatProviderDateTimeStylesOut;

        private readonly System.DateTime _value;

        private System.Func<DateTime> _add;
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
        public static DateTime MaxValue { get { return new DateTime( System.DateTime.MaxValue.Ticks); } }

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
            if( t1 == null)
            {
                throw new System.ArgumentNullException(nameof(t1));
            }
            if( t2 == null)
            {
                throw new System.ArgumentNullException(nameof(t2));
            }
            return (_compare ?? System.DateTime.Compare)(new System.DateTime(t1.Ticks), new System.DateTime(t2.Ticks));
        }

        /// <summary>See <see cref="System.DateTime.DaysInMonth(int, int)"/>.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public static int DaysInMonth(int year, int month)
        {
            return (_daysInMonth ?? System.DateTime.DaysInMonth)(year, month);
        }

        // TODO:Implement Equals properly. System.DateTime is a struct while Abstractions.DateTime is a class which means the whole equals has to be implemented. Also check for == >= etc. Also ToString and GetHashCode.

        /// <summary>See <see cref="System.DateTime.Equals(System.DateTime, System.DateTime)"/>.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool Equals(DateTime t1, DateTime t2)
        {
            if( t1 == null)
            {
                throw new System.ArgumentNullException(nameof(t1));
            }
            if( t2 == null)
            {
                throw new System.ArgumentNullException(nameof(t2));
            }

            return (_equals ?? System.DateTime.Equals)(new System.DateTime( t1.Ticks), new System.DateTime( t2.Ticks));
        }

        /// <summary>See <see cref="System.DateTime.FromBinary(long)"/>.
        /// </summary>
        /// <param name="dateData"></param>
        /// <returns></returns>
        public static DateTime FromBinary(long dateData)
        {
            return new DateTime((_fromBinary ?? System.DateTime.FromBinary)(dateData).Ticks);
        }

        /// <summary>See <see cref="System.DateTime.FromFileTime(long)"/>.
        /// </summary>
        /// <param name="fileTime"></param>
        /// <returns></returns>
        public static DateTime FromFileTime(long fileTime)
        {
            return new DateTime((_fromFileTime ?? System.DateTime.FromFileTime)(fileTime).Ticks, System.DateTimeKind.Local);
        }

        /// <summary>See <see cref="System.DateTime.FromFileTimeUtc(long)"/>.
        /// </summary>
        /// <param name="fileTime"></param>
        /// <returns></returns>
        public static DateTime FromFileTimeUtc(long fileTime)
        {
            return new DateTime((_fromFileTimeUtc ?? System.DateTime.FromFileTimeUtc)(fileTime).Ticks, System.DateTimeKind.Utc);
        }
        /// <summary>See <see cref="System.DateTime.FromOADate(double)"/>.
        /// </summary>
        /// <param name="fileTime"></param>
        /// <returns></returns>
        public static DateTime FromOADate(double d)
        {
            return new DateTime((_fromOADate ?? System.DateTime.FromOADate)(d).Ticks, System.DateTimeKind.Unspecified);
        }

        /// <summary>See <see cref="System.DateTime.IsLeapYear(int)"/>.
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static bool IsLeapYear(int year)
        {
            return (_isLeapYear ?? System.DateTime.IsLeapYear)(year);
        }

        /// <summary>See <see cref="System.DateTime.Parse(string, System.IFormatProvider, DateTimeStyles)"/>.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <param name="styles"></param>
        /// <returns></returns>
        public static DateTime Parse(string s, System.IFormatProvider provider, DateTimeStyles styles)
        {
            var result = (_parseStringFormatProviderStyle == null) ?
                System.DateTime.Parse(s, provider, styles) :
                _parseStringFormatProviderStyle(s, provider, styles);
            return new DateTime(result.Ticks, result.Kind);
        }

        /// <summary>See <see cref="System.DateTime.Parse(string, System.IFormatProvider)"/>.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static DateTime Parse(string s, System.IFormatProvider provider)
        {
            var result = (_parseStringFormatProvider == null) ?
                System.DateTime.Parse(s, provider) :
                _parseStringFormatProvider(s, provider);
            return new DateTime(result.Ticks, result.Kind);
        }

        /// <summary>See <see cref="System.DateTime.Parse(string)"/>.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static DateTime Parse(string s)
        {
            var result = (_parseString == null) ?
                System.DateTime.Parse(s) :
                _parseString(s);
            return new DateTime(result.Ticks, result.Kind);
        }

        /// <summary>See <see cref="System.DateTime.ParseExact(string, string[], System.IFormatProvider, DateTimeStyles)"/>.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="formats"></param>
        /// <param name="provider"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static DateTime ParseExact(string s, string[] formats, System.IFormatProvider provider, DateTimeStyles style)
        {
            var result = (_parseExactStringStringArrayFormatProviderStyle == null) ?
                System.DateTime.ParseExact(s, formats, provider, style) :
                _parseExactStringStringArrayFormatProviderStyle(s, formats, provider, style);
            return new DateTime(result.Ticks, result.Kind);
        }

        /// <summary>See <see cref="System.DateTime.ParseExact(string, string, System.IFormatProvider, DateTimeStyles)"/>.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static DateTime ParseExact(string s, string format, System.IFormatProvider provider, DateTimeStyles style)
        {
            var result = (_parseExactStringStringFormatProviderStyle == null) ?
                System.DateTime.ParseExact(s, format, provider, style) :
                _parseExactStringStringFormatProviderStyle(s, format, provider, style);
            return new DateTime(result.Ticks, result.Kind);
        }

        /// <summary>See <see cref="System.DateTime.ParseExact(string, string, System.IFormatProvider)"/>.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static DateTime ParseExact(string s, string format, System.IFormatProvider provider)
        {
            var result = (_parseExactStringStringFormatProvider == null) ?
                System.DateTime.ParseExact(s, format, provider) :
                _parseExactStringStringFormatProvider(s, format, provider);
            return new DateTime(result.Ticks, result.Kind);
        }

        /// <summary>See <see cref="System.DateTime.SpecifyKind(System.DateTime, System.DateTimeKind)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static DateTime SpecifyKind(DateTime value, System.DateTimeKind kind)
        {
            var result = System.DateTime.SpecifyKind(
                new System.DateTime(value.Ticks, value.Kind), 
                _specifyKind == null ? kind: _specifyKind());
            return new DateTime(result.Ticks, result.Kind);
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

            ret = _setTryParseStringIFormatProviderDateTimeStylesDateTimeReturn == null ?
                ret : _setTryParseStringIFormatProviderDateTimeStylesDateTimeReturn();

            resultOut = _setTryParseStringIFormatProviderDateTimeStylesDateTimeOut == null ?
                new DateTime(
                    @out.Ticks,
                    @out.Kind) :
                new DateTime(
                    _setTryParseStringIFormatProviderDateTimeStylesDateTimeOut().Ticks,
                    _setTryParseStringIFormatProviderDateTimeStylesDateTimeOut().Kind);

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

            ret = _setTryParseStringDateTimeReturn == null ?
                ret : _setTryParseStringDateTimeReturn();

            result = _setTryParseStringDateTimeOut == null ?
                new DateTime(
                    @out.Ticks,
                    @out.Kind) :
                new DateTime(
                    _setTryParseStringDateTimeOut().Ticks,
                    _setTryParseStringDateTimeOut().Kind);

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

            ret = _setTryParseExactStringStringIFormatProviderDateTimeStylesReturn == null ?
                ret : _setTryParseExactStringStringIFormatProviderDateTimeStylesReturn();

            result = _setTryParseExactStringStringIFormatProviderDateTimeStylesOut == null ?
                new DateTime(
                    @out.Ticks,
                    @out.Kind) :
                    new DateTime(
                        _setTryParseExactStringStringIFormatProviderDateTimeStylesOut().Ticks,
                        _setTryParseExactStringStringIFormatProviderDateTimeStylesOut().Kind);

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

            ret = _setTryParseExactStringStringArrayIFormatProviderDateTimeStylesReturn == null ?
                ret : _setTryParseExactStringStringArrayIFormatProviderDateTimeStylesReturn();

            result = _setTryParseExactStringStringArrayIFormatProviderDateTimeStylesOut == null ?
                new DateTime(
                    @out.Ticks,
                    @out.Kind) :
                    new DateTime(
                        _setTryParseExactStringStringArrayIFormatProviderDateTimeStylesOut().Ticks,
                        _setTryParseExactStringStringArrayIFormatProviderDateTimeStylesOut().Kind);

            return ret;
        }

        #endregion

        #region Instance methods.

        /// <summary>See <see cref="System.DateTime.Add(System.TimeSpan)"/>l
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DateTime Add(TimeSpan value)
        {
            return _add == null ?
                FromSystemDateTime(_value.Add(value.ToSystemTimeSpan())) :
                _add();
        }

        /// <summary>See <see cref="System.DateTime.AddDays(double)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DateTime AddDays(double value)
        {
            return _addDays == null ?
                FromSystemDateTime(_value.AddDays(value)) :
                _addDays();
        }

        /// <summary>See <see cref="System.DateTime.AddHours(double)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DateTime AddHours(double value)
        {
            return _addHours == null ?
                FromSystemDateTime(_value.AddHours(value)) :
                _addHours();
        }

        /// <summary>See <see cref="System.DateTime.AddMilliseconds(double)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DateTime AddMilliseconds(double value)
        {
            return _addMilliseconds == null ?
                FromSystemDateTime(_value.AddMilliseconds(value)) :
                _addMilliseconds();
        }

        /// <summary>See <see cref="System.DateTime.AddMinutes(double)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DateTime AddMinutes(double value)
        {
            return _addMinutes == null ?
                FromSystemDateTime(_value.AddMinutes(value)) :
                _addMinutes();
        }

        /// <summary>See <see cref="System.DateTime.AddMonths(int)"/>.
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public DateTime AddMonths(int months)
        {
            return _addMonths == null ?
                FromSystemDateTime(_value.AddMonths(months)) :
                _addMonths();
        }

        /// <summary>See <see cref="System.DateTime.AddSeconds(double)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DateTime AddSeconds(double value)
        {
            return _addSeconds == null ?
                FromSystemDateTime(_value.AddSeconds(value)) :
                _addSeconds();
        }

        /// <summary>See <see cref="System.DateTime.AddTicks(long)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DateTime AddTicks(long value)
        {
            return _addTicks == null ?
                FromSystemDateTime(_value.AddTicks(value)) :
                _addTicks();
        }

        /// <summary>See <see cref="System.DateTime.AddYears(int)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public DateTime AddYears(int value)
        {
            return _addYears == null ?
                FromSystemDateTime(_value.AddYears(value)) :
                _addYears();
        }

        /// <summary>See <see cref="System.DateTime.CompareTo(System.DateTime)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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
            if ( _compareToDateTime != null)
            {
                return _compareToDateTime();
            }
                return _value.CompareTo(ToSystem(value));
        }

        /// <summary>See <see cref="System.DateTime.CompareTo(object)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int CompareTo(object value)
        {
            if (value == null)
            {
                return _value.CompareTo(value);
            }
            if( (value is DateTime) == false)
            {
                _value.CompareTo(value); // Will throw an exception, the same as System will.
            }
            if ( _compareToObject!= null)
            {
                return _compareToObject();
            }
            return _value.CompareTo(ToSystem((DateTime)value));
        }

        /// <summary>See <see cref="System.DateTime.Equals(object)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool Equals(object value)
        {
            if( _equalsObject != null)
            {
                return _equalsObject();
            }
            if (value == null)
            {
                return _value.Equals(value);
            }
            if( value is DateTime)
            {
                return _value.Equals(ToSystem((DateTime)value));
            }
            return _value.Equals(value);
        }

        /// <summary>See <see cref="System.DateTime.Equals(System.DateTime)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

            if ( _equalsDateTime != null)
            {
                return _equalsDateTime();
            }
            if( value is DateTime)
            {
                return _value.Equals(ToSystem((DateTime)value));
            }
            return _value.Equals(value);
        }

        /// <summary>See <see cref="System.DateTime.GetDateTimeFormats(char, System.IFormatProvider)"/>.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string[] GetDateTimeFormats(char format, System.IFormatProvider provider)
        {
            return
                _getDateTimeFormatsCharIFormatProvider != null ?
                _getDateTimeFormatsCharIFormatProvider() :
                _value.GetDateTimeFormats(format, provider);
        }

        /// <summary>See <see cref="System.DateTime.GetDateTimeFormats(char)"/>.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string[] GetDateTimeFormats(char format)
        {
            return
                _getDateTimeFormatsChar != null ?
                _getDateTimeFormatsChar() :
                _value.GetDateTimeFormats(format);
        }

        /// <summary>See <see cref="System.DateTime.GetDateTimeFormats()"/>.
        /// </summary>
        /// <returns></returns>
        public string[] GetDateTimeFormats()
        {
            return
                _getDateTimeFormats != null ?
                _getDateTimeFormats() :
                _value.GetDateTimeFormats();
        }

        /// <summary>See <see cref="System.DateTime.GetDateTimeFormats(System.IFormatProvider)"/>.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string[] GetDateTimeFormats(System.IFormatProvider provider)
        {
            return
                _getDateTimeFormatsIFormatProvider != null ?
                _getDateTimeFormatsIFormatProvider() :
                _value.GetDateTimeFormats(provider);
        }

        /// <summary>See <see cref="System.DateTime.GetHashCode"/>.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _getHashCode != null ?
                _getHashCode() :
                _value.GetHashCode();
        }

        /// <summary>See <see cref="System.DateTime.GetTypeCode"/>.
        /// </summary>
        /// <returns></returns>
        public System.TypeCode GetTypeCode()
        {
            return _getTypeCode != null ?
                _getTypeCode() :
                _value.GetTypeCode();
        }

        /// <summary>See <see cref="System.DateTime.IsDaylightSavingTime"/>.
        /// </summary>
        /// <returns></returns>
        public bool IsDaylightSavingTime()
        {
            return _isDaylightSavingTime != null ?
                _isDaylightSavingTime() :
                _value.IsDaylightSavingTime();
        }

        #endregion

        #region Methods used for testing and not production.

        #region Static methods used for testing and not production.

        /// <summary>This method sets the function used for <see cref="Compare(DateTime, DateTime)"/>.
        /// By default it is set to <see cref="System.DateTime.Compare(System.DateTime, System.DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="Compare(DateTime, DateTime)"/> return <see cref="System.DateTime.Compare(System.DateTime, System.DateTime)"/>.
        /// </summary>
        /// <param name="compareFunc"></param>
        internal static void SetCompare(System.Func<System.DateTime, System.DateTime, int> compareFunc)
        {
            _compare = compareFunc;
        }

        /// <summary>This method sets the function used for <see cref="DaysInMonth(int, int)"/>.
        /// By default it is set to <see cref="System.DateTime.DaysInMonth(int, int)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="DaysInMonth(int, int)"/> use its default function.
        /// </summary>
        /// <param name="daysInMonthFunc"></param>
        internal static void SetDaysInMonth(System.Func<int, int, int> daysInMonthFunc)
        {
            _daysInMonth = daysInMonthFunc;
        }
        
        /// <summary>This method sets the function used for <see cref="Equals(DateTime, DateTime)"/>.
        /// By default it is set to <see cref="System.DateTime.Equals(System.DateTime, System.DateTime)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="Equals(DateTime, DateTime)"/> use its default function.
        /// </summary>
        /// <param name="equalsFunc"></param>
        internal static void SetEquals(System.Func<System.DateTime, System.DateTime, bool> equalsFunc)
        {
            _equals = equalsFunc;
        }

        /// <summary>This method sets the function used for <see cref="FromBinary(long)"/>.
        /// By default it is set to <see cref="System.DateTime.FromBinary(long)"/>.
        /// 
        /// This method should onl be used for testing and really not bi in this class at all.
        /// Set to null to have <see cref="FromBinary(long)"/> use its default function.
        /// </summary>
        /// <param name="fromBinaryFunc"></param>
        internal static void SetFromBinary(System.Func<long, System.DateTime> fromBinaryFunc)
        {
            _fromBinary = fromBinaryFunc;
        }

        /// <summary>This method sets the <see cref="FromFileTime(long)"/> property.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="FromFileTime(long)"/> return <see cref="System.DateTime.FromFileTime(long)"/>.
        /// </summary>
        /// <param name="fromFileTimeFunc"></param>
        internal static void SetFromFileTime(System.Func<long, System.DateTime> fromFileTimeFunc) => _fromFileTime = fromFileTimeFunc;

        /// <summary>This method sets the <see cref="FromFileTimeUtc(long)"/> method.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="FromFileTimeUtc(long)"/> return <see cref="System.DateTime.FromFileTimeUtc(long)"/>.
        /// </summary>
        /// <param name="fromFileTimeUtcFunc"></param>
        internal static void SetFromFileTimeUtc(System.Func<long, System.DateTime> fromFileTimeUtcFunc) => _fromFileTimeUtc = fromFileTimeUtcFunc;

        /// <summary>This method sets the <see cref="FromOADate(double)"/> method.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="FromOADate(double)"/> return <see cref="System.DateTime.FromOADate(double)"/>.
        /// </summary>
        /// <param name="fromOADateFunc"></param>
        internal static void SetFromOADate(System.Func<double, System.DateTime> fromOADateFunc) => _fromOADate = fromOADateFunc;

        /// <summary>This method sets the <see cref="IsLeapYear(int)"/> method.
        /// Set to null to have <see cref="IsLeapYear(int)"/> return <see cref="System.DateTime.IsLeapYear(int)"/>.
        /// 
        /// This method should only be used for testing and really not be in this class at all
        /// </summary>
        /// <param name="isLeapYearFunc"></param>
        internal static void SetIsLeapYear(System.Func<int, bool> isLeapYearFunc) => _isLeapYear = isLeapYearFunc;

        /// <summary>This method sets the <see cref="Parse(string, System.IFormatProvider, DateTimeStyles)"/> method.
        /// Set to null to have <see cref="Parse(string, System.IFormatProvider, DateTimeStyles)"/> return <see cref="System.DateTime.Parse(string, System.IFormatProvider, DateTimeStyles)"/>.
        /// 
        /// This method should only be used for testing and should really not be in this class at all.
        /// </summary>
        /// <param name="parseFunc"></param>
        internal static void SetParseStringFormatProviderStyle(System.Func<string, System.IFormatProvider, DateTimeStyles, System.DateTime> parseFunc) => _parseStringFormatProviderStyle = parseFunc;

        /// <summary>This method set the <see cref="Parse(string, System.IFormatProvider)"/> method.
        /// Set to null to have <see cref="Parse(string, System.IFormatProvider)"/> return <see cref="System.DateTime.Parse(string, System.IFormatProvider)"/>.
        /// 
        /// This method should only be used for testing and should really not be in this class at all.
        /// </summary>
        /// <param name="parseFunc"></param>
        internal static void SetParseStringFormatProvider(System.Func<string, System.IFormatProvider, System.DateTime> parseFunc) => _parseStringFormatProvider = parseFunc;

        /// <summary>This method set the <see cref="Parse(string)"/> method.
        /// Set to null to have <see cref="Parse(string)"/> return <see cref="System.DateTime.Parse(string)"/>.
        /// 
        /// This method should only be used for testing and should really not in this class att all.
        /// </summary>
        /// <param name="parseFunc"></param>
        internal static void SetParseString(System.Func<string, System.DateTime> parseFunc) => _parseString = parseFunc;

        /// <summary>This method set the <see cref="ParseExact(string, string[], System.IFormatProvider, DateTimeStyles)"/> method.
        /// Set to null to have <see cref="ParseExact(string, string[], System.IFormatProvider, DateTimeStyles)"/> return <see cref="System.DateTime.ParseExact(string, string[], System.IFormatProvider, DateTimeStyles)"/>.
        /// 
        /// This method should only be used for testing and should really not in this class att all.
        /// </summary>
        /// <param name="parseFunc"></param>
        internal static void SetParseExactStringStringArrayFormatProviderStyle(System.Func<string, string[], System.IFormatProvider, DateTimeStyles, System.DateTime> parseFunc) =>
            _parseExactStringStringArrayFormatProviderStyle = parseFunc;

        /// <summary>This method set the <see cref="ParseExact(string, string, System.IFormatProvider, DateTimeStyles)"/> method.
        /// Set to null to have <see cref="ParseExact(string, string, System.IFormatProvider, DateTimeStyles)"/> return <see cref="System.DateTime.ParseExact(string, string, System.IFormatProvider, DateTimeStyles)"/>.
        /// 
        /// This method should only be used for testing and should really not in this class att all.
        /// </summary>
        /// <param name="parseFunc"></param>
        internal static void SetParseExactStringStringFormatProviderStyle(System.Func<string, string, System.IFormatProvider, DateTimeStyles, System.DateTime> parseFunc) =>
            _parseExactStringStringFormatProviderStyle = parseFunc;

        /// <summary>This method sets the <see cref="ParseExact(string, string, System.IFormatProvider)"/> method.
        /// Set to null to have <see cref="ParseExact(string, string, System.IFormatProvider)"/> return <see cref="System.DateTime.ParseExact(string, string, System.IFormatProvider)"/>.
        /// 
        /// This method should only be used for testing and should really not in this class att all.
        /// </summary>
        /// <param name="parseFunc"></param>
        internal static void SetParseExactStringStringFormatProvider(System.Func<string, string, System.IFormatProvider, System.DateTime> parseFunc) =>
            _parseExactStringStringFormatProvider = parseFunc;

        /// <summary>This method sets the <see cref="SpecifyKind(DateTime, System.DateTimeKind)"/> method.
        /// Set to null to have <see cref="SpecifyKind(DateTime, System.DateTimeKind)"/> return <see cref="System.DateTime.SpecifyKind(System.DateTime, System.DateTimeKind)"/>.
        /// </summary>
        /// <param name="specifyKindFunc"></param>
        internal static void SetSpecifyKind(System.Func<System.DateTimeKind> specifyKindFunc) => _specifyKind = specifyKindFunc;

        /// <summary>This method sets the <see cref="TryParse(string, System.IFormatProvider, DateTimeStyles, out DateTime)"/> method.
        /// Set to null to have <see cref="TryParse(string, System.IFormatProvider, DateTimeStyles, out DateTime)"/> return <see cref="System.DateTime.TryParse(string, System.IFormatProvider, DateTimeStyles, out System.DateTime)"/>.
        /// </summary>
        /// <param name="returnFunc"></param>
        /// <param name="outFunc"></param>
        internal static void SetTryParseStringIFormatProviderDateTimeStylesDateTime(
            System.Func<bool> returnFunc,
            System.Func<System.DateTime> outFunc) {
            _setTryParseStringIFormatProviderDateTimeStylesDateTimeReturn = returnFunc;
            _setTryParseStringIFormatProviderDateTimeStylesDateTimeOut = outFunc;
        }

        /// <summary>This method sets the <see cref="TryParse(string, out DateTime)"/> method.
        /// Set to null to have <see cref="TryParse(string, out DateTime)"/> return <see cref="System.DateTime.TryParse(string, out System.DateTime)"/>.
        /// </summary>
        /// <param name="returnFunc"></param>
        /// <param name="outFunc"></param>
        internal static void SetTryParseStringDateTime(
            System.Func<bool> returnFunc,
            System.Func<System.DateTime> outFunc) {
            _setTryParseStringDateTimeReturn = returnFunc;
            _setTryParseStringDateTimeOut = outFunc;
        }

        /// <summary>This method sets the <see cref="TryParseExact(string, string, System.IFormatProvider, DateTimeStyles, out System.DateTime)"/> method.
        /// Set to null to have <see cref="TryParseExact(string, string, System.IFormatProvider, DateTimeStyles, out System.DateTime)"/> return <see cref="System.DateTime.TryParseExact(string, string, System.IFormatProvider, DateTimeStyles, out System.DateTime)"/>.
        /// </summary>
        /// <param name="returnFunc"></param>
        /// <param name="outFunc"></param>
        internal static void SetTryParseExactStringStringIFormatProviderDateTimeStyles(
            System.Func<bool> returnFunc, 
            System.Func<System.DateTime> outFunc)
        {
            _setTryParseExactStringStringIFormatProviderDateTimeStylesReturn = returnFunc;
            _setTryParseExactStringStringIFormatProviderDateTimeStylesOut = outFunc;
        }

        /// <summary>This method sets the <see cref="TryParseExact(string, string[], System.IFormatProvider, DateTimeStyles, out System.DateTime)"/> method.
        /// Set to null to have <see cref="TryParseExact(string, string[], System.IFormatProvider, DateTimeStyles, out System.DateTime)"/> return <see cref="System.DateTime.TryParseExact(string, string[], System.IFormatProvider, DateTimeStyles, out System.DateTime)"/>.
        /// </summary>
        /// <param name="returnFunc"></param>
        /// <param name="outFunc"></param>
        internal static void SetTryParseExactStringStringArrayIFormatProviderDateTimeStyles(
            System.Func<bool> returnFunc, 
            System.Func<System.DateTime> outFunc)
        {
            _setTryParseExactStringStringArrayIFormatProviderDateTimeStylesReturn = returnFunc;
            _setTryParseExactStringStringArrayIFormatProviderDateTimeStylesOut = outFunc;
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

        #endregion

        #region Instance methods used for testing and not production.

        /// <summary>This method sets the <see cref="Add(TimeSpan)"/> return value.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="Add(TimeSpan)"/> return <see cref="System.DateTime.Add(System.TimeSpan)"/>.
        /// </summary>
        /// <param name="func"></param>
        internal void SetAdd(System.Func<DateTime> func)
        {
            _add = func;
        }

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

        #endregion

        #endregion

        #region Private helper methods.

        private DateTime FromSystemDateTime(System.DateTime datetime)
        {
            return new DateTime(datetime.Ticks, datetime.Kind);
        }

        private System.DateTime ToSystem(DateTime datetime)
        {
            return new System.DateTime(datetime.Ticks, datetime.Kind);
        }

        #endregion
    }
}
