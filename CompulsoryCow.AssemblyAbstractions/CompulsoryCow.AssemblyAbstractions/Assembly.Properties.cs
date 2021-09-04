namespace CompulsoryCow.AssemblyAbstractions
{
    partial class Assembly
    {
        /// <inheritdoc />
        public string FullName
        {
            get
            {
                return _systemReflectionAssembly.FullName;
            }
        }

        /// <inheritdoc />
        public string Location
        {
            get
            {
                return _systemReflectionAssembly.Location;
            }
        }
    }
}
