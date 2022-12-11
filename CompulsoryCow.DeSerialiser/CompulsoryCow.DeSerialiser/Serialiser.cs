using System;
using System.Diagnostics.CodeAnalysis;
using System.Xml;

namespace CompulsoryCow;

/// <summary>This class is for serialising objects.
/// </summary>
public static class Serialiser
{
    /// <summary>This method serialises an object to Xml.
    /// If null is passed then null is returned.
    ///  http://www.dotnetfunda.com/articles/article98.aspx
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static XmlDocument ToXml([DisallowNull] object obj)
    {
        if (null == obj)
        {
            throw new ArgumentNullException(nameof(obj));
        }
        var doc = new XmlDocument();
        var serializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
        using (var stream = new System.IO.MemoryStream())
        {
            serializer.Serialize(stream, obj);
            stream.Position = 0;
            doc.Load(stream);
            return doc;
        }
    }
}
