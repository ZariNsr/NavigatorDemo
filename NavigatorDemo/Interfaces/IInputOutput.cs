using System.Collections.Generic;

namespace NavigatorDemo.Interfaces
{
    public interface IInputOutput
    {
        List<string> Content { get; }       
        void Write(string output);
    }
}
