using AZF2S_Backend.Model;
using AZF2S_Backend.Model.ThirdParty.SendInBlue;

namespace AZF2S_Backend.Service.ThirdParty.Interface
{
    public interface ISendInBlueService : IBaseThirdPartyService
    {
        Task<ServiceResponse<bool>> SendEmailAsync(Email email);
    }
}
