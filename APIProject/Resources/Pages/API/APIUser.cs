using System;
using APIProject.Resources.APIClients;
using APIProject.Resources.Base;
using RestSharp;

namespace APIProject.Resources.Pages
{
    public class Data
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Avatar { get; set; }
    }

    public class Support
    {
        public string Url { get; set; }
        public string Text { get; set; }
    }

    public class UserPost
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class APIUser : BaseAPI
    {
        public Data Data { get; set; }
        public Support Support { get; set; }


        public APIUser(APIClientManager apiClientManager) : base(apiClientManager) { }

        public async Task<RestResponse> GetUserById(string id)
        {
            var request = new RestRequest($"{_endpoints.UsersEndpoint}/{id}", Method.Get);
            return await _apiClientManager.ExecuteRequestAsync(request);
        }


        public async Task<RestResponse> CreateUserSuccess(UserPost user)
        {
            var request = new RestRequest($"{_endpoints.UsersEndpoint}", Method.Post);
            request.AddJsonBody(user);
            return await _apiClientManager.ExecuteRequestAsync(request);
        }


    }
}

