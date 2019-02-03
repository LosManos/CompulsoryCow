using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace CompulsoryCow
{
    /// <summary>This class is for deserialising objects.
    /// </summary>
    public static class Deserializer
    {
        /// <summary>This method deserialises an object from Xml.
        /// If null is passed then null is returned.
        ///  http://www.dotnetfunda.com/articles/article98.aspx
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static T FromXml<T>(XmlDocument doc) where T:class 
        {
            if (null == doc)
            {
                return null;
            }
            using (var stringreader = new StringReader(doc.InnerXml))
            {
                var serializer = new XmlSerializer(typeof (T));
                XmlReader reader = new XmlTextReader(stringreader);
                try
                {
                    var ret = (T) serializer.Deserialize(reader);
                    return ret;
                }
                finally
                {
                    reader.Close();
                }
            }
        }
    }
}
