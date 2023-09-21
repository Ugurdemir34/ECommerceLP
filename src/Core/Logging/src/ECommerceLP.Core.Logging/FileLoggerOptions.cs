using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.FileLogging
{
    public class FileLoggerOptions
    {
        public bool Append { get; set; } = true;
        public long FileSizeLimitBytes { get; set; } = 0;
        public int MaxRollingFiles { get; set; } = 0;
        public bool UseUtcTimestamp { get; set; }
        public Func<LogMessage, string> FormatLogEntry { get; set; }
        public Func<LogMessage, bool> FilterLogEntry { get; set; }
        public LogLevel MinLevel { get; set; } = LogLevel.Trace;
        public Func<string, string> FormatLogFileName { get; set; }
        public Action<FileLoggerProvider.FileError> HandleFileError { get; set; }
    }
}
