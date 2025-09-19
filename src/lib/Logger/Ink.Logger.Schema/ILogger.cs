namespace Ink.Logger.Schema
{
    public interface ILogger
    {
        void Assert(string message);

        void Debug(string message);

        void Information(string message);

        void Warning(string message);

        void Error(string message);

        void Critical(string message);

        void SetLoggerLevel(LogLevel logLevel);
    }
}