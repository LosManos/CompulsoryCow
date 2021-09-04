namespace CompulsoryCow.AssemblyAbstractions
{
    partial class Assembly
    {
        public string FullName
        {
            get
            {
                return _systemReflectionAssembly.FullName;
            }
        }
    }
}
