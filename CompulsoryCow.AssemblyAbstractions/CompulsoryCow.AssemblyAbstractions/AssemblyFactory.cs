namespace CompulsoryCow.AssemblyAbstractions
{
    public partial class AssemblyFactory : IAssemblyFactory
    {
        #region Constructors.

        /// <summary>Since <see cref="System.Reflection.Assembly"/> has static constructors
        /// we choose to implement them in a factory.
        /// We could choose to implement them as object methods in <see cref="IAssembly"/>
        /// but it would make the calling code look wierd.
        /// ```
        /// var assembly = new Assembly();
        /// assembly = assembly.LoadFromFile("whatever");
        /// ```
        /// </summary>
        public AssemblyFactory()
        {
        }

        #endregion

        #region Originally static constructors in System.Reflection.Assembly.

        /// <inheritdoc />
        public IAssembly GetAssembly(System.Type type)
        {
            return new Assembly(
                System.Reflection.Assembly.GetAssembly(type));
        }

        /// <inheritdoc />
        public IAssembly GetExecutingAssembly()
        {
            return new Assembly(
                System.Reflection.Assembly.GetExecutingAssembly());
        }

        /// <inheritdoc />
        public IAssembly LoadFile(string pathFile)
        {
            return new Assembly(
                System.Reflection.Assembly.LoadFile(pathFile));
        }

        /// <inheritdoc />
        public IAssembly LoadFrom(string pathFile)
        {
            return new Assembly(
                System.Reflection.Assembly.LoadFrom(pathFile));
        }

        #endregion

    }
}
