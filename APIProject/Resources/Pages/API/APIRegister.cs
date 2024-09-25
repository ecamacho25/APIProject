using System;
using APIProject.Resources.APIClients;
using APIProject.Resources.Base;
using RestSharp;

namespace APIProject.Resources.Pages.API
{

    public class APIRegister : BaseAPI
	{
        public APIRegister(APIClientManager apiClientManager) : base(apiClientManager) { }

        public async Task<RestResponse> PostRegisterUser(PageCredential credentials)
        {
            var request = new RestRequest($"{_endpoints.RegisterEndpoint}", Method.Post);
            request.AddJsonBody(credentials);
            return await _apiClientManager.ExecuteRequestAsync(request);
        }

    }
}

