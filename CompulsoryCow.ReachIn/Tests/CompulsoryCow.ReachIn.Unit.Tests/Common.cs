namespace CompulsoryCow.ReachIn.Tests
{
    internal static class Common
    {
        /// <summary>The tests handling static properties must be run in parallel
        /// to be deterministic.
        /// Alas, every test regarding a static property should have this flag set.
        /// 
        /// The flag can only be set at classes
        /// and by the time of writing the classes also encompasses tests
        /// that don't test static properties.
        /// Well... the tests don't take _that_ long time
        /// so the testing time saved is not _that_ great
        /// if we should run in parallel.
        /// Feel free to update to split tests in "static" and "non static"
        /// to allow as many tests as possible to run in parallel.
        /// </summary>
        internal const string SequentialDueToStatic = "Sequential";
    }
}
