[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("CompulsoryCow.DateTimeAbstractions.Unit.Tests")]

namespace CompulsoryCow.DateTimeAbstractions
{
    // TODO:OF:Implement interfaces found at https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netcore-2.2
    public struct DateTime
    {
        private global::System.DateTime _value;

        public DateTime(long ticks)
        {
            _value = new System.DateTime(ticks);
        }

        public global::System.DateTimeKind Kind
        {
            get
            {
                return _value.Kind;
            }
        }

        public long Ticks { get
            {
                return _value.Ticks;
            }
        }

        public DateTime Add(TimeSpan value)
        {
            return ToSystemDateTime(_value.Add(value.ToSystemTimeSpan()));
        }

        private DateTime ToSystemDateTime( global::System.DateTime datetime)
        {
            return new DateTime(datetime.Ticks);
        }
    }
}
