using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceLP.Core.FileLogging
{
    public class FileLoggerConfig
    {
        public string Path { get; set; } = null;

        public bool Append { get; set; } = true;

        public long FileSizeLimitBytes { get; set; } = 0;

        public int MaxRollingFiles { get; set; } = 0;

        public LogLevel MinLevel { get; set; } = LogLevel.Trace;
    }
}
