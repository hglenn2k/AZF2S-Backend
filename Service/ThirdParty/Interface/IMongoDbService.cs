using AZF2S_Backend.Model;

namespace AZF2S_Backend.Service.ThirdParty.Interface
{
    public interface IMongoDbService : IBaseThirdPartyService
    {
        Task<ServiceResponse<T>> GetDocumentAsync<T>(string documentId);
        Task<ServiceResponse<Dictionary<string, object>>> GetFieldsAsync(string documentId, List<string> fields);
        Task<ServiceResponse<bool>> UpsertDocumentAsync<T>(string documentId, T data);
        Task<ServiceResponse<bool>> UpsertFieldsAsync(string documentId, Dictionary<string, object> updates);
        Task<ServiceResponse<bool>> DeleteDocumentAsync(string documentId);
    }
}
