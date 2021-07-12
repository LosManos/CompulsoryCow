namespace CompulsoryCow.AssemblyAbstractions
{
    public partial interface IAssembly
    {
        /// <summary>See <see cref="System.Reflection.Assembly.FullName"/>.
        /// </summary>
        string FullName { get; }

        ///// <summary>See <see cref="System.Reflection.Assembly.GetAssembly(System.Type)"/>.
        ///// In Dotnet this method is a static constructor
        ///// but as that makes unit testing and mocking hard
        ///// the signaure is changed to be an object method.
        ///// Other from that the method should behave as expected.
        ///// </summary>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //IAssembly GetAssembly(System.Type type);

        ///// <summary>See <see cref="System.Reflection.Assembly.LoadFrom(string)"/>.
        ///// In Dotnet this method is a static constructor
        ///// but as that makes unit testing and mocking hard
        ///// the signature is changed to be a normal method.
        ///// Other from that the method should behave as expected.
        ///// </summary>
        ///// <param name="path"></param>
        ///// <returns></returns>
        //IAssembly LoadFile(string path);
    }
}