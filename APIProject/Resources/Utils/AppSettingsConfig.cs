using System;
namespace APIProject.Resources.Utils
{
	public class ApiSettings
	{
        public string BaseAPIUrl { get; set; }


	}

    public class Endpoints
    {
        public string LoginEndpoint { get; set; }
        public string RegisterEndpoint { get; set; }
        public string UsersEndpoint { get; set; }
    }
}

