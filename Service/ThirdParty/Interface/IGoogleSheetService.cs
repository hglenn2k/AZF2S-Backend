using AZF2S_Backend.Model;

namespace AZF2S_Backend.Service.ThirdParty.Interface
{
    public interface IGoogleSheetService : IBaseThirdPartyService
    {
        Task<Result<string>> GetSheetCsvAsync(string sheetId);
    }
}
