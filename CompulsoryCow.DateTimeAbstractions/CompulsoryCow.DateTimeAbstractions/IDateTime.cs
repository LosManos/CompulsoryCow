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

        /// <summary>See <see cref="System.DateTime.AddDays(double)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        DateTime AddDays(double value);

        /// <summary>See <see cref="System.DateTime.AddHours(double)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        DateTime AddHours(double value);

        /// <summary>See <see cref="System.DateTime.AddMilliseconds(double)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        DateTime AddMilliseconds(double value);

        /// <summary>See <see cref="System.DateTime.AddMinutes(double)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        DateTime AddMinutes(double value);

        /// <summary>See <see cref="System.DateTime.AddMonths(int)"/>.
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        DateTime AddMonths(int months);

        /// <summary>See <see cref="System.DateTime.AddSeconds(double)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        DateTime AddSeconds(double value);

        /// <summary>See <see cref="System.DateTime.AddTicks(long)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        DateTime AddTicks(long value);

        /// <summary>See <see cref="System.DateTime.AddYears(int)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        DateTime AddYears(int value);

        /// <summary>See <see cref="System.DateTime.CompareTo(object)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int CompareTo(object value);

        /// <summary>See <see cref="System.DateTime.CompareTo(System.DateTime)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        int CompareTo(DateTime value);

        /// <summary>See <see cref="System.DateTime.Equals(System.DateTime)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Equals(DateTime value);

        /// <summary>See <see cref="System.DateTime.Equals(object)"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Equals(object value);

        /// <summary>See <see cref="System.DateTime.GetDateTimeFormats()"/>.
        /// </summary>
        /// <returns></returns>
        string[] GetDateTimeFormats();

        /// <summary>See <see cref="System.DateTime.GetDateTimeFormats(char, System.IFormatProvider)"/>.
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        string[] GetDateTimeFormats(char format, System.IFormatProvider provider);

        /// <summary>See <see cref="System.DateTime.GetDateTimeFormats(char)"/>.
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        string[] GetDateTimeFormats(char format);

        /// <summary>See <see cref="System.DateTime.GetDateTimeFormats(System.IFormatProvider)"/>.
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        string[] GetDateTimeFormats(System.IFormatProvider provider);

        /// <summary>See <see cref="System.DateTime.GetHashCode"/>.
        /// </summary>
        /// <returns></returns>
        int GetHashCode();

        /// <summary>See <see cref="System.DateTime.GetTypeCode"/>.
        /// </summary>
        /// <returns></returns>
        System.TypeCode GetTypeCode();

        /// <summary>See <see cref="System.DateTime.IsDaylightSavingTime"/>.
        /// </summary>
        /// <returns></returns>
        bool IsDaylightSavingTime();
    }
}
