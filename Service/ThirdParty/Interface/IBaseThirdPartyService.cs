using AZF2S_Backend.Model;

namespace AZF2S_Backend.Service.ThirdParty.Interface
{
    public interface IBaseThirdPartyService
    {
        Task<ServiceResponse<bool>> SmoketestAsync();
    }
}