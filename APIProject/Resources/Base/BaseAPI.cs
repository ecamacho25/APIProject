using System;
using APIProject.Resources.APIClients;
using APIProject.Resources.Utils;
using Microsoft.Extensions.Configuration;

namespace APIProject.Resources.Base
{
	public class BaseAPI
	{

        protected Endpoints _endpoints;

        protected readonly APIClientManager _apiClientManager;

        public BaseAPI(APIClientManager apiClientManager)
        {
            var configuration = ConfigLoader.LoadConfiguration();
            _endpoints = configuration.GetSection("Endpoints").Get<Endpoints>();
            _apiClientManager = apiClientManager;
        }

    }
}

