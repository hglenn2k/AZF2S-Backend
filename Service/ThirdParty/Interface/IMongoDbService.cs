using AZF2S_Backend.Model;

namespace AZF2S_Backend.Service.ThirdParty.Interface
{
    public interface IMongoDbService : IBaseThirdPartyService
    {
        Task<Result<T>> GetDocumentAsync<T>(string documentId);
        Task<Result<Dictionary<string, object>>> GetFieldsAsync(string documentId, List<string> fields);
        Task<Result<bool>> UpsertDocumentAsync<T>(string documentId, T data);
        Task<Result<bool>> UpsertFieldsAsync(string documentId, Dictionary<string, object> updates);
        Task<Result<bool>> DeleteDocumentAsync(string documentId);
    }
}
