using AZF2S_Backend.Model;
using AZF2S_Backend.Service.ThirdParty.Interface;

namespace AZF2S_Backend.Service.ThirdParty
{
    public class MailchimpService : IMailchimpService
    {
        public Task<ServiceResponse<bool>> AddSubscriberAsync(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> RemoveSubscriberAsync(string emailAddress)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> SmoketestAsync()
        {
            throw new NotImplementedException();
        }
    }
}

