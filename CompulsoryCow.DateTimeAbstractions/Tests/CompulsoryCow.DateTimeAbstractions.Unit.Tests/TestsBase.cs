using System.Reflection;
using Xunit.Abstractions;

namespace CompulsoryCow.DateTimeAbstractions.Unit.Tests
{
    public abstract class TestsBase
    {
        protected readonly VacheTacheLibrary.PseudoRandom _pr;

        protected internal TestsBase(ITestOutputHelper output)
        {
            //  Get test info.
            var type = output.GetType();
            var testMember = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
            var test = (ITest)testMember.GetValue(output);

            //  Set the seed for randomising.
            _pr = new VacheTacheLibrary.PseudoRandom(test.DisplayName);
        }

        protected internal long AnyTicks()
        {
            return _pr.PositiveLong(1, global::System.DateTime.MaxValue.Ticks);
        }
    }
}
