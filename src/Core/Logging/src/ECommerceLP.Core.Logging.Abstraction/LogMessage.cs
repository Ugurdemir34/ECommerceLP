using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.FileLogging
{
    public struct LogMessage
    {
        public readonly string LogName;
        public readonly string Message;
        public readonly LogLevel LogLevel;
        public readonly EventId EventId;
        public readonly Exception Exception;

        public LogMessage(string logName, LogLevel level, EventId eventId, string message, Exception ex)
        {
            LogName = logName;
            Message = message;
            LogLevel = level;
            EventId = eventId;
            Exception = ex;
        }

    }
}
