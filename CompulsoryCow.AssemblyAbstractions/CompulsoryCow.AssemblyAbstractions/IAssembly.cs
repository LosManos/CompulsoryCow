using System;

namespace CompulsoryCow.AssemblyAbstractions
{
    public partial interface IAssembly
    {
        /// <summary>See <see cref="System.Reflection.Assembly.FullName"/>.
        /// </summary>
        string FullName { get; }

        /// <summary>See <see cref="System.Reflection.Assembly.Location"/>
        /// </summary>
        string Location { get; }

        /// <summary>See <see cref="System.Reflection.Assembly.GetAssembly(Type)"/>.
        /// In Dotnet this method is a static constructor
        /// but as that makes unit testing and mocking hard
        /// the signaure is changed to be an object method.
        /// Other from that the method should behave as expected.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [Obsolete("Use IAssemblyFactory.GetAssembly instead.", true)]
        IAssembly GetAssembly(Type type);

        /// <summary>See <see cref="System.Reflection.Assembly.GetExecutingAssembly()"/>.
        /// In Dotnet this method is a static constructor
        /// but as that makes unit testing and mocking hard
        /// the signaure is changed to be an object method.
        /// Other from that the method should behave as expected.
        /// </summary>
        /// <returns></returns>
        [Obsolete("Use IAssemblyFactory.GetExecutingAssembly instead.", true)]
        IAssembly GetExecutingAssembly();

        /// <summary>See <see cref="System.Reflection.Assembly.LoadFrom(string)"/>.
        /// In Dotnet this method is a static constructor
        /// but as that makes unit testing and mocking hard
        /// the signature is changed to be a normal method.
        /// Other from that the method should behave as expected.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [Obsolete("Use IAssemblyFactory.LoadFile instead.", true)]
        IAssembly LoadFile(string path);

        /// <summary>See <see cref="System.Reflection.Assembly.GetName"/>.
        /// 

        /// </summary>
        /// <returns></returns>
        System.Reflection.AssemblyName GetName();

        /// <summary>See <see cref="System.Reflection.Assembly.GetTypes"/>
        /// </summary>
        /// <returns></returns>
        Type[] GetTypes();
    }
}