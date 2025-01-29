using AZF2S_Backend.Model;
using AZF2S_Backend.Model.ThirdParty.SendInBlue;

namespace AZF2S_Backend.Service.ThirdParty.Interface
{
    public interface IBrevoService : IBaseThirdPartyService
    {
        Task<Result<bool>> SendEmailAsync(Email email);
    }
}
