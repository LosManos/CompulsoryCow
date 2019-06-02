using System;
using System.Xml;

namespace CompulsoryCow.DeSerialiser
{
    [Obsolete("This class has been renamed to Serialiser.")]
    public static class Serializer
    {
        [Obsolete("This method has been moved to Serialiser class.")]
        public static XmlDocument ToXml(object obj)
        {
            throw new NotImplementedException("This method has been moved to Serialiser class.");
        }
    }
}
