using AZF2S_Backend.Model;
using AZF2S_Backend.Service.ThirdParty.Interface;

namespace AZF2S_Backend.Service.ThirdParty 
{
    public class MongoDbService : IMongoDbService
    {
        public Task<ServiceResponse<bool>> Smoketest()
        {
            throw new NotImplementedException();
        }
    }
}

