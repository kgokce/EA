using EA.Infrastructure.Enumerations;
using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using log4net.Config;

namespace EA.Infrastructure.CrossCutting.Logging
{
    public class Log4netLogger : ILogger
    {
        /// <summary>
        /// bu alan atılan log'lar için thread takibinde kullanılıyor. Eğer kullanılıyor ise ILogger PerThread olarak register edilmeli.
        /// </summary>
        /// //track info
        public TrackInfo TrackInfo { get; set; }

        public static void Init(string logfile)
        {
            if (string.IsNullOrEmpty(logfile))
            {
                logfile = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            }

            XmlConfigurator.Configure(new FileInfo(logfile));
        }

        public void Log(string message)
        {
            this.Log(string.Empty, message, LogType.Information, null);
        }

        public void Log(string message, LogType logType)
        {
            this.Log(string.Empty, message, logType, null);
        }

        public void Log(string message, LogType logType, Exception exception)
        {
            this.Log(string.Empty, message, logType, exception);
        }

        public void Log(string logName, string message)
        {
            this.Log(logName, message, LogType.Information, null);
        }

        public void Log(string logName, string message, LogType logType)
        {
            this.Log(logName, message, logType, null);
        }

        public void Log(string logName, string message, LogType logType, Exception exception)
        {
            log4net.ILog logger = string.IsNullOrWhiteSpace(logName) ?
                LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType) :
                LogManager.GetLogger(logName);

            if (this.TrackInfo != null && !(string.IsNullOrWhiteSpace(this.TrackInfo.TrackId)))
            {
                message = string.Format("Ref:{0} {1}", this.TrackInfo.TrackId, message);
            }

            switch (logType)
            {
                case LogType.Error:

                    if (logger.IsErrorEnabled)
                    {
                        logger.Error(message, exception);
                    }

                    break;
                case LogType.Information:

                    if (logger.IsInfoEnabled)
                    {
                        logger.Info(message, exception);
                    }

                    break;
                case LogType.Warning:

                    if (logger.IsWarnEnabled)
                    {
                        logger.Warn(message, exception);
                    }

                    break;

                case LogType.Debug:

                    if (logger.IsDebugEnabled)
                    {
                        logger.Debug(message, exception);
                    }

                    break;

                default:

                    if (logger.IsDebugEnabled)
                    {
                        logger.Debug(message, exception);
                    }

                    break;
            }
        }
    }
}
