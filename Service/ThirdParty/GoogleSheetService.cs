using AZF2S_Backend.Model;
using AZF2S_Backend.Service.ThirdParty.Interface;

namespace AZF2S_Backend.Service.ThirdParty 
{
    public class GoogleSheetService : IGoogleSheetService
    {
        public Task<ServiceResponse<string>> GetSheetCsvAsync(string sheetId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> SmoketestAsync()
        {
            throw new NotImplementedException();
        }
    }
}

