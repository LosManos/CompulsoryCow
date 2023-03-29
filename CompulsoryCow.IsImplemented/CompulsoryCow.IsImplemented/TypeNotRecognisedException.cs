using System;

namespace CompulsoryCow.IsImplemented;

[Serializable]
public class TypeNotRecognisedException : Exception
{
    public TypeNotRecognisedException() { }
    public TypeNotRecognisedException(string message) : base(message) { }
    public TypeNotRecognisedException(string message, Exception inner) : base(message, inner) { }
    protected TypeNotRecognisedException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}
