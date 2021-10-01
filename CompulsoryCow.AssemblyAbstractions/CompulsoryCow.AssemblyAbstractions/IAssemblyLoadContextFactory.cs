namespace CompulsoryCow.AssemblyAbstractions
{
    public interface IAssemblyLoadContextFactory
    {
        /// <summary>Create an <see cref="IAssemblyLoadContext"/>.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isCollectible"></param>
        /// <returns></returns>
        IAssemblyLoadContext Create(string name, bool isCollectible = false);
    }
}
