﻿using System;

namespace CompulsoryCow.AssemblyAbstractions
{
    /// <summary>Abstract <see cref="System.Reflection.Assembly"/>.
    /// </summary>
    public partial class Assembly: IAssembly
    {
        private System.Reflection.Assembly _systemReflectionAssembly;

        internal Assembly(System.Reflection.Assembly assembly)
        {
            _systemReflectionAssembly = assembly;
        }

        /// <inheritdoc />
        [Obsolete("Use IAssemblyFactory.GetAssembly instead.", true)]
        public IAssembly GetAssembly(Type type)
        {
            throw new NotImplementedException("Use IAssemblyFactory.GetAssembly instead.");
        }

        /// <inheritdoc />
        [Obsolete("Use IAssemblyFactory.GetExecutingAssembly instead.", true)]
        public IAssembly GetExecutingAssembly()
        {
            throw new NotImplementedException("Use IAssemblyFactory.GetExecutingAssembly instead.");
        }

        /// <inheritdoc />
        [Obsolete("Use IAssemblyFactory.LoadFile instead.", true)]
        public IAssembly LoadFile(string path)
        {
            throw new NotImplementedException("Use IAssemblyFactory.LoadFile instead.");
        }
    }
}
