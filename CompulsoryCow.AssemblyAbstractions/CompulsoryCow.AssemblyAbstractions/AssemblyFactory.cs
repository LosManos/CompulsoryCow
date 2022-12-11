using System;

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
            var ass = System.Reflection.Assembly.GetAssembly(type);

            // We are covering for a very weird case here. There is no way for a type to _not_ be in an assembly AFAIK.
            // There might be a way, by creating a type runtime, if even possible. But that is a border case
            // so let's just bail.
            if (ass == null)
            {
                throw new ArgumentException($"Type {type} is not in an assembly", nameof(type));
            }

            return new Assembly(ass);
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
