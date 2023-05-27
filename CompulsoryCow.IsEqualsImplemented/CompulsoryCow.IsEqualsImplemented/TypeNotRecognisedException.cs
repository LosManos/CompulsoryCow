using System;

namespace CompulsoryCow.IsEqualsImplemented;

[Serializable]
[Obsolete("Deprecated. Use CompulsoryCow.IsImplemented instead.", false)]
public class TypeNotRecognisedException : Exception
{
    [Obsolete("Deprecated. Use CompulsoryCow.IsImplemented instead.", false)]
    public TypeNotRecognisedException() { }
    
    [Obsolete("Deprecated. Use CompulsoryCow.IsImplemented instead.", false)]
    public TypeNotRecognisedException(string message) : base(message) { }
    
    [Obsolete("Deprecated. Use CompulsoryCow.IsImplemented instead.", false)]
    public TypeNotRecognisedException(string message, Exception inner) : base(message, inner) { }
    
    protected TypeNotRecognisedException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
