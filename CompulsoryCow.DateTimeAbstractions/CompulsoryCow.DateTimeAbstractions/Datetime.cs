using System.Globalization;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("CompulsoryCow.DateTimeAbstractions.Unit.Tests")]

namespace CompulsoryCow.DateTime.Abstractions
{
    public interface IDateTime
    {
        /// <summary>See <see cref="System.DateTime.Kind"/>.
        /// </summary>
        System.DateTimeKind Kind { get; }

        /// <summary>See <see cref="System.DateTime.Ticks"/>.
        /// </summary>
        long Ticks { get; }

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
        internal static System.DateTime? _now;
        internal static System.DateTime? _utcNow;

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

        public static DateTime Now
        {
            get
            {
                return new DateTime(_now?.Ticks ?? System.DateTime.Now.Ticks);
            }
        }

        public static DateTime UtcNow
        {
            get
            {
                return new DateTime(_utcNow?.Ticks ?? System.DateTime.UtcNow.Ticks);
            }
        }

        /// <inheritdoc />
        public long Ticks { get { return _value.Ticks; } }
        public int Second { get { return _value.Second; } }
        public DateTime Date { get { return new DateTime(_value.Date.Ticks); } }
        public int Month { get { return _value.Month; } }
        public int Minute { get { return _value.Minute; } }
        public int Millisecond { get { return _value.Millisecond; } }
        public System.DateTimeKind Kind { get { return _value.Kind; } }
        public int Hour { get { return _value.Hour; } }
        public object DayOfYear { get { return _value.DayOfYear; } }
        public System.DayOfWeek DayOfWeek { get { return _value.DayOfWeek; } }
        public int Day { get { return _value.Day; } }
        public TimeSpan TimeOfDay { get { return new TimeSpan(_value.TimeOfDay.Ticks); } }
        public int Year { get { return _value.Year; } }

        public static DateTime MaxValue { get { return new DateTime( System.DateTime.MaxValue.Ticks); } }
        public static DateTime MinValue { get { return new DateTime(System.DateTime.MinValue.Ticks); } }

        public DateTime Add(TimeSpan value)
        {
            return FromSystemDateTime(_value.Add(value.ToSystemTimeSpan()));
        }

        /// <summary>This method sets the <see cref="Now"/> propjerty.
        /// It should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="DateTime.Now"/> return <see cref="System.DateTime.Now"/>.
        /// </summary>
        /// <param name="now"></param>
        internal static void SetNow(System.DateTime? now) => _now = now;

        /// <summary>Thid method sets the <see cref="DateTime.UtcNow"/> property.
        /// It should only be used for testing and really not be in this class at all.
        /// Set to null to have <see cref="DateTime.UtcNow"/> return <see cref="System.DateTime.UtcNow"/>.
        /// </summary>
        /// <param name="utcNow"></param>
        internal static void SetUtcNow(System.DateTime? utcNow) => _utcNow = utcNow;

        private DateTime FromSystemDateTime(System.DateTime datetime)
        {
            return new DateTime(datetime.Ticks);
        }
    }
}
