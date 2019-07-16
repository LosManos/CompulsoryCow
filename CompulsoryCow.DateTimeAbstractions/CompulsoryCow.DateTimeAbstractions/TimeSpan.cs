[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("CompulsoryCow.DateTimeAbstractions.Unit.Tests")]

namespace CompulsoryCow.DateTimeAbstractions
{
    // TODO:OF:Implement interfaces at https://docs.microsoft.com/en-us/dotnet/api/system.timespan?view=netcore-2.2
    public struct TimeSpan
    {
        private global::System.TimeSpan _value;

        internal global::System.TimeSpan ToSystemTimeSpan()
        {
            return _value;
        }
    }
}
