[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("CompulsoryCow.DateTimeAbstractions.Unit.Tests")]

namespace CompulsoryCow.DateTime.Abstractions
{
    public interface ITimeSpan
    {
        long Ticks { get; }
    }

    // TODO:OF:Implement interfaces at https://docs.microsoft.com/en-us/dotnet/api/system.timespan?view=netcore-2.2
    public struct TimeSpan : ITimeSpan
    {
        private readonly System.TimeSpan _value;

        public TimeSpan(long ticks)
        {
            _value = new System.TimeSpan(ticks);
        }

        public long Ticks { get { return _value.Ticks; } }

        /// <summary>This method converts the <see cref="TimeSpan"/> to <see cref="System.TimeSpan"/>.
        /// It should only be used for tests and is not part of the TimeSpan interface.
        /// </summary>
        /// <returns></returns>
        internal System.TimeSpan ToSystemTimeSpan()
        {
            return _value;
        }
    }
}
