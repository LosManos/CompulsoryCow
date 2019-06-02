using System;
using System.Xml;

namespace CompulsoryCow
{
    [Obsolete("This class has been renamed to Deserialiser.")]
    public static class Deserializer
    {
        [Obsolete("This method has been moved to Serialiser class.")]
        public static T FromXml<T>(XmlDocument doc) where T : class
        {
            throw new NotImplementedException("This method has been moved to Serialiser class.");
        }
    }
}
