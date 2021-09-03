[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("CompulsoryCow.AssemblyAbstractions.Unit.Tests")]

namespace CompulsoryCow.AssemblyAbstractions
{
    partial class Assembly
    {
        #region Methods used for testing and not production.

        /// <inheritdoc />
        public void ClearAssembly()
        {
            _systemReflectionAssembly = null;
        }

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
    }
}
