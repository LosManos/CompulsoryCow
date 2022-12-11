[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("CompulsoryCow.AssemblyAbstractions.Unit.Tests")]

namespace CompulsoryCow.AssemblyAbstractions
{
    partial class Assembly
    {
        #region Methods used for testing and not production.

        /// <inheritdoc />
        public System.Reflection.Assembly GetAssembly()
        {
            return _systemReflectionAssembly;
        }

        /// <inheritdoc />
        public void SetAssembly(System.Func<System.Reflection.Assembly> assemblyFunc)
        {
            _systemReflectionAssembly = assemblyFunc();
        }

        #endregion

        /// <summary>Convert a <see cref="System.Reflection.Assembly"/> to a <see cref="IAssembly"/>.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IAssembly ToIAssembly( System.Reflection.Assembly assembly)
        {
            return new Assembly(assembly);
        }
    }
}
