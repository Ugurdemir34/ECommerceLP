using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.FileLogging
{
    public class CustomLogger : ILogger
    {

        private readonly string logName;
        private readonly FileLoggerProvider LoggerPrv;

        public CustomLogger(string logName, FileLoggerProvider loggerPrv)
        {
            this.logName = logName;
            this.LoggerPrv = loggerPrv;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= LoggerPrv.MinLevel;
        }

        string GetShortLogLevel(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Trace:
                    return "TRCE";
                case LogLevel.Debug:
                    return "DBUG";
                case LogLevel.Information:
                    return "INFO";
                case LogLevel.Warning:
                    return "WARN";
                case LogLevel.Error:
                    return "FAIL";
                case LogLevel.Critical:
                    return "CRIT";
            }
            return logLevel.ToString().ToUpper();
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            if (formatter == null)
            {
                throw new ArgumentNullException(nameof(formatter));
            }

            string message = formatter(state, exception);

            if (LoggerPrv.Options.FilterLogEntry != null)
                if (!LoggerPrv.Options.FilterLogEntry(new LogMessage(logName, logLevel, eventId, message, exception)))
                    return;

            if (LoggerPrv.FormatLogEntry != null)
            {
                LoggerPrv.WriteEntry(LoggerPrv.FormatLogEntry(
                    new LogMessage(logName, logLevel, eventId, message, exception)));
            }
            else
            {
                // default formatting logic
                var logBuilder = new StringBuilder();
                if (!string.IsNullOrEmpty(message))
                {
                    DateTime timeStamp = LoggerPrv.UseUtcTimestamp ? DateTime.UtcNow : DateTime.Now;
                    logBuilder.Append(timeStamp.ToString("o"));
                    logBuilder.Append('\t');
                    logBuilder.Append(GetShortLogLevel(logLevel));
                    logBuilder.Append("\t[");
                    logBuilder.Append(logName);
                    logBuilder.Append("]");
                    logBuilder.Append("\t[");
                    logBuilder.Append(eventId);
                    logBuilder.Append("]\t");
                    logBuilder.Append(message);
                }

                if (exception != null)
                {
                    // exception message
                    logBuilder.AppendLine(exception.ToString());
                }
                LoggerPrv.WriteEntry(logBuilder.ToString());
            }
        }
    }
}
