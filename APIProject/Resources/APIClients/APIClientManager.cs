
namespace APIProject.Resources.APIClients
{
    using System.Threading.Tasks;
    using RestSharp;

    public class APIClientManager
    {
        private readonly RestClient _client;

        public APIClientManager(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<RestResponse> ExecuteRequestAsync(RestRequest request)
        {
            return await _client.ExecuteAsync(request);
        }
    }
}


