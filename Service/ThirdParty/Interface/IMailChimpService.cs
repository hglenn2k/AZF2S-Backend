using AZF2S_Backend.Model;

namespace AZF2S_Backend.Service.ThirdParty.Interface
{
    public interface IMailchimpService : IBaseThirdPartyService
    {
        Task<ServiceResponse<bool>> AddSubscriberAsync(string emailAddress);
        Task<ServiceResponse<bool>> RemoveSubscriberAsync(string emailAddress);
    }
}
