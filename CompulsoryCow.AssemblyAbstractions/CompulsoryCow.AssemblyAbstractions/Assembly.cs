namespace CompulsoryCow.AssemblyAbstractions
{
    public partial class Assembly: IAssembly
    {
        private System.Reflection.Assembly _systemReflectionAssembly;
        private string _fullName;
    }
}
