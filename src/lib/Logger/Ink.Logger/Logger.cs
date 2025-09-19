using Ink.Logger.Options;
using Ink.Logger.Schema;

namespace Ink.Logger
{
    public abstract class Logger : ILogger
    {
        private readonly LoggerOptions _options;

        private LogLevel loggerlevel;

        protected Logger(LoggerOptions options, LogLevel logLevel)
        {
            _options = options;

            SetLoggerLevel(logLevel);
        }

        public abstract void Assert(string message);

        public abstract void Debug(string message);

        public abstract void Information(string message);

        public abstract void Warning(string message);

        public abstract void Error(string message);

        public abstract void Critical(string message);

        public void SetLoggerLevel(LogLevel logLevel)
        {
            loggerlevel = logLevel;
        }

        protected virtual bool CanLog(LogLevel log)
        {
            return log >= loggerlevel;
        }

        protected TLoggerOption GetOptions<TLoggerOption>() where TLoggerOption : LoggerOptions
        {
            return (TLoggerOption)_options;
        }
    }
}