using Xunit.Abstractions;
using Abstractions = CompulsoryCow.DateTime.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests
{
    /// <summary>This class contains test tests for the <see cref="Abstractions.DateTime"/> class.
    /// Due to the number of properties/methods/etc. it is split into several files
    /// named in an obvious fashion. ...yeah, right...
    /// </summary>
    public partial class DateTimeTests : DateTimeTestsBase
    {
        public DateTimeTests(ITestOutputHelper output)
            : base(output)
        { }
    }
}
