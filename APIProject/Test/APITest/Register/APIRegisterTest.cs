using System;
using APIProject.Resources.Pages;
using APIProject.Resources.Pages.API;
using Newtonsoft.Json;

namespace APIProject.Test.APITest.Register
{
	public class APIRegisterTest : BaseTest
	{

        private APIRegister _apiRegister;

        [SetUp]
        public void Setup()
        {
            _apiRegister = new APIRegister(_apiClientManager);
            _test = GlobalSetup._extent.CreateTest(TestContext.CurrentContext.Test.Name).AssignCategory("Register Tests");

        }

        [Test, Description("This test checks if user can register successfully")]
        [Category("Register Tests")]
        public async Task RegisterSuccess()
        {

            var credentials = new PageCredential
            {
                Email = "eve.holt@reqres.in",
                Password = "pistol"
            };

            var response = await _apiRegister.PostRegisterUser(credentials);
            var bodyResponse = JsonConvert.DeserializeObject<PageCredential>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(bodyResponse.Id, Is.EqualTo(4));
            Assert.That(bodyResponse.Token, Is.Not.Empty, "Response has a empty token.");


        }

        [Test, Description("This test checks if API responses '400- Bad request' in case password isn't send in the request")]
        [Category("Register Tests")]
        public async Task UnsuccessfulRegister()
        {

            var credentials = new PageCredential
            {
                Email = "no.valid.email@reqres.in"
            };

            var response = await _apiRegister.PostRegisterUser(credentials);
            var bodyResponse = JsonConvert.DeserializeObject<PageCredential>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.BadRequest));
            Assert.That(bodyResponse.Error, Is.EqualTo("Missing password"));
            Assert.That(bodyResponse.Token, Is.Null, "The 'Token' field should not be present in this case.");

            
        }
    }
}

