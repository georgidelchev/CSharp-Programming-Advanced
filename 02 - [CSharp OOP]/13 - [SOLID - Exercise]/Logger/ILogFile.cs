using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    public interface ILogFile
    {
         string Text { get; }

        int Size { get; }

        void Write(string error); 
    }
}
