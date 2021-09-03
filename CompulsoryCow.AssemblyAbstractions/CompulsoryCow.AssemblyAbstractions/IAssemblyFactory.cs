using System;

namespace CompulsoryCow.AssemblyAbstractions
{
    public partial interface IAssemblyFactory
    {
        /// <summary>See <see cref="System.Reflection.Assembly.GetAssembly(Type)"/>.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IAssembly GetAssembly(Type type);

        /// <summary>See <see cref="System.Reflection.Assembly.GetExecutingAssembly()"/>
        /// </summary>
        /// <returns></returns>
        IAssembly GetExecutingAssembly();

        /// <summary>See <see cref="System.Reflection.Assembly.LoadFile(string)"/>
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        IAssembly LoadFile(string pathFile);
    }
}