using AZF2S_Backend.Model;

namespace AZF2S_Backend.Service.ThirdParty.Interface
{
    public interface IGoogleSheetService : IBaseThirdPartyService
    {
        Task<ServiceResponse<string>> GetSheetCsvAsync(string sheetId);
    }
}
