using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dempapps.Services
{
    public abstract class ILoggerManager
    {
       public abstract void LogInfo(string message);
       public abstract void LogWarn(string message);
       public abstract void LogDebug(string message);
       public abstract void LogError(string message);
    }
}
