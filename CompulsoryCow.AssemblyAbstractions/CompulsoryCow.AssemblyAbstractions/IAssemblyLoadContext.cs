using System.IO;

namespace CompulsoryCow.AssemblyAbstractions
{
    /// <summary>See <see cref="System.Runtime.Loader.AssemblyLoadContext"/>.
    /// </summary>
    public interface IAssemblyLoadContext
    {
        /// <summary>See <see cref="System.Runtime.Loader.AssemblyLoadContext.LoadFromStream(Stream)"/>.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public IAssembly LoadFromStream(Stream assembly);
    }
}
