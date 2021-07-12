[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("CompulsoryCow.AssemblyAbstractions.Unit.Tests")]

namespace CompulsoryCow.AssemblyAbstractions
{
    partial class Assembly: IAssembly
    {
        #region Methods used for testing and not production.

        #region Assembly methods.

        #endregion

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

        #region

        #region FullName methods.

        #endregion

        /// <inheritdoc />
        public void ClearFullName()
        {
            SetFullName(null);
        }

        /// <inheritdoc />
        public void SetFullName(string value)
        {
            _fullName = value;
        }

        #endregion

#endregion
    }
}
