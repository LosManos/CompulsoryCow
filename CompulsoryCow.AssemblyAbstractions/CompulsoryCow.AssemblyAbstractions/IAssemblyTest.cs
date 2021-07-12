[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("CompulsoryCow.AssemblyAbstractions.Unit.Tests")]

namespace CompulsoryCow.AssemblyAbstractions
{
    /// <summary>This interface is used when mocking
    /// and testing the <see cref="IAssembly"/>.
    /// 
    /// This interface should have been its own and `internal` in a perfect world
    /// but as <see cref="IAssembly"/> has to be `public` due to
    /// <see cref="IAssembly"/>; also this interface has to be public
    /// and when reality hits it must be part of `IAssembly` instead of
    /// `IAssemblyForTetingPurposes` or similar.
    /// </summary>
    public partial interface IAssembly
    {
        #region Value getters and setters.

        /// <summary>Same as `SetValue(null)`.
        /// </summary>
        void ClearAssembly();

        /// <summary>Get the mocked <see cref="System.Reflection.Assembly"/> value.
        /// If nothing is mocked, this value is null.
        /// </summary>
        /// <returns></returns>
        System.Reflection.Assembly GetAssembly();

        /// <summary>Set the mocked <see cref="System.Reflection.Assembly"/> value. Set to null avoid mocking.
        /// </summary>
        /// <param name="assemblyFunc"></param>
        void SetAssembly(System.Func<System.Reflection.Assembly> assemblyFunc);

        #endregion

        #region FullName getters and setters.

        /// <summary>Same as `SetFullName(null);
        /// </summary>
        void ClearFullName();

        /// <summary>Sets the FullName as <see cref="FullName"/>.
        /// If null; the FullName of the SystemReflectionAssembly is returned.
        /// If Assembly is null, null is returned.
        /// </summary>
        /// <param name="value"></param>
        void SetFullName(string value);

        #endregion
    }
}