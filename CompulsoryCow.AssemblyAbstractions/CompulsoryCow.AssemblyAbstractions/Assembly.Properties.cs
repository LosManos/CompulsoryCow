namespace CompulsoryCow.AssemblyAbstractions
{
    partial class Assembly
    {
        #region Getters.

        public string FullName
        {
            get
            {
                return _systemReflectionAssembly.FullName;
            }
        }

        #endregion
    }
}
