using System.IO;

namespace CompulsoryCow.AssemblyAbstractions
{
    /// <summary>Abstract <see cref="System.Runtime.Loader.AssemblyLoadContext"/>.
    /// </summary>
    public class AssemblyLoadContext : IAssemblyLoadContext
    {
        private readonly System.Runtime.Loader.AssemblyLoadContext assemblyLoadContext;

        /// <inheritdoc />
        public AssemblyLoadContext(System.Runtime.Loader.AssemblyLoadContext assemblyLoadContext)
        {
            this.assemblyLoadContext = assemblyLoadContext;
        }

        /// <inheritdoc />
        public IAssembly LoadFromStream(Stream assembly)
        {
            return Assembly.ToIAssembly(
                assemblyLoadContext.LoadFromStream(assembly)
            );
        }
    }
}
