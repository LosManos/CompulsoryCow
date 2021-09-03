namespace CompulsoryCow.AssemblyAbstractions
{
    public partial class Assembly
    {
        public System.Reflection.AssemblyName GetName()
        {
            return _systemReflectionAssembly.GetName();
        }
    }
}
