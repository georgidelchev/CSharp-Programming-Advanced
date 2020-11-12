using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Loggers
{
    public interface ILogger
    {
        void Info(string dateTime, string message);

        void Warning(string dateTime, string message);

        void Error(string dateTime, string message);

        void Critical(string dateTime, string message);

        void Fatal(string dateTime, string message);
    }
}
