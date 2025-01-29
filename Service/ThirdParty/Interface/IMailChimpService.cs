using AZF2S_Backend.Model;

namespace AZF2S_Backend.Service.ThirdParty.Interface
{
    public interface IMailchimpService : IBaseThirdPartyService
    {
        Task<Result<bool>> AddSubscriberAsync(string emailAddress);
        Task<Result<bool>> RemoveSubscriberAsync(string emailAddress);
    }
}
