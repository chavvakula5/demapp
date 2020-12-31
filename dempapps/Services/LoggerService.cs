using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dempapps.Services
{
    public class LoggerManager : ILoggerManager
    {
        public static ILogger logger = LogManager.GetCurrentClassLogger();
        public override void LogDebug(string message)
        {
            logger.Debug(message);
        }
        public override void LogError(string message)
        {
            logger.Error(message);
        }
        public override void LogInfo(string message)
        {
            logger.Info(message);
        }
        public override void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
