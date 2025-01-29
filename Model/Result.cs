using Newtonsoft.Json;

namespace AZF2S_Backend.Model
{
    public class Result<TPayload>(TPayload? payload = default, IEnumerable<Error>? errors = null)
    {
        private readonly TPayload? _payload = payload;
        private readonly IReadOnlyList<Error>? _errors = errors?.ToList();

        [JsonProperty("payload")]
        public TPayload? Payload => _payload;
        public bool HasPayload => _payload != null;

        [JsonProperty("errors")]
        public IReadOnlyList<Error>? Errors => _errors;
        public bool HasErrors => _errors?.Any() ?? false;

        [JsonIgnore]
        public Result<TPayload> UserFacingResponse => new(
            _payload,
            _errors?.Select(e => new Error(
                message: e.Message,
                logLevel: e.LogLevel,
                exception: null // scrub stacktrace
            ))
        );

        public class Builder
        {
            private TPayload? _payload;
            private readonly List<Error> _errors = [];

            public Builder WithPayload(TPayload? payload)
            {
                _payload = payload;
                return this;
            }

            public Builder WithError(Error error)
            {
                _errors.Add(error);
                return this;
            }

            public Builder WithErrors(IEnumerable<Error> errors)
            {
                _errors.AddRange(errors);
                return this;
            }

            public Result<TPayload> Build() => new(_payload, _errors);
        }

        public static Builder CreateBuilder() => new();
    }
}
