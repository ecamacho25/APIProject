using System;
using APIProject.Resources.APIClients;
using APIProject.Resources.Base;
using RestSharp;

namespace APIProject.Resources.Pages.API
{
	public class APILogin : BaseAPI
    {
       
        public APILogin(APIClientManager apiClientManager) : base(apiClientManager) { }

        public async Task<RestResponse> PostLogin(PageCredential credentials)
        {
            var request = new RestRequest($"{_endpoints.LoginEndpoint}", Method.Post);
            request.AddJsonBody(credentials);
            return await _apiClientManager.ExecuteRequestAsync(request);
        }

    }
}

