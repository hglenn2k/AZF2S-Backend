using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AZF2S_Backend.Model
{
    public class Error(string message, LogLevel logLevel, Exception? exception = null)
    {
        [JsonProperty("message")]
        public string Message { get; } = message;
        
        [JsonProperty("logLevel")] 
        public LogLevel LogLevel { get; } = logLevel;
        
        [JsonIgnore]
        public Exception? Exception { get; } = exception;
        
        public Error ToUserFacing() => new(Message, LogLevel);
    }
}