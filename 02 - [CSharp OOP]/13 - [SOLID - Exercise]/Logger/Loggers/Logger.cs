using Logger.Appenders;
using Logger.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Loggers
{
    public class Logger : ILogger
    {
        private readonly IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }
        public void Info(string dateTime, string message)
        {
            this.AppendError(dateTime, ReportLevel.Info, message);
        }

        public void Warning(string dateTime, string message)
        {
            this.AppendError(dateTime, ReportLevel.Warning, message);
        }

        public void Error(string dateTime, string message)
        {
            this.AppendError(dateTime, ReportLevel.Error, message);
        }

        public void Critical(string dateTime, string message)
        {
            this.AppendError(dateTime, ReportLevel.Critical, message);
        }

        public void Fatal(string dateTime, string message)
        {
            this.AppendError(dateTime, ReportLevel.Fatal, message);
        }

        private void AppendError(string dateTime, ReportLevel reportLevel, string message)
        {
            foreach (var item in this.appenders)
            {
                item.Append(dateTime, reportLevel, message);
            }
        }
    }
}
