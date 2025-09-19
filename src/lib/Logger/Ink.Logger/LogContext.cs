using Ink.Logger.Schema;

namespace Ink.Logger
{
    public class LogContext : ILogger
    {
        private readonly ICollection<ILogger> _loggers;

        public LogContext()
        {
            _loggers = [];
        }

        public void Assert(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Assert(message);
            }
        }

        public void Debug(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Debug(message);
            }
        }

        public void Information(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Information(message);
            }
        }

        public void Warning(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Warning(message);
            }
        }

        public void Error(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Error(message);
            }
        }

        public void Critical(string message)
        {
            foreach (var logger in _loggers)
            {
                logger.Critical(message);
            }
        }

        public LogContext SetLoggerLevel(LogLevel logLevel)
        {
            foreach (var logger in _loggers)
            {
                logger.SetLoggerLevel(logLevel);
            }

            return this;
        }

        public LogContext SetLoggerLevel<TLogger>(LogLevel logLevel)
        {
            var logger =
                _loggers.FirstOrDefault(
                    x => x.GetType() == typeof(TLogger));

            logger?.SetLoggerLevel(logLevel);

            return this;
        }

        void ILogger.SetLoggerLevel(LogLevel logLevel)
        {
            SetLoggerLevel(logLevel);
        }

        public LogContext UseLogger(ILogger logger)
        {
            _loggers.Add(logger);

            return this;
        }
    }
}