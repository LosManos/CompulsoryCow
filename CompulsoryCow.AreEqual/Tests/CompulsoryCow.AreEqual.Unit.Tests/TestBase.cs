using Microsoft.VisualStudio.TestTools.UnitTesting;
using VacheTacheLibrary;

namespace AreEqualTest;

public class TestBase
{
    protected PseudoRandom _pr;

    public TestContext TestContext { get; set; }

    [TestInitialize]
    public void Initialise()
    {
        _pr = new PseudoRandom(TestContext.TestName);
    }
}
