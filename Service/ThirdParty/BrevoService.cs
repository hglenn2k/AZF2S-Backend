using AZF2S_Backend.Model;
using AZF2S_Backend.Model.ThirdParty.SendInBlue;
using AZF2S_Backend.Service.ThirdParty.Interface;

namespace AZF2S_Backend.Service.ThirdParty 
{
    public class BrevoService : IBrevoService
    {
        public Task<Result<bool>> SendEmailAsync(Email email)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> SmoketestAsync()
        {
            throw new NotImplementedException();
        }
    }
}

