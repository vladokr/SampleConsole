namespace Parser.Core.Interfaces
{
    public interface ILogger
    {
        void LogError(string ErrorMessage);
        void LogInfo(string InfoMessage);
    }
}
