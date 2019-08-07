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
        private readonly System.DateTime _value;
        private static System.DateTime? _now;
        private static System.DateTime? _utcNow;
        private static System.Func<System.DateTime, System.DateTime, int> _compare;
        private static System.Func<int, int, int> _daysInMonth;
        private static System.Func<System.DateTime, System.DateTime, bool> _equals;
        private static System.Func<long, System.DateTime> _fromBinary;
        private static System.Func<long, System.DateTime> _fromFileTime;

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

        #endregion

        #region Instance methods.

        public DateTime Add(TimeSpan value)
        {
            return FromSystemDateTime(_value.Add(value.ToSystemTimeSpan()));
        }

        #endregion

        #region Methods used for testing and not production.

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

        /// <summary>This method sets the <see cref="FromFileTime(long)"/> proprty.
        /// 
        /// This method should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="FromFileTime(long)"/> return <see cref="System.DateTime.FromFileTime(long)"/>.
        /// </summary>
        /// <param name="fromFileTimeFunc"></param>
        internal static void SetFromFileTime(System.Func<long, System.DateTime> fromFileTimeFunc) => _fromFileTime = fromFileTimeFunc;

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

        #region Private helper methods.

        private DateTime FromSystemDateTime(System.DateTime datetime)
        {
            return new DateTime(datetime.Ticks);
        }

        #endregion
    }
}
