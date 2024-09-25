using APIProject.Resources.Pages.API;
using Newtonsoft.Json;

namespace APIProject.Test.APITest.Login
{
	public class APILoginTest : BaseTest
	{
        private APILogin _apiLogin;

        [SetUp]
        public void Setup()
        {
            _apiLogin = new APILogin(_apiClientManager);
            _test = GlobalSetup._extent.CreateTest(TestContext.CurrentContext.Test.Name).AssignCategory("Login Tests");

        }

        [Test, Description("This test checks if a valid user can log in successfully.")]
        [Category("Login Tests")]
        public async Task LoginSuccess()
        {
            _test.Info("este es el login");
            var credentials = new PageCredential
            {
                Email = properties["activeUserEmail"],
                Password = properties["validPassword"]
            };

            var response = await _apiLogin.PostLogin(credentials);
            var bodyResponse = JsonConvert.DeserializeObject<PageCredential>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(bodyResponse.Token, Is.Not.Empty, "Response has a empty token.");


        }

        [Test, Description("This test checks if an user is not able to log in If the email filled is not found.")]
        [Category("Login Tests")]
        public async Task UnsuccessLogin_UserNotFound()
        {

            var credentials = new PageCredential
            {
                Email = properties["noValidUserEmail"],
                Password = properties["validPassword"]
            };

            var response = await _apiLogin.PostLogin(credentials);
            var bodyResponse = JsonConvert.DeserializeObject<PageCredential>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.OK));
            Assert.That(bodyResponse.Error, Is.EqualTo(properties["errorUserNotFound"]));

        }

        [Test, Description("This test checks if API responses '400- Bad request' in case user doesn't send the password.")]
        [Category("Login Tests")]
        public async Task UnsuccessLogin_MissingPassword()
        {

            var credentials = new PageCredential
            {
                Email = properties["activeUserEmail"]
            };

            var response = await _apiLogin.PostLogin(credentials);
            var bodyResponse = JsonConvert.DeserializeObject<PageCredential>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.BadRequest));
            Assert.That(bodyResponse.Error, Is.EqualTo(properties["errorMissingPassword"]));


        }

        [Test, Description("This test checks if API responses '400- Bad request' in case user doesn't send the email.")]
        [Category("Login Tests")]
        public async Task UnsuccessLogin_MissingEmail()
        {

            var credentials = new PageCredential
            {
                Password = properties["validPassword"]
            };

            var response = await _apiLogin.PostLogin(credentials);
            var bodyResponse = JsonConvert.DeserializeObject<PageCredential>(response.Content);

            Assert.That(response.StatusCode, Is.EqualTo(System.Net.HttpStatusCode.BadRequest));
            Assert.That(bodyResponse.Error, Is.EqualTo(properties["errorMissingEmail"]));


        }
    }
}

