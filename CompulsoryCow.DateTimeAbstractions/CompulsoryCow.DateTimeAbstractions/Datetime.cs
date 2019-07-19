[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("CompulsoryCow.DateTimeAbstractions.Unit.Tests")]

namespace CompulsoryCow.DateTime.Abstractions
{
    public interface IDateTime
    {
        System.DateTimeKind Kind { get; }
        long Ticks { get; }
        DateTime Add(TimeSpan value);
    }

    // TODO:OF:Implement interfaces found at https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netcore-2.2
    public class DateTime : IDateTime
    {
        private System.DateTime _value;

        public DateTime(long ticks)
        {
            _value = new System.DateTime(ticks);
        }

        public System.DateTimeKind Kind
        {
            get
            {
                return _value.Kind;
            }
        }

        public long Ticks
        {
            get
            {
                return _value.Ticks;
            }
        }

        public DateTime Add(TimeSpan value)
        {
            return FromSystemDateTime(_value.Add(value.ToSystemTimeSpan()));
        }

        public static DateTime UtcNow
        {
            get
            {
                return new DateTime(System.DateTime.UtcNow.Ticks);
            }
        }

        private DateTime FromSystemDateTime(System.DateTime datetime)
        {
            return new DateTime(datetime.Ticks);
        }
    }
}
