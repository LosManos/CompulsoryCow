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
            var res = new Assembly();
            res.SetAssembly(() => System.Reflection.Assembly.GetAssembly(type));
            return res;
        }

        /// <inheritdoc />
        public IAssembly GetExecutingAssembly()
        {
            var res = new Assembly();
            res.SetAssembly(() => System.Reflection.Assembly.GetExecutingAssembly());
            return res;
        }

        /// <inheritdoc />
        public IAssembly LoadFile(string pathFile)
        {
            var res = new Assembly();
            res.SetAssembly(() => System.Reflection.Assembly.LoadFile(pathFile));
            return res;
        }

        /// <inheritdoc />
        public IAssembly LoadFrom(string pathFile)
        {
            var res = new Assembly();
            res.SetAssembly(() => System.Reflection.Assembly.LoadFrom(pathFile));
            return res;
        }

        #endregion

    }
}
