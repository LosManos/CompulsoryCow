namespace CompulsoryCow.AssemblyAbstractions
{
    /// <summary>Create a <see cref="AssemblyLoadContext"/>.
    /// </summary>
    public class AssemblyLoadContextFactory : IAssemblyLoadContextFactory
    {
        /// <inheritdoc/>
        public IAssemblyLoadContext Create(string name, bool isCollectible = false)
        {
            var ass = new System.Runtime.Loader.AssemblyLoadContext(name, isCollectible);
            var ret = new AssemblyLoadContext(ass);
            return ret;
        }
    }
}
