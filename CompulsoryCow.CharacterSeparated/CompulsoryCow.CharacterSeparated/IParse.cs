using System.Collections.Generic;

namespace CompulsoryCow.CharacterSeparated
{
    public interface IParse
    {
        IEnumerable<object> Line(string line);
        IEnumerable<string> StringLine(string line);
    }
}