using System;

namespace CompulsoryCow.AssemblyAbstractions
{
    /// <summary>Abstract <see cref="System.Reflection.Assembly"/>.
    /// </summary>
    public partial class Assembly
    {
        public System.Reflection.AssemblyName GetName()
        {
            return _systemReflectionAssembly.GetName();
        }

        public Type[] GetTypes()
        {
            return _systemReflectionAssembly.GetTypes();
        }
    }
}
